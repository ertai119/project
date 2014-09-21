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
        
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        TesterEnviorment testEnv = new SerialProgram.TesterEnviorment();
        FormViewer viewer = new FormViewer();

        public Form1()
        {

            InitializeComponent();
            lblPortDesc.Text = Rs232Utils.PortDescString(serialPort1);
            btnOpenClose.Tag = PortStatus.Closed;

            

#if DEBUG
            comboBoxTimer.SelectedIndex = 2;
#else
            comboBoxTimer.SelectedIndex = 0;
#endif
            timer.Tick += new EventHandler(timer_Tick);

            radioButtonTemperature.Checked = true;

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
            lblMsg.Text = s;
        }

        private void lblPortDesc_Click(object sender, EventArgs e)
        {
            using (ComportSettingDialog csd = new ComportSettingDialog())
            {
                csd.Owner = this;
                csd.PortDescString = lblPortDesc.Text;
                if (csd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Rs232Utils.SetPortDescString(serialPort1, csd.PortDescString);
                    lblPortDesc.Text = csd.PortDescString;
                }
            }
        }

        private void lblPortDesc_MouseHover(object sender, EventArgs e)
        {
            DisplayStatusbarMessage("마우스를 클릭하면 통신 포트 설정값을 변경할 수 있습니다");
        }

        private void MessageNone(object sender, EventArgs e)
        {
            DisplayStatusbarMessage("");
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((PortStatus)btnOpenClose.Tag == PortStatus.Closed)
                {
                    serialPort1.Open();
                    btnOpenClose.Text = "통신포트 닫기";
                    btnOpenClose.Tag = PortStatus.Opened;
                    btnSend.Enabled = true;
                    btnSend.Text = "Start";

                    testEnv.connected = true;

                    DisplayStatusbarMessage("통신포트가 열렸습니다. 데이터를 전송할 수 있습니다");
                }
                else
                {
                    serialPort1.Close();
                    btnOpenClose.Text = "통신포트 열기";
                    btnOpenClose.Tag = PortStatus.Closed;
                    btnSend.Text = "Not Connected";
                    btnSend.Enabled = false;

                    testEnv.connected = false;

                    DisplayStatusbarMessage("통신포트를 닫았습니다");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string recieveSB;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // 비동기로 넘긴다.
            this.Invoke(new EventHandler(AddRecieve));
        }

        private void AddRecieve(object sender, EventArgs e)
        {
            string st = serialPort1.ReadExisting();
            recieveSB += st;

            if (recieveSB.Length < 26)
                return;

            char[] buffer = st.ToCharArray();
            if (buffer[buffer.Length - 1] == Rs232Utils.RECV_ETX)
            {
                this.Invoke(new EventHandler(ReadData));
            }
        }

        private void ReadData(object s, EventArgs e)
        {
            // 누적된 데이터를 받고
            string recieveData = recieveSB.ToString();

            this.RecvTextBox.AppendText(recieveData);
            this.RecvTextBox.AppendText("\r\n");

            // 누적 데이터를 없애고
            recieveSB = "";

            if (recieveData.Length <= 0)
                return;

            char[] chStr = recieveData.ToCharArray();
            if (chStr[0] != Rs232Utils.RECV_ETX || chStr[chStr.Length - 1] != Rs232Utils.RECV_ETX)
                return;

            string token = "";
            token += chStr[3];
            token += chStr[4];

            int payloadLength = Convert.ToInt32(token);
            if (payloadLength % 4 != 0)
                return;

            token = "";
            int receivedTokencount = payloadLength / 4;
            string[] datas = new string[TesterEnviorment.PACKET_TOKEN_COUNT];
            if (receivedTokencount > TesterEnviorment.PACKET_TOKEN_COUNT)
                return;

            for (int i = 0; i < receivedTokencount; i++)
            {
                token += chStr[5 + i * 4];
                token += chStr[5 + i * 4 + 1];
                token += chStr[5 + i * 4 + 2];
                token += chStr[5 + i * 4 + 3];

                double value = Convert.ToDouble(token) / 1000;
                datas[i] = string.Format("{0:0.000}", value);
                token = "";
            }

            //수조온도	pH농도	염도	용존산소량	음극전위, 양극전류
            string[] row = { DateTime.Now.ToString(), datas[0], datas[1]
                               , datas[2], datas[3], datas[4], datas[5] };
            SetDataToUI(row);
        }
        
        //데이터를 보내기
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!testEnv.EnableRunTest())
            {
                MessageBox.Show("설정이 완료되지 못했습니다.");
                return;
            }

            if (testEnv.working)
            {
                testEnv.working = false;
                btnSend.Text = "Start";

                timer.Stop();
                ModalessMsgBox("시험 종료");
            }
            else
            {
                testEnv.working = true;
                btnSend.Text = "Stop";

                InitGraph();

                timer.Stop();
                timer.Interval = testEnv.delay;
                timer.Start();
                ModalessMsgBox("시험 시작");
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

        private void buttonPrintGraph_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            SaveTofile(true, dataGridView1);
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            this.viewer.Owner = this;
            this.viewer.Show();
        }

        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        public void SaveTofile(bool captions, DataGridView myDataGridView)
        {
            this.saveFileDialog.FileName = testEnv.fileName;
            this.saveFileDialog.DefaultExt = "xls";
            this.saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            this.saveFileDialog.InitialDirectory = System.Environment.CurrentDirectory;

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                int num = 0;
                object missingType = Type.Missing;
                Microsoft.Office.Interop.Excel.Application objApp;
                Microsoft.Office.Interop.Excel._Workbook objBook;
                Microsoft.Office.Interop.Excel.Workbooks objBooks;
                Microsoft.Office.Interop.Excel.Sheets objSheets;
                Microsoft.Office.Interop.Excel._Worksheet objSheet;
                Microsoft.Office.Interop.Excel.Range range;

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
                    objBook.SaveAs(@saveFileDialog.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                        missingType, missingType, missingType, missingType,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        missingType, missingType, missingType, missingType, missingType);

                    objBook.Close(false, missingType, missingType);

                    Cursor.Current = Cursors.Default;
                    // Clean up
                    ReleaseExcelObject(objSheet);
                    ReleaseExcelObject(objBooks);
                    ReleaseExcelObject(objApp);

                    ModalessMsgBox("Save Success!!!");
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
            if (!serialPort1.IsOpen)
            {
                testEnv.connected = false;
                return;
            }

            // 시리얼데이터 버퍼 STX 1 / LocalID 2 / ETX 1
            byte[] buffer = new byte[4];
            // Start Byte
            string token;
            buffer[0] = Rs232Utils.STX;
            // Local ID
            token = "C";
            buffer[1] = System.Text.Encoding.ASCII.GetBytes(token.ToCharArray())[0];
            token = "0";
            buffer[2] = System.Text.Encoding.ASCII.GetBytes(token.ToCharArray())[0];
            // End Byte
            buffer[3] = Rs232Utils.ETX;

            serialPort1.Write(buffer, 0, buffer.Length);
            DisplayStatusbarMessage(string.Format("{0}, {1}byte를 보냈읍니다", buffer, buffer.Length));

            SendTextBox.Text += Rs232Utils.ByteArrayToHexString(buffer) + "\r\n";
        }

        public void LoadFromFile()
        {
            try
            {
                FileDialog fileDlg = new OpenFileDialog();
                fileDlg.InitialDirectory = System.Environment.CurrentDirectory;
                fileDlg.Filter = "모든 파일 (*.*)|*.*";
                fileDlg.RestoreDirectory = true;
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    // OLEDB를 이용한 엑셀 연결
                    string szConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileDlg.FileName + ";Extended Properties='Excel 8.0;HDR=YES'";
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
                }
            }
            catch
            {
                ModalessMsgBox("중복되는 파일입니다. 파일을 다시한번확인해주세요");
            }

            return;
        }
        
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            testEnv.endTime = dateTimePickerEnd.Value;
            testEnv.fileName = "ICCP " + dateTimePickerEnd.Value.ToString();
        }

        private void comboBoxTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimer.SelectedIndex >= 0)
            {
                if (comboBoxTimer.SelectedIndex == 0)
                    testEnv.delay = 1000 * 60 * 30;
                else if (comboBoxTimer.SelectedIndex == 1)
                    testEnv.delay = 1000 * 60 * 60 * 24;
                else if (comboBoxTimer.SelectedIndex == 2)
                    testEnv.delay = 1000 * 5;
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
    }
}

