namespace FortniteSettingsParser.Property
{
    public class FBoolProperty : UProperty
    {
        protected internal override void PreDeserializeProperty(UnrealBinaryReader reader)
            => Value = reader.ReadBoolean();

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            if(Value == null)
            {
                Value = reader.ReadBoolean();
            }
        }
    }
}
