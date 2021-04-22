using FortniteSettingsParser.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser
{
    public class FortniteSettings
    {
        public SettingsHeader Header { get;  set; }
        public List<GuidData> GuidData { get; set; }
        public Dictionary<string, UProperty> Settings { get; set; } 
    }
}
