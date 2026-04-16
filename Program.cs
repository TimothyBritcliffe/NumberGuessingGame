using System.Runtime.InteropServices;

namespace NumberGuessingGame;

class Program
{
    static void Main(string[] args)
    {
        
        //Variable Initialization (for the loop, random number, and the users guess)
        bool iter = true;
        
        Random random = new();
        int num = random.Next(1000);
        
        int guessNumber;
        
        
        Console.WriteLine("Guess the number between 0 and 999.");

        //Main game loop that runs until the users input matches the randomly generated number
        while (iter)
        {
            string guess = Console.ReadLine();

            try
            {
                guessNumber = Int32.Parse(guess);
            }
            //If the input is not an integer
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Must input an integer.");
                continue;
            }
            //If the input is too big
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Input too large.");
                continue;
            }
            //General catch for any other non-specific runtime errors
            catch  (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            
            iter = GameLogic(guessNumber, num);
        }
        
    }

    //Game logic for comparing the guessNumber and random number (num); returns true or false depending on whether the user needs to make another guess or if the game is over
    private static bool GameLogic(int guessNumber, int num)
    {
        if (guessNumber == num)
        {
            Console.WriteLine("Number guessed correctly!!");
            return false;
        }
        else
        {
            Console.WriteLine("Wrong!");
            if (guessNumber < num)
            {
                Console.WriteLine($"Guess higher!");
            }
            else
            {
                Console.WriteLine($"Guess lower!");
            }
            return true;
        }
    }
}