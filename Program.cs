using System;
using lab2;

class Program
{
    static void Main()
    {
        string text = "Hello World";
        Console.WriteLine(MyFunctions.ReverseString(text));

        int[] numbers = { 1, 2, 3, 4, 5 };
        MyFunctions.PrintArray(numbers);
    }
}
