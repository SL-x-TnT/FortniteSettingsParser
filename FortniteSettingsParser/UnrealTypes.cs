using FortniteSettingsParser.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSettingsParser
{
    public class UnrealTypes
    {
		public static Dictionary<string, Func<UProperty>> Types = new Dictionary<string, Func<UProperty>>
		{
			{ "FloatProperty", () => new FFloatProperty() },
			{ "NameProperty", () => new FNameProperty() },
			{ "StrProperty", () => new FStringProperty() },
			{ "EnumProperty", () => new FEnumProperty() },
			{ "TextProperty", () => new FTextProperty() },
			{ "BoolProperty", () => new FBoolProperty() },
			{ "StructProperty", () => new FStructProperty() },
			{ "MapProperty", () => new FMapProperty() },
			{ "ArrayProperty", () => new FArrayProperty() },
			{ "IntProperty", () => new FIntProperty() },
			{ "ByteProperty", () => new FByteProperty() },
		};
    }
}
