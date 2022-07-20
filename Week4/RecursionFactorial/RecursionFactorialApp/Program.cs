namespace RecursionFactorialApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecFactorial(0));
        }

        public static int RecFactorial(int num)
        {
            if (num <= 1) return 1;
            int prev = RecFactorial(num - 1);
            int factorial = num * prev;
            return factorial;
        }
    }
}