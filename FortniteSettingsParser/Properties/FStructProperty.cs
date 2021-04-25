using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FStructProperty : UProperty
    {
        internal string _structName;
        private string _structGuid;

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            _structName = reader.ReadFString();
            _structGuid = reader.ReadGuid();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if(_structName == null || !UnrealTypes.HasPropertyName(_structName))
            {
                Value = reader.ReadProperties();
            }
            else
            {
                UProperty property = UnrealTypes.GetPropertyByName(_structName);
                property.Deserialize(reader);

                Value = property;
            }
        }
    }
}
