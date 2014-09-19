using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;


namespace SerialProgram
{
    public partial class Form1 : Form
    {
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        internal enum PortStatus { None, Opened, Closed }
        public Form1()
        {
            InitializeComponent();
            lblPortDesc.Text = Rs232Utils.PortDescString(serialPort1);
            btnOpenClose.Tag = PortStatus.Closed;

            serialPort1.ReceivedBytesThreshold = 1;
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
                    DisplayStatusbarMessage("통신포트가 열렸습니다. 데이터를 전송할 수 있습니다");
                }
                else
                {
                    serialPort1.Close();
                    btnOpenClose.Text = "통신포트 열기";
                    btnOpenClose.Tag = PortStatus.Closed;
                    btnSend.Enabled = false;
                    DisplayStatusbarMessage("통신포트를 닫았습니다");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int bytes = serialPort1.BytesToRead;
            if(bytes >= 40)
            {
                byte[] buffer = new byte[bytes];
                serialPort1.Read(buffer, 0, bytes);
                this.Invoke(new MethodInvoker(delegate
                {
                    RecvTextBox.Text += Rs232Utils.ByteArrayToHexString(buffer) + "\r\n";
                }));

                string dump = RecvTextBox.Text;
            }
        }

        //데이터를 보내기
        private void btnSend_Click(object sender, EventArgs e)
        {
            string str;
            // 시리얼데이터 버퍼 STX 1 / LocalID 2 / ETX 2

            byte[] buffer = new byte[4];

            // Start Byte
            buffer[0] = Rs232Utils.STX;

            // Local ID
            str = "A";
            buffer[1] = System.Text.Encoding.ASCII.GetBytes(str.ToCharArray())[0];
            str = "0";
            buffer[2] = System.Text.Encoding.ASCII.GetBytes(str.ToCharArray())[0];

            // End Byte
            buffer[3] = Rs232Utils.ETX;

            serialPort1.Write(buffer, 0, buffer.Length);
            DisplayStatusbarMessage(string.Format("{0}, {1}byte를 보냈읍니다", buffer, buffer.Length));

            SendTextBox.Text += Rs232Utils.ByteArrayToHexString(buffer) + "\r\n";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) { serialPort1.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(10, 10);
            chart1.Series[0].Points.AddXY(100, 100);
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Legends[0].Enabled = true;

            chart1.Invalidate();

            string [] row = {"1200", "3.175", "23.0", "7.1"};
            dataGridView1.Rows.Add(row);
        }
        
        public void ExportExcel(bool captions, DataGridView myDataGridView)
        {
            this.saveFileDialog.FileName = "TempName";
            this.saveFileDialog.DefaultExt = "xls";
            this.saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            this.saveFileDialog.InitialDirectory = "c:\\temp\\";

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

                    MessageBox.Show("Save Success!!!");
                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);
                    MessageBox.Show(errorMessage, "Error");
                }
            }
        }

    }
}

