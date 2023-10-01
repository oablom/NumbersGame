// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;

class NumGameClass
{
    public static string MyMethod(int index, int guessesLeftIndex)
    {
        string guessesLeft;
        if (index >= guessesLeftIndex) {
            guessesLeft = "inga";
        }
        else
        {
             guessesLeft = (guessesLeftIndex - index).ToString();
        }

        string guessesLeftString = "\nDu har " + guessesLeft + " försök kvar";
        return guessesLeftString;
    }

    public static void MyGame(int roundNum, int maxNum)
    {

        Random randomAnswer = new Random();
        int number = randomAnswer.Next(1, maxNum);

        Random randomResponse = new Random();

        string[,] randomResponseArray = { { "Woohooo!!", "Snyggt!", "Sådärja!!" }, { "Ajdå,", "Synd,", "Ledsen," } };
        string[,] randomCloseResponseArray = { { "Nu bränns det!", "Du är rätt så nära nu.", "Nästan rätt ändå!" }, { "Du är långt ifrån rätt svar än.", "Du får nog gissa liite bättre!", "Bättre kan du!" } };

        for (int i = 0; i < roundNum; i++)
        {

          
            int randomResponseNum = randomResponse.Next(0, 3);
            
             
            Console.WriteLine($"Skriv in din gissning (ett heltal mellan 1-{maxNum}):");
            int input = int.Parse(Console.ReadLine());

            int differenceNum = input - number;
            if  (input-number < 1)
            {
                differenceNum = Math.Abs(differenceNum);
            }

            if (input == number)
            {
                Console.WriteLine($"{randomResponseArray[0, randomResponseNum]} Du klarade det!");
                break;
            }
            else if (input < number)
            {
                Console.WriteLine($"{randomResponseArray[1, randomResponseNum]} du gissade för lågt!");
                if (differenceNum < maxNum / 10)
                {
                    Console.WriteLine(randomCloseResponseArray[0, randomResponseNum]);
                }
                else
                {
                    Console.WriteLine(randomCloseResponseArray[1, randomResponseNum]);
                }
                Console.WriteLine(MyMethod(i, roundNum -1));
            
            }
            else if (input > number)
            {
                Console.WriteLine($"{randomResponseArray[1, randomResponseNum]} du gissade för högt!");
                if (differenceNum < maxNum / 10)
                {
                    Console.WriteLine(randomCloseResponseArray[0, randomResponseNum]);
                }
                else
                {
                    Console.WriteLine(randomCloseResponseArray[1, randomResponseNum]);
                }
                Console.WriteLine(MyMethod(i, roundNum - 1));
             


            }
        }
        Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!\n" +
            $"Det rätta svaret var {number}!\n\n");
        



    }

    static void Main(string[] args) {

        int levelInput = 0;

        bool playAgain = true;

        while ((levelInput != 1 && levelInput != 2 && levelInput != 3) || playAgain)

        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får några försök.");
            Console.WriteLine("Välj svårighetsgrad! \n" +
                "Nivå 1: talet du ska gissa är mellan 1-20 och du får 8 försök\n" +
                "Nivå 2: talet du ska gissa är mellan 1-50 och du får 6 försök\n" +
                "Nivå 3: talet du ska gissa är mellan 1-100 och du får 4 försök");
             levelInput = int.Parse(Console.ReadLine());

          
            
            if (levelInput == 1)
            {

                MyGame(8, 20);
            }
            else if (levelInput == 2)
            {
                MyGame(6, 50);
            }
            else if (levelInput == 3)
            {
                MyGame(4, 100);
            }
            Console.WriteLine("Vill du spela igen? ja/nej");
            string playAgainInput = Console.ReadLine();
            if (playAgainInput == "ja")
            {
                playAgain = true;
            } else
            {
                playAgain = false;
            }
        }


     


   


    }
}