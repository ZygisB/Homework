﻿using System;

namespace Homework
{
    class HomeworkClass
    {
        static void Main()
        {
            Console.WriteLine(D20(21));
        }

        static int Max(int number1, int number2, int number3)
        {
            if (number1 > number2 & number1 > number3)
            {
                return number1;
            }
            else if (number2 > number1 & number2 > number3)
            {
                return number2;
            }
            else
            {
                return number3;
            }

        }

        static int D20(out int number1)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, number1);
            return randomNumber;
        }
    }
}
