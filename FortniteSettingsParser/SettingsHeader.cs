using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser
{
    public class SettingsHeader
    {
        public byte[] Unknown1 { get; set; }
        public string Branch { get; set; }
        public int Unknown2 { get; set; }
        public byte Unknown3 { get; set; }
        public byte Unknown4 { get; set; }
    }
}
