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
    public partial class ComportSettingDialog : Form
    {
        private static char[] WhiteSpace = new char[] { ' ', '\n', '\r', '\t' };
        public string PortDescString 
        {
            get
            {

                return string.Format("{0}-{1}-{2}-{3}-{4}-{5}",
                    cboPortName.Text,
                    cboBaudrate.Text,
                    cboDatabits.Text,
                    cboParity.Text,
                    cboStopbits.Text,
                    cboFlowControl.Text);
            }
            set
            {
                if (Rs232Utils.IsValidPortDescString(value))
                {
                    string[] tmp = value.Split('-');
                    cboPortName.Text = tmp[0];
                    cboBaudrate.Text = tmp[1];
                    cboDatabits.Text = tmp[2];
                    cboParity.Text = tmp[3];
                    cboStopbits.Text = tmp[4];
                    cboFlowControl.Text = tmp[5];
                }

            }
        }
       
        public ComportSettingDialog()
        {
            InitializeComponent();
        }
    }
}
