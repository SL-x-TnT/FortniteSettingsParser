namespace FortniteSettingsParser.Property
{
    public class FEnumProperty : UProperty
    {
        public string EnumName { get; private set; }

        protected internal override void PreDeserializeProperty(UnrealBinaryReader reader)
            => EnumName = reader.ReadFString();

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadFString();
    }
}
