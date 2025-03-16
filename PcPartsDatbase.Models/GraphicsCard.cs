using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPartsDatbase.Models
{
    public class GraphicsCard
    {
        public int GraphicsID { get; set; }
        public string GraphicName { get; set; }
        public int GraphicCoreSpeed { get; set; }
        public int GraphicSpeed { get; set; }
        public int GraphicMemoryMB { get; set; }
        public string BrandName { get; set; }
    }
}
