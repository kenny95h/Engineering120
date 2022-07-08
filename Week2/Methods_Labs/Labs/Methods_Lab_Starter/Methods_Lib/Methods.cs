using System;

namespace Methods_Lib
{
    public class Methods
    {
        // implement this method so it returns a tuple (weeks, days) 
        // corresponding to a given number of days
        public static (int weeks, int days) DaysAndWeeks(int totalDays)
        {
            if (totalDays < 0)
                throw new ArgumentOutOfRangeException("totalDays must not be negative");
            return (totalDays / 7, totalDays % 7);
            
        }

        public static (int square, int cube, double root) PowersRoot(int num)
        {
            checked
            {
                return ((int)Math.Pow(num, 2), (int)Math.Pow(num, 3), Math.Round(Math.Sqrt(num), 2));
            }
        }

        public static int RollDice(Random rng)
        {
            var num1 = rng.Next(1, 7);
            var num2 = rng.Next(1, 7);
            return num1 + num2;
        }

    }
}
