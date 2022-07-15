using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections_Lib
{
    public class CollectionsExercises
    {

        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            if (num == 0) return "";
            string result = queue.Peek();
            queue.Dequeue();
            num = num > queue.Count() ? queue.Count() + 1: num;
            for (int i = 1; i < num; i++)
            {
                result += ", " + queue.Peek();
                queue.Dequeue();
            }
            return result;

        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            var stack = new Stack<int>();
            int[] array = new int[original.Length]; 
            foreach(int i in original)
            {
                stack.Push(i);
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = stack.Pop();
            }
            return array;
        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            string result = "";
            input = new string(input.Where(char.IsDigit).ToArray());
            var dict = new Dictionary<char, int>();
            foreach(char c in input)
            {
                if(dict.ContainsKey(c))
                {
                    dict[c]++;
                } else
                {
                    dict.Add(c, 1);
                }
            }
            foreach(var entry in dict)
            {
                result += entry;
            }

            return result;
        }
    }
}
