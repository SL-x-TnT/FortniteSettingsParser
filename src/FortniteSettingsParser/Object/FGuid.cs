using System.Runtime.InteropServices;

namespace FortniteSettingsParser.Object
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct FGuid
    {

        public readonly uint A;
        public readonly uint B;
        public readonly uint C;
        public readonly uint D;

        public override string ToString()
            => $"{A:X8}-{B:X8}-{C:X8}-{D:X8}";

    }
}
