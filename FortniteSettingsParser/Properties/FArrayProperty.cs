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
        public Dictionary<string, UProperty> Items { get; private set; } = new Dictionary<string, UProperty>();

        protected override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            InnerType = reader.ReadFString();
        }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            base.DeserializeProperty(reader);

            return;

            int count = reader.ReadInt32();

            string settingName = reader.ReadFString();
            string typeName = reader.ReadFString();

            UProperty property = UnrealTypes.GetPropertyByName(InnerType);
            property.Deserialize(reader);

            for (int i = 0; i < count; i++)
            {
                UProperty arrayType = UnrealTypes.GetPropertyByName(property.TypeName);
            }
        }
    }
}
