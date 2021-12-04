using System;

namespace Homework
{
    class HomeworkClass1
    {
        static void Main2()
        {

            string[] array = new string[] { "", "", "", "", "" };

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Please enter word:");
                string word = Console.ReadLine();
                array[i] = word;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write($"{array[i]} ");
            }
        }


    }
}
