namespace FortniteSettingsParser.Property
{
  public class FGameplayTagContainer : UStruct
  {
    protected internal override void DeserializeProperty(UnrealBinaryReader reader)
    {
      int count = reader.ReadInt32();

      Value = new string[count];

      for (int i = 0; i < count; i++)
      {
        ((string[])Value)[i] = reader.ReadFString();
      }
    }
  }
}
