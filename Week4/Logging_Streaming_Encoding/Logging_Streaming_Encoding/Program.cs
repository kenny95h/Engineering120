using System.IO;
using System.Diagnostics;

namespace Logging_Streaming_Encoding;

internal class Program
{
    private static string _currentDirectory = Directory.GetCurrentDirectory();
    private static string _path = Path.Combine(_currentDirectory, @"../../../");
    static void Main(string[] args)
    {
        #region fileops
        //Console.WriteLine("What is your name?");
        //var name = Console.ReadLine();
        //Console.WriteLine($"Hello {name}, it is now {DateTime.Now}");
        //string currentDirectory = Directory.GetCurrentDirectory();
        //var path = Path.Combine(currentDirectory, @"../../../");

        //var text = "Hello, World!";
        //File.WriteAllText(path + "Hello.txt", text);

        ////string content = File.ReadAllText(path + "Hello.txt");
        ////Console.WriteLine(content);

        //string[] lines = { "And after all", "You're my Wonderwall" };
        //File.WriteAllLines(path + "Wonderwall.txt", lines);
        //string[] readLines = File.ReadAllLines(path + "Wonderwall.txt");
        //foreach (var item in readLines)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion

        #region logging
        //Console.WriteLine($"This is being logged at time {DateTime.Now}");
        //TextWriterTraceListener twtl = new TextWriterTraceListener(File.Create(_path + "TraceOutput.txt"));
        //Trace.Listeners.Add(twtl);
        //int total = 0;
        //for (int i = 0; i <= 3; i++)
        //{
        //    Console.WriteLine(i);
        //    total += i;
        //    //Useful to find defect
        //    Debug.WriteLine($"Debug - The value of i is {i}");
        //    Trace.WriteLine($"Trace - The value of i is {i}");
        //}
        //Trace.Flush();
        #endregion

        #region Conditionally compiling code
        //        Console.WriteLine("Starting app");
        //#if DEBUG
        //        Console.WriteLine("This is debug code");
        //#endif
        //        Console.WriteLine("Finishing app");

        #endregion

        #region streaming

        //using (StreamWriter sw = File.AppendText(_path + "Mary.txt"))
        //{
        //    sw.WriteLine("Mary had a little lamb");
        //}

        //using (StreamReader sr = File.OpenText(_path + "Mary.txt"))
        //{
        //    string s = "";
        //    while ((s = sr.ReadLine()) != null)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}

        //using (Stream ns = NetworkStream(clientSocket, true), bufStream = new BufferedStream(ns, 2014))
        //{
        //    //do something
        //}

        #endregion
    }
}