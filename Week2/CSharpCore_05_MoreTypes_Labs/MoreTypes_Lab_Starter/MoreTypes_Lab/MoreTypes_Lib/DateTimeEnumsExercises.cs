using System;

namespace MoreTypes_Lib
{
    public enum Suit
    {
        HEARTS, CLUBS, DIAMONDS, SPADES
    }
    public class DateTimeEnumsExercises
    {
        // returns a person's age at a given date, given their birth date.
        public static int AgeAt(DateTime birthDate, DateTime date)
        {
            if (birthDate > date)
                throw new ArgumentException("Error - birthDate is in the future");
            var year = date.Year - birthDate.Year;
            if (date.Month < birthDate.Month)
                year--;
            else if (date.Month == birthDate.Month && date.Day < birthDate.Day)
                year--;
            
            return year;
        }
        // returns a date formatted in the manner specified by the unit test
        public static string FormatDate(DateTime date)
        {

            return date.ToString("yy/dd/MMM");
        }

        // returns the name of the month corresponding to a given date
        public static string GetMonthString(DateTime date)
        {
            return date.ToString("MMMM");
        }

        // see unit tests for requirements
        public static string Fortune(Suit suit)
        {              
            return suit == Suit.CLUBS ? "And the seventh rule is if this is your first night at fight club, you have to fight." 
                : suit == Suit.HEARTS ? "You've broken my heart" 
                : suit == Suit.DIAMONDS ? "Diamonds are a girls best friend" 
                : "Bucket and spade";
        }
    }
}
