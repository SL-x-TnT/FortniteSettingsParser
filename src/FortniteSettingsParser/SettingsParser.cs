using System;
using System.IO;
using System.Threading.Tasks;

using FortniteSettingsParser.Object;

using GenericReader;

using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace FortniteSettingsParser
{
    public sealed class SettingsParser
    { 
        private static UnrealBinaryReader _binaryReader;

        private const uint ClientSettingsMagic = 0x44464345;

        public static async Task<FortniteSettings> GetClientSettingsAsync(string fileName)
        {
            var stream = new FileStream(fileName, FileMode.Open);
            _binaryReader = new UnrealBinaryReader(stream);
            await Decompress();
            return new FortniteSettings(_binaryReader);
        }

        public static async Task<FortniteSettings> GetClientSettingsAsync(Stream stream)
        {
            _binaryReader = new UnrealBinaryReader(stream);
            await Decompress();
            return new FortniteSettings(_binaryReader);
        }

        private static async Task Decompress()
        {
            var magic = _binaryReader.Read<uint>();
            
            if (!magic.Equals(ClientSettingsMagic)) throw new NotImplementedException("Invalid settings file.");
            _binaryReader.Seek(4, SeekOrigin.Current); //63001 unknown?

            var isCompressed = _binaryReader.ReadInt32() == 1;
            if (!isCompressed) throw new NotImplementedException("File is not compressed");

            var size = _binaryReader.Read<int>();
            await DecompressData(_binaryReader.ReadBytes(_binaryReader.Size - (int)_binaryReader.Position), size);
        }

        private static async Task DecompressData(byte[] data, int length)
        {
            var decompressedStream = new MemoryStream(length);
            
            using var compressedStream = new MemoryStream(data);
            using var inflaterStream = new InflaterInputStream(compressedStream);
            
            await inflaterStream.CopyToAsync(decompressedStream);
            decompressedStream.Seek(0, SeekOrigin.Begin);

            _binaryReader = new UnrealBinaryReader(decompressedStream);
        }
    }
}
