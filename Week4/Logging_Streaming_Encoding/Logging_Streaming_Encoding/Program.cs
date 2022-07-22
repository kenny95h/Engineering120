using System.IO;

namespace Logging_Streaming_Encoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //Console.WriteLine($"Hello {name}, it is now {DateTime.Now}");
            var text = "Hello, World!";
            File.WriteAllText("Hello.txt", text);
        }
    }
}