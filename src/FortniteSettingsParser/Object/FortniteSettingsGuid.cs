using System;

namespace FortniteSettingsParser.Object
{
    public class FortniteSettingsGuid
    {

        public Guid Guid { get; set; }

        public int Value { get; set; }

        public FortniteSettingsGuid(string guid, int value)
        {
            Guid = Guid.Parse(guid);
            Value = value;
        }
    }
}
