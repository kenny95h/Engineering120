using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections_Lib
{
    public class ListExercises
    {
        // returns a list of all the integers between 1 to max inclusive
        // that are multiples of 5
        public static List<int> MakeFiveList(int max)
        {
            //List<int> myList = new List<int>();
            //for (int i = 1; i <= max; i++)
            //{
            //    if (i % 5 == 0)
            //        myList.Add(i);
            //}
            //return myList;

            return Enumerable.Range(1, max).Where(x => x % 5 == 0).ToList();
        }

        // returns a list of all the strings in sourceList that start with the letter 'A' or 'a'
        public static List<string> MakeAList(List<string> sourceList)
        {
            //List<string> myList = new List<string>();
            //foreach (string word in sourceList)
            //    if (word.StartsWith('a') || word.StartsWith('A'))
            //        myList.Add(word);
            //return myList;
            
            return sourceList.Where(x => x.StartsWith('a') || x.StartsWith('A')).ToList();

        }
    }
}
