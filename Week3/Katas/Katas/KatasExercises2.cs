using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class KatasExercises2
    {
        static void Main(string[] args)
        { }

        public static int SecondHighest(List<int> nums)
        {
            return nums.Count >= 2 ? nums.OrderByDescending(x => x).ElementAt(1) : nums.Count == 0 ? 0 : nums[0];
        }

        public static char[] DuplicateCharacters(string word)
        {
 
            var charList = new List<char>();
            foreach (char c in word)
            {
                if (word.Count(x => (x == c)) > 1)
                    if (!charList.Contains(c))
                        charList.Add(c);
            }
            return charList.ToArray();
        }
    }
}
