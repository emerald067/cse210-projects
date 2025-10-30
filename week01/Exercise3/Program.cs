using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        string playAgain = "yes";
        while (playAgain == "yes")
        {
            int guess = -1;
            int numberOfGuesses = 0;
            while (guess != number)
            {
                if (guess != number)
                {
                    numberOfGuesses++;
                }
                Console.Write("What is your guess? ");
                string magicGuess = Console.ReadLine();
                guess = int.Parse(magicGuess);
                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You made {numberOfGuesses} guess(es). ");
                    Console.Write("Would you want to play again (yes/no)? ");
                    playAgain = Console.ReadLine();
                }
            }
        }
    }
}