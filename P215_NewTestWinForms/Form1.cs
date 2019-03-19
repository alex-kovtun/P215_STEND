using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using static P215Test.NetworkAdapters;
using static P215Test.Program;
using static System.Drawing.Color;
using System.ComponentModel;
using System.Threading.Tasks;

namespace P215Test
{
    internal partial class Form1 : Form
    {
        internal static bool IsClosing { get; set; } = false;
        private uint TickSec { get; set; } = 10;
        private NetworkAdapter NetActive { get; set; } = new NetworkAdapter();
        internal static bool IsTestConducted { get; set; } = false;

        internal Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Networks.SearchNetworkAdapters();

            foreach (CheckBox checkBox in groupBoxPorts.Controls.OfType<CheckBox>())
            {
                uint n = Convert.ToUInt32(checkBox.Name.Substring(8));
                Networks[n].CheckBox = checkBox;
            }

            foreach (Label label in groupBoxPorts.Controls.OfType<Label>())
            {
                label.Visible = false;

                uint n = Convert.ToUInt32(label.Name.Substring(5));
                Networks[n].Label = label;
            }
        }

        internal void LabelsHide()
        {
            for(uint i = 1; i < Count; ++i)
                Networks[i].Label.Visible = false;
        }

        internal void RadioButtonReset()
        {
            radioButtonSpeed10.Checked =
                radioButtonSpeed100.Checked = false;
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            RadioButtonReset();

            bool check = true;
            if ((Button)sender == buttonRemoveAll)
                check = false;

            for (uint i = 1; i < Count; ++i)
            {
                Networks[i].CheckBox.Checked = check;
                Networks[i].Label.Visible = false;
            }
        }

        internal bool CheckPorts()
        {
            uint i;

            for (i = 1; i < Count; ++i)
                if (Networks[i].CheckBox.Checked)
                    break;

            if (i == Count)
            {
                MessageBox.Show("Порты не выбраны!", "Ошибка выбора портов",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        internal bool CheckSpeed()
        {
            if (!((RadioButton)Controls["radioButtonSpeed100"]).Checked &&
                !((RadioButton)Controls["radioButtonSpeed10"]).Checked)
            {
                MessageBox.Show("Установите скорость соединения!", "Ошибка выбора скорости",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        internal void BlockingForTest(bool isLock)
        {
            foreach (Control item in Controls)
                item.Enabled = !isLock;

            MyForm.groupBoxPorts.Enabled = true;
            foreach (CheckBox checkBox in groupBoxPorts.Controls.OfType<CheckBox>())
                checkBox.Enabled = !isLock;

            Button survey = (Button)Controls["buttonSurvey"];
            survey.Text = isLock ? "СТОП" : "ОПРОС";
            survey.Enabled = true;
        }

        internal void WaitChangeSpeed(bool isEnabled)
        {
            foreach (Control item in Controls)
                item.Enabled = !isEnabled;

            labelWaitChangeSpeed.Visible = 
                labelWaitChangeSpeed.Enabled = isEnabled;
        }

        private async void ButtonSurvey_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "ОПРОС")
            {
                LabelsHide();

                if (Networks.CheckPort17() || CheckPorts() || CheckSpeed())
                    return;

                try
                {
                    BlockingForTest(true);
                    await PingTestAsync();
                    IsTestConducted = true;
                    BlockingForTest(false);
                }
                catch { }   // при закрытии программы во время теста
            }
            else if (button.Text == "СТОП")
            {
                NetworkAdapter.CTS_Ping.Cancel();   // запрос на отмену PingTest()
                NetActive.Label.Visible = false;    // скрыть обратный отсчет таймера
                TimerStop();
            }
        }

        private async Task PingTestAsync()
        {
            for (uint i = 1; i < Count; ++i)
            {
                NetActive = Networks[i];
                if (NetActive.CheckBox.Checked)
                {
                    timer.Start();
                    NetworkAdapter.CTS_Ping = new CancellationTokenSource();

                    bool result = await NetActive.PingTestAsync();
                    if (NetworkAdapter.CTS_Ping.IsCancellationRequested == false)
                    {
                        ShowResult(result);
                        TimerStop();
                    }
                    else if(Form1.IsClosing) break;
                }
            }
        }

        private void ButtonVideo_Click(object sender, EventArgs e)
        {
            if (NetworkAdapter.GetMACFromIP(VideoIP) != "")
            {
                Process.Start(@"iexplore");
            }
            else
                MessageBox.Show("Камера не найдена", "Ошибка подключения камеры", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void RadioButtonSpeed_CheckedChanged(object sender, EventArgs e)
        {
            // Для исключения срабатывания при сбросе радикнопок
            if(radioButtonSpeed10.Checked || radioButtonSpeed100.Checked)
            {
                NetworkAdapter.NetworkSpeed speed = radioButtonSpeed100.Checked
                    ? NetworkAdapter.NetworkSpeed.FullDuplex_100
                    : NetworkAdapter.NetworkSpeed.FullDuplex_10;

                LabelsHide();

                WaitChangeSpeed(true);
                await Networks.SetSpeedAllAsync(speed);
                WaitChangeSpeed(false);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            uint num = Convert.ToUInt32(((CheckBox)sender).Name.Substring(8));
            Networks[num].CheckConfig(num);
        }

        void ShowLabel(NetworkAdapter adapter, System.Drawing.Color color, string str)
        {
            adapter.Label.ForeColor = color;
            adapter.Label.Text = str;
            adapter.Label.Visible = true;
        }

        void ShowResult(bool result)
        {
            if (result) ShowLabel(NetActive, Green, "Работает");
            else        ShowLabel(NetActive, Red, "Не работает");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (--TickSec > 0)
                ShowLabel(NetActive, Black, $"{TickSec.ToString()} сек.");

            else  // прошло 10 секунд
            {
                NetworkAdapter.CTS_Ping.Cancel();
                ShowResult(false);
                TimerStop();
            }
        }

        void TimerStop()
        {
            timer.Stop();
            TickSec = 10;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.IsClosing = true;

            if (NetworkAdapters.CTS_SetSpeed.IsCancellationRequested == false)
            {
                CTS_SetSpeed.Cancel();
            }
            if (NetworkAdapter.CTS_Ping.IsCancellationRequested == false)
            {
                NetworkAdapter.CTS_Ping.Cancel();
            }
        }
    }
}
