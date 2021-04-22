using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FGuid : UStruct
    {
        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadGuid();
        }
    }
}
