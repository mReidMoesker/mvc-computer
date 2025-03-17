using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPartsDatbase.Models
{
    public class Computer : Sys
    {
        public string SystemName { get; set; }
        public int SystemID { get; set; }
        public string ComputerDescription { get; set; }
        public string SystemType { get; set; }
        public Processor Processor { get; set; }
        public GraphicsCard GraphicsCard { get; set; }
        public List<Storage> Storage { get; set; }
        public OperatingSys OperatingSystems { get; set; }
    }
}
