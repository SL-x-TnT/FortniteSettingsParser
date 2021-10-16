namespace FortniteSettingsParser.Property
{
    public class FUInt32Property : UProperty
    {
        
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadUInt32();

    }
}
