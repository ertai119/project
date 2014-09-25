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
        internal enum eGraphState { INVALID, TEMPERATURE, PH, SALT, OXGEN, AMP, VOLT}

        private int sendCnt = 0;
        private int recvCnt = 0;
        string[] preSaveRow;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer handShakeTimer = new System.Windows.Forms.Timer();

        TesterEnviorment testEnv = new SerialProgram.TesterEnviorment();
        FormViewer viewer;

        public Form1()
        {
            InitializeComponent();
            
            testEnv.descPort = Rs232Utils.PortDescString(serialPort1);
            DisplayStatusbarMessage(testEnv.descPort);

            testEnv.InitFromFile();

            dateTimeEnd.Format = DateTimePickerFormat.Custom;
            dateTimeEnd.CustomFormat = "yyyy-MM-dd-HH:mm";

            if (testEnv.EnableRunTest())
            {
                textBoxDelay.Text = testEnv.delay.ToString();
                textBoxTarget.Text = testEnv.target;
                dateTimeEnd.Value = Convert.ToDateTime(testEnv.endTime);
            }

            this.Text = testEnv.appname;

            AdjustBtnText();
            timer.Tick += new EventHandler(OnTimer);

            handShakeTimer.Interval = 1000;
            handShakeTimer.Tick += new EventHandler(OnTimerHandShake);

            radioButtonTemperature.Checked = true;
            serialPort1.ReceivedBytesThreshold = 1;

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

        private bool IsValidStr(string str)
        {
            if (str == null)
                return false;

            if (str == "" || str == "NNNN" || str == "NA")
                return false;

            return true;
        }
        private void SetDataToUI(string[] data)
        {
            if (data == null)
                return;

            preSaveRow = data;

            string strGridTimestamp = IsValidStr(data[0]) ? data[0] : "NA";
            string strGridTemperature = IsValidStr(data[1]) ? string.Format("{0:0.0}", Convert.ToDouble(data[1])) : "NA";
            string strGridPH = IsValidStr(data[2]) ? string.Format("{0:0.0}", Convert.ToDouble(data[2])) : "NA";
            string strGridSalt = IsValidStr(data[3]) ? string.Format("{0:0.0}", Convert.ToDouble(data[3])) : "NA";
            string strGridOxgen = IsValidStr(data[4]) ? string.Format("{0:0.0}", Convert.ToDouble(data[4])) : "NA";
            string strGridVolt = IsValidStr(data[5]) ? string.Format("{0:0.0}", Convert.ToDouble(data[5])) : "NA";
            string strGridAmp = IsValidStr(data[6]) ? string.Format("{0:0.0}", Convert.ToDouble(data[6])) : "NA";

            string[] gridData = {strGridTimestamp, strGridTemperature
                , strGridPH, strGridSalt, strGridOxgen, strGridVolt, strGridAmp};
            dataGridView1.Rows.Add(gridData);

            string strTimestamp = IsValidStr(data[0]) ? data[0] : "";
            string strTemperature = IsValidStr(data[1]) ? data[1] : "";
            string strPH = IsValidStr(data[2]) ? data[2] : "";
            string strSalt = IsValidStr(data[3]) ? data[3] : "";
            string strOxgen = IsValidStr(data[4]) ? data[4] : "";
            string strVolt = IsValidStr(data[5]) ? data[5] : "";
            string strAmp = IsValidStr(data[6]) ? data[6] : "";

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
            string str = "";
            str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
            if (str.Equals(Rs232Utils.ByteToHex(Rs232Utils.STX)))
            {
                // Local ID MSB
                str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                // Local ID LSB
                str = Convert.ToString(serialPort1.ReadByte(), 16).ToUpper();
                // Pay Load Length MSB + LSB
                str = Convert.ToString(serialPort1.ReadByte(), 16) + Convert.ToString(serialPort1.ReadByte(), 16);
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

        private void HandleReadData(object s, EventArgs e)
        {
            // 누적된 데이터를 받고
            string recieveData = recieveSB.ToString();

            this.RecvTextBox.AppendText(recieveData);
            this.RecvTextBox.AppendText("\r\n");

            // 누적 데이터를 없애고
            recieveSB = "";
            recvCnt++;

            if (recieveData.Length <= 0)
                return;

            int payloadLength = recieveData.Length;
            if (payloadLength % 4 != 0)
                return;

            string token = "";
            int receivedTokencount = payloadLength / 4;
            string[] datas = new string[TesterEnviorment.PACKET_TOKEN_COUNT];
            if (receivedTokencount > TesterEnviorment.PACKET_TOKEN_COUNT)
                return;

            for (int i = 0; i < receivedTokencount; i++)
            {
                token += recieveData[i * 4];
                token += recieveData[i * 4 + 1];
                token += recieveData[i * 4 + 2];
                token += recieveData[i * 4 + 3];

                if (token.Equals("NNNN"))
                {
                    datas[i] = "";
                }
                else
                {
                    if (token.Length >= 2)
                    {
                        string value = token.Insert(token.Length - 1, ".");
                        datas[i] = value;
                    }
                    else
                    {
                        datas[i] = token;
                    }
                    
                }

                token = "";
            }

            //수조온도	pH농도	염도	용존산소량	음극전위, 양극전류
            string[] row = { DateTime.Now.ToString(dateTimeEnd.CustomFormat), datas[0], datas[1]
                               , datas[2], datas[3], datas[4], datas[5] };
            SetDataToUI(row);

            SaveTofile(dataGridView1);

            DisplayStatusbarMessage(string.Format("SendCnt: {0}, RecvCnt: {1}", sendCnt, recvCnt));
        }

        
        private void SetStateStartTest()
        {
            testEnv.working = true;

            timer.Stop();

            sendCnt = 0;
            recvCnt = 0;

            if (TesterEnviorment.DEBUG_MODE == 1)
            {
                timer.Interval = 5 * 1000;
            }
            else if(TesterEnviorment.DEBUG_MODE == 2)
            {
                timer.Interval = 5 * 1000;
                timer.Start(); 
            }
            else
            {
                timer.Interval = testEnv.delay * 1000 * 60;
                timer.Start();
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

            timer.Stop();

            textBoxTarget.Enabled = true;
            textBoxDelay.Enabled = true;
            dateTimeEnd.Enabled = true;

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
                if (testEnv.EnableRunTest())
                {
                    testEnv.SaveConfig(); ;
                    InitUIControl();

                    SetStateStartTest();
                }
                else
                {
                    ModalessMsgBox("설정이 올바르지 않습니다.");
                }

                AdjustBtnText();
            }
        }

        private void SetStatePortSetting()
        {
            testEnv.connected = false;
            testEnv.working = false;

            timer.Stop();
            handShakeTimer.Stop();

            AdjustBtnText();
        }
        private void buttonPortSetting_Click(object sender, EventArgs e)
        {
            using (ComportSettingDialog csd = new ComportSettingDialog())
            {
                csd.Owner = this;
                csd.PortDescString = testEnv.descPort;
                if (csd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (serialPort1.IsOpen)
                    {
                        testEnv.connected = false;
                        serialPort1.Close();
                    }

                    Rs232Utils.SetPortDescString(serialPort1, csd.PortDescString);
                    testEnv.descPort = csd.PortDescString;

                    try
                    {
                        if (TesterEnviorment.DEBUG_MODE != 1)
                        {
                            serialPort1.Open();
                        }

                        DisplayStatusbarMessage(testEnv.descPort);

                        testEnv.connected = true;
                        sendCnt = 0;
                        recvCnt = 0;

                        AdjustBtnText();
                    }
                    catch (Exception ex)
                    {
                        testEnv.connected = false;

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void UpdateTestEnv()
        {
            testEnv.delay = textBoxDelay.Text != "" ? Convert.ToInt32(textBoxDelay.Text) : 0;
            testEnv.endTime = dateTimeEnd.Value;
            testEnv.target = textBoxTarget.Text;

            testEnv.SaveConfig();
        }

        //데이터를 보내기
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (testEnv.working == false)
            {
                string preFileName = testEnv.fileName;
                UpdateTestEnv();
                string curFileName = testEnv.fileName;

                bool bContinue = preFileName.Equals(curFileName);

                if (testEnv.connected && bContinue && testEnv.EnableRunTest())
                {
                    DialogResult ret = MessageBox.Show("이전 테스트가 완료되지 못했습니다. 이어하시겠습니까?"
                        , "이어하기", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        try
                        {
                            InitUIControl();

                            // 이어하기
                            LoadFromFile();

                            textBoxTarget.Text = testEnv.target;
                            textBoxDelay.Text = testEnv.delay.ToString();
                            dateTimeEnd.Value = testEnv.endTime;
                            SetStateStartTest();
                        }
                        catch (Exception ex)
                        {
                            ModalessMsgBox(ex.Message);
                        }
                    }
                    else
                    {
                        InitUIControl();

                        testEnv.target = "";
                        testEnv.delay = 0;
                        testEnv.endTime = DateTime.Now;

                        textBoxTarget.Text = testEnv.target;
                        textBoxDelay.Text = testEnv.delay.ToString();
                        dateTimeEnd.Value = testEnv.endTime;
                    }

                    return;
                }
            }

            if (testEnv.connected)
            {
                if (testEnv.working)
                {
                    if (MessageBox.Show("기록을 종료하시겠습니까?"
                        , "기록 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        SetStateStopTest();
                    }

                    return;
                }

                UpdateTestEnv();
                
                if (testEnv.EnableRunTest())
                {
                    if (MessageBox.Show("기록을 시작하시겠습니까?"
                        , "기록 시작", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        InitUIControl();

                        SetStateStartTest();
                    }

                    return;
                }
                else
                {
                    ModalessMsgBox("기록 설정이 잘못 되었습니다.");
                    return;
                }
            }
            else
            {
                if (testEnv.working == false)
                {
                    ModalessMsgBox("포트가 연결되지 않았습니다.");
                }
                else
                {
                    if (MessageBox.Show("기록을 종료하시겠습니까?"
                        , "기록 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말 종료하시겠습니까?", "Exit",
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
        public void SaveTofile(DataGridView myDataGridView)
        {
            //test to see if the DataGridView has any rows
            if (myDataGridView.RowCount > 0)
            {
                try
                {
                    string value = "";
                    DataGridViewRow dr = new DataGridViewRow();
                    StreamWriter swOut = new StreamWriter(
                        System.Environment.CurrentDirectory + "\\" + testEnv.fileName + ".csv", false, Encoding.UTF8);

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
                    for (int j = 0; j <= myDataGridView.Rows.Count - 1; j++)
                    {
                        if (j > 0)
                        {
                            swOut.WriteLine();
                        }

                        dr = myDataGridView.Rows[j];

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
                        }
                    }

                    swOut.Close();
                }
                catch(Exception ex)
                {
                    ModalessMsgBox(ex.Message);
                }
            }
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        
        void OnTimerHandShake(object sender, EventArgs e)
        {
            if (sendCnt != recvCnt)
            {
                ModalessMsgBox("포트가 끊겼습니다.");
                testEnv.connected = false;
                AdjustBtnText();

                SetDataToUI(preSaveRow);
                SaveTofile(dataGridView1);
            }

            handShakeTimer.Stop();
        }
        void OnTimer(object sender, EventArgs e)
        {
            if (TesterEnviorment.DEBUG_MODE != 1)
            {
                if (!serialPort1.IsOpen)
                {
                    testEnv.connected = false;
                    serialPort1.Close();
                    return;
                }
            }

            if (sendCnt != recvCnt)
            {
                if (preSaveRow == null)
                    return;

                preSaveRow[0] = DateTime.Now.ToString(dateTimeEnd.CustomFormat);

                SetDataToUI(preSaveRow);
                SaveTofile(dataGridView1);

                return;
            }

            SendPacket();

        }

        private void SendPacket()
        {
            sendCnt++;

            handShakeTimer.Start();

            if (TesterEnviorment.DEBUG_MODE == 1)
            {
                //recvCnt++;
                string[] row = { DateTime.Now.ToString(dateTimeEnd.CustomFormat), "1", "2.000"
                               , "NNNN", "NNNN", "2.000", "2.000" };
                SetDataToUI(row);

                SaveTofile(dataGridView1);
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

            if (TesterEnviorment.DEBUG_MODE != 1)
            {
                serialPort1.Write(buffer, 0, buffer.Length);
            }

            DisplayStatusbarMessage(string.Format("SendCnt: {0}, RecvCnt: {1}", sendCnt, recvCnt));

            SendTextBox.Text += Rs232Utils.ByteArrayToHexString(buffer) + "\r\n";
        }

        public void LoadFromFile()
        {
            FileStream inStream = new FileStream(testEnv.fileName + ".csv", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(inStream, Encoding.UTF8);

            try
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    if (i == 0)
                    {
                        i++;
                        continue;
                    }

                    string[] dr = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    string[] row = { dr[0].ToString(), dr[1].ToString()
                                        , dr[2].ToString(), dr[3].ToString()
                                        , dr[4].ToString(), dr[5].ToString()
                                        , dr[6].ToString() };
                    SetDataToUI(row);
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

