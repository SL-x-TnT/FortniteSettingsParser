using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FSetProperty : UProperty
    {
        private string _innerType;

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            _innerType = reader.ReadFString();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            List<UProperty> items = new List<UProperty>();

            reader.ReadInt32(); //?
            int count = reader.ReadInt32();

            for(int i = 0; i < count; i++)
            {
                UProperty property = UnrealTypes.GetPropertyByName(_innerType);
                property.DeserializeProperty(reader);

                items.Add(property);
            }
        }

    }
}
