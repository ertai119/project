using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    class Cell
    { }
    class TesterEnviorment
    {

        private bool init { get; set; }
        public string fileName { get; set; }
        public DateTime endTime { get; set; }
        public int delay { get; set; }
        public bool connected { get; set; }
        public bool working { get; set; }

        public bool EnableRunTest()
        {
            if (DateTime.Now >= endTime)
                return false;

            if (delay <= 0)
                return false;

            if (working == true)
                return false;

            if (fileName == null)
                return false;

            if (fileName.Length <= 0)
                return false;

            return true;
        }
    }
}
