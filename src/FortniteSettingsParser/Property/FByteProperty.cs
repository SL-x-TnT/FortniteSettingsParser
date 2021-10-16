namespace FortniteSettingsParser.Property
{
    public class FByteProperty : UProperty
    {
        public string Name { get; private set; }

        protected internal override void PreDeserializeProperty(UnrealBinaryReader reader)
        {
            Name = reader.ReadFString();
        }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if (Name == null || Name == "None")
            {
                Value = reader.ReadByte();
            }
            else
            {
                Value = reader.ReadFString();
            }
        }
    }
}
