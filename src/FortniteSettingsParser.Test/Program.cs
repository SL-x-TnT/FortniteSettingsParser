using System;
using System.IO;
using System.Threading.Tasks;

namespace FortniteSettingsParser.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var settings = await SettingsParser.GetClientSettingsAsync("ClientSettings.Sav");

            Console.WriteLine();
        }
    }
}
