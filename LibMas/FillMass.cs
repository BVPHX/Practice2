using System;
using Lib_7;
using System.IO;
namespace LibMas
{
    public class FillMass
    {
        public static int[] Fill(int numbersCount)
        {
            int[] numbers = new int[numbersCount];
            Random randomNumber = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = randomNumber.Next(-50, 50);
            }

            return numbers;
        }
        public static void SaveMatrix(string path, int[] matrix)
        {
            using (StreamWriter save = new StreamWriter(path))
            {
                save.WriteLine(matrix.GetLength(0));
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    save.WriteLine(matrix[i]);
                }
            }
        }
        public static void OpenArray(string path, out int[] savedArray)
        {
            using (StreamReader open = new StreamReader(path))
            {
                int arrayLenght = Convert.ToInt32(open.ReadLine());
                savedArray = new int[arrayLenght];
                for (int i = 0; i < savedArray.GetLength(0); i++)
                {
                    savedArray[i] = Convert.ToInt32(open.ReadLine());
                }
            }
        }
    }
}
