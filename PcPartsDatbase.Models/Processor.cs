using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPartsDatbase.Models
{
    public class Processor
    {
        public int ProcessorID { get; set; }
        public string ProcessorName { get; set; }
        public int CoreSpeed { get; set; }
        public int CoreNums { get; set; }
        public int CacheAmount {  get; set; }
        public bool isOverclockable { get; set; }
        public string BrandName { get; set; }
    }
}