using FortniteSettingsParser.Property;

using System.Collections.Generic;
using System.IO;

namespace FortniteSettingsParser.Object
{
    public class FortniteSettings
    {

        public IReadOnlyCollection<FGuid> Guids { get; set; }
        public IReadOnlyDictionary<string, UProperty> Properties { get; set; }

        public FortniteSettingsHeader Header { get; set; }

        public FortniteSettings(UnrealBinaryReader stream)
        {
            Header = new FortniteSettingsHeader(stream);

            stream.Header = Header;

            Guids = ParseGuidData(stream);
            Properties = stream.ReadProperties();
        }

        private static IReadOnlyCollection<FGuid> ParseGuidData(UnrealBinaryReader reader)
        {
            var length = reader.ReadInt32();
            var guids = new List<FGuid>(length);

            for (var i = 0; i < length; i++)
            {
                var guid = reader.Read<FGuid>();
                reader.Seek(4, SeekOrigin.Current);

                guids.Add(guid);
            }

            return guids;
        }

    }
}
