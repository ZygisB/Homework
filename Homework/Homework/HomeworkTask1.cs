using System;

namespace Homework
{
    class HomeworkTask1
    {
        static void MainKomework1()
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

            int wordNumber = Convert.ToInt32(word);

            isRange = IsItRange(wordNumber);

            Console.WriteLine(ChangeNumberToText(wordNumber));

            //Testing
            /*
            for (int i=1000000; i< 1220000; i++)
            {
                Console.WriteLine(ChangeNumberToText(i));
            }
            //*/
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
                if (firstSymbol == 48)
                {
                    numberInText = "Nulis";
                }
                else
                {
                    numberInText = numberInText + Ones(firstSymbol);
                }
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
                numberInText = numberInText + Tens(firstSymbol ,secondSymbol);
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
                numberInText = numberInText + Hundreds(firstSymbol, secondSymbol, thirdSymbol);
            }
            else if (symbolCount == 4)
            {
                int secondSymbol;
                int thirdSymbol;
                int fourthSymbol;
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                    secondSymbol = (int)word[2];
                    thirdSymbol = (int)word[3];
                    fourthSymbol = (int)word[4];
                }
                else
                {
                    firstSymbol = (int)word[0];
                    secondSymbol = (int)word[1];
                    thirdSymbol = (int)word[2];
                    fourthSymbol = (int)word[3];
                }
                numberInText = numberInText + Thousands(firstSymbol, secondSymbol, thirdSymbol, fourthSymbol);
            }
            else if (symbolCount == 5)
            {
                int secondSymbol;
                int thirdSymbol;
                int fourthSymbol;
                int fifthSymbol;
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                    secondSymbol = (int)word[2];
                    thirdSymbol = (int)word[3];
                    fourthSymbol = (int)word[4];
                    fifthSymbol = (int)word[5];
                }
                else
                {
                    firstSymbol = (int)word[0];
                    secondSymbol = (int)word[1];
                    thirdSymbol = (int)word[2];
                    fourthSymbol = (int)word[3];
                    fifthSymbol = (int)word[4];
                }
                numberInText = numberInText + TenThousands(firstSymbol, secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol);
            }
            else if (symbolCount == 6)
            {
                int secondSymbol;
                int thirdSymbol;
                int fourthSymbol;
                int fifthSymbol;
                int sixthSymbol;
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                    secondSymbol = (int)word[2];
                    thirdSymbol = (int)word[3];
                    fourthSymbol = (int)word[4];
                    fifthSymbol = (int)word[5];
                    sixthSymbol = (int)word[6];
                }
                else
                {
                    firstSymbol = (int)word[0];
                    secondSymbol = (int)word[1];
                    thirdSymbol = (int)word[2];
                    fourthSymbol = (int)word[3];
                    fifthSymbol = (int)word[4];
                    sixthSymbol = (int)word[5];
                }
                numberInText = numberInText + HundredThousands(firstSymbol, secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol, sixthSymbol);
            }
            else if (symbolCount == 7)
            {
                int secondSymbol;
                int thirdSymbol;
                int fourthSymbol;
                int fifthSymbol;
                int sixthSymbol;
                int seventhSymbol;
                if (negativeNumber)
                {
                    numberInText = "Minus ";
                    firstSymbol = (int)word[1];
                    secondSymbol = (int)word[2];
                    thirdSymbol = (int)word[3];
                    fourthSymbol = (int)word[4];
                    fifthSymbol = (int)word[5];
                    sixthSymbol = (int)word[6];
                    seventhSymbol = (int)word[7];
                }
                else
                {
                    firstSymbol = (int)word[0];
                    secondSymbol = (int)word[1];
                    thirdSymbol = (int)word[2];
                    fourthSymbol = (int)word[3];
                    fifthSymbol = (int)word[4];
                    sixthSymbol = (int)word[5];
                    seventhSymbol = (int)word[6];
                }
                if (firstSymbol == 49)
                {
                    numberInText = numberInText + Ones(firstSymbol) + " milijonas " + HundredThousands(secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol, sixthSymbol, seventhSymbol);
                }
                else
                {
                    numberInText = numberInText + Ones(firstSymbol) + " milijonai " + HundredThousands(secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol, sixthSymbol, seventhSymbol);
                }
            }
            else
            {
                numberInText = "Error, number is too long";
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
        static string Tens(int firstSymbol, int secondSymbol)
        {
            string tens = "";
            if (firstSymbol == 48)
            {
                tens = Ones(secondSymbol);
            }
            else if (firstSymbol == 49)
            {
                switch (secondSymbol)
                {
                    case 48:
                        tens = "desimt";
                        break;
                    case 49:
                        tens = "vienuolika";
                        break;
                    case 50:
                        tens = "dvylika";
                        break;
                    case 51:
                        tens = "trylika";
                        break;
                    case 52:
                        tens = "keturiolika";
                        break;
                    case 53:
                        tens = "penkiolika";
                        break;
                    case 54:
                        tens = "sesiolika";
                        break;
                    case 55:
                        tens = "septyniolika";
                        break;
                    case 56:
                        tens = "astuoniolika";
                        break;
                    case 57:
                        tens = "devyniolika";
                        break;
                }
            }
            else
            {
                switch (firstSymbol)
                {
                    case 50:
                        tens = "dvi";
                        break;
                    case 51:
                        tens = "tris";
                        break;
                    case 52:
                        tens = "keturias";
                        break;
                    case 53:
                        tens = "penkias";
                        break;
                    case 54:
                        tens = "sesias";
                        break;
                    case 55:
                        tens = "septynias";
                        break;
                    case 56:
                        tens = "astuonias";
                        break;
                    case 57:
                        tens = "devynias";
                        break;
                }
                tens = tens + "desimt " + Ones(secondSymbol);
            }

            return tens;
        }
        static string Hundreds(int firstSymbol, int secondSymbol, int thirdSymbol)
        {
            string hundreds = "";
            if (firstSymbol == 48)
            {
                hundreds = Tens(secondSymbol, thirdSymbol);
            }
            else if (firstSymbol == 49)
            {
                hundreds = Ones(firstSymbol) + " simtas " + Tens(secondSymbol, thirdSymbol);
            }
            else
            {
                hundreds = Ones(firstSymbol) + " simtai " + Tens(secondSymbol, thirdSymbol);
            }
            return hundreds;
        }
        static string Thousands(int firstSymbol, int secondSymbol, int thirdSymbol, int fourthSymbol)
        {
            string thousands = "";
            if (firstSymbol == 48)
            {
                thousands = Hundreds(secondSymbol, thirdSymbol, fourthSymbol);
            }
            else if (firstSymbol == 49)
            {
                thousands = Ones(firstSymbol) + " tukstantis " + Hundreds(secondSymbol, thirdSymbol, fourthSymbol);
            }
            else
            {
                thousands = Ones(firstSymbol) + " tukstanciai " + Hundreds(secondSymbol, thirdSymbol, fourthSymbol);
            }
            return thousands;
        }
        static string TenThousands(int firstSymbol, int secondSymbol, int thirdSymbol, int fourthSymbol, int fifthSymbol)
        {
            string tenthousands = "";
            if (firstSymbol == 48)
            {
                tenthousands = Thousands(secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol);
            }
            else if (firstSymbol == 49)
            {
                tenthousands = Tens(firstSymbol, secondSymbol) + " tukstanciu " + Hundreds(thirdSymbol, fourthSymbol, fifthSymbol);
            }
            else
            {
                if (secondSymbol == 48)
                {
                    tenthousands = Tens(firstSymbol, secondSymbol) + "tukstanciu " + Hundreds(thirdSymbol, fourthSymbol, fifthSymbol);
                }
                else if (secondSymbol == 49)
                {
                    tenthousands = Tens(firstSymbol, secondSymbol) + " tukstantis " + Hundreds(thirdSymbol, fourthSymbol, fifthSymbol);
                }
                else
                {
                    tenthousands = Tens(firstSymbol, secondSymbol) + " tukstanciai " + Hundreds(thirdSymbol, fourthSymbol, fifthSymbol);
                }
            }
            return tenthousands;
        }
        static string HundredThousands(int firstSymbol, int secondSymbol, int thirdSymbol, int fourthSymbol, int fifthSymbol, int sixthSymbol)
        {
            string hundredThousands = "";
            if (firstSymbol == 48)
            {
                hundredThousands = TenThousands(secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol, sixthSymbol);
            }
            else if (firstSymbol == 49)
            {
                hundredThousands = Ones(firstSymbol) + " simtas " + TenThousands(secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol, sixthSymbol);
            }
            else
            {
                hundredThousands = Ones(firstSymbol) + " simtai " + TenThousands(secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol, sixthSymbol);
            }

            return hundredThousands;
        }
    }
}

