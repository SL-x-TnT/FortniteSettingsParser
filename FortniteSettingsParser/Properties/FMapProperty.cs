using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FMapProperty : UProperty
    {
        private string _innerType;
        private string _valueType;

        protected int NumKeysToRemove { get; set; }

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            _innerType = reader.ReadFString();
            _valueType = reader.ReadFString();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Dictionary<UProperty, UProperty> values = new Dictionary<UProperty, UProperty>();

            NumKeysToRemove = reader.ReadInt32();
            int numEntries = reader.ReadInt32();

            for (int i = 0; i < NumKeysToRemove; i++)
            {
                UProperty propertyKey = UnrealTypes.GetPropertyByName(_innerType);
                propertyKey.DeserializeProperty(reader);
            }

            for (int i = 0; i < numEntries; i++)
            {
                UProperty propertyKey = UnrealTypes.GetPropertyByName(_innerType);
                propertyKey.DeserializeProperty(reader);

                UProperty propertyValue = UnrealTypes.GetPropertyByName(_valueType);

                propertyValue.DeserializeProperty(reader);

                values.Add(propertyKey, propertyValue);
            }

            Value = values;
        }
    }
}
