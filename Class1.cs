using System;

namespace lab2
{
    public class MyFunctions
    {
        
        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        
        public static void PrintArray(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Масив порожній");
                return;
            }

            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
