using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Data.OleDb;

using System.Runtime.InteropServices;


namespace SerialProgram
{
    public partial class Form1 : Form
    {
        internal enum PortStatus { None, Opened, Closed }
        internal enum eGraphState { INVALID, TEMPERATURE, PH, SALT, OXGEN, AMP, VOLT }

        private double sendCnt = 0;
        string[] preRecvData;

        System.Windows.Forms.Timer timerSendPacket = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerSaveToFile = new System.Windows.Forms.Timer();

        TesterEnviorment testEnv = new SerialProgram.TesterEnviorment();
        FormViewer viewer;

        [DllImport("kernel32.dll", EntryPoint = "SetThreadExecutionState", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE flags);

        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_USER_PRESENT = 0x00000004,
            ES_CONTINUOUS = 0x80000000
        }

        // 절전/대기 모드 진입 금지
        private void PreventMonitorPowerdown()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
        // 절전/대기 모드 진입 허용
        private void AllowMonitorPowerdown()
        {
            SetThreadExecutionState(~EXECUTION_STATE.ES_DISPLAY_REQUIRED & EXECUTION_STATE.ES_CONTINUOUS & ~EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }

        public DateTime getBuildDateTime2()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return System.IO.File.GetLastWriteTime(assembly.Location);
        }
        public Form1()
        {
            InitializeComponent();
            
            testEnv.descPort = Rs232Utils.PortDescString(serialPort1);
            testEnv.InitFromFile();

            if (Rs232Utils.IsValidPortDescString(testEnv.descPort))
            {
                SyncSerialPort();
            }

            DisplayStatusbarMessage(testEnv.descPort);

            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.CustomFormat = TesterEnviorment.DATETIME_FORMAT;

            if (testEnv.EnableRunTest() == 0)
            {
                textBoxDelay.Text = testEnv.delay.ToString();
                textBoxTarget.Text = testEnv.target;
                dateTimeEnd.Value = testEnv.endTime;
                textBoxStartTime.Text = testEnv.startTime.ToString(TesterEnviorment.DATETIME_FORMAT);
            }
            else
            {
                textBoxDelay.Text = "1";
                textBoxTarget.Text = "";
            }

            this.Text = String.Format("{0} [Build : {1}]" , testEnv.appname ,getBuildDateTime2().ToString());

            AdjustBtnText();
            timerSendPacket.Interval = 1000;
            timerSendPacket.Tick += new EventHandler(OnTimeSendPacket);
            timerSaveToFile.Tick += new EventHandler(OnTimeSaveToFile);

            radioButtonTemperature.Checked = true;
            //serialPort1.ReceivedBytesThreshold = 1;

            object[] AllGraph = { chartTemperature, chartSalt, chartOxgen, chartAmp, chartVolt, chartPH };
            foreach (System.Windows.Forms.DataVisualization.Charting.Chart chart in AllGraph)
            {
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                chart.ChartAreas[0].CursorX.AutoScroll = true;
                chart.ChartAreas[0].CursorY.AutoScroll = true;
                chart.Series[0].IsValueShownAsLabel = false;
                chart.Legends[0].Enabled = true;
            }

            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void InitUIControl()
        {
            object[] AllGraph = { chartTemperature, chartPH, chartSalt, chartOxgen, chartVolt, chartAmp };
            foreach (System.Windows.Forms.DataVisualization.Charting.Chart chart in AllGraph)
            {
                chart.Series[0].Points.Clear();
            }

            dataGridView1.Rows.Clear();

            radioButtonTemperature.Checked = true;
        }
        private void SetCurrentData(string[] data)
        {
            TesterEnviorment.AdjustDataStringFormat(data);

            preRecvData = data;

            textBoxData_Time.Text = data[0];
            textBoxData_Temperature.Text = data[1];
            textBoxData_pH.Text = data[2];
            textBoxData_Salt.Text = data[3];
            textBoxData_Oxygen.Text = data[4];
            textBoxData_Volt.Text = data[5];
            textBoxData_Amp.Text = data[6];
        }
        private void SetDataToUI(string[] data)
        {
            if (data == null)
                return;

            string NA = TesterEnviorment.STR_NA;

            dataGridView1.Rows.Insert(0, data);

            string EMPTY = TesterEnviorment.STR_EMPTY;

            string strTimestamp = TesterEnviorment.IsValidStr(data[0]) ? data[0] : EMPTY;
            string strTemperature = TesterEnviorment.IsValidStr(data[1]) ? data[1] : EMPTY;
            string strPH = TesterEnviorment.IsValidStr(data[2]) ? data[2] : EMPTY;
            string strSalt = TesterEnviorment.IsValidStr(data[3]) ? data[3] : EMPTY;
            string strOxgen = TesterEnviorment.IsValidStr(data[4]) ? data[4] : EMPTY;
            string strVolt = TesterEnviorment.IsValidStr(data[5]) ? data[5] : EMPTY;
            string strAmp = TesterEnviorment.IsValidStr(data[6]) ? data[6] : EMPTY;

            chartTemperature.Series[0].Points.AddXY(strTimestamp, strTemperature);
            chartPH.Series[0].Points.AddXY(strTimestamp, strPH);
            chartSalt.Series[0].Points.AddXY(strTimestamp, strSalt);
            chartOxgen.Series[0].Points.AddXY(strTimestamp, strOxgen);
            chartVolt.Series[0].Points.AddXY(strTimestamp, strVolt);
            chartAmp.Series[0].Points.AddXY(strTimestamp, strAmp);
        }
        private void SetVisibleGraph(eGraphState graphState)
        {
            if (graphState == eGraphState.INVALID)
            {
                chartTemperature.Visible = false;
                chartPH.Visible = false;
                chartSalt.Visible = false;
                chartOxgen.Visible = false;
                chartAmp.Visible = false;
                chartVolt.Visible = false;
            }
            else if (graphState == eGraphState.TEMPERATURE)
            {
                chartTemperature.Visible = true;
                chartPH.Visible = false;
                chartSalt.Visible = false;
                chartOxgen.Visible = false;
                chartAmp.Visible = false;
                chartVolt.Visible = false;
            }
            else if (graphState == eGraphState.PH)
            {
                chartTemperature.Visible = false;
                chartPH.Visible = true;
                chartSalt.Visible = false;
                chartOxgen.Visible = false;
                chartAmp.Visible = false;
                chartVolt.Visible = false;
            }
            else if (graphState == eGraphState.SALT)
            {
                chartTemperature.Visible = false;
                chartPH.Visible = false;
                chartSalt.Visible = true;
                chartOxgen.Visible = false;
                chartAmp.Visible = false;
                chartVolt.Visible = false;
            }
            else if (graphState == eGraphState.OXGEN)
            {
                chartTemperature.Visible = false;
                chartPH.Visible = false;
                chartSalt.Visible = false;
                chartOxgen.Visible = true;
                chartAmp.Visible = false;
                chartVolt.Visible = false;
            }
            else if (graphState == eGraphState.AMP)
            {
                chartTemperature.Visible = false;
                chartPH.Visible = false;
                chartSalt.Visible = false;
                chartOxgen.Visible = false;
                chartAmp.Visible = true;
                chartVolt.Visible = false;
            }
            else if (graphState == eGraphState.VOLT)
            {
                chartTemperature.Visible = false;
                chartPH.Visible = false;
                chartSalt.Visible = false;
                chartOxgen.Visible = false;
                chartAmp.Visible = false;
                chartVolt.Visible = true;
            }
        }
        private void DisplayStatusbarMessage(string s)
        {
            toolStripStatusLabel1.Text = s;
        }
        private void MessageNone(object sender, EventArgs e)
        {
            DisplayStatusbarMessage("");
        }
        public string recieveSB;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // 비동기로 넘긴다.
            this.Invoke(new EventHandler(recvData));
        }
        private void recvData(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                if (str.Equals(Rs232Utils.ByteToHex(Rs232Utils.STX)))
                {
                    // Local ID MSB
                    str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                    // Local ID LSB
                    str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                    // Pay Load Length MSB + LSB
                    str = Convert.ToString(serialPort1.ReadByte(), 16);
                    str += Convert.ToString(serialPort1.ReadByte(), 16);
                    str += Convert.ToString(serialPort1.ReadByte(), 16);
                    str = Rs232Utils.ConvertHexToString(str);
                    int payloadLength = Int32.Parse(str);

                    for (int i = 0; i < payloadLength; i++)
                    {
                        str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                        recieveSB += Rs232Utils.ConvertHexToString(str);
                    }

                    str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                    if (str.Equals(Rs232Utils.ByteToHex(Rs232Utils.ETX)))
                    {
                        this.Invoke(new EventHandler(HandleReadData));
                    }
                }
            }
            catch (Exception ex)
            {
                // 누적 데이터를 없애고
                recieveSB = "";
                sendCnt = 0;
            }
        }
        private void HandleReadData(object s, EventArgs e)
        {
            try
            {
                // 누적된 데이터를 받고
                string recieveData = recieveSB.ToString();

                if (TesterEnviorment.DEBUG_MODE == 1)
                {
                    this.RecvTextBox.AppendText(recieveData);
                    this.RecvTextBox.AppendText("\r\n");
                }

                // 누적 데이터를 없애고
                recieveSB = "";
                sendCnt = 0;

                if (recieveData.Length <= 0)
                    return;

                int payloadLength = recieveData.Length;
                if (payloadLength % 5 != 0)
                    return;

                string token = "";
                int receivedTokencount = payloadLength / 5;
                string[] datas = new string[TesterEnviorment.PACKET_TOKEN_COUNT];
                if (receivedTokencount > TesterEnviorment.PACKET_TOKEN_COUNT)
                    return;

                for (int i = 0; i < receivedTokencount; i++)
                {
                    token += recieveData[i * 5];
                    token += recieveData[i * 5 + 1];
                    token += recieveData[i * 5 + 2];
                    token += recieveData[i * 5 + 3];
                    token += recieveData[i * 5 + 4];

                    if (token.Equals(TesterEnviorment.STR_NNNNN))
                    {
                        datas[i] = TesterEnviorment.STR_EMPTY;
                    }
                    else
                    {
                        datas[i] = token;
                    }

                    token = "";
                }

                //수조온도  pH농도    염도  용존산소량   음극전위    양극전류
                string[] row = { DateTime.Now.ToString(dateTimeEnd.CustomFormat), datas[0], datas[1]
                               , datas[2], datas[3], datas[4], datas[5] };

                SetCurrentData(row);

                if (dataGridView1.Rows.Count == 1)
                {
                    TesterEnviorment.ConvertDateTime(row, testEnv.startTime);

                    SetDataToUI(row);
                    SaveTofile(dataGridView1, testEnv.fileName, true);
                }

                DisplayStatusbarMessage(string.Format("Serial Status: {0} RecvData: {1}", sendCnt, recieveData));
            }
            catch (Exception ex)
            {
                // 누적 데이터를 없애고
                recieveSB = "";
                sendCnt = 0;
            }
        }
        private void SetStateStartTest()
        {
            testEnv.working = true;

            timerSendPacket.Stop();
            timerSaveToFile.Stop();

            sendCnt = 0;

            if (TesterEnviorment.DEBUG_MODE == 1)
            {
                timerSendPacket.Interval = 1000;
                timerSendPacket.Start();

                timerSaveToFile.Interval = 60 * 1000;
                timerSaveToFile.Start();
            }
            else
            {
                timerSendPacket.Interval = 1000;
                timerSendPacket.Start();

                timerSaveToFile.Interval = testEnv.delay * 1000 * 60;
                timerSaveToFile.Start();
            }

            textBoxTarget.Enabled = false;
            textBoxDelay.Enabled = false;
            dateTimeEnd.Enabled = false;

            AdjustBtnText();

            SendPacket();
        }
        private void SetStateStopTest()
        {
            testEnv.working = false;

            timerSendPacket.Stop();
            timerSaveToFile.Stop();

            textBoxTarget.Enabled = true;
            textBoxDelay.Enabled = true;
            dateTimeEnd.Enabled = true;

            testEnv.target = "";
            testEnv.delay = 1;
            testEnv.endTime = DateTime.Now.AddDays(1);
            testEnv.startTime = DateTime.Now;

            textBoxTarget.Text = testEnv.target;
            textBoxDelay.Text = testEnv.delay.ToString();
            dateTimeEnd.Value = testEnv.endTime;
            textBoxStartTime.Text = testEnv.startTime.ToString(TesterEnviorment.DATETIME_FORMAT);

            AdjustBtnText();
        }
        private void SetStateTestSetting()
        {
            testEnv.target = textBoxTarget.Text;
            testEnv.delay = Convert.ToInt32(textBoxDelay.Text.ToString());
            testEnv.endTime = dateTimeEnd.Value;

            textBoxTarget.Text = testEnv.target;
            textBoxDelay.Text = testEnv.delay.ToString();
            dateTimeEnd.Value = testEnv.endTime;

            using (TesterSettingDialog tsd = new TesterSettingDialog())
            {
                TesterEnviorment.eRunState runState = testEnv.EnableRunTest();

                if (runState == TesterEnviorment.eRunState.SUCCESS)
                {
                    testEnv.SaveConfig();
                    InitUIControl();

                    SetStateStartTest();
                }
                else
                {
                    ModalessMsgBox(MakeStrInvalidSettingEnum(runState));
                }

                AdjustBtnText();
            }
        }
        private void SetStatePortSetting()
        {
            testEnv.connected = false;
            testEnv.working = false;

            timerSendPacket.Stop();
            timerSaveToFile.Stop();

            AdjustBtnText();
        }
        private void SyncSerialPort()
        {
            if (serialPort1.IsOpen)
            {
                testEnv.connected = false;
                serialPort1.Close();
            }

            Rs232Utils.SetPortDescString(serialPort1,testEnv.descPort);

            try
            {
                if (TesterEnviorment.DEBUG_MODE != 1)
                {
                    serialPort1.Open();
                }

                DisplayStatusbarMessage(testEnv.descPort);

                testEnv.connected = true;
                sendCnt = 0;

                AdjustBtnText();
            }
            catch (Exception ex)
            {
                testEnv.connected = false;

                MessageBox.Show(ex.Message);
            }
        }
        private void buttonPortSetting_Click(object sender, EventArgs e)
        {
            using (ComportSettingDialog csd = new ComportSettingDialog())
            {
                csd.Owner = this;
                csd.PortDescString = testEnv.descPort;
                if (csd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    testEnv.descPort = csd.PortDescString;
                    SyncSerialPort();
                }
            }
        }
        private string MakeStrInvalidSettingEnum(TesterEnviorment.eRunState runState)
        {
            if (runState == TesterEnviorment.eRunState.INVALID_DELAY)
            {
                return "저장 간격이 너무 짧습니다.";
            }
            else if (runState == TesterEnviorment.eRunState.INVALID_ENDTIME)
            {
                return "종료 일시는 시작 일시보다 길어야 합니다.";
            }
            else if (runState == TesterEnviorment.eRunState.INVALID_LOCAL_VALUE)
            {
                return "Local value 셋팅이 안되어있습니다.";
            }
            else if (runState == TesterEnviorment.eRunState.INVALID_LOCALID)
            {
                return "Local Id 셋팅이 안되어있습니다.";
            }
            else if (runState == TesterEnviorment.eRunState.INVALID_TARGET)
            {
                return "저장 화일 이름이 없습니다.";
            }
            else if (runState == TesterEnviorment.eRunState.INVALID_TARGET_LENGTH)
            {
                return "저장 화일 이름이 너무 짧습니다.";
            }
            else if (runState == TesterEnviorment.eRunState.INVALID_WORKING)
            {
                return "기록이 진행중일때는 설정을 변경할수 없습니다.";
            }

            return "";
        }
        private void UpdateTestEnv()
        {
            testEnv.delay = textBoxDelay.Text != "" ? Convert.ToInt32(textBoxDelay.Text) : 1;
            testEnv.endTime = dateTimeEnd.Value;
            testEnv.target = textBoxTarget.Text;

            testEnv.SaveConfig();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (testEnv.working == false)
            {
                string preFileName = testEnv.fileName;
                UpdateTestEnv();
                string curFileName = testEnv.fileName;

                bool bContinue = preFileName.Equals(curFileName);

                TesterEnviorment.eRunState runState = testEnv.EnableRunTest();

                if (testEnv.connected && bContinue && runState == TesterEnviorment.eRunState.SUCCESS)
                {
                    DialogResult ret = MessageBox.Show("이전 테스트가 완료되지 못했습니다. 이어하시겠습니까?"
                        , "이어하기", MessageBoxButtons.YesNo);
                    if (ret == DialogResult.Yes)
                    {
                        try
                        {
                            InitUIControl();
                            // 이어하기
                            LoadFromFile();

                            textBoxStartTime.Text = testEnv.startTime.ToString(
                                TesterEnviorment.DATETIME_FORMAT);
                            textBoxTarget.Text = testEnv.target;
                            textBoxDelay.Text = testEnv.delay.ToString();
                            dateTimeEnd.Value = testEnv.endTime;

                            SetStateStartTest();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        InitUIControl();

                        testEnv.target = "";
                        testEnv.delay = 1;
                        testEnv.endTime = DateTime.Now.AddDays(1);
                        testEnv.startTime = DateTime.Now;

                        textBoxTarget.Text = testEnv.target;
                        textBoxDelay.Text = testEnv.delay.ToString();
                        dateTimeEnd.Value = testEnv.endTime;
                        textBoxStartTime.Text = testEnv.startTime.ToString(TesterEnviorment.DATETIME_FORMAT);
                    }

                    return;
                }
            }

            if (testEnv.connected)
            {
                if (testEnv.working)
                {
                    if (MessageBox.Show("기록을 종료하시겠습니까?"
                        , "기록 종료", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        SaveTofile(dataGridView1, testEnv.completedFilePath, false);

                        SetStateStopTest();
                    }

                    return;
                }

                TesterEnviorment.eRunState runState = testEnv.EnableRunTest();

                if (runState == TesterEnviorment.eRunState.SUCCESS)
                {
                    if (MessageBox.Show("기록을 시작하시겠습니까?"
                        , "기록 시작", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        InitUIControl();

                        testEnv.startTime = DateTime.Now;
                        textBoxStartTime.Text = testEnv.startTime.ToString(TesterEnviorment.DATETIME_FORMAT);

                        UpdateTestEnv();

                        SetStateStartTest();
                    }

                    return;
                }
                else
                {
                    MessageBox.Show(MakeStrInvalidSettingEnum(runState));
                    return;
                }
            }
            else
            {
                if (testEnv.working == false)
                {
                    ModalessMsgBox("장치와 연결이 되지 않았습니다.");
                }
                else
                {
                    if (MessageBox.Show("기록을 종료하시겠습니까?"
                        , "기록 종료", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        SetStateStopTest();
                    }

                    return;
                }

                return;
            }
        }
        private void AdjustBtnText()
        {
            if (testEnv.connected == false && testEnv.working == false)
            {
                btnStart.Text = "기록 시작";
                return;
            }

            if (testEnv.connected)
            {
                if (testEnv.working)
                {
                    btnStart.Text = "기록 종료";
                    return;
                }
                else
                {
                    btnStart.Text = "기록 시작";
                    return;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PreventMonitorPowerdown();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (serialPort1.IsOpen)
            {
                testEnv.connected = false;
                serialPort1.Close();
            }

            AllowMonitorPowerdown();
        }
        private void textBoxDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void textBoxTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        public void SaveTofile(DataGridView myDataGridView, string path, bool usingTempFolder)
        {
            //test to see if the DataGridView has any rows
            if (myDataGridView.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();

                string sDirPath;
                sDirPath = System.Environment.CurrentDirectory + "\\Completed\\";
                DirectoryInfo di = new DirectoryInfo(sDirPath);
                if (di.Exists == false)
                {
                    di.Create();
                }

                sDirPath = System.Environment.CurrentDirectory + "\\Temp\\";
                DirectoryInfo di1 = new DirectoryInfo(sDirPath);
                if (di1.Exists == false)
                {
                    di1.Create();
                }

                FileStream fStream;
                StreamWriter swOut; 

                try
                {
                    fStream = new FileStream(usingTempFolder ? "Temp\\" + path : path, FileMode.OpenOrCreate);
                    swOut = new StreamWriter(fStream, Encoding.UTF8);
 
                    //write header rows to csv
                    for (int i = 0; i <= myDataGridView.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }
                        swOut.Write(myDataGridView.Columns[i].HeaderText);
                    }

                    swOut.WriteLine();

                    //write DataGridView rows to csv
                    int totalRowCount = myDataGridView.Rows.Count;
                    if (totalRowCount > 0)
                    {
                        for (int j = totalRowCount - 1 ; j >= 0; j--)
                        {
                            dr = myDataGridView.Rows[j];

                            bool isWrite = false;
                            for (int i = 0; i <= myDataGridView.Columns.Count - 1; i++)
                            {
                                if (dr.Cells[i].Value == null)
                                    continue;

                                if (i > 0)
                                {
                                    swOut.Write(",");
                                }

                                value = dr.Cells[i].Value.ToString();
                                //replace comma's with spaces
                                value = value.Replace(',', ' ');
                                //replace embedded newlines with spaces
                                value = value.Replace(Environment.NewLine, " ");

                                swOut.Write(value);

                                isWrite = true;
                            }

                            if (isWrite)
                                swOut.WriteLine();
                        }
                    }
                    
                    swOut.Close();
                    fStream.Close();
                }
                catch(Exception ex)
                {
                    ModalessMsgBox(ex.Message);
                }
            }
        }
        void OnTimeSaveToFile(object sender, EventArgs e)
        {
            if (preRecvData != null)
            {
                string[] dump = (string[])preRecvData.Clone();
                TesterEnviorment.ConvertDateTime(dump, testEnv.startTime);

                SetDataToUI(dump);
                SaveTofile(dataGridView1, testEnv.fileName, true);
            }
        }
        void OnTimeSendPacket(object sender, EventArgs e)
        {
            if (DateTime.Now > testEnv.endTime)
            {
                SetStateStopTest();
                SaveTofile(dataGridView1, testEnv.completedFilePath, false);

                MessageBox.Show("시험이 완료되었습니다.");

                return;
            }

            if (sendCnt != 0)
            {
                if (testEnv.connected == true)
                {
                    ModalessMsgBox("장치와의 연결이 끊겼습니다.");
                }

                testEnv.connected = false;
                AdjustBtnText();

                if (preRecvData != null)
                {
                    preRecvData[0] = DateTime.Now.ToString(dateTimeEnd.CustomFormat);
                    textBoxData_Time.Text = preRecvData[0].ToString();
                }
            }

            SendPacket();
        }

        private void SendPacket()
        {
            sendCnt++;

            if (TesterEnviorment.DEBUG_MODE == 1)
            {
                //수조온도  pH농도    염도  용존산소량   음극전위    양극전류
                string[] row = { DateTime.Now.ToString(dateTimeEnd.CustomFormat), "-0023", " 0076"
                               , "-2000", "-1234", " 0040", " 0201" };

                SetCurrentData(row);
                sendCnt--;

                if (dataGridView1.Rows.Count == 1)
                {
                    TesterEnviorment.ConvertDateTime(row, testEnv.startTime);

                    SetDataToUI(row);
                    SaveTofile(dataGridView1, testEnv.fileName, true);
                }
            }

            // 시리얼데이터 버퍼 STX 1 / LocalID 2 / ETX 1
            byte[] buffer = new byte[4];
            // Start Byte
            buffer[0] = Rs232Utils.STX;
            // Local ID
            buffer[1] = System.Text.Encoding.ASCII.GetBytes(testEnv.localId.ToCharArray())[0];
            buffer[2] = System.Text.Encoding.ASCII.GetBytes(testEnv.localValue.ToCharArray())[0];
            // End Byte
            buffer[3] = Rs232Utils.ETX;

            try
            {
                if (TesterEnviorment.DEBUG_MODE != 1)
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (Exception e)
            {
            }

            DisplayStatusbarMessage(string.Format("Serial Status: {0} Send Data: {1}", sendCnt, Rs232Utils.ByteArrayToHexString(buffer) ));
        }

        public void LoadFromFile()
        {
            string path = System.Environment.CurrentDirectory + "\\Temp\\" + testEnv.fileName;
            FileStream inStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(inStream, Encoding.UTF8);

            try
            {
                int i = 0;
                List<string[]> fileDataList = new List<string[]>();

                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    string[] dr = s.Split(','); // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    string[] row = { dr[0].ToString(), dr[1].ToString()
                                        , dr[2].ToString(), dr[3].ToString()
                                        , dr[4].ToString(), dr[5].ToString()
                                        , dr[6].ToString() };

                    fileDataList.Add(row);
                }

                for(int idx = 0 ; idx < fileDataList.Count ; idx++)
                {
                    SetDataToUI(fileDataList[idx]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                inStream.Close();
                return;
            }
            finally
            {
                if (sr != null)
                    sr.Close();

                if (inStream != null)
                    inStream.Close();
            }
        }

        private void ModalessMsgBox(string msg)
        {
            new Thread(() => { MessageBox.Show(new Form() { TopMost = true }, msg); }).Start();
        }
        private void printDocument1_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red,
              new Rectangle(500, 500, 500, 500));
        }
        // 전위
        private void radioButtonAmp_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.AMP);
        }
        // 온도
        private void radioButtonTemperature_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.TEMPERATURE);
        }
        // ph농도
        private void radioButtonPH_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.PH);
        }
        private void radioButtonSalt_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.SALT);
        }
        private void radioButtonOxgen_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.OXGEN);
        }
        private void radioButtonVolt_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.VOLT);
        }
        private void buttonViewer_Click(object sender, EventArgs e)
        {
            viewer = new FormViewer();
            viewer.Owner = this;
            viewer.Show();
        }
    }
}

