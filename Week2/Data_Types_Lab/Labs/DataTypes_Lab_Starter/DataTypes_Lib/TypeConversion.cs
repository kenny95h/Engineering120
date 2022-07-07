using System;

namespace DataTypes_Lib
{
    public class TypeConversion
    {
        public static short UIntToShort(uint num)
        {
            checked
            {
                return (short)num;
            }
        }

        public static long FloatToLong(float num)
        {

            return Convert.ToInt64(num);
        }
    }
}
