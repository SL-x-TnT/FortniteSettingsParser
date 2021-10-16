namespace FortniteSettingsParser.Property
{
    public class FBoolProperty : UProperty
    {
        protected internal override void PreDeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.Read<bool>());

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if(Value == null)
            {
                Value = reader.Read<bool>();
            }
        }
    }
}
