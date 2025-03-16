using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPartsDatbase.Models
{
    public class Storage
    {
        public int StorageID { get; set; }
        public int StorageAmount { get; set; }
        public string? StorageBrand { get; set; }
        public bool IsSolidState { get; set; }
    }
}
