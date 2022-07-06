using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Create a method for each type of loop which returns the highest number in a list

namespace ControlFlowApp
{
    public static class LoopTypes
    {
        public static int HighestForEachLoop(List<int> nums)
        {
            int highest = nums[0];
            foreach (int i in nums)
            {
               if (i > highest)
                {
                    highest = i;
                }
            }
            return highest;
        }

        public static int LowestForEachLoop(List<int> nums)
        {
            int lowest = nums[0];
            foreach (int i in nums)
            {
                if (i < lowest)
                {
                    lowest = i;
                }
            }
            return lowest;
        }

        public static int HighestForLoop(List<int> nums)
        {
            int highest = nums[0];
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] > highest)
                {
                    highest = nums[i];
                }
            }
            return highest;
        }

        public static int LowestForLoop(List<int> nums)
        {
            int lowest = nums[0];
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < lowest)
                {
                    lowest = nums[i];
                }
            }
            return lowest;
        }


        public static int HighestWhileLoop(List<int> nums)
        {
            int i = 0;
            int highest = nums[0];
            while (i < nums.Count)
            {
                if (nums[i] > highest)
                {
                    highest = nums[i];
                }
                i++;
            }
            return highest;
        }

        public static int LowestWhileLoop(List<int> nums)
        {
            int i = 0;
            int lowest = nums[0];
            while (i < nums.Count)
            {
                if (nums[i] < lowest)
                {
                    lowest = nums[i];
                }
                i++;
            }
            return lowest;
        }

        public static int HighestDoWhileLoop(List<int> nums)
        {
            int i = 0;
            int highest = nums[0];
            do
            {
                if (nums[i] > highest)
                {
                    highest = nums[i];
                }
                i++;
            }
            while (i < nums.Count);
            return highest;
        }

        public static int LowestDoWhileLoop(List<int> nums)
        {
            int i = 0;
            int lowest = nums[0];
            do
            {
                if (nums[i] < lowest)
                {
                    lowest = nums[i];
                }
                i++;
            }
            while (i < nums.Count);
            return lowest;
        }
    }
}
