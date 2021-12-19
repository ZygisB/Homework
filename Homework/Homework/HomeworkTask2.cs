using System;
using System.Collections.Generic;

namespace Homework
{
    class HomeworkTask2
    {
        static void Main()
        {
            bool tests = true;
            int magicNumber;

            for (int i = 100000; i < 500000; i++)
            {
                List<int> startingNumberArray = IntToArray(i);

                tests = NoDuplicates(startingNumberArray);

                if (tests == true)
                {
                    for (int x = 2; x < 7; x++)
                    {
                        int secondNumberInt = x * ArrayToInt(startingNumberArray);

                        List<int> secondNumberArray = IntToArray(secondNumberInt);

                        if (NoDuplicates(secondNumberArray) == false)
                        {
                            tests = false;
                        }
                        else if (ArrayComparison(startingNumberArray, secondNumberArray) == false)
                        {
                            tests = false;
                        }
                        // exit loop if any of the tests fail
                        if (tests == false)
                        {
                            break;
                        }
                    }
                }

                if (tests == true)
                {
                    magicNumber = i;
                    Console.WriteLine("Magic Number is " + magicNumber);
                    // exit loop when Magic Number is found
                    break;
                }
            }
            if (tests == false)
            {
                Console.WriteLine("There is no Magic Number for this range");
            }
        }

        static List<int> IntToArray(int startingNumberInt) //converts int number to array
        {
            string startingNumberString = Convert.ToString(startingNumberInt);

            List<int> startingNumberArray = new List<int>();

            for (int i = 0; i < startingNumberString.Length; i++)
            {
                startingNumberArray.Add(Convert.ToInt32(Char.GetNumericValue(startingNumberString[i])));
            }
            return startingNumberArray;
        }
        static int ArrayToInt(List<int> startingNumberArray) //comverts array to int number
        {
            int startingNumberInt = 0;

            for (int i = 0; i < startingNumberArray.Count; i++)
            {
                startingNumberInt += startingNumberArray[i] * Convert.ToInt32(Math.Pow(10, startingNumberArray.Count - i - 1));
            }
            return startingNumberInt;
        }
        static bool NoDuplicates(List<int> startingNumberArray) //checks if there are no duplicate numbers in an array
        {
            bool noDuplicates = true;

            for (int i = 0; i < 10; i++)
            {
                List<int> resulData = startingNumberArray.FindAll(item => item == i);
                if (resulData.Count > 1)
                {
                    noDuplicates = false;
                    break;
                }
            }
            return noDuplicates;
        }
        static bool ArrayComparison(List<int> startingNumberArray, List<int> secondNumberArray)
        {
            bool sameNumbers = true;

            for (int i = 0; i < 10; i++)
            {
                List<int> resulDataFirstArray = startingNumberArray.FindAll(item => item == i);
                List<int> resulDataSecondArray = secondNumberArray.FindAll(item => item == i);
                if (resulDataFirstArray.Count != resulDataSecondArray.Count)
                {
                    sameNumbers = false;
                }
            }
            return sameNumbers;
        }
    }
}
