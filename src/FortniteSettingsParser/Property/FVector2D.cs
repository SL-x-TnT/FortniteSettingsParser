namespace FortniteSettingsParser.Property
{
    public class FVector2D : UStruct
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if (reader.Header.Major >= 22)
            {
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
            }
            else
            {
                X = reader.ReadSingle();
                Y = reader.ReadSingle();
            }

            Value = $"X: {X}, Y: {Y}";
        }
    }
}
