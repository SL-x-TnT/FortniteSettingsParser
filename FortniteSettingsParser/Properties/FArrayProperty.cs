using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FArrayProperty : UProperty
    {
        private string _innerType;

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            _innerType = reader.ReadFString();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            List<UProperty> items = new List<UProperty>();

            int count = reader.ReadInt32();

            string settingName = reader.ReadFString();
            string typeName = reader.ReadFString();

            UProperty property = UnrealTypes.GetPropertyByName(_innerType);
            property.DeserializeTypeInfo(reader);

            for (int i = 0; i < count; i++)
            {
                UProperty arrayType = UnrealTypes.GetPropertyByName(property.TypeName);
                arrayType.DeserializeProperty(reader);
                arrayType.ArrayIndex = i;

                items.Add(arrayType);
            }

            Value = items;
        }
    }
}
