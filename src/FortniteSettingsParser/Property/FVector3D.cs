namespace FortniteSettingsParser.Property
{
    public class FVector3D : UStruct
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if (reader.Header.Major >= 22)
            {
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
            }
            else
            {
                X = reader.ReadSingle();
                Y = reader.ReadSingle();
                Z = reader.ReadSingle();
            }

            Value = $"X: {X}, Y: {Y}, Z: {Z}";
        }
    }
}
