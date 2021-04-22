using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FStructProperty : UProperty
    {
        public string StructName { get; private set; }
        public string StructGuid { get; private set; }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            StructName = reader.ReadFString();
            StructGuid = reader.ReadGuid();
        }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if(StructName == null || !UnrealTypes.HasPropertyName(StructName))
            {
                Value = reader.ReadProperties();
            }
            else
            {
                UProperty property = UnrealTypes.GetPropertyByName(StructName);
                property.Deserialize(reader);

                Value = property;
            }
        }
    }
}
