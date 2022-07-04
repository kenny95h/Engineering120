using System;

namespace CodeToTest;

public class Program
{
    static void Main(string[] args)
    {
        int timeOfDay = 21;
        string greet = Greeting(timeOfDay);
        Console.WriteLine(greet);
    }

    public static string Greeting(int timeOfDay)
    {
        string greeting;

        if (timeOfDay >= 5 && timeOfDay <= 12)
        {
            greeting = "Good morning!";
        }
        else if (timeOfDay >= 12 && timeOfDay <= 18)
        {
            greeting = "Good afternoon!";
        }
        else
        {
            greeting = "Good evening!";
        }
        return greeting;
    }
}
