namespace FortniteSettingsParser.Property
{
    public abstract class UProperty
    {
        public string TypeName { get; internal set; }
        public virtual object Value { get; protected set; }
        protected int Size { get; set; }
        protected internal int ArrayIndex { get; set; }
        protected bool HasPropertyGuid { get; set; }
        protected string Guid { get; set; }
        
        public virtual void Deserialize(UnrealBinaryReader reader)
        {
            DeserializeTypeInfo(reader);
            DeserializeProperty(reader);
        }

        protected internal virtual void PreDeserializeProperty(UnrealBinaryReader reader)
        { }

        protected internal virtual void DeserializeTypeInfo(UnrealBinaryReader reader)
        {
            Size = reader.ReadInt32();
            ArrayIndex = reader.ReadInt32();

            PreDeserializeProperty(reader);

            HasPropertyGuid = reader.Read<bool>();

            if (HasPropertyGuid)
            {
                Guid = reader.ReadGuid();
            }
        }

        protected internal virtual void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadBytes(Size);
        }
    }
}
