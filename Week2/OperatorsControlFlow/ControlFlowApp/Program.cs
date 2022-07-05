namespace ControlFlowApp
{
    public class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(Grade(90));
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