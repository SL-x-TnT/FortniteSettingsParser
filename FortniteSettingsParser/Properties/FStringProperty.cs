using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FStringProperty : UProperty
    {
        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {

        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadFString();
        }
    }
}
