namespace ControlFlowApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 10, 6, 22, -17, 3 };
            Console.WriteLine("Highest foreach loop: " + LoopTypes.HighestForEachLoop(nums));
            Console.WriteLine("Highest for- loop: " + LoopTypes.HighestForLoop(nums));
            Console.WriteLine("Highest while- loop: " + LoopTypes.HighestWhileLoop(nums));
            Console.WriteLine("Highest do-while loop: " + LoopTypes.HighestDoWhileLoop(nums));
            Console.WriteLine("Lowest foreach loop: " + LoopTypes.LowestForEachLoop(nums));
            Console.WriteLine("Lowest for- loop: " + LoopTypes.LowestForLoop(nums));
            Console.WriteLine("Lowest while- loop: " + LoopTypes.LowestWhileLoop(nums));
            Console.WriteLine("Lowest do-while loop: " + LoopTypes.LowestDoWhileLoop(nums));
            Console.WriteLine(int.MaxValue);
        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark > 100)
            {
                throw new ArgumentOutOfRangeException("Must be between 0 and 100 inclusive");
            }
            return mark >= 85 ? "Distinction"
                : mark >= 65 ? "Pass"
                : mark < 20 ? "Failed no retake"
                : "Failed with retake";
        }
    }
}