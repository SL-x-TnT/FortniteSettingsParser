using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FDateTime : UStruct
    {
        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = new DateTime(reader.ReadInt64());
        }
    }
}
