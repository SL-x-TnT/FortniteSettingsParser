using System.Collections.Generic;
using System.Diagnostics;

using FortniteSettingsParser.Property;

namespace FortniteSettingsParser.Object
{
    public class FortniteSettings
    {
        
        public FortniteSettingsHeader Header { get; set; }

        public List<FortniteSettingsGuid> Guids { get; set; }

        public Dictionary<string, UProperty> Properties { get; set; }

        public readonly Stopwatch _stopWatch;

        public readonly long _timeTaken;

        public FortniteSettings(UnrealBinaryReader stream)
        {
            _stopWatch = new();
            _stopWatch.Start();

            Header = new(stream);
            ParseGuidData(stream);
            Properties = stream.ReadProperties();

            _stopWatch.Stop();
            _timeTaken = _stopWatch.ElapsedMilliseconds;
        }

        private void ParseGuidData(UnrealBinaryReader reader)
        {
            var length = reader.ReadInt32();
            Guids = new List<FortniteSettingsGuid>(length);

            for (int i = 0; i < length; i++)
            {
                var variable = reader.ReadGuid();
                var value = reader.ReadInt32();
                Guids.Add(new FortniteSettingsGuid(variable, value));
            }
        }

    }


}
