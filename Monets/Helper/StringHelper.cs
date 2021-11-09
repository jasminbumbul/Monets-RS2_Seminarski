using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Helper
{
    public class StringHelper
    {
        public static string FirstLetterToUpperCase(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
