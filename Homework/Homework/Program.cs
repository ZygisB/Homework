using System;

namespace Homework
{
    class Program
    {
        static void Main1()
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
            string individualNumber= "";
            int symbolCount = word.Length;
            int firstSymbol = (int)word[0];
            bool negativeNumber = false;
            if (firstSymbol == 45)
            {
                negativeNumber = true;
                symbolCount--;
            }

            if (symbolCount == 1)
            {
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                }
                else
                {
                    firstSymbol = (int)word[0];
                }
                numberInText = numberInText + Ones(firstSymbol);
            }

            else if (symbolCount == 2)
            {
                int secondSymbol;
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                    secondSymbol = (int)word[2];
                }
                else
                {
                    firstSymbol = (int)word[0];
                    secondSymbol = (int)word[1];
                }
                if (firstSymbol == 49)
                {
                    numberInText = numberInText + individualNumber + DesimtDevyniolika(secondSymbol);
                }
                else
                {
                    numberInText = numberInText + Tens(firstSymbol) + "desimt " + Ones(secondSymbol);
                }
            }
            else if (symbolCount == 3)
            {
                int secondSymbol;
                int thirdSymbol;
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                    secondSymbol = (int)word[2];
                    thirdSymbol = (int)word[3];
                }
                else
                {
                    firstSymbol = (int)word[0];
                    secondSymbol = (int)word[1];
                    thirdSymbol = (int)word[2];
                }
                if (firstSymbol == 49)
                {
                    if (secondSymbol == 49)
                    {
                        numberInText = numberInText + Ones(firstSymbol) + " simtas " + DesimtDevyniolika(thirdSymbol);
                    }
                    else
                    {
                        numberInText = numberInText + Ones(firstSymbol) + " simtas " + Tens(secondSymbol) + "desimt " + Ones(thirdSymbol);
                    }
                }
                else
                {
                    if (secondSymbol == 49)
                    {
                        numberInText = numberInText + Ones(firstSymbol) + " simtai " + DesimtDevyniolika(thirdSymbol);
                    }
                    else
                    {
                        numberInText = numberInText + Ones(firstSymbol) + " simtai " + Tens(secondSymbol) + "desimt " + Ones(thirdSymbol);
                    }
                }
            }
            else
            {
                numberInText = "Error";
            }
            return numberInText;
        }

        static string Ones(int Symbol)
        {
            string individualNumber = "";
            switch (Symbol)
            {
                case 48:
                    individualNumber = "";
                    break;
                case 49:
                    individualNumber = "vienas";
                    break;
                case 50:
                    individualNumber = "du";
                    break;
                case 51:
                    individualNumber = "trys";
                    break;
                case 52:
                    individualNumber = "keturi";
                    break;
                case 53:
                    individualNumber = "penki";
                    break;
                case 54:
                    individualNumber = "sesi";
                    break;
                case 55:
                    individualNumber = "septyni";
                    break;
                case 56:
                    individualNumber = "astuoni";
                    break;
                case 57:
                    individualNumber = "devyni";
                    break;
            }
            return individualNumber;
        }
        static string Tens(int Symbol)
        {
            string tens = "";
            switch (Symbol)
            {
                case 50:
                    tens = "Dvi";
                    break;
                case 51:
                    tens = "Tris";
                    break;
                case 52:
                    tens = "Keturias";
                    break;
                case 53:
                    tens = "Penkias";
                    break;
                case 54:
                    tens = "Sesias";
                    break;
                case 55:
                    tens = "Septynias";
                    break;
                case 56:
                    tens = "Astuonias";
                    break;
                case 57:
                    tens = "Devynias";
                    break;
            }
            return tens;
        }
        static string DesimtDevyniolika(int Symbol)
        {
            string individualNumber = "";
            switch (Symbol)
            {
                case 48:
                    individualNumber = "Desimt";
                    break;
                case 49:
                    individualNumber = "Vienuolika";
                    break;
                case 50:
                    individualNumber = "Dvylika";
                    break;
                case 51:
                    individualNumber = "Trylika";
                    break;
                case 52:
                    individualNumber = "Keturiolika";
                    break;
                case 53:
                    individualNumber = "Penkiolika";
                    break;
                case 54:
                    individualNumber = "Sesiolika";
                    break;
                case 55:
                    individualNumber = "Septyniolika";
                    break;
                case 56:
                    individualNumber = "Astuoniolika";
                    break;
                case 57:
                    individualNumber = "Devyniolika";
                    break;
            }
            return individualNumber;
        }

    }
}

