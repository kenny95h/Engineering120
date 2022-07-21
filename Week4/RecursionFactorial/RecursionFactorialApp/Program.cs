namespace RecursionFactorialApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecFactorial(12));
        }

        public static int RecFactorial(int num)
        {
            checked
            {
                if (num < 0) throw new ArgumentOutOfRangeException("Cannot be a negative number");
                if (num <= 1) return 1;
                int prev = RecFactorial(num - 1);
                int factorial = num * prev;
                return factorial;
            }
            
        }
    }
}