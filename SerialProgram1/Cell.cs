﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SerialProgram
{
    struct CellData
    {
        public DateTime timeStamp { get; set; }
        public float solt { get; set; }
        public float oxgen { get; set; }
        public float temperature { get; set; }
        public float pH { get; set; }
        public float amp { get; set; }
    }

    class TesterEnviorment
    {

        private bool init { get; set; }
        public string target { get; set; }
        public string fileName 
        {
            get
            {
                return target + "_" + endTime.ToString("yyyy.MM.dd.HH.mm.ss");
            }
        }

        public DateTime endTime { get; set; }
        public int delay { get; set; }
        public bool connected { get; set; }
        public bool working { get; set; }
        public string descPort { get; set; }
        static public int PACKET_TOKEN_COUNT = 6;
        static public string NA = "N/A";

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
                    else if (token == "FILENAME")
                    {
                        target = value;
                    }
                    else if (token == "STX")
                    {
                        //string temp
                    }
                    else if (token == "LOCAL_ID")
                    {
                        localId = value;
                    }
                    else if (token == "LOCAL_VALUE")
                    {
                        localValue = value;
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

                sw.WriteLine("delay=" + delay.ToString());
                sw.WriteLine("endTime=" + endTime.ToString());
                sw.WriteLine("fileName=" + target);
                sw.WriteLine("LOCAL_ID=" + localId);
                sw.WriteLine("LOCAL_VALUE=" + localValue);

                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
