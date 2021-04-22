﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public abstract class UProperty
    {
        public string TypeName { get; internal set; }
        public virtual object Value { get; protected set; }
        public int Size { get; protected set; }
        public int ArrayIndex { get; protected internal set; }
        public bool HasPropertyGuid { get; protected set; }
        public string Guid { get; protected set; }
        
        public virtual void Deserialize(UnrealBinaryReader reader)
        {
            DeserializeTypeInfo(reader);
            DeserializeProperty(reader);
        }

        protected abstract void PreDeserializeProperty(UnrealBinaryReader reader);

        protected internal virtual void DeserializeTypeInfo(UnrealBinaryReader reader)
        {
            Size = reader.ReadInt32();
            ArrayIndex = reader.ReadInt32();

            PreDeserializeProperty(reader);

            HasPropertyGuid = reader.ReadBoolean();

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