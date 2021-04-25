using FortniteSettingsParser.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser
{
    public class UnrealBinaryReader : BinaryReader
    {
        public UnrealBinaryReader(string file) : base(File.OpenRead(file))
        {

        }

        public UnrealBinaryReader(Stream input) : base(input)
        {
        }

        public string ReadFString()
        {
            int length = ReadInt32();

            if (length == 0)
            {
                return "";
            }

            bool isUnicode = length < 0;
            byte[] data;
            string value;

            if (isUnicode)
            {
                data = ReadBytes(-length);
                value = Encoding.Unicode.GetString(data);
            }
            else
            {
                data = ReadBytes(length);
                value = Encoding.Default.GetString(data);
            }

            return value.Trim(new[] { ' ', '\0' });
        }

        public string ReadBytesToString(int count)
        {
            return BitConverter.ToString(ReadBytes(count)).Replace("-", "");
        }

        public string ReadGuid()
        {
            return ReadBytesToString(16);
        }

        public Dictionary<string, UProperty> ReadProperties()
        {
            Dictionary<string, UProperty> properties = new Dictionary<string, UProperty>();

            while (true)
            {
                string settingName = ReadFString();

                if (settingName == "None")
                {
                    return properties;
                }

                string type = ReadFString();
                UProperty uProperty = UnrealTypes.GetPropertyByName(type);

                uProperty.Deserialize(this);

                properties.Add(settingName, uProperty);
            }
        }
    }
}
