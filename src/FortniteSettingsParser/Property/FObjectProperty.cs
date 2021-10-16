namespace FortniteSettingsParser.Property
{
    public class FObjectProperty : UProperty
    {

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadFString();

    }
}
