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
        public List<UProperty> Items { get; private set; } = new List<UProperty>();

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            InnerType = reader.ReadFString();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            int count = reader.ReadInt32();

            string settingName = reader.ReadFString();
            string typeName = reader.ReadFString();

            UProperty property = UnrealTypes.GetPropertyByName(InnerType);
            property.DeserializeTypeInfo(reader);

            for (int i = 0; i < count; i++)
            {
                UProperty arrayType = UnrealTypes.GetPropertyByName(property.TypeName);
                arrayType.DeserializeProperty(reader);
                arrayType.ArrayIndex = i;

                Items.Add(arrayType);
            }
        }
    }
}
