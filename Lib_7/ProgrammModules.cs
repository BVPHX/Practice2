using System;
namespace Lib_7
{
    public class ProgrammModules
    {
        public static int[] NumbersBelowZeroToPower(int [] numbers)
        {
            
            for (int i=0;i<numbers.Length; i++)
            {
                
                if (numbers[i] < 0)
                {
                    numbers[i] = (int)Math.Pow(numbers[i], 2);
                }
            }
            return numbers;
        }
    }
}
