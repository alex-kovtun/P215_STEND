using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using static P215Test.NetworkAdapters;
using static P215Test.Program;
using static System.Drawing.Color;
using System.ComponentModel;


namespace P215Test
{
    internal partial class Form1 : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();

        private uint TickSec { get; set; } = 10;
        private uint ItemsGroupBox => 16;
        internal BackgroundWorker Worker => worker = MyForm.backgroundWorker;
        private NetworkAdapter NetActive { get; set; } = new NetworkAdapter();

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

        internal NetworkAdapter.SpeedDuplex GetSpeed()
        {
            if (radioButtonSpeed10.Checked)
                return NetworkAdapter.SpeedDuplex.FullDuplex_10;

            else return radioButtonSpeed100.Checked
                ? NetworkAdapter.SpeedDuplex.FullDuplex_100
                : NetworkAdapter.SpeedDuplex.AutoNegotiation;
        }

        internal void LabelsHide()
        {
            for(uint i = 1; i < Count; ++i)
                Networks[i].Label.Visible = false;
        }

        private void ButtonChooseAll_Click(object sender, EventArgs e)
        {
            for (uint i = 1; i < Count; ++i)
                Networks[i].CheckBox.Checked = true;
        }

        private void ButtonRemoveAll_Click(object sender, EventArgs e)
        {
            LabelsHide();
            for (uint i = 1; i < Count; ++i)
                Networks[i].CheckBox.Checked = Networks[i].Speed = false;
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

        private void ButtonSurvey_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "ОПРОС")
            {
                LabelsHide();   // очистить поля

                if (Networks.CheckPort17() || CheckPorts() || CheckSpeed())
                    return;

                BlockingForTest(true);
                Worker.RunWorkerAsync(Networks);
                Thread.Sleep(5);
            }
            else if (button.Text == "СТОП")
            {
                Worker.CancelAsync();
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

        private void RadioButtonSpeed_CheckedChanged(object sender, EventArgs e)
        {
            NetworkAdapter.SpeedDuplex speed = NetworkAdapter.SpeedDuplex.FullDuplex_100;

            LabelsHide();
            if (((RadioButton)sender).Name == "radioButtonSpeed10")
                speed = NetworkAdapter.SpeedDuplex.FullDuplex_10;

            Networks.SetSpeedAllAsync(speed);
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (--TickSec > 0)
                ShowLabel(NetActive, Black, $"{TickSec.ToString()} сек.");

            else  // прошло 10 секунд
            {
                timer.Stop();
                TickSec = 10;
                ShowLabel(NetActive, Red, "Не работает");
                Worker.CancelAsync();
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            PortState portState;
            NetworkAdapters adapters = (NetworkAdapters)e.Argument;

            for(uint i = 1; i < Count; ++i)
            {
                if (Networks[i].CheckBox.Checked)
                {
                    NetActive = Networks[i];

                    timer.Start();

                    if (e.Cancel = NetActive.PingNumberOfTimes(100, out uint sendCount, out uint replyCount))
                        return;

                    portState = replyCount > 80 ? PortState.Working : PortState.NotWorking;
                    timer.Stop();
                    Worker.ReportProgress(Convert.ToInt32(portState), Networks[i]);
                }
            }
        }

        private void Worker_Progress(object sender, ProgressChangedEventArgs e)
        {
            bool isWork = e.ProgressPercentage == 0;
            ShowLabel((NetworkAdapter)e.UserState, isWork ? Green : Red, isWork ? "Работает" : "Не работает");
        }

        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                timer.Stop();

            BlockingForTest(false);
        }
    }
}
