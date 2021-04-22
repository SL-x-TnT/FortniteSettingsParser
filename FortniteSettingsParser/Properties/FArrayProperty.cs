using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FArrayProperty : UProperty
    {
        public string InnerType { get; private set; }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            InnerType = reader.ReadFString();
        }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            base.DeserializeProperty(reader);
        }
    }
}
