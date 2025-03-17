using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPartsDatbase.Models
{
    public class OperatingSys
    {
        public int OsID { get; set; }
        public string OsName { get; set; }
        public bool IsOpenSource { get; set; }
        public string OsDeveloper { get; set; }
    }
}
