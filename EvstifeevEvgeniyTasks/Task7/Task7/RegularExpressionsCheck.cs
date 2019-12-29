using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Task7.RegularExpressions;

namespace Task7
{
    class RegularExpressionsCheck
    {
        internal bool IsDate(string line)
        {
            Regex regex = new Regex(RegularExpressionPatters.DateExistance);
            return regex.IsMatch(line);
        }
        internal string RemoveHtmlTags(string line)
        {
            Regex regex = new Regex(RegularExpressionPatters.HtmlReplacer);
            return regex.Replace(line,"_");
        }
        internal MatchCollection GetEmails(string line)
        {
            Regex regex = new Regex(RegularExpressionPatters.EmailFinder);
            return regex.Matches(line);
        }
        internal bool IsCommonRealNumber(string line)
        {
            return new Regex(RegularExpressionPatters.CommonRealNumberValidator).IsMatch(line);
        }
        internal bool IsScientificRealNumber(string line)
        {
            return new Regex(RegularExpressionPatters.ScientificRealNumberValidator).IsMatch(line);
        }
        internal int TimeCount(string line)
        {
            Regex regex = new Regex(RegularExpressionPatters.TimeCounter);
            return regex.Matches(line).Count;
        }
    }
}
