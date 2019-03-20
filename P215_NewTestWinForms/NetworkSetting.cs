using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static P215Test.NetworkAdapter;
using static P215Test.Program;

namespace P215Test
{
    internal class NetworkAdapters
    {
        internal static uint Count => 17;
        internal static IPAddress DestAddr => IPAddress.Parse("192.168.100.100");
        internal static IPAddress VideoIP => IPAddress.Parse("192.168.100.44");

        internal static CancellationTokenSource CTS_SetSpeed { get; private set; } = new CancellationTokenSource();
        internal CancellationToken Token_SetSpeed => CTS_SetSpeed.Token;
        
        // ��������, ������� �� ����
        private bool IsConfigPort17 => Dns.GetHostEntry(Dns.GetHostName()).AddressList.Contains(DestAddr);

        internal NetworkAdapter[] Interface { get; set; } = new NetworkAdapter[Count];
        internal NetworkAdapter this[uint i] { get => Interface[i]; set => Interface[i] = value; }
        internal NetworkAdapters()
        {
            for (uint i = 0; i < Count; ++i)
                Interface[i] = new NetworkAdapter();
        }
        public IEnumerator Enumerator => Interface.GetEnumerator();


        internal void SearchNetworkAdapters()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(NetworkRegisrty.Path);
            string[] folders = key.GetSubKeyNames();  // �������� �������� � ����������

            foreach (string folder in folders)
            {
                NetworkRegisrty.GetTypeAndDriverId(folder, out key, out int type, out string driverId);
                if (type == 14 && driverId.Substring(0, 3) == "PCI") // ���� ��������� 802.3 && �������, �����. ����� PCI-����
                {
                    NetworkRegisrty.GetIPAndMAC(key, out string folderIP, out string[] ips, out string[] macs);
                    if (ips != null && macs != null)
                    {
                        ValidatedConfigPort(folder, folderIP, ips[0], macs[0]);
                    }
                }
            }
        }
        private void ValidatedConfigPort(string folder, string folderIP, string ip, string mac)
        {
            if (ip == null || mac == null)
            { return; }

            try
            {
                if (ip.Substring(0, 12) == "192.168.100." && mac == "255.255.255.0")
                {
                    uint num = Convert.ToUInt32(ip.Substring(12));

                    if (1 <= num && num <= 16)
                    {
                        Interface[num] = new NetworkAdapter(true, folder, folderIP, ip);
                    }
                    else if (num == 100 && IsConfigPort17)
                    {
                        Interface[0] = new NetworkAdapter(true, folder, folderIP, ip);
                    }
                }
            }
            catch { }   // Substring(), Interface[portNum].GetSpeed()
        }

        internal async Task<bool> SetSpeedAllAsync(NetworkSpeed speed)
        {
            return await Task<bool>.Factory.StartNew(() =>
            {
                bool speedChange = false;
                CTS_SetSpeed = new CancellationTokenSource();

                for (uint i = 1; i < Count; ++i)
                {
                    if (Networks[i].CheckBox.Checked)           // ���� ���� ������
                        if (Networks[i].GetSpeed() != speed)    // � ��� �������� �� ��������� � ������������� � �����,
                        {
                            Networks[i].SetSpeed(speed);        // ����� �������� ��
                            speedChange = true;
                        }
                }

                return speedChange;
            }, Token_SetSpeed);
        }

