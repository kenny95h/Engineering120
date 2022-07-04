using System;

namespace CodeToTest;

public class Program
{
    static void Main(string[] args)
    {
        int timeOfDay = 10;
        string greet = Greeting(timeOfDay);
        Console.WriteLine(greet);
    }

    public static string Greeting(int timeOfDay)
    {
        string greeting;

        if (timeOfDay >= 5 && timeOfDay < 12)
        {
            greeting = "Good morning!";
        }
        else if (timeOfDay >= 12 && timeOfDay <= 18)
        {
            greeting = "Good afternoon!";
        }
        else if ((timeOfDay > 18 && timeOfDay < 24) || (timeOfDay >= 0 && timeOfDay < 5))
        {
            greeting = "Good evening!";
        }
        else
        {
            greeting = "Invalid time";
        }
        return greeting;
    }

    public static string AvailableClassifications(int ageOfViewer)
    {
        string result;
        if (ageOfViewer < 0)
        {
            throw new ArgumentOutOfRangeException("Must be a non-negative integer");
        }
        else if (ageOfViewer >= 0 && ageOfViewer < 12)
        {
            result = "U & PG films are available.";
        }
        else if (ageOfViewer < 15)
        {
            result = "U, PG & 12 films are available.";
        }
        else if (ageOfViewer < 18)
        {
            result = "U, PG, 12 & 15 films are available.";
        }
        else
        {
            result = "All films are available.";
        }
        return result;
    }
}
