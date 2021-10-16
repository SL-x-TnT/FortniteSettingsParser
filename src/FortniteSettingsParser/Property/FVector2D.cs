namespace FortniteSettingsParser.Property
{
    public class FVector2D : UStruct
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();

            Value = $"X: {X}, Y: {Y}";
        }
    }
}
