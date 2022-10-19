using System;
using System.Collections.Generic;
using System.IO;

using FortniteSettingsParser.Property;
using FortniteSettingsParser.Object;

using GenericReader;

namespace FortniteSettingsParser
{
    public class UnrealBinaryReader : GenericStreamReader
    {
        public FortniteSettingsHeader Header { get; set; }

        public UnrealBinaryReader(Stream input)
        : base(input) { }

        public string ReadBytesToString(int count)
        {
            var convert = BitConverter.ToString(ReadBytes(count));
            return convert.Replace("-", "");
        }

        public string ReadGuid() => Read<Guid>().ToString();

        public float ReadSingle() => Read<float>();

        public short ReadInt16() => Read<short>();

        public short ReadInt8() => Read<byte>();

        public int ReadInt32() => Read<int>();

        public long ReadInt64() => Read<long>();

        public uint ReadUInt32() => Read<uint>();

        public double ReadDouble() => Read<double>();

        public Dictionary<string, UProperty> ReadProperties()
        {
            var properties = new Dictionary<string, UProperty>();

            while (true)
            {
                string settingName = ReadFString();

                if (settingName == "None")
                {
                    return properties;
                }

                var type = ReadFString();
                var uProperty = UnrealTypes.GetPropertyByName(type);
                uProperty.Deserialize(this);
                properties.Add(settingName, uProperty);
            }
        }
    }
}
