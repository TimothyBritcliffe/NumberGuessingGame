using System.Runtime.InteropServices;

namespace NumberGuessingGame;

class Program
{
    static void Main(string[] args)
    {

        bool iter = true;
        
        Random random = new();
        int num = random.Next(1000);
        
        Console.WriteLine("Guess the number between 0 and 999.");
        int guessNumber;
        while (iter)
        {
            string guess = Console.ReadLine();

            try
            {
                guessNumber = Int32.Parse(guess);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Must input an integer.");
                continue;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Input too large.");
                continue;
            }
            catch  (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            iter = GameLogic(guessNumber, num);
        }
        
    }

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