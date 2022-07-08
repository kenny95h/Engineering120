using System.Diagnostics;
using System.Text;

namespace MoreDataTypesApp
{
    public enum Pokemon
    {
        FIRE, WATER, ELEC, GRASS
    }
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

            //ParsingStrings();

            #endregion

            #region Arrays
            ////1D arrays
            //string[] arrayOfString = { "hello", "world" };
            //char[] arrayOfChar = { 'a', 'b', 'c' };
            //int[] arrayOfInts = new int[10];

            ////2D arrays
            //int[,] grid = new int[2, 4];
            //grid[0, 1] = 6;
            //grid[1, 3] = 8;

            //foreach(var element in grid)
            //{
            //    Console.WriteLine(grid);
            //}

            //string[,] chessBoard = { { "pawn", "king"},
            //    { "blank", "knight"},
            //    { "enemy queen", "enemy pawn"} };

            //int lower1D = chessBoard.GetLowerBound(0);
            //int lower2D = chessBoard.GetLowerBound(1);
            //int upper1D = chessBoard.GetUpperBound(0);
            //int upper2D = chessBoard.GetUpperBound(1);

            //string theBoard = "";
            //for (int i = lower1D; i <= upper1D; i++)
            //{
            //    for (int j = lower2D; j <= upper2D; j++)
            //    {
            //        theBoard += $"{chessBoard[i, j]} is at {i} and {j}\n";
            //    }
            //}
            //Console.WriteLine(theBoard);
            #endregion

            //Jagged arrays
            //int[][] jaggedIntArray = new int[2][];
            //jaggedIntArray[0] = new int[4];
            //jaggedIntArray[1] = new int[2];

            //jaggedIntArray[1][1] = 666;

            //jaggedIntArray[0] = new int[] { 1, 1, 1, 1 };

            //foreach (int[] innerArray in jaggedIntArray)
            //{
            //    foreach (int value in innerArray)
            //    {
            //        Console.WriteLine(value);
            //    }
            //}

            #region DateTime

            //var now = DateTime.Now;
            //Console.WriteLine(now);

            //var tomorrow = now.AddDays(1);
            //Console.WriteLine(tomorrow);

            //var myBirth = new DateOnly(1995, 06, 02);

            //var now2 = DateOnly.FromDateTime(now);

            //var stopwatch = new Stopwatch();
            //stopwatch.Start();
            //int total = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    total += i;
            //}
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.Elapsed);
            #endregion

            #region Enums

            Pokemon type = Pokemon.FIRE;

            if (type == Pokemon.WATER) Console.WriteLine("Water is the type");
            else if (type == Pokemon.FIRE) Console.WriteLine("Fire is the type");

            switch(type)
            {
                case Pokemon.ELEC:
                    Console.WriteLine("Electric is the type");
                    break;
                case Pokemon.GRASS:
                    Console.WriteLine("Grass is the type");
                    break;
                case Pokemon.FIRE:
                    Console.WriteLine($"Beats {Pokemon.GRASS}");
                    break;
                default:
                    Console.WriteLine("No type");
                    break;
            }

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
            Console.WriteLine(numOfCars);
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