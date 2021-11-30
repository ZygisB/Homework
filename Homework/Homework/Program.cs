using System;

namespace Homework
{
    class Program
    {
        static void Main()
        {
            bool isNumber;
            string word;
            bool isRange;
            do
            {
                Console.WriteLine("Please enter number");
                word = Console.ReadLine();
                isNumber = IsItNumber(word);
            } while (isNumber == false);

            int wordNumber = Convert.ToInt16(word);

            isRange = IsItRange(wordNumber);

            Console.WriteLine(ChangeNumberToText(wordNumber));
        }

        static bool IsItNumber(string word)
        {
            int wordCount = 0;

            if (word == "")
                word = "numberInText";

            for (int i = 0; i < word.Length; i++)
            {
                char symbol = word[i];

                if ((i == 0 & (int)symbol == 45) || (i == 0 & (int)symbol == 43))
                {
                }
                else if ((int)symbol > 47 & (int)symbol < 58)
                {
                }
                else
                {
                    wordCount++;
                }
            }

            if (wordCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsItRange(int wordNumber)
        {
            if (wordNumber > -10 & wordNumber < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string ChangeNumberToText(int wordNumber)
        {
            string word = Convert.ToString(wordNumber);

            string numberInText = "";
            string individualNumber;

            for (int i = 0; i < word.Length; i++)
            {
                char symbol = word[i];

                if (i == 0 & (int)symbol == 45)
                {
                    numberInText = "Minus ";
                }
                else
                {
                    switch ((int)symbol)
                    {
                        case 48:
                            individualNumber = "Nulis";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 49:
                            individualNumber = "Vienas";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 50:
                            individualNumber = "Du";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 51:
                            individualNumber = "Trys";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 52:
                            individualNumber = "Keturi";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 53:
                            individualNumber = "Penki";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 54:
                            individualNumber = "Sesi";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 55:
                            individualNumber = "Septyni";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 56:
                            individualNumber = "Astuoni";
                            numberInText = numberInText + individualNumber;
                            break;
                        case 57:
                            individualNumber = "Devyni";
                            numberInText = numberInText + individualNumber;
                            break;
                    }
                }
            }
            return numberInText;
        }
    }
}

