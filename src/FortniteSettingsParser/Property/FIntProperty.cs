namespace FortniteSettingsParser.Property
{
    public class FIntProperty : UProperty
    {
        
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadInt32();
        }

    }
}
