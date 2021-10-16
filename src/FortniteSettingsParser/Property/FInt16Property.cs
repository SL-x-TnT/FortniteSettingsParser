namespace FortniteSettingsParser.Property
{
    public class FInt16Property : UProperty
    {
        
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadInt16();

    }
}
