using System;
using System.Text.RegularExpressions;

namespace Blip.Common.Formatting
{
    public static class Phones
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");
        public static string CleanPhone(string phone)
        {
            if (!String.IsNullOrEmpty(phone))
            {
                return digitsOnly.Replace(phone, "");
            }
            else
            {
                return null;
            }
        }

        public static string FormatPhone(string phone)
        {
            if (!String.IsNullOrEmpty(phone))
            {
                Int64 phoneDigits;
                if (Int64.TryParse(phone, out phoneDigits))
                    return String.Format("{0:(###) ###-####}", phoneDigits);
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
    }
}