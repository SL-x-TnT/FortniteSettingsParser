namespace FortniteSettingsParser.Object
{
    public class FortniteSettingsGuid
    {

        public string Guid { get; set; }

        public int Value { get; set; }

        public FortniteSettingsGuid(UnrealBinaryReader reader)
        {
            Guid = reader.ReadGuid();
            Value = reader.ReadInt32();
        }
    }
}
