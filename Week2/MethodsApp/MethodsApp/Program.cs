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

        #region Tuples
        var myTuple = ("Kai", "Chan", 60);
        (string fName, string lName, int age) myTuple2 = ("Kai", "Chan", 60);
        Console.WriteLine(myTuple2.fName);
        #endregion

        //bool z;
        //var result2 = DoThat(11, "Hello", out z);

        int number = 10;
        Subtract(number);
        
        Console.WriteLine(number);
        
        Subtract(ref number);
        Console.WriteLine(number);
    }

    public static void Subtract(int num)
    {
        num--;
    }

    public static void Subtract(ref int num)
    {
        num--;
    }


    public static int DoThat(int x, string y, out bool z)
    {
        Console.WriteLine(y);
        z = (x > 10);
        return x * x;
    }
    public static (int, int) ConvertPoundsToStones(int pounds)
    {
        if (pounds < 0)
            throw new ArgumentOutOfRangeException();
        return (pounds == 0 ? 0 : pounds / 14, pounds % 14);
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

    #region Memory 
    public static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
    #endregion

}

