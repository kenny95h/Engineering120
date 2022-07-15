using System;
using System.Text;

namespace Katas;

public class KatasExercises
{

    public static bool IsPallindrome(string word)
    {
        char[] array = word.ToLower().ToCharArray();
        Array.Reverse(array);
        return word.ToLower() == new string(array);
    }
}