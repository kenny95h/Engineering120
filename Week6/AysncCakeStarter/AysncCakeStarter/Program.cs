using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake
{
    class Program
    {
        #region Version 1
        //    public static void Main(string[] args)
        //    {
        //        Console.WriteLine("Welcome to my birthday party");
        //        HaveAPartyAsync();
        //        Console.WriteLine("Thanks for a lovely party");
        //        Console.ReadLine();
        //    }

        //    private static void HaveAPartyAsync()
        //    {
        //        var name = "Cathy";
        //        var cakeTask = BakeCake();
        //        PlayPartyGames();
        //        OpenPresents();
        //        var cake = cakeTask.Result;
        //        Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        //    }

        //    private static async Task<Cake> BakeCake()
        //    {
        //        Console.WriteLine("Cake is in the oven");
        //        // Await for this task to complete
        //        // Whilst waiting, go back to the caller method
        //        await Task.Delay(TimeSpan.FromSeconds(5));
        //        Console.WriteLine("Cake is done");
        //        return new Cake();
        //    }

        //    private static void PlayPartyGames()
        //    {
        //        Console.WriteLine("Starting games");
        //        Thread.Sleep(TimeSpan.FromSeconds(2));
        //        
        //        Console.WriteLine("Finishing Games");
        //    }

        //    private static void OpenPresents()
        //    {
        //        Console.WriteLine("Opening Presents");
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine("Finished Opening Presents");
        //    }


        //}

        //public class Cake
        //{
        //    public override string ToString()
        //    {
        //        return "Here's a cake";
        //    }
        //}

        #endregion

        #region version 2
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to my birthday party");
            await HaveAPartyAsync();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        private static async Task HaveAPartyAsync()
        {
            var name = "Cathy";
            var cakeTask = BakeCakeAsync();
            var game = PlayPartyGamesAsync();
            var cake = await cakeTask;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
            var gamewinner = await game;
            Console.WriteLine(gamewinner);
            OpenPresents();
            
            
        }

        private static async Task<Cake> BakeCakeAsync()
        {
            Console.WriteLine("Cake is in the oven");
            // Await for this task to complete
            // Whilst waiting, go back to the caller method
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static async Task<Winner> PlayPartyGamesAsync()
        {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var gamewinner = await PassTheParcelAsync();
            Console.WriteLine("Finishing Games");
            return gamewinner;
        }

        private static async Task<Winner> PassTheParcelAsync()
        {
            Random parcel = new Random();
            int parLayers = parcel.Next(3, 10);
            Console.WriteLine("Playing Pass The Parcel");
            int layersLeft = parLayers;
            await Task.Delay(TimeSpan.FromSeconds(0.1));
            do
            {
                layersLeft--;
                Console.WriteLine("Layer removed");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            while (layersLeft > 0);
            return new Winner(parLayers);
        }

        private static void OpenPresents()
        {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }
    }

    public class Cake
    {
        public override string ToString()
        {
            return "Here's a cake";
        }
    }

    public class Winner
    {
        private int winner;
        public Winner (int personNo)
        {
            winner = personNo;
        }
        public override string ToString()
        {
            return $"Winner is person {winner}";
        }
    }
    #endregion
}
