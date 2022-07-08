//using System;

//namespace MemoryModel
//{
//    public class Person
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public int Age { get; set; }
//    }
//    class PassToMethod
//    {
//        public static void Main()
//        {
//            Person ellis = new Person { FirstName = "Ellis", LastName = "Witten", Age = 21 };
//            double jon = 4.2;
//            string dan = DemoMethod(ellis, jon);
//            int charlie;
//            var success = Int32.TryParse("632", out charlie);
//            int maks = 42;
//            PassByReference(maks, out int david);
//            Console.WriteLine(david);
//        }
//        public static string DemoMethod(Person peter, double nish)
//        {
//            peter.LastName = "Sawyer";
//            peter.Age = 26;
//            nish *= 2;
//            return peter.FirstName;
//        }

//        public static void PassByReference(in int cathy, out int alan)
//        {
//            alan = 2 * cathy;
//        }
//    }
//}
