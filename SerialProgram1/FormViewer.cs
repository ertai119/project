using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
            
            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            SetVisibleGraph(eGraphState.TEMPERATURE);
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

        public void LoadFromFile()
        {
            try
            {
                FileDialog fileDlg = new OpenFileDialog();
                fileDlg.InitialDirectory = System.Environment.CurrentDirectory + "\\" + TesterEnviorment.PATH_COMPLETE;
                fileDlg.Filter = "모든 파일 (*.*)|*.*";
                fileDlg.RestoreDirectory = true;
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    InitUIControl();

                    StreamReader sr = new StreamReader(fileDlg.FileName, Encoding.UTF8);

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

                            string[] dr = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                            string[] row = { dr[0].ToString(), dr[1].ToString()
                                                , dr[2].ToString(), dr[3].ToString()
                                                , dr[4].ToString(), dr[5].ToString()
                                                , dr[6].ToString() };

                            fileDataList.Add(row);
                        }

                        for (int idx = 0 ; idx < fileDataList.Count; idx++)
                        {
                            SetDataFromFile(fileDataList[idx]);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }

                    this.Text = fileDlg.FileName;
                }
            }
            catch
            {
                ModalessMsgBox("중복되는 파일입니다. 파일을 다시한번확인해주세요");
            }

            return;
        }
        private void SetDataFromFile(string[] data)
        {
            if (data == null)
                return;

            dataGridView1.Rows.Add(data);

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
