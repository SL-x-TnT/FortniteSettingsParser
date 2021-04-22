using FortniteSettingsParser;
using Newtonsoft.Json;
using System;

namespace SettingsParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsParser parser = new SettingsParser("fullSettings.sav");

            parser.ReadSettings();
        }
    }
}
