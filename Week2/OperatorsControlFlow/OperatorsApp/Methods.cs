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
            return totalPounds / 14;
        }

        public static int GetPounds(int totalPounds)
        {
            return totalPounds % 14;
        }
    }
}
