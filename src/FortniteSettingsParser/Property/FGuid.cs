namespace FortniteSettingsParser.Property
{ 
    public class FGuid : UStruct
    {
        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadGuid();
    }
}
