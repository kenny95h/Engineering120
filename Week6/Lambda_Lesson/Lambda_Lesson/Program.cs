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

        //int countEven = 0;
        //foreach (var num in nums)
        //{
        //    if (IsEven(num))
        //    {
        //        countEven++;
        //    }
        //}

        //int countMEven = nums.Count(IsEven);
        //int countDEven = nums.Count(delegate (int n) { return n % 2 == 0});
        //int countLEven = nums.Count(x => x % 2 == 0);
        //Console.WriteLine(countDEven);

        var people = new List<Person>
        {
            new Person{Name = "Nish", Age = 40, City = "Birmingham"},
            new Person{Name = "Cathy", Age = 20, City = "Ottowa"},
            new Person{Name = "Peter", Age = 55, City = "London"}
        };

        int countYoungPeople = people.Count(x => x.Age < 30);
        int totalAge = people.Sum(x => x.Age);

        int totalAgeOver30 = people.Where(x => x.Age >= 30).Sum(x => x.Age);

        var londonPeopleQuery = people.Where(x => x.City.ToLower() == "london");

        var peopleOrderByAge = people.OrderBy(x => x.Age).OrderByDescending(x => x.Name);

        var peopleLonQueryAge = people.Where(x => x.City == "London").Select(x => x.Age);


    }

    public static bool IsYoung(Person p)
    {
        return p.Age < 30;
    }

    public static bool IsEven(int n)
    {
        return n % 2 == 0;
    }

}
