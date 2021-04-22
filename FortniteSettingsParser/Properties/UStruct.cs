using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class UStruct : UProperty
    {
        public override void Deserialize(UnrealBinaryReader reader)
        {
            DeserializeProperty(reader);
        }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {

        }

    }
}
