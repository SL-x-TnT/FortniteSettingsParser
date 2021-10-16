namespace FortniteSettingsParser.Property
{
    public class FFloatProperty : UProperty
    {

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadSingle();

    }
}
