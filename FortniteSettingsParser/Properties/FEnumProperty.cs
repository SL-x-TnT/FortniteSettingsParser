using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FEnumProperty : UProperty
    {
        public string EnumName { get; private set; }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            EnumName = reader.ReadFString();
        }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadFString();
        }
    }
}
