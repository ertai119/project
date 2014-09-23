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
    public partial class TesterSettingDialog : Form
    {
        public string target
        {
            get
            {
                return textBoxTarget.Text;
            }
        }
        public string endTime
        {
            get
            {
                return dateTimePickerEnd.Value.ToString();
            }
        }
        public int delay
        {
            get
            {
                return Convert.ToInt32(textBoxDelay.Text);
            }
        }
        public TesterSettingDialog()
        {
            InitializeComponent();

            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "yyyy-MM-dd-HH:mm";
            textBoxDelay.Text = "1";
            textBoxTarget.Text = "Empty";
        }
        private void textBoxDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
