using System.Text;

namespace FizzBuzzApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add("-1,-2"));
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
                else if (i % 5 == 0)
                    fBString.Append("Buzz ");
                else
                    fBString.Append(i + " ");
            return fBString.ToString().TrimEnd();

        }

        public static int Add(string numbers)
        {
            List<char> splitList = new List<char> { ',', '\n' };
            if (numbers == "") return 0;
            else if (numbers.StartsWith("//"))
            {
                splitList.Add(numbers.ElementAt(2));
                numbers.Remove(0, numbers.IndexOf("\n"));
            }
            string[] numsArray = numbers.Split(splitList.ToArray());
            int total = 0;
            List<int> negative = new List<int>();
            foreach (var i in numsArray)
            {
                var success = int.TryParse(i, out var nums);
                if (nums < 0) negative.Add(nums);
                if (nums > 1000) nums = 0;
                total += nums;
                
            }
            string neg = "";
            if (negative.Count > 0)
            {
                foreach (int i in negative)
                {
                    neg += $" {i}";
                }
                throw new ArgumentException($"negatives not allowed{neg}");
            }
            return total;
        }
    }
}