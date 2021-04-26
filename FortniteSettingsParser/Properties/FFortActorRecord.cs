using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FFortActorRecord : UStruct
    {
        public byte Unknown { get; private set; }
        public string ActorPath { get; private set; }
        public FQuat Unknown4 { get; private set; } = new FQuat();
        public FVector3D Location { get; private set; } = new FVector3D();
        public FVector3D Scale { get; private set; } = new FVector3D();
        public int Unknown5 { get; private set; }

        public int PropertyByteSize { get; private set; }
        public Dictionary<string, UProperty> Properties { get; private set; }

        private byte[] UnknownExtraBytes;

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadGuid();
            Unknown = reader.ReadByte();
            ActorPath = reader.ReadFString();

            Unknown4.DeserializeProperty(reader);
            Location.DeserializeProperty(reader);
            Scale.DeserializeProperty(reader);

            Unknown5 = reader.ReadInt32();
            PropertyByteSize = reader.ReadInt32();

            long currentPosition = reader.BaseStream.Position;

            if(PropertyByteSize > 0)
            {
                Properties = reader.ReadProperties();
                reader.ReadInt32(); //?
            }

            long remainingBytes = PropertyByteSize - (reader.BaseStream.Position - currentPosition);

            if(remainingBytes > 0)
            {
                UnknownExtraBytes = reader.ReadBytes((int)remainingBytes);
            }
        }
    }
}
