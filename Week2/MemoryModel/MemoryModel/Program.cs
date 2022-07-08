using System;

namespace MemoryModel
{
    class Program
    {
        static void Main(string[] args)
        {


            int dan = 4;
            string tom = "Tom";
            int[] david = { 6, 7, 2 };
            for (var jon = 0; jon < david.Length; jon++)
            { Console.WriteLine(david[jon]); }
            double kai = 3.14159;
            var muhammad = dan;
            dan++;
            string[] dylan = { "cat", "dog" };
            {
                var laba = david;
                laba[2] = 42;
                string[] kenny = { "perch", "cod", "eel" };
                dylan = kenny;
                dylan[1] = "bass";
                var ned = tom;
                tom = kenny[0];
            }
            kai = david[2];
        }


    }
}
