## Usage
```cs
namespace Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var settings = await SettingsParser.GetClientSettingsAsync("ClientSettings.Sav");
        }
    }
}
```

## Credits
* [SharpZipLib](https://github.com/icsharpcode/SharpZipLib) - #ziplib is a library written entirely in C# for the .NET platform.
* [GenericReader](https://github.com/NotOfficer/GenericReader) - A generic binary reader for .NET