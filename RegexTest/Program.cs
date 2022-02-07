using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "12,1+0,23";
            string dbl_mask = @"\d*(,\d*)?";

            Regex dblRGX = new Regex(dbl_mask);

            //Regex num1vld = new Regex("^" + dbl_mask + "$");

            //string msgBody = null;
            //foreach (Match match in dblRGX.Matches(input))
            //    msgBody += match + "\n";
            //MessageBox.Show(msgBody);

            //MessageBox.Show(dblRGX.Matches(input)[0].Value);

            string Op = input;
            //Op = Op.Replace(dblRGX.Matches(input)[0].Value, null);
            //Op = Op.Replace(dblRGX.Matches(input)[1].Value, null);
            
            string NumA = dblRGX.Matches(input)[0].Value;
            //string NumB = dblRGX.Matches(input)[1].Value;
            Op = Op.Replace(NumA, null);
            Op = Op.Substring(0, 1);
            MessageBox.Show(Op,"Op:");
        }
    }
}
