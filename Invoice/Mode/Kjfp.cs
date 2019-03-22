using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invoice.Mode
{
    [Serializable]
    class Kjfp
    {
        public string bill_batch_code { get; set; }
        public string bill_no { get; set; }
        public string serial_number { get; set; }
        public string random { get; set; }
        public string create_time { get; set; }
        public string bill_name { get; set; }
        public string state { get; set; }
        public string date { get; set; }      
    }
}
