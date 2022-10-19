namespace FortniteSettingsParser.Property
{
    public class FInt8Property : UProperty
    {
        
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadInt8();
    }
}
