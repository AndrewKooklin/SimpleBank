using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleBank.Help
{
    public class CheckParse
    {
        public CheckParse()
        {
        }

        public bool CheckParsePhone(string text)
        {
            text = text.Trim();
            Regex regex = new Regex(@"^\d{11}$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            return false;
        }

        public bool CheckParsePassportNumber(string text)
        {
            text = text.Trim();

            Regex regex = new Regex(@"^\d{6}$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            return false;
        }
    }
}
