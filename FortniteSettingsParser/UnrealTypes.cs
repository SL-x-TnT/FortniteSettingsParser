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
		private static Dictionary<string, Func<UProperty>> _types = new Dictionary<string, Func<UProperty>>
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
			{ "SetProperty", () => new FSetProperty() },
			{ "IntProperty", () => new FIntProperty() },
			{ "UInt32Property", () => new FUInt32Property() },
			{ "ByteProperty", () => new FByteProperty() },
			{ "Vector2D", () => new FVector2D() },
			{ "DateTime", () => new FDateTime() },
			{ "Guid", () => new FGuid() }
		};

		public static bool HasPropertyName(string name)
        {
			return _types.ContainsKey(name);
        }

		public static UProperty GetPropertyByName(string name)
        {
			UProperty uProperty = null;

			if (!_types.TryGetValue(name, out Func<UProperty> propertyFunc))
			{
				throw new NotImplementedException($"Type {name} currently not implemented");
			}
			else
			{
				uProperty = propertyFunc();
			}

			uProperty.TypeName = name;

			return uProperty;
		}
	}
}
