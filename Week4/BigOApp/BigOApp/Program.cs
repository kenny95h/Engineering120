namespace BigOApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumLoop(100));
            Console.WriteLine(SumRecursive(100));
        }

        public static int SumLoop(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static int SumRecursive(int n)
        {
            if (n == 0) return 0;
            int prev = SumRecursive(n - 1);
            int sum = n + prev;
            return sum;

        }
    }
}