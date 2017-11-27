﻿
using System.Collections.Generic;

namespace Kartverket.GmlSampleGenerator.Models.Translations
{
    public class Culture
    {
        public const string EnglishCode = "en";
        public const string EnglishName = "Engelsk";

        public const string NorwegianCode = "no";
        public const string NorwegianName = "Norsk";

        public static readonly Dictionary<string, string> Languages = new Dictionary<string, string>()
        {
            {EnglishCode, EnglishName}
        };
    }
}