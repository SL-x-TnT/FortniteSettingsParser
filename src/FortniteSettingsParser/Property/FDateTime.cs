using System;

namespace FortniteSettingsParser.Property
{
    public class FDateTime : UStruct
    {
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = new DateTime(reader.ReadInt64());
        }
    }
}
