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

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        TesterEnviorment testEnv = new SerialProgram.TesterEnviorment();
        FormViewer viewer;

        public Form1()
        {

            InitializeComponent();
            
            testEnv.descPort = Rs232Utils.PortDescString(serialPort1);
            DisplayStatusbarMessage(testEnv.descPort);

            testEnv.InitFromFile();
            testEnv.SaveConfig();

            this.Text = testEnv.appname;

            AdjustBtnText();
            timer.Tick += new EventHandler(timer_Tick);

            //radioButtonTemperature.Checked = true;
            SetVisibleGraph(eGraphState.INVALID);
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

        private void InitGraph()
        {
            object[] AllGraph = { chartTemperature, chartPH, chartSalt, chartOxgen, chartVolt, chartAmp };
            foreach (System.Windows.Forms.DataVisualization.Charting.Chart chart in AllGraph)
            {
                chart.Series[0].Points.Clear();
            }
        }

        private void SetDataToUI(string[] data)
        {
            string strGridTimestamp = data[0] != null ? data[0] : "NA";
            string strGridTemperature = data[1] != null ? data[1] : "NA";
            string strGridPH = data[2] != null ? data[2] : "NA";
            string strGridSalt = data[3] != null ? data[3] : "NA";
            string strGridOxgen = data[4] != null ? data[4] : "NA";
            string strGridVolt = data[5] != null ? data[5] : "NA";
            string strGridAmp = data[6] != null ? data[6] : "NA";

            string[] gridData = {strGridTimestamp, strGridTemperature
                , strGridPH, strGridSalt, strGridOxgen, strGridVolt, strGridAmp};
            dataGridView1.Rows.Add(gridData);

            string strTimestamp = data[0] != null ? data[0] : "";
            string strTemperature = data[1] != null ? data[1] : "";
            string strPH = data[2] != null ? data[2] : "";
            string strSalt = data[3] != null ? data[3] : "";
            string strOxgen = data[4] != null ? data[4] : "";
            string strVolt = data[5] != null ? data[5] : "";
            string strAmp = data[6] != null ? data[6] : "";

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
                    double value = Convert.ToDouble(token) / 1000;
                    datas[i] = string.Format("{0:0.000}", value);
                }

                token = "";
            }

            //수조온도	pH농도	염도	용존산소량	음극전위, 양극전류
            string[] row = { DateTime.Now.ToString(), datas[0], datas[1]
                               , datas[2], datas[3], datas[4], datas[5] };
            SetDataToUI(row);
        }

        
        private void SetStateStartTest()
        {
            testEnv.working = true;

            timer.Stop();

            sendCnt = 0;
            recvCnt = 0;
#if DEBUG
            timer.Interval = 5 * 1000;
#else
            timer.Interval = testEnv.delay * 1000 * 60;
#endif
            timer.Start();
            ModalessMsgBox("시험 시작");

            AdjustBtnText();
        }

        private void SetStateStopTest()
        {
            testEnv.working = false;

            timer.Stop();

            AdjustBtnText();
        }

        private void SetStateTestSetting()
        {
            using (TesterSettingDialog tsd = new TesterSettingDialog())
            {
                tsd.Owner = this;
                if (tsd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    testEnv.target = tsd.target;
                    testEnv.delay = tsd.delay;
                    testEnv.endTime = Convert.ToDateTime(tsd.endTime);

                    textBoxTarget.Text = testEnv.target;
                    textBoxDelay.Text = testEnv.delay.ToString();
                    textBoxEnd.Text = testEnv.endTime.ToString();
                }

                if (testEnv.EnableRunTest())
                {
                    testEnv.SaveConfig(); ;
                    InitGraph();
                    dataGridView1.Rows.Clear();

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

            AdjustBtnText();
        }

        //데이터를 보내기
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (testEnv.connected == false)
            {
                using (ComportSettingDialog csd = new ComportSettingDialog())
                {
                    csd.Owner = this;
                    csd.PortDescString = testEnv.descPort;
                    if (csd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Rs232Utils.SetPortDescString(serialPort1, csd.PortDescString);
                        testEnv.descPort = csd.PortDescString;

                        try
                        {
#if !DEBUG
                            serialPort1.Open();
#endif
                            testEnv.connected = true;

                            AdjustBtnText();
                        }
                        catch (Exception ex)
                        {
                            testEnv.connected = false;

                            MessageBox.Show(ex.Message);
                        }
                    }
                }

                if (testEnv.connected && testEnv.endTime > DateTime.Now)
                {
                    if (MessageBox.Show("이전 테스트가 완료되지 못했습니다. 이어하시겠습니까?"
                        , "이어하기",MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            // 이어하기
                            LoadFromFile();

                            textBoxTarget.Text = testEnv.target;
                            textBoxDelay.Text = testEnv.delay.ToString();
                            textBoxEnd.Text = testEnv.endTime.ToString();

                            SetStateStartTest();
                        }
                        catch(Exception ex)
                        {
                            ModalessMsgBox(ex.Message);
                        }
                    }
                    else
                    {
                        InitGraph();
                        dataGridView1.Rows.Clear();

                        testEnv.target = "";
                    }
                }

                return;
            }

            if (testEnv.connected)
            {
                if (testEnv.working)
                {
                    if (MessageBox.Show("시험을 종료하시겠습니까?"
                        , "시험 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        SetStateStopTest();
                        testEnv.target = "";
                    }

                    return;
                }

                if (!testEnv.EnableRunTest())
                {
                    SetStateTestSetting();
                    return;
                }
                else
                {
                    SetStateStartTest();
                    return;
                }
            }

            
        }
        private void AdjustBtnText()
        {
            if (testEnv.connected == false)
            {
                btnStart.Text = "포트 설정";
                return;
            }

            if (testEnv.connected)
            {
                if (testEnv.working)
                {
                    btnStart.Text = "시험 종료";
                    return;
                }

                if (!testEnv.EnableRunTest())
                {
                    btnStart.Text = "시험 환경 설정";
                    return;
                }
                else
                {
                    btnStart.Text = "시험 시작";
                    return;
                }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                testEnv.connected = false;
                serialPort1.Close();
            }
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            SaveTofile(true, dataGridView1);
        }

        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        public void SaveTofile(bool captions, DataGridView myDataGridView)
        {
            int num = 0;

            string[] headers = new string[myDataGridView.ColumnCount];
            string[] columns = new string[myDataGridView.ColumnCount];

            for (int c = 0; c < myDataGridView.ColumnCount; c++)
            {
                headers[c] = myDataGridView.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();

                if (c <= 25)
                {
                    num = c + 65;
                    columns[c] = Convert.ToString((char)num);
                }
                else
                {
                    columns[c] = Convert.ToString((char)(Convert.ToInt32(c / 26) - 1 + 65)) + Convert.ToString((char)(c % 26 + 65));
                }
            }

            try
            {
                object missingType = Type.Missing;
                Microsoft.Office.Interop.Excel.Application objApp;
                Microsoft.Office.Interop.Excel._Workbook objBook;
                Microsoft.Office.Interop.Excel.Workbooks objBooks;
                Microsoft.Office.Interop.Excel.Sheets objSheets;
                Microsoft.Office.Interop.Excel._Worksheet objSheet;
                Microsoft.Office.Interop.Excel.Range range = null;

                objApp = new Microsoft.Office.Interop.Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(1);

                if (captions)
                {
                    for (int c = 0; c < myDataGridView.ColumnCount; c++)
                    {
                        range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                        range.set_Value(Missing.Value, headers[c]);
                    }
                }

                for (int i = 0; i < myDataGridView.RowCount - 1; i++)
                {
                    for (int j = 0; j < myDataGridView.ColumnCount; j++)
                    {
                        range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2),
                            Missing.Value);
                        range.set_Value(Missing.Value,
                            myDataGridView.Rows[i].Cells[j].Value.ToString());

                    }
                }
                objApp.Visible = false;
                objApp.UserControl = false;
                objApp.DisplayAlerts = false;

                objBook.SaveAs(System.Environment.CurrentDirectory + "\\" + testEnv.fileName + ".xls",
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                    missingType, missingType, missingType, missingType,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    missingType, missingType, missingType, missingType, missingType);

                objBook.Close(false, missingType, missingType);
                Cursor.Current = Cursors.Default;

                // Clean up
                ReleaseExcelObject(range);
                ReleaseExcelObject(objSheet);
                ReleaseExcelObject(objSheets);
                ReleaseExcelObject(objBook);
                ReleaseExcelObject(objBooks);
                ReleaseExcelObject(objApp);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                ModalessMsgBox(errorMessage);
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

        void timer_Tick(object sender, EventArgs e)
        {
#if DEBUG

#else
            if (!serialPort1.IsOpen)
            {
                testEnv.connected = false;
                serialPort1.Close();
                return;
            }
#endif

            if (sendCnt != recvCnt)
            {
                ModalessMsgBox("포트가 끊겼습니다.");
                timer.Stop();

                SetStatePortSetting();

                return;
            }

            sendCnt++;

#if DEBUG
            recvCnt++;
            string[] row = { DateTime.Now.ToString(), "1", "2.000"
                               , "2.000", "2.000", "2.000", "2.000" };
            SetDataToUI(row);

            SaveTofile(true, dataGridView1);
#endif

            // 시리얼데이터 버퍼 STX 1 / LocalID 2 / ETX 1
            byte[] buffer = new byte[4];
            // Start Byte
            buffer[0] = Rs232Utils.STX;
            // Local ID
            buffer[1] = System.Text.Encoding.ASCII.GetBytes(testEnv.localId.ToCharArray())[0];
            buffer[2] = System.Text.Encoding.ASCII.GetBytes(testEnv.localValue.ToCharArray())[0];
            // End Byte
            buffer[3] = Rs232Utils.ETX;

#if DEBUG
#else
            serialPort1.Write(buffer, 0, buffer.Length);
#endif
            DisplayStatusbarMessage(string.Format("{0}, {1}byte를 보냈읍니다 SendCnt: {2}, RecvCnt: {3}"
                , buffer.ToString(), buffer.Length, sendCnt, recvCnt));

            SendTextBox.Text += Rs232Utils.ByteArrayToHexString(buffer) + "\r\n";
        }

        public void LoadFromFile()
        {
            try
            {
                // OLEDB를 이용한 엑셀 연결
                string szConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + testEnv.fileName + ".xls" + ";Extended Properties='Excel 8.0;HDR=YES'";
                OleDbConnection conn = new OleDbConnection(szConn);
                conn.Open();

                // 엑셀로부터 데이타 읽기
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
                OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string[] row = { dr[0].ToString(), dr[1].ToString()
                                        , dr[2].ToString(), dr[3].ToString()
                                        , dr[4].ToString(), dr[5].ToString()
                                        , dr[6].ToString() };
                    SetDataToUI(row);
                }

                conn.Close();
            }
            catch(Exception e)
            {
                ModalessMsgBox(e.Message);
            }

            return;
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

        private void textBoxDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void buttonViewer_Click(object sender, EventArgs e)
        {
            viewer = new FormViewer();
            viewer.Owner = this;
            viewer.Show();
        }
    }
}

