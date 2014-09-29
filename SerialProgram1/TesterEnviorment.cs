using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SerialProgram
{
    class TesterEnviorment
    {

        private bool init { get; set; }
        public string target { get; set; }
        public string fileName 
        {
            get
            {
                return target + "_" + startTime.ToString("yyyy.MM.dd.HH.mm") + "_to_" + endTime.ToString("yyyy.MM.dd.HH.mm");
            }
        }

        public DateTime endTime { get; set; }
        public DateTime startTime { get; set; }
        public int delay { get; set; }
        public bool connected { get; set; }
        public bool working { get; set; }
        public string appname { get; set; }
        public string descPort { get; set; }
        static public int PACKET_TOKEN_COUNT = 6;
        static public string NA = "N/A";
        static public int DEBUG_MODE = 0;

        public string localValue { get; set; }
        public string localId { get; set; }

        public bool EnableRunTest()
        {
            if (DateTime.Now >= endTime)
                return false;

            if (delay <= 0)
                return false;

            if (working == true)
                return false;

            if (target == null)
                return false;

            if (target.Length <= 0)
                return false;

            if (localId == null || localId.Length <= 0)
                return false;

            if (localValue == null || localValue.Length <= 0)
                return false;

            return true;
        }

        public void InitFromFile()
        {
            string path = System.Environment.CurrentDirectory +"\\" + "config.txt";
            try
            {
                FileStream inStream = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader reader = new StreamReader(inStream, Encoding.UTF8);

                string readStr = string.Empty;
                while((readStr = reader.ReadLine()) != null)
                {
                    string [] tokens = readStr.Split('=');
                    if (tokens.Length != 2)
                        continue;

                    string token = tokens[0].ToUpper();
                    string value = tokens[1].ToUpper();
                    if (value.Length == 0)
                        continue;

                    if (token == "DELAY")
                    {
                        delay = Convert.ToInt16(value);
                    }
                    else if (token == "ENDTIME")
                    {
                        endTime = Convert.ToDateTime(value);
                    }
                    else if (token == "STARTTIME")
                    {
                        startTime = Convert.ToDateTime(value);
                    }
                    else if (token == "FILENAME")
                    {
                        target = value;
                    }
                    else if (token == "LOCAL_ID")
                    {
                        localId = value.ToUpper();
                    }
                    else if (token == "LOCAL_VALUE")
                    {
                        localValue = value.ToUpper();
                    }
                    else if (token == "APP_NAME")
                    {
                        appname = value;
                    }
                    else if (token == "DEBUG_MODE")
                    {
                        DEBUG_MODE = Convert.ToInt32(value);
                    }
                }

                inStream.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SaveConfig()
        {
            string path = System.Environment.CurrentDirectory + "\\" + "config.txt";
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);

                sw.WriteLine("DELAY=" + delay.ToString());
                sw.WriteLine("ENDTIME=" + endTime.ToString());
                sw.WriteLine("STARTTIME=" + startTime.ToString());
                sw.WriteLine("FILENAME=" + target);
                sw.WriteLine("LOCAL_ID=" + localId.ToUpper());
                sw.WriteLine("LOCAL_VALUE=" + localValue.ToUpper());
                sw.WriteLine("APP_NAME=" + appname);
                sw.WriteLine("DEBUG_MODE=" + DEBUG_MODE);

                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static public void ConvertData(string[] data, DateTime startTime)
        {
            TimeSpan elpasedTime = DateTime.Now.AddDays(1) - startTime;
            data[0] = elpasedTime.Days + "일 " + elpasedTime.Hours + "시간 " + elpasedTime.Minutes + "분";
        }
    }
}
