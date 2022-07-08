using System;
using System.Text;

namespace MoreTypes_Lib
{
    public class StringExercises
    {
        // manipulates and returns a string - see the unit test for requirements
        public static string ManipulateString(string input, int num)
        {
            input = input.Trim().ToUpper();
            StringBuilder sb = new StringBuilder(input);
            for (int i = 0; i < num; i++)
            {
                sb.Append(i);
            }
            return sb.ToString();
        }

        // returns a formatted address string given its components
        public static string Address(int number, string street, string city, string postcode)
        {
            return $"{number} {street}, {city} {postcode}."; 
        }
        // returns a string representing a test score, written as percentage to 1 decimal place
        public static string Scorer(int score, int outOf)
        {
            return $"You got {score} out of {outOf}: {((double)score / outOf):P1}";
        }

        // returns the double represented by the string, or -999 if conversion is not possible
        public static double ParseNum(string numString)
        {
            var output = double.TryParse(numString, out double pass);
            return output ? pass : -999;
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        public static string CountLetters(string input)
        {
            int a = input.Split('A').Length - 1, b = input.Split('B').Length - 1, c = input.Split('C').Length - 1, d = input.Split('D').Length - 1;
            //foreach (char i in input)
            //{
            //    if (i == 'A')
            //    {
            //        a++;
            //    }
            //    else if (i == 'B')
            //    {
            //        b++;
            //    }
            //    else if (i == 'C')
            //    {
            //        c++;
            //    }
            //    else if (i == 'D')
            //    {
            //        d++;
            //    }
            //}
            return $"A:{a} B:{b} C:{c} D:{d}";
        }
    }
}