        internal bool CheckPort17()
        {
            bool isPort = false;

            // ���� �� �������� ��� �� �������,
            // ������������ ��� ������ ����������� SearchNetworkAdapters()
            if (Networks[0].IsConfig == false)
            {
                if (GetMACFromIP(DestAddr) == "")
                {
                    MessageBox.Show("������� �� ��������� ��� ����������� ������ ��������� ������������ ���� ��������!",
                                    "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isPort = true;
                }
            }
            // ���� ��������, �� �� �������
            else if(IsConfigPort17 == false)
            {
                MessageBox.Show("��������� ������ ��� ��������� ����� �17", "������ �����",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                isPort = true;
            }

            return isPort;
        }
    }


    internal class NetworkAdapter : NetworkRegisrty
    {
        internal NetworkAdapter (bool config = false)
            : base()
        {
            IsConfig = config;
        }
        internal NetworkAdapter(bool config, string folder, string folderIP, string ip)
            : base(folder, folderIP, ip)
        {
            IsConfig = config;
        }

        internal static CancellationTokenSource CTS_Ping { get; set; } = new CancellationTokenSource();
        internal CancellationToken Token_Ping => CTS_Ping.Token;
        private uint NumberOfPingForSuccess => 10000;
        private float QualityLevel => 0.8f;

        internal enum NetworkSpeed
        {
            AutoNegotiation,
            HalfDuplex_10,
            FullDuplex_10,
            HalfDuplex_100,
            FullDuplex_100,
            FullDuplex_1000 = 6,
            Empty = 255
        }
        internal bool IsConfig { get; set; }   // ���������� �� ip-�����
        internal CheckBox CheckBox { get; set; }
        internal Label Label { get; set; }

        internal void SetSpeed(NetworkSpeed speed)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(Path + "\\" + Folder, true);
                key.SetValue("*SpeedDuplex", speed.ToString("d"));
                key.Flush();

                Reset();
            }
            catch
            {
                MessageBox.Show("������������� ��������� � ������� ��������������.", "������ ���� �������",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        internal void Reset()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2",
                    $"SELECT * FROM Win32_NetworkAdapter WHERE GUID = '{FolderIP}'");

            foreach (ManagementObject obj in searcher.Get())
            {
                obj.InvokeMethod("Disable", null, null);
                obj.InvokeMethod("Enable", null, null);
            }
        }

        internal void CheckConfig(uint num)
        {
            if (CheckBox.Checked)   // ���� ������ ����
            {
                // ���� ������� ��������, �������� ���������� � �������� �����������
                if (MyForm.radioButtonSpeed10.Checked || MyForm.radioButtonSpeed100.Checked)
                {
                    MyForm.LabelsHide();
                    MyForm.RadioButtonReset();
                }

                if (IsConfig == false) // ���� ����������� �������� ip
                {
                    MessageBox.Show($"��������� ������������ ����� �{num.ToString()}", "������ �����",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CheckBox.Checked = false;
                }
            }
            else if (Form1.IsTestConducted) // ���� ������ ��� ���������� ����
            {
                MyForm.LabelsHide();
                Form1.IsTestConducted = false;
            }
        }

        internal async Task<bool> PingTestAsync()
        {
            return await Task<bool>.Factory.StartNew(() =>
            {
                PingReply pingReply;

                uint replyCount = 0, sendCount = 0;
                do
                {
                    pingReply = Send(IPAddress.Parse(IP), NetworkAdapters.DestAddr);
                    if (pingReply.NativeCode == 1 && pingReply.Status == 0)
                        ++replyCount;

                    ++sendCount;
                }
                while ((replyCount/sendCount < QualityLevel ||
                        replyCount < NumberOfPingForSuccess) &&
                       CTS_Ping.IsCancellationRequested == false);

                return (replyCount/sendCount > QualityLevel) && replyCount >= NumberOfPingForSuccess
                        ? true
                        : false;
            }, Token_Ping);
        }

        internal PingReply Send(IPAddress srcAddress, IPAddress destAddress, int timeout = 5000,
                        byte[] buffer = null, PingOptions po = null)
        {
            if (destAddress == null || destAddress.AddressFamily != AddressFamily.InterNetwork || destAddress.Equals(IPAddress.Any))
                throw new ArgumentException();

            //Defining pinvoke args
            var source = srcAddress == null ? 0 : BitConverter.ToUInt32(srcAddress.GetAddressBytes(), 0);
            var destination = BitConverter.ToUInt32(destAddress.GetAddressBytes(), 0);
            var sendbuffer = buffer ?? new byte[] { };
            var options = new Interop.Option
            {
                Ttl = (po == null ? (byte)255 : (byte)po.Ttl),
                Flags = (po == null ? (byte)0 : po.DontFragment ? (byte)0x02 : (byte)0) //0x02
            };
            var fullReplyBufferSize = Interop.ReplyMarshalLength + sendbuffer.Length; //Size of Reply struct and the transmitted buffer length.
            var allocSpace = Marshal.AllocHGlobal(fullReplyBufferSize); // unmanaged allocation of reply size. TODO Maybe should be allocated on stack

            var reply = new Interop.Reply();
            TimeSpan duration = new TimeSpan();

            try
            {
                DateTime start = DateTime.Now;
                var nativeCode = Interop.IcmpSendEcho2Ex(
                    Interop.IcmpHandle, //_In_      HANDLE IcmpHandle,
                    default(IntPtr), //_In_opt_  HANDLE Event,
                    default(IntPtr), //_In_opt_  PIO_APC_ROUTINE ApcRoutine,
                    default(IntPtr), //_In_opt_  PVOID ApcContext
                    source, //_In_      IPAddr SourceAddress,
                    destination, //_In_      IPAddr DestinationAddress,
                    sendbuffer, //_In_      LPVOID RequestData,
                    (short)sendbuffer.Length, //_In_      WORD RequestSize,
                    ref options, //_In_opt_  PIP_OPTION_INFORMATION RequestOptions,
                    allocSpace, //_Out_     LPVOID ReplyBuffer,
                    fullReplyBufferSize, //_In_      DWORD ReplySize,
                    timeout //_In_      DWORD Timeout
                    );
                duration = DateTime.Now - start;
                reply = (Interop.Reply)Marshal.PtrToStructure(allocSpace, typeof(Interop.Reply)); // Parse the beginning of reply memory to reply struct

                byte[] replyBuffer = null;
                if (sendbuffer.Length != 0)
                {
                    replyBuffer = new byte[sendbuffer.Length];
                    Marshal.Copy(allocSpace + Interop.ReplyMarshalLength, replyBuffer, 0, sendbuffer.Length); //copy the rest of the reply memory to managed byte[]
                }

                if (nativeCode == 1 && reply.Status == 0)
                    return new PingReply(nativeCode, reply.Status, new IPAddress(reply.Address), reply.RoundTripTime, replyBuffer);
                else //Means that native method is faulted.
                    return new PingReply(nativeCode, reply.Status, new IPAddress(reply.Address), duration);
            }
            finally
            {
                Marshal.FreeHGlobal(allocSpace); //free allocated space
            }
        }

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        internal static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);

        internal static string GetMACFromIP(IPAddress ip)
        {
            string mac = "";

            try
            {
                byte[] array = new byte[6];
                int len = array.Length;

                if (SendARP(ip.GetHashCode(), 0, array, ref len) == 0)
                    mac = BitConverter.ToString(array, 0, 6);
            }
            catch { }

            return mac;
        }
    }


