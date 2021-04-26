using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FVector3D : UStruct
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        protected internal override void DeserializeProperty(UnrealBinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();

            Value = $"X: {X}, Y: {Y}, Z: {Z}";
        }
    }
}
