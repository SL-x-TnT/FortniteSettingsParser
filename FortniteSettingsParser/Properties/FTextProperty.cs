using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FTextProperty : UProperty
    {
        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {

        }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            base.DeserializeProperty(reader);
        }
    }
}
