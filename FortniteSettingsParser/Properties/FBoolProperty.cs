using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FBoolProperty : UProperty
    {
        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadBoolean();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
        }
    }
}
