using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FByteProperty : UProperty
    {
        public string Name { get; private set; }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            Name = reader.ReadFString();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadByte();
        }
    }
}
