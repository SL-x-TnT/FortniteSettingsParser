using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Properties
{
    public class FVector2D : UStruct
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        protected override void DeserializeProperty(UnrealBinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();

            Value = $"X: {X}, Y: {Y}";
        }
    }
}
