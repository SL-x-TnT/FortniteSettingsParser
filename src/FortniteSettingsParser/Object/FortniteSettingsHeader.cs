namespace FortniteSettingsParser.Object
{
    public class FortniteSettingsHeader
    {
        public byte[] Unknown1 { get; set; }

        public string Branch { get; set; }

        public int Unknown2 { get; set; }

        public byte Unknown3 { get; set; }

        public byte Unknown4 { get; set; }


        public FortniteSettingsHeader(UnrealBinaryReader reader)
        {
            Unknown1 = reader.ReadBytes(18);
            Branch = reader.ReadFString();
            Unknown2 = reader.ReadInt32();
            Unknown3 = reader.ReadByte();
            Unknown4 = reader.ReadByte();
        }
    }
}
