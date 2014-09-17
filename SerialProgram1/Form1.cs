using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialProgram
{
    public partial class Form1 : Form
    {
        internal enum PortStatus { None, Opened, Closed }
        public Form1()
        {
            InitializeComponent();
            lblPortDesc.Text = Rs232Utils.PortDescString(serialPort1);
            btnOpenClose.Tag = PortStatus.Closed;
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
            DisplayStatusbarMessage("마우스를 클릭하면 통신 포트 설정값을 변경할 수 있읍니다");
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
                    DisplayStatusbarMessage("통신포트가 열렸읍니다. 데이터를 전송할 수 있읍니다");
                }
                else
                {
                    serialPort1.Close();
                    btnOpenClose.Text = "통신포트 열기";
                    btnOpenClose.Tag = PortStatus.Closed;
                    btnSend.Enabled = false;
                    DisplayStatusbarMessage("통신포트를 닫았읍니다");
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
            byte[] buffer = new byte[bytes];
            serialPort1.Read(buffer, 0, bytes);
            this.Invoke(new MethodInvoker(delegate
                {
                    RecvTextBox.Text += Rs232Utils.ByteArrayToHexString(buffer)+" ";

                }));
           
        }
        //데이터를 보내기
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (SendTextBox.Text.Length < 2 || !Rs232Utils.IsValidHexString(SendTextBox.Text))
            {
                MessageBox.Show("보낼려는 데이터가 비어 있거나 올바른 Hex 값이 아닙니다");
            }
            else
            {
                byte[] bytes = Rs232Utils.HexStringToByteArray(SendTextBox.Text);
                serialPort1.Write(bytes, 0, bytes.Length);
                DisplayStatusbarMessage(string.Format("{0} byte를 보냈읍니다", bytes.Length));
            }
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
            /*
            chart1.Series[1].Points.AddXY(1, 1);
            chart1.Series[1].Points.AddXY(1, 1);
            chart1.Series[1].IsValueShownAsLabel = true;
    */
            chart1.Invalidate();

            string [] row = {"1200", "3.175", "23.0", "7.1"};
            dataGridView1.Rows.Add(row);
        }

    }
}

