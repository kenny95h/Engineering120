

namespace SafariParkApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Person jon = new Person("Jon", "Crofts", 22);
            //Console.WriteLine(jon.GetFullName());
            //Person charlie = new Person("Charlie");
            //Person dan = new Person("Dan", "Summerside") { Age = 100 };
            //Person laba = new Person { Age = 30 };

            //var shop1 = new Shopping { Ties = 3, Shirts = 3, Trousers = 1 };
            //var shop2 = new Shopping { Socks = 10 };

            //var kai = new Spartan { FullName = "Kai", Course = "C# SDET", Personalid = 999 };

            //Point3d p3d;
            //p3d.x = 2;

            //Point3d pt = new Point3d(3, 6, 2);
            //Person jon = new Person("Jon", "Crofts", 22);
            //Vehicle v = new Vehicle();
            //v.Move(2);

            //Hunter maks = new Hunter("Maks", "Hadys", "Sony") { Age = 10};
            ////Console.WriteLine(maks.Age);
            ////Console.WriteLine(maks.Shoot());

            //Person dan = new Person("Dan", "Daaboul") { Age = 1 };

            ////Console.WriteLine(maks.Equals(dan));

            //var maks2 = maks;

            //Console.WriteLine(maks.GetHashCode());
            //Console.WriteLine(maks2.GetHashCode());
            //Console.WriteLine(dan.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            //Console.WriteLine(1.GetHashCode());
            //Console.WriteLine(maks.GetType());
            //Console.WriteLine(maks.ToString());

            //Airplane a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            //a.Ascend(500);
            //Console.WriteLine(a.Move(3));
            //Console.WriteLine(a);
            //a.Descend(200);
            //Console.WriteLine(a.Move());
            //a.Move();
            //Console.WriteLine(a);



            //List<Object> gameObj = new List<Object>
            //{ ellis, plane, vehicle, kenny};

            //    foreach(var Obj in gameObj)
            //{
            //    Console.WriteLine(Obj);
            //}

            //SpartaWrite(ellis);

            //var ellis = new Hunter("Ellis", "Witten", "Nikon") { Age = 21 };
            //var plane = new Airplane(400, 200, "Virgin");
            //plane.Ascend(500);
            //var ford = new Vehicle(20, 20);
            //var tesla = new Vehicle();
            //var kenny = new Person("Kenny", "Harvey") { Age = 22 };

            //List<IMovable> movables = new List<IMovable>
            //{ ellis, plane, ford, kenny, tesla};

            //foreach (var Obj in movables)
            //{
            //    Console.WriteLine(Obj.ToString());
            //    Console.WriteLine(Obj.Move());
            //}
            //Random rand = new Random();
            //// Shooters
            //var cameraOne = new Camera("Sony");
            //var cameraTwo = new Camera("Panasonic");
            //var laserOne = new LaserGun("Photon Beam");
            //var pistol = new WaterPistol("The Splasher");

            //IShootable playerOneWeapon = cameraOne;
            //IShootable playerTwoWeapon = cameraTwo;

            //// Hunters
            //var playerOne = new Hunter("Kenny", "Harvey", playerOneWeapon) { Age = 27 };
            //var playerTwo = new Hunter("Laba", "Limbu", playerTwoWeapon) { Age = 44 };

            //int playerOneHealth = 100;
            //int playerTwoHealth = 100;

            //List<IShootable> weapons = new List<IShootable> { laserOne, pistol, cameraOne, cameraTwo };

            //while (playerOneHealth > 0 && playerTwoHealth > 0)
            //{
            //    int playerOneRand = rand.Next(0, 3);
            //    int playerTwoRand = rand.Next(0, 3);
            //    if (playerOneRand == 0)
            //    {
            //        playerOneWeapon = cameraOne;
            //        playerTwoHealth -= 5;
            //    }
            //    else if (playerOneRand == 1)
            //    {
            //        playerOneWeapon = cameraTwo;
            //        playerTwoHealth -= 6;
            //    }
            //    else if (playerOneRand == 2)
            //    {
            //        playerOneWeapon = laserOne;
            //        playerTwoHealth -= 20;
            //    }
            //    else
            //    {
            //        playerOneWeapon = pistol;
            //        playerTwoHealth -= 10;
            //    };

            //    if (playerTwoRand == 0)
            //    {
            //        playerTwoWeapon = cameraOne;
            //        playerOneHealth -= 5;
            //    }
            //    else if (playerTwoRand == 1)
            //    {
            //        playerTwoWeapon = cameraTwo;
            //        playerOneHealth -= 6;
            //    }

            //    else if (playerTwoRand == 2)
            //    {
            //        playerTwoWeapon = laserOne;
            //        playerOneHealth -= 20;
            //    }
            //    else
            //    {
            //        playerTwoWeapon = pistol;
            //        playerOneHealth -= 10;
            //    }


            //    playerOne.Shooter = playerOneWeapon;
            //    playerTwo.Shooter = playerTwoWeapon;

            //    Console.WriteLine($"{playerOne.Shoot()} Health: {playerTwoHealth}");
            //    Console.WriteLine($"{playerTwo.Shoot()} Health: {playerOneHealth}");
            //}




            //if (playerOneHealth <= 0 && playerTwoHealth <= 0)
            //    Console.WriteLine($"{playerTwo.FullName} & {playerOne.FullName} lost");
            //else if (playerOneHealth <= 0)
            //    Console.WriteLine($"Winner is {playerTwo.FullName}");
            //else
            //    Console.WriteLine($"Winner is {playerOne.FullName}");

            //foreach (var Obj in weapons)
            //{
            //    Console.WriteLine(Obj.Shoot());
            //}

            // var cameraOne = new Camera("Sony");
            // var cameraTwo = new Camera("Panasonic");
            // var laserOne = new LaserGun("Photon Beam");
            // var pistol = new WaterPistol("The Splasher");

            // var array = new IShootable[] { cameraOne, cameraTwo, laserOne, pistol };

            // var playerOne = new Hunter("Kenny", "Harvey", cameraOne );
            // var playerTwo = new Hunter("Laba", "Limbu", laserOne);
            // var playerThree = new Hunter("Nish", "Mandal", pistol);

            // //var array2 = new Hunter[] { playerOne, playerTwo, playerThree };

            // //foreach(Hunter h in array2)
            // //{
            // //    Console.WriteLine(h.Shoot());
            // //}


            //ShootOut(playerThree, playerTwo, array);

            //List<Person> peopleList = new List<Person>()
            //{
            //    new Person("Nish", "Mandal") {Age = 32}
            //};

            var kai = new Person("Kai", "Chan");
            var tom = new Person("Tom", "W");

            //peopleList.Add(tom);

            //var newerList = new List<Person>();
            //newerList.AddRange(peopleList);
            //newerList.Add(kai);

            //peopleList.ForEach(x => Console.WriteLine(x));
            //Console.WriteLine();
            //newerList.ForEach(x => Console.WriteLine(x));

            //List<int> numList = new List<int>()
            //{
            //    5, 4, 3, 9, 0
            //};
            //numList.Add(8);
            //numList.Sort();
            //numList.RemoveRange(1, 2);
            //numList.Insert(2, 1);
            //numList.Reverse();
            //numList.Remove(9);
            //numList.ForEach(x => Console.Write(x));

            //var newList = new LinkedList<Person>();
            //newList.AddFirst(kai);
            //newList.AddLast(tom);
            //Console.WriteLine(newList.Find(tom).Value);

            //foreach (var person in newList)
            //{
            //    Console.WriteLine(person);
            //}

            //var myQueue = new Queue<Person>();
            //myQueue.Enqueue(kai);
            //myQueue.Enqueue(tom);
            //myQueue.Enqueue(new Person("David", "Joyce"));

            //foreach(var person in myQueue)
            //{
            //    Console.WriteLine(person);
            //}

            //var first = myQueue.Peek();
            //Console.WriteLine(first);

            //var stack = new Stack<int>();
            //int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };
            //int[] numsReversed = new int[nums.Length];

            //foreach(var num in nums)
            //{
            //    stack.Push(num);
            //}

            //for (int i = 0; i < numsReversed.Length; i++)
            //{
            //    numsReversed[i] = stack.Pop();
            //}

            var vehicleSet = new HashSet<Vehicle>
            {
                new Vehicle(10, 20) {NumPassengers = 3},
                new Vehicle(1, 100) {NumPassengers = 1},
                new Vehicle()
            };

            vehicleSet.Add(new Vehicle(1, 100) { NumPassengers = 1 });
            vehicleSet.Add(new Vehicle());
        }

        public static void AutoShootOut(Hunter playerOne, Hunter playerTwo)
        {
            Random rand = new Random();
            // Shooters
            var cameraOne = new Camera("Sony");
            var cameraTwo = new Camera("Panasonic");
            var laserOne = new LaserGun("Photon Beam");
            var pistol = new WaterPistol("The Splasher");

            IShootable playerOneWeapon = playerOne.Shooter;
            IShootable playerTwoWeapon = playerTwo.Shooter;

            int playerOneHealth = 100;
            int playerTwoHealth = 100;

            while (playerOneHealth > 0 && playerTwoHealth > 0)
            {
                int playerOneRand = rand.Next(0, 3);
                int playerTwoRand = rand.Next(0, 3);
                switch(playerOneRand)
                {
                    case 0:
                        playerOneWeapon = cameraOne;
                        playerTwoHealth -= 5;
                        break;
                    case 1:
                        playerOneWeapon = cameraTwo;
                        playerTwoHealth -= 6;
                        break;
                    case 2:
                        playerOneWeapon = laserOne;
                        playerTwoHealth -= 20;
                        break;
                    case 3:
                        playerOneWeapon = pistol;
                        playerTwoHealth -= 10;
                        break;
                }
                
                switch(playerTwoRand)
                {
                    case 0:
                        playerTwoWeapon = cameraOne;
                        playerOneHealth -= 5;
                        break;
                    case 1:
                        playerTwoWeapon = cameraTwo;
                        playerOneHealth -= 6;
                        break;
                    case 2:
                        playerTwoWeapon = laserOne;
                        playerOneHealth -= 20;
                        break;
                    case 3:
                        playerTwoWeapon = pistol;
                        playerOneHealth -= 10;
                        break;
                }    

                playerOne.Shooter = playerOneWeapon;
                playerTwo.Shooter = playerTwoWeapon;

                Console.WriteLine($"{playerOne.Shoot()} Health: {playerTwoHealth}");
                Console.WriteLine($"{playerTwo.Shoot()} Health: {playerOneHealth}");
            }


            if (playerOneHealth <= 0 && playerTwoHealth <= 0)
                Console.WriteLine($"{playerTwo.FullName} & {playerOne.FullName} lost");
            else if (playerOneHealth <= 0)
                Console.WriteLine($"Winner is {playerTwo.FullName}");
            else
                Console.WriteLine($"Winner is {playerOne.FullName}");
        }








        public static void ShootOut(Hunter playerOne, Hunter playerTwo, IShootable[] shooters)
        {
            Random rand = new Random();
            // Shooters

            IShootable playerOneWeapon = playerOne.Shooter;
            IShootable playerTwoWeapon = playerTwo.Shooter;

            int playerOneHealth = 100;
            int playerTwoHealth = 100;

            while (playerOneHealth > 0 && playerTwoHealth > 0)
            {
                shooters = shooters.OrderBy(x => rand.Next()).ToArray();
                Console.WriteLine($"Choose your weapon {playerOne.FirstName}: (Pick a number from 0 - {shooters.Length - 1})");
                bool success = false;
                int input = 0;
                while (success == false || input > shooters.Length - 1)
                {
                    string playerOneInput = Console.ReadLine();
                    success = int.TryParse(playerOneInput, out input);
                    if (success == false || input > shooters.Length - 1)
                    {
                        Console.WriteLine($"Must enter number between 0 - {shooters.Length - 1}, in integer format");
                    }
                    if (input >= shooters.Length)
                        playerOneWeapon = shooters[0];
                    else
                        playerOneWeapon = shooters[input];
                }
                if (playerOneWeapon.GetType().Equals(typeof(Camera)))
                {
                    playerTwoHealth -= 5;
                }
                else if (playerOneWeapon.GetType().Equals(typeof(WaterPistol)))
                {
                    playerTwoHealth -= 10;
                }
                else if (playerOneWeapon.GetType().Equals(typeof(LaserGun)))
                {
                    playerTwoHealth -= 20;
                }

                Console.WriteLine($"Choose your weapon {playerTwo.FirstName}: (Pick a number from 0 - {shooters.Length - 1})");
                bool success2 = false;
                int input2 = 0;
                while (success2 == false || input2 > shooters.Length - 1)
                {
                    string playerTwoInput = Console.ReadLine();
                    success2 = int.TryParse(playerTwoInput, out input2);
                    if (success2 == false || input2 > shooters.Length - 1)
                    {
                        Console.WriteLine($"Must enter number between 0 - {shooters.Length - 1}, in integer format");
                    }
                    if (input2 >= shooters.Length)
                        playerTwoWeapon = shooters[0];
                    else
                        playerTwoWeapon = shooters[input2];
                }
                //int playerTwoRand = rand.Next(0, shooters.Length);
                //playerTwoWeapon = shooters[playerTwoRand];

                if (playerTwoWeapon.GetType().Equals(typeof(Camera)))
                {
                    playerOneHealth -= 5;
                }
                else if (playerTwoWeapon.GetType().Equals(typeof(WaterPistol)))
                {
                    playerOneHealth -= 10;
                }
                else if (playerTwoWeapon.GetType().Equals(typeof(LaserGun)))
                {
                    playerOneHealth -= 20;
                }

                playerOne.Shooter = playerOneWeapon;
                playerTwo.Shooter = playerTwoWeapon;

                Console.WriteLine($"{playerOne.Shoot()}.\n{playerTwo.FirstName}'s Health: {playerTwoHealth}");
                Console.WriteLine($"{playerTwo.Shoot()}.\n{playerOne.FirstName}'s Health: {playerOneHealth}");
            }


            if (playerOneHealth <= 0 && playerTwoHealth <= 0)
                Console.WriteLine($"{playerTwo.FullName} & {playerOne.FullName} lost");
            else if (playerOneHealth <= 0)
                Console.WriteLine($"Winner is {playerTwo.FullName}");
            else
                Console.WriteLine($"Winner is {playerOne.FullName}");
        }

        public static void SpartaWrite(Object obj)
        {
            Console.WriteLine(obj);
            if (obj is Hunter)
            {
                var hunterObj = (Hunter)obj;
                Console.WriteLine(hunterObj.Shoot);
            }
        }

        public static void DemoMethod(Point3d pt, Person p)
        {
            pt.x = 100;
            p.Age = 100;
        }
    }
}