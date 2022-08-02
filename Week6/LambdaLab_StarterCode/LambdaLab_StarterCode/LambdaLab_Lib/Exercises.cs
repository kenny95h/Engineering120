namespace LambdaLab_Lib
{
    public class Exercsises
    {
        public static int CountTotalNumberOfSpartans(List<Spartan> spartans)
        {
            return spartans.Count();
        }

        public static int CountTotalNumberOfSpartansInUKAndUSA(List<Spartan> spartans)
        {
            return spartans.Where(x => x.Country == "U.K." || x.Country == "U.S.A.").Count();
        }

        public static int NumberOfSpartansBornAfter1980(List<Spartan> spartans)
        {
            return spartans.Where(x => x.DateOfBirth.Year > 1980).Count();
        }

        public static int SumOfAllSpartaMarksMoreThan50Inclusive(List<Spartan> spartans)
        {
            return spartans.Where(x => x.SpartaMark >= 50).Sum(x => x.SpartaMark);
        }

        //To 2 decimal points
        public static double AverageSpartanMark(List<Spartan> spartans)
        {
            return Math.Round(spartans.Average(x => x.SpartaMark),2);
        }

        public static List<Spartan> SortByAlphabeticallyByLastName(List<Spartan> spartans)
        {
            return spartans.OrderBy(x => x.LastName).ToList();

        }

        public static List<string> ListAllDistinctCities(List<Spartan> spartans)
        {
            return spartans.DistinctBy(x => x.City).Select(x => x.City).ToList();
        }

        public static List<Spartan> ListAllSpartansWithIdBeginingWithB(List<Spartan> spartans)
        {
            return spartans.Where(x => x.SpartanId.StartsWith("B")).ToList();
        }
    }
}