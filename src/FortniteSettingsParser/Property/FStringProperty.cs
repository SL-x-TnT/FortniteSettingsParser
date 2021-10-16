namespace FortniteSettingsParser.Property
{
    public class FStringProperty : UProperty
    {
        
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadFString();

    }
}
