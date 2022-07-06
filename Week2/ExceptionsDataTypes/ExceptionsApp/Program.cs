
namespace ExceptionsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region indexOutOfBoundsException
            //var theBeatles = new string[] { "John", "Paul", "Ringo", "George" };
            //theBeatles[4] = "Yoko";
            #endregion

            #region fileNotFoundException
            //var text = File.ReadAllText("Wonderwall.txt");
            #endregion

            #region Handling Exceptions
            //string text;
            //string fileName = "Wonderwall.txt";
            //try
            //{
            //    text = File.ReadAllText(fileName);
            //    Console.WriteLine(text);
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine("Sorry cannot find: " + fileName);
            //}


            //try
            //{
            //    Console.WriteLine("Charlie received 88: " + Grade(88));
            //    Console.WriteLine("Tom received -100: " + Grade(-100));
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    Console.WriteLine(ex.Message);

            //}
            //finally
            //{
            //    Console.WriteLine("I will always execute");
            //}
            #endregion

            #region numerical types
            //int anInt = 3; //Explicitly typed
            //var vInt = 3; //Implicitly typed

            //decimal sum = 0;
            //for (int i = 0; i < 100_000; i++)
            //{
            //    sum += 2 / 5.0m;
            //}
            //Console.WriteLine("2/5 added 100,000 times: " + sum);
            //Console.WriteLine("2/5 multiplied by 100,000: " + 2/5.0f * 100_000);
            #endregion

            #region numerical casting
            //var result = 5.50 / 5;

            //int a = 3;
            //double b = a;

            //double c = 3.0;
            //int d = c;
            #endregion

            #region stack overflow
            //int max = int.MaxValue;
            //max++;

            //checked
            //{
            //    sbyte sNum = sbyte.MaxValue;
            //    Console.WriteLine("sbyte max: " + sNum);
            //    sNum += 1;
            //    Console.WriteLine(sNum);
            //}

            //int bankBalance = -2;
            //uint posBalance = (uint)bankBalance;
            //Console.WriteLine(Convert.ToString(bankBalance, 2));
            //Console.WriteLine(Convert.ToString(posBalance, 2));

            //char n = 'N';
            //int i = n;
            //Console.WriteLine(i);
            //Console.WriteLine(n);

            //var theInt = 5;
            //var anotherInt = Convert.ToChar(theInt);
            //Console.WriteLine(anotherInt);
            #endregion


        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark > 100)
            {
                throw new ArgumentOutOfRangeException("Mark needs to be between 0 and 100 inclusive.");
            }
            return mark >= 65 ? (mark >= 85 ? "Distinction" : "Pass") : "Fail";
        }
    }
}