namespace Lambda_Lesson;
public class Program
{
    static void Main(string[] args)
    {
        List<int> nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

        //int allCount = nums.Count();
        //int allCountAlt = 0;
        //foreach (int i in nums)
        //{
        //    allCountAlt++;
        //}

        int countEven = 0;
        foreach (var num in nums)
        {
            if (IsEven(num))
            {
                countEven++;
            }
        }

        int countMEven = nums.Count(IsEven);
        int countDEven = nums.Count(delegate (int n) { return n % 2 == 0});
        int countLEven = nums.Count(x => x % 2 == 0);
        Console.WriteLine(countDEven);
    }

    public static bool IsEven(int n)
    {
        return n % 2 == 0;
    }
}
