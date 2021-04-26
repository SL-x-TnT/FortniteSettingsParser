using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FFortActorRecord : UStruct
    {
        public EFortBuildingPersistentState ActorState { get; private set; }
        public string ActorPath { get; private set; }
        public FQuat Rotation { get; private set; } = new FQuat();
        public FVector3D Location { get; private set; } = new FVector3D();
        public FVector3D Scale { get; private set; } = new FVector3D();
        public bool SpawnedActor { get; private set; }

        public int PropertyByteSize { get; private set; }
        public Dictionary<string, UProperty> ActorData { get; private set; }

        private byte[] UnknownExtraBytes;

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadGuid();
            ActorState = (EFortBuildingPersistentState)reader.ReadByte();
            ActorPath = reader.ReadFString();

            Rotation.DeserializeProperty(reader);
            Location.DeserializeProperty(reader);
            Scale.DeserializeProperty(reader);

            SpawnedActor = reader.ReadInt32() == 1;

            PropertyByteSize = reader.ReadInt32();

            long currentPosition = reader.BaseStream.Position;

            if(PropertyByteSize > 0)
            {
                ActorData = reader.ReadProperties();
                reader.ReadInt32(); //?
            }

            long remainingBytes = PropertyByteSize - (reader.BaseStream.Position - currentPosition);

            if(remainingBytes > 0)
            {
                UnknownExtraBytes = reader.ReadBytes((int)remainingBytes);
            }
        }
    }
    public enum EFortBuildingPersistentState
    {
        Default,
        New,
        Constructed,
        Destroyed,
        Searched,
        None,
        EFortBuildingPersistentState_MAX,
    };
}
