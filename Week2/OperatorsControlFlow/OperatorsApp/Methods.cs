using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsApp
{
    public class Methods
    {
        public static int GetStones(int totalPounds)
        {
            if (totalPounds < 0)
            {
                throw new ArgumentOutOfRangeException("Must be a non-negative integer");
            }
            return totalPounds / 14;
        }

        public static int GetPounds(int totalPounds)
        {
            if (totalPounds < 0)
            {
                throw new ArgumentOutOfRangeException("Must be a non-negative integer");
            }
            return totalPounds % 14;
        }
    }
}
