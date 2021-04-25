using FortniteSettingsParser.Properties;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser
{
    public class SettingsParser
    {
        private readonly string _fileName;

        public SettingsParser(string filename)
        {
            _fileName = filename;
        }

        public FortniteSettings ReadSettings()
        {
            FortniteSettings settings = new FortniteSettings();

            using UnrealBinaryReader decompressedStream = Decompress();

#if DEBUG
            File.WriteAllBytes("decompressed.dat", decompressedStream.ReadBytes((int)decompressedStream.BaseStream.Length));

            decompressedStream.BaseStream.Seek(0, SeekOrigin.Begin);
#endif
            settings.Header = ParseSettingsHeader(decompressedStream);

            settings.GuidData = ParseGuidData(decompressedStream);
            settings.Settings = decompressedStream.ReadProperties();

            return settings;
        }

        private UnrealBinaryReader Decompress()
        {
            using BinaryReader reader = new BinaryReader(File.OpenRead(_fileName));

            int magicNumber = reader.ReadInt32();

            if (magicNumber != 1145455429) //ECFD
            {
                throw new InvalidDataException("Invalid settings file");
            }

            reader.ReadInt32(); //Unknown, but constant

            bool compressed = reader.ReadInt32() == 1; //?

            if (compressed)
            {
                int size = reader.ReadInt32();

                MemoryStream decompressedData = DecompressData(reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)), size);

                return new UnrealBinaryReader(decompressedData);
            }

            throw new NotImplementedException("Uncompressed(?) files not supported");
        }

        private SettingsHeader ParseSettingsHeader(UnrealBinaryReader reader)
        {
            SettingsHeader header = new SettingsHeader
            {
                Unknown1 = reader.ReadBytes(18),
                Branch = reader.ReadFString(),
                Unknown2 = reader.ReadInt32(),
                Unknown3 = reader.ReadByte(),
                Unknown4 = reader.ReadByte()
            };

            return header;
        }

        private List<GuidData> ParseGuidData(UnrealBinaryReader reader)
        {
            int length = reader.ReadInt32();

            List<GuidData> data = new List<GuidData>(length);

            for (int i = 0; i < length; i++)
            {
                data.Add(new GuidData
                {
                    Guid = reader.ReadGuid(),
                    Value = reader.ReadInt32()
                });
            }

            return data;
        }


        private MemoryStream DecompressData(byte[] data, int length)
        {
            MemoryStream decompressedStream = new MemoryStream(length);

            using MemoryStream memory = new MemoryStream(data);
            using InflaterInputStream inflater = new InflaterInputStream(memory);

            inflater.CopyTo(decompressedStream);
            decompressedStream.Seek(0, SeekOrigin.Begin);

            return decompressedStream;
        }
    }
}