    internal class NetworkRegisrty
    {
        internal NetworkRegisrty(string folder = "", string folderIP = "", string ip = "")
        {
            Folder = folder;
            FolderIP = folderIP;
            IP = ip;
        }
        internal string FolderIP { get; private set; }
        internal string IP { get; private set; }
        internal string Folder { get; private set; }
        internal static string Path { get; } = "SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}";
        internal static string PathIP { get; } = "SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces";


        internal NetworkSpeed GetSpeed()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey($"{Path}\\{Folder}");
            string value = (string)key.GetValue("*SpeedDuplex");
            return (NetworkSpeed) Convert.ToUInt32(value);
        }

        internal static void GetTypeAndDriverId(string folder, out RegistryKey key, out int type, out string driverId)
        {
            try
            {
                key = Registry.LocalMachine.OpenSubKey($"{Path}\\{folder}");
                driverId = (string)key.GetValue("DeviceInstanceID"); // �������� ����������
                type = key.GetValue("*PhysicalMediaType") == null ? 0 : (int)key.GetValue("*PhysicalMediaType");   // ��� ����������
            }
            catch { key = null; driverId = null; type = 255; }
        }

        internal static void GetIPAndMAC(RegistryKey key, out string folderIP, out string[] ips, out string[] macs)
        {
            folderIP = (string)key.GetValue("NetCfgInstanceId");   // ���������� �������� ����������
            key = Registry.LocalMachine.OpenSubKey($"{PathIP}\\{folderIP}");
            ips = (string[])key.GetValue("IPAddress");    // ������ ip-�������
            macs = (string[])key.GetValue("SubnetMask");
        }
    }


    /// <summary>Interoperability Helper
    ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/bb309069(v=vs.85).aspx" />
    /// </summary>
    internal static class Interop
    {
        private static IntPtr? icmpHandle;
        private static int? _replyStructLength;

        /// <summary>Returns the application legal icmp handle. Should be close by IcmpCloseHandle
        ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa366045(v=vs.85).aspx" />
        /// </summary>
        internal static IntPtr IcmpHandle
        {
            get
            {
                if (icmpHandle == null)
                    icmpHandle = IcmpCreateFile();

                return icmpHandle.GetValueOrDefault();
            }
        }
        /// <summary>Returns the the marshaled size of the reply struct.</summary>
        internal static int ReplyMarshalLength
        {
            get
            {
                if (_replyStructLength == null)
                    _replyStructLength = Marshal.SizeOf(typeof(Reply));

                return _replyStructLength.GetValueOrDefault();
            }
        }


        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern IntPtr IcmpCreateFile();
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern bool IcmpCloseHandle(IntPtr handle);
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        internal static extern uint IcmpSendEcho2Ex(IntPtr icmpHandle, IntPtr Event, IntPtr apcroutine, IntPtr apccontext, UInt32 sourceAddress, UInt32 destinationAddress, byte[] requestData, short requestSize, ref Option requestOptions, IntPtr replyBuffer, int replySize, int timeout);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]

        internal struct Option
        {
            internal byte Ttl;
            internal readonly byte Tos;
            internal byte Flags;
            internal readonly byte OptionsSize;
            internal readonly IntPtr OptionsData;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct Reply
        {
            internal readonly UInt32 Address;
            internal readonly int Status;
            internal readonly int RoundTripTime;
            internal readonly short DataSize;
            internal readonly short Reserved;
            internal readonly IntPtr DataPtr;
            internal readonly Option Options;
        }
    }


    [Serializable]
    internal class PingReply
    {
        private readonly byte[] _buffer = null;
        private readonly IPAddress _ipAddress = null;
        private readonly uint _nativeCode = 0;
        private readonly TimeSpan _roundTripTime = TimeSpan.Zero;
        private readonly IPStatus _status = IPStatus.Unknown;
        private Win32Exception _exception;


        internal PingReply(uint nativeCode, int replystatus, IPAddress ipAddress, TimeSpan duration)
        {
            _nativeCode = nativeCode;
            _ipAddress = ipAddress;
            if (Enum.IsDefined(typeof(IPStatus), replystatus))
                _status = (IPStatus)replystatus;
        }
        internal PingReply(uint nativeCode, int replystatus, IPAddress ipAddress, int roundTripTime, byte[] buffer)
        {
            _nativeCode = nativeCode;
            _ipAddress = ipAddress;
            _roundTripTime = TimeSpan.FromMilliseconds(roundTripTime);
            _buffer = buffer;
            if (Enum.IsDefined(typeof(IPStatus), replystatus))
                _status = (IPStatus)replystatus;
        }


        /// <summary>Native result from <code>IcmpSendEcho2Ex</code>.</summary>
        internal uint NativeCode { get { return _nativeCode; } }

        internal IPStatus Status { get { return _status; } }

        /// <summary>The source address of the reply.</summary>
        internal IPAddress IpAddress { get { return _ipAddress; } }

        internal byte[] Buffer { get { return _buffer; } }

        internal TimeSpan RoundTripTime { get { return _roundTripTime; } }

        /// <summary>Resolves the <code>Win32Exception</code> from native code</summary>
        internal Win32Exception Exception
        {
            get
            {
                if (Status != IPStatus.Success)
                    return _exception ?? (_exception = new Win32Exception((int)NativeCode, Status.ToString()));
                else
                    return null;
            }
        }

        public override string ToString()
        {
            if (Status == IPStatus.Success)
                return Status + " from " + IpAddress + " in " + RoundTripTime + " ms with " + Buffer.Length + " bytes";
            else if (Status != IPStatus.Unknown)
                return Status + " from " + IpAddress;
            else
                return Exception.Message + " from " + IpAddress;
        }
    }
}
