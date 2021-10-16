namespace FortniteSettingsParser.Property
{
    public class UStruct : UProperty
    {
        public override void Deserialize(UnrealBinaryReader reader)
        {
            DeserializeProperty(reader);
        }

        protected internal override void PreDeserializeProperty(UnrealBinaryReader reader)
        { }

    }
}
