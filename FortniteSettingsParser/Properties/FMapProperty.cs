using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FMapProperty : UProperty
    {
        public string InnerType { get; private set; }
        public string ValueType { get; private set; }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            InnerType = reader.ReadFString();
            ValueType = reader.ReadFString();
        }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            base.DeserializeProperty(reader);
        }
    }
}
