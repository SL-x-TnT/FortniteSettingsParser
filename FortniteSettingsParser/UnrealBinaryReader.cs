﻿using System;
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
                length = -2 * length;
                data = ReadBytes(length);
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
    }
}
