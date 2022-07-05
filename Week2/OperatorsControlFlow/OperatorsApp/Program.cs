namespace OperatorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //const int NUM_ROWS = 2;
            //const int NUM_COLS = 3;
            //bool running = true;
            //int row = 0;
            //int col = 0;
            //int sprintNo = -1;

            //while(running)
            //{
            //    sprintNo++;
            //    sprintNo %= (NUM_ROWS * NUM_COLS);
            //    row = sprintNo / NUM_COLS;
            //    col = sprintNo % NUM_COLS;
            //}

            #region Logical Operators
            //bool isWearingParachute = false;
            //if (isWearingParachute && JumpOutOfPlane())
            //{
            //    Console.WriteLine("Congrats, you have made a successful jump");
            //}
            //string greeting = null;
            //if (greeting != null && greeting.ToLower().StartsWith('h'))
            //{
            //    Console.WriteLine($"{greeting} starts with an 'h'");
            //}

            //int n = 0;
            //int o = 3;
            //if (n == 5 ^ o == 3)
            //{
            //    Console.WriteLine("Exclusive or");
            //}
            #endregion

            
        }

        public static bool JumpOutOfPlane()
        {
            Console.WriteLine("Jump");
            return true;
        }
    }
}