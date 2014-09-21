using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

namespace SerialProgram
{
    public partial class FormViewer : Form
    {
        internal enum eGraphState { INVALID, TEMPERATURE, PH, SALT, OXGEN, AMP, VOLT }

        public FormViewer()
        {
            InitializeComponent();

            object[] AllGraph = { chartTemperature, chartSalt, chartOxgen, chartAmp, chartVolt, chartPH };
            foreach (System.Windows.Forms.DataVisualization.Charting.Chart chart in AllGraph)
            {
                chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart.ChartAreas[0].CursorX.AutoScroll = true;
                chart.ChartAreas[0].CursorY.AutoScroll = true;
                chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                chart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
                chart.Series[0].IsValueShownAsLabel = false;
                chart.Legends[0].Enabled = true;
            }

            SetVisibleGraph(eGraphState.TEMPERATURE);
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
        private void SetDataToUI(string[] data)
        {
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

        private void radioButtonTemperature_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.TEMPERATURE);
        }

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

        private void radioButtonAmp_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibleGraph(eGraphState.AMP);
        }

        private void ModalessMsgBox(string msg)
        {
            new Thread(() => { MessageBox.Show(new Form() { TopMost = true }, msg); }).Start();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void buttonPrintGraph_Click(object sender, EventArgs e)
        {
            object[] AllGraph = { chartTemperature, chartSalt, chartOxgen, chartAmp, chartVolt, chartPH };
            foreach (System.Windows.Forms.DataVisualization.Charting.Chart chart in AllGraph)
            {
                if (chart.Visible)
                {
                    try
                    {
                        chart.Printing.Print(true);
                    }
                    catch (Exception theException)
                    {
                        string msg = "인쇄중에 에러가 발생했습니다" + theException.ToString();
                        ModalessMsgBox(msg);
                    }
                }
            }
        }
    }
}
