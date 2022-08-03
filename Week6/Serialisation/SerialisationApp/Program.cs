namespace SerialisationApp
{
    public class Program
    {
        private static readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\");
        private static ISerialise? _serialiser;
        static void Main(string[] args)
        {
            Trainee trainee = new Trainee
            {
                FirstName = "Dylan",
                LastName = "Cole",
                SpartaNo = 100
            };

            //_serialiser = new SerialiserBinary();
            //_serialiser.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);
            //Trainee deserialisedDylan = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");

            ////if (trainee == deserialisedDylan)
            ////    Console.WriteLine("Welcome Back");
            ////else
            ////    Console.WriteLine("Imposter!!");

            //_serialiser = new SerialiserXML();
            //// Write out trainee to file
            //_serialiser.SerialiseToFile($"{_path}/XMLTrainee.xml", trainee);
            //Trainee deserialisedXMLDylan = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/XMLTrainee.xml");

            var eng120 = new Course();
            eng120.AddTrainee(trainee);
            eng120.AddTrainee(new Trainee { FirstName = "Tom", LastName = "Wolstencroft", SpartaNo = 101 });


            //_serialiser.SerialiseToFile($"{_path}/XMLCourse.xml", eng120);
            //Thread.Sleep(5000);
            //Course deserialisedXMLCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/XMLCourseEdited.xml");

            //_serialiser = new SerialiserJSON();
            //_serialiser.SerialiseToFile($"{_path}/JSONTrainee.json", trainee);
            //var desJTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/JSONTrainee.json");

            //_serialiser.SerialiseToFile($"{_path}/Course.json", eng120);
            //var desJCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/Course.json");
            Controller serialise = new Controller();
            int choice = 0;
            bool correctInput = false;
            while (!correctInput)
            { 
                Console.WriteLine("Choose serialiser:\n" +
                   "[1] XML Serialiser\n" +
                   "[2] JSON Serialiser\n" +
                   "[3] Binary Serialiser");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int num))
                {
                    if (num <= 3 && num >= 1)
                        correctInput = true;
                        //ChooseSerialiser(num);
                        choice = num;
                }
            }

            int choice2 = 0;
            correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine("Input 1 to serialise or 2 to deserialise");
                var input2 = Console.ReadLine();
                if (int.TryParse(input2, out int num1))
                {
                    if (num1 <= 2 && num1 >= 1)
                        correctInput = true;
                        choice2 = num1;
                }
            }

            if (choice2 == 1)
            {
                serialise.Serialise(trainee, choice);
            }
            else
            {
                var deserItem = serialise.Deserialise<Trainee>(choice2);
                Console.WriteLine(deserItem);
            }

        }

    }
}