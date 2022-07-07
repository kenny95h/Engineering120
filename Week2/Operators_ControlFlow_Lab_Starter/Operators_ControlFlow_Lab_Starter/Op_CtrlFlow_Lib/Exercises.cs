using System.Collections.Generic;
using System;


namespace Op_CtrlFlow
{
    public class Exercises
    {
        public static bool MyMethod(int num1, int num2)
        {
            return num1 == num2 ? false : (num1 % num2) == 0;
        }

        // returns the average of the array nums
        public static double Average(List<int> nums)
        {
            if (nums.Count == 0)
            {
                throw new ArgumentOutOfRangeException("List must not be empty");
            };
            
            double sum = 0;
            int count = 0;
            //int i = 0;
            //while (i < nums.Count)
            //{
            //    sum += nums[i];
            //    i++;
            //}

            //return sum / i;

            foreach (int i in nums)
            {
                sum += i;
                count++;

            }
            return sum / count;
        }

        // returns the type of ticket a customer is eligible for based on their age
        // "Standard" if they are between 18 and 59 inclusive
        // "OAP" if they are 60 or over
        // "Student" if they are 13-17 inclusive
        // "Child" if they are 5-12
        // "Free" if they are under 5
        public static string TicketType(int age)
        {
            if (age < 0 || age > 200)
            {
                throw new ArgumentOutOfRangeException("Age must be a non-negative integer and under 201");
            }
            return age > 59 ? "OAP" 
                : age > 17 ? "Standard" 
                : age > 12 ? "Student"
                : age > 4 ? "Child"
                : "Free";
        }

        public static string Grade(int mark)
        {
            if (mark < 0 || mark > 100)
            {
                throw new ArgumentOutOfRangeException("Mark must be a non-negative integer and under 101");
            }

            string grade;
            if (mark >= 40)
            {
                grade = "Pass";
                if (mark >= 75)
                {
                    grade += " with Distinction";
                }
                else if (mark >= 60)
                {
                    grade += " with Merit";
                }
                
            }
            else
            {
                grade = "Fail";
            }
            //if (mark > 74)
            //{
            //    grade = "Pass with Distinction";
            //}
            //else if (mark > 59)
            //{
            //    grade = "Pass with Merit";
            //}
            //else if (mark > 39)
            //{
            //    grade = "Pass";
            //}
            //else
            //{
            //    grade = "Fail";
            //}
            return grade;
        }

        public static int GetScottishMaxWeddingNumbers(int covidLevel)
        {
            if (covidLevel < 0 || covidLevel > 4)
            {
                throw new ArgumentOutOfRangeException("Covid Level cannot be a non-negative integer or over 4");
            }

            int attendees = 0;
            switch (covidLevel)
            {
                case 4:
                    attendees = 20;
                    break;
                case 3:
                    attendees = 50;
                    break;
                case 2:
                    attendees = 50;
                    break;
                case 1:
                    attendees = 100;
                    break;
                case 0:
                    attendees = 200;
                    break;
                default:
                    break;
            }
            return attendees;
        }
    }
}
