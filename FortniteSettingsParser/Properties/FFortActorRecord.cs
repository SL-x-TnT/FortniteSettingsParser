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
        public byte[] Unknown3 { get; private set; }
        public Dictionary<string, UProperty> Properties { get; private set; }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            Value = reader.ReadGuid();
            Unknown = reader.ReadByte();
            ActorPath = reader.ReadFString();
            Unknown3 = reader.ReadBytes(48);

            if(ActorPath != "None")
            {
                Properties = reader.ReadProperties();
                reader.ReadInt32(); //?
            }
        }
    }
}
