using System.Text;

namespace FizzBuzzApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FizzBuzz(1));
        }

        public static string FizzBuzz(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException("Input must be over 0");
            StringBuilder fBString = new StringBuilder();
            for (int i = 1; i <= n; i++)
                if (i % 3 == 0 && i % 5 == 0)
                    fBString.Append("FizzBuzz ");
                else if (i % 3 == 0)
                    fBString.Append("Fizz ");
                else if(i % 5 == 0)
                    fBString.Append("Buzz ");
                else
                    fBString.Append(i + " ");
            return fBString.ToString().TrimEnd();

        }
    }
}