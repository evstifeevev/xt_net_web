using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.RegularExpressions 
{ 
    public class RegularExpressionPatters
    {
        // Date of form dd-mm - yyyy
        public static string DateExistance = @"((((0[1-9])|([1-2]\d)|(3[0-1]))-(0(1|3|5|7|8)|(10)|(12)))|" +
            @"(((0[1-9])|([1-2]\d))-(02))|(((0[1-9])|([1-2]\d)|(30))-(0(4|6|9|11))))-(\d{4})";
        //public static string HtmlReplacer = @"(<(\/)*(\w|\s|\""|=){1,}>)";
        public static string HtmlReplacer = @"(<\/*(\w|\s|\""|=)+>)";
        public static string EmailFinder = @"[\da-zA-Z]{1}(\w|\.|-)*@(\w{2,6})(\.\w+)?(\.\w*([\da-zA-Z]){1})";
        public static string CommonRealNumberValidator = @"^-?\d+((\.)?\d+)?$";
        public static string ScientificRealNumberValidator = @"^-?\d+((\.)?\d+)?e-?\d+((\.)?\d+)?$";
        public static string TimeCounter = @"(\b0?\d|(1\d)|(2[0-3])):([0-5]\d\b)";
    }
}
