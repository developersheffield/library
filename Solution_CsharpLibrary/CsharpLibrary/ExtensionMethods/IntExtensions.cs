﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLibrary.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsOdd(this int integer)
        {
            return integer % 2 == 1;
        }

        public static bool IsEven(this int integer)
        {
            return integer % 2 == 0;
        }

        public static string Ordinal(this int integer)
        {
            // Less than 1 has no ordinal
            if (integer < 1)
                return string.Empty;

            // Check if last 2 digits are 11, 12 or 13
            switch (integer % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }

            // Check the last digit
            switch (integer % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

        public static string ToRomanNumerals(this int integer)
        {
            var result = new StringBuilder();
            var romanNumeralsMap = new SortedDictionary<int, string>
                               {
                                   { 1, "I" },
                                   { 4, "IV" },
                                   { 5, "V" },
                                   { 9, "IX" },
                                   { 10, "X" },
                                   { 40, "XL" },
                                   { 50, "L" },
                                   { 90, "XC" },
                                   { 100, "C" },
                                   { 400, "CD" },
                                   { 500, "D" },
                                   { 900, "CM" },
                                   { 1000, "M" },
                               };

            foreach (var mapping in romanNumeralsMap.Reverse())
            {
                while (integer >= mapping.Key)
                {
                    integer -= mapping.Key;
                    result.Append(mapping.Value);
                }
            }

            return result.ToString();
        }

        public static int Negate(this int integer)
        {
            return integer * -1;
        }
    }
}
