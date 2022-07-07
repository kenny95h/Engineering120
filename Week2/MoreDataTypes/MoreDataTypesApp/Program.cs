using System.Text;

namespace MoreDataTypesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region strings
            //string message = "I like donuts";
            //message = message.Insert(message.Length, " Actually, I like pie");

            //message = message + ". Give me more pie.";


            //string message2 = ". Sorry, too much pie";

            //string completeMessage = String.Concat(message + message2);
            //Console.WriteLine(completeMessage);
            #endregion

            //Console.WriteLine(StringBuilderExercise(" C# list fundamentals "));

            //StringBuilder sb = new StringBuilder("Hello World");

            #region String Interpolation

            //string a = "A";
            //string b = "B";
            //string aAndB = a + b;
            //Console.WriteLine(aAndB);
            //aAndB = String.Concat(a, b);
            //Console.WriteLine(aAndB);

            //string[] arrayOfString = { "hello", "world" };
            //char[] arrayOfChar = { 'a', 'b', 'c' };

            //Console.WriteLine(String.Concat(arrayOfString));
            //Console.WriteLine(String.Concat(arrayOfChar));
            //Console.WriteLine($"Your blood type is: {a} {b}.\nA blood donation will cost: {100:C}");

            #endregion

            #region String Parsing

            ParsingStrings();

            #endregion

        }

        public static void ParsingStrings()
        {
            Console.WriteLine("How many cars do you own?");
            string input = Console.ReadLine();
            //int numOfCars = int.Parse(input);
            //try
            //{
            //    string input = Console.ReadLine();
            //    int numOfCars = int.Parse(input);
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("Must enter an integer");
            //}


            var success = int.TryParse(input, out int numOfCars);
        }
        public static string StringExercise(string myString)
        {
            return myString.Trim().ToUpper().Replace('L','*').Replace('T','*').Remove(myString.IndexOf('n'));
        }

        public static string StringBuilderExercise(string myString)
        {
            string upperTrimString = myString.Trim().ToUpper().Remove(myString.IndexOf('n'));

            StringBuilder sb = new StringBuilder(upperTrimString);
            sb.Replace('L', '*').Replace('T', '*');

            return sb.ToString();
        }
    }
}