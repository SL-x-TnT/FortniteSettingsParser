using System.IO;
using System.Text.RegularExpressions;

namespace FortniteSettingsParser.Object
{
    public class FortniteSettingsHeader
    {
        public short Something { get; set; }

        public int FileVersionUE4 { get; set; }

        public int FileVersionUE5 { get; set; }

        public int Patch { get; set; }

        public int Changelist { get; set; }

        public string Branch { get; set; }

        public int Major { get; set; }

        public int Minor { get; set; }

        public int Version { get; set; }

        public byte Unknown3 { get; set; }

        public byte Unknown4 { get; set; }


        public FortniteSettingsHeader(UnrealBinaryReader reader)
        {
            Something = reader.ReadInt16();

            reader.Seek(2, SeekOrigin.Current);

            FileVersionUE4 = reader.ReadInt32();

            if (Something != 2464) {
                FileVersionUE5 = reader.ReadInt32();
            }

            reader.Seek(4, SeekOrigin.Current);
            Patch = reader.ReadInt16();
            Changelist = reader.ReadInt32();

            Branch = reader.ReadFString();

            string pattern = @"\+\+Fortnite\+Release-(?<major>\d{1,2}).(?<minor>\d{1,2})";
            var match = Regex.Match(Branch, pattern);

            if (match.Success) {
                Major = int.Parse(match.Groups["major"].Value);
                Minor = int.Parse(match.Groups["minor"].Value);
            }

            Version = reader.ReadInt32();
            Unknown3 = reader.ReadByte();
            Unknown4 = reader.ReadByte();
        }
    }
}
