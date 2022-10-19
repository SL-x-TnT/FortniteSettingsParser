namespace FortniteSettingsParser.Property
{
    public class FQuat : UStruct
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double W { get; private set; }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if (reader.Header.Major >= 22)
            {
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
                W = reader.ReadDouble();
            }
            else
            {
                X = reader.ReadSingle();
                Y = reader.ReadSingle();
                Z = reader.ReadSingle();
                W = reader.ReadSingle();
            }

            Value = $"X: {X}, Y: {Y}, Z: {Z}, W: {W}";
        }
    }
}
