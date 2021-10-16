namespace FortniteSettingsParser.Property
{
    public class FNameProperty : UProperty
    {

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadFString();

    }
}
