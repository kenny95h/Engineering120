namespace MethodsApp;

public class Program
{
    static void Main(string[] args)
    {
        //var result = DoThis(10);

        //var spartaPizza = OrderPizza(true, true, true, true);
        //Console.WriteLine(spartaPizza);

        //Console.WriteLine(Add(1,2,3));
        //Console.WriteLine(Add(1,2));

        var myTuple = ("Kai", "Chan", 60);
        (string fName, string lName, int age) myTuple2 = ("Kai", "Chan", 60);
        Console.WriteLine(myTuple2.fName);
    }

    public static int DoThis(int x, string y = "sad")
    {
        Console.WriteLine($"I'm feeling {y}");
        return x * x;
    }

    #region Method overloading
    public static int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    public static int Add(int num1, int num2, int num3)
    {
        return num1 + num2 + num3;
    }
    #endregion

    public static string OrderPizza(bool pepperoni, bool chicken, bool jalapenos, bool kiwi)
    {
        var pizza = "Pizza with tomato sauce, cheese";
        if (pepperoni) pizza += ", pepperoni";
        if (chicken) pizza += ", chicken";
        if (jalapenos) pizza += ", jalapenos";
        if (kiwi) pizza += ", kiwi";

        return pizza + ".";
    }
}

