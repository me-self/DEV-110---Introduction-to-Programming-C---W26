namespace GuessTheNumber;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Guess the Number: Loop Trio ===\n");

        // Maximum possible random value.
        int maxValue = ReadIntInRange("Enter a max value (10-100): ", 10, 100);

        // Total number of rounds.
        int rounds = ReadIntInRange("How many rounds? (1-3): ", 1, 3);

        for (int round = 1; round <= rounds; round++)
        {
            Console.WriteLine($"\nRound {round} of {rounds}");

            // The seed (and in turn, the secret) is predictable across games.
            // Is this intentional, or should we be using time in the seed?
            Random random = new Random(maxValue + round);
            int secret = random.Next(1, maxValue + 1);

            int guess = 0;
            int guessCount = 0;

            while (guess != secret)
            {
                guess = ReadIntInRange($"Guess a number (1-{maxValue}): ", 1, maxValue);

                guessCount++;
                if (guess < secret)
                {
                    Console.WriteLine("Too low.");
                }
                else if (guess > secret)
                {
                    Console.WriteLine("Too high.");
                }
                else
                {
                    Console.WriteLine($"Correct! You got it in {guessCount} guesses.");
                }
            }
        }

        Console.WriteLine("Thanks for playing!");
    }

    private static int ReadIntInRange(string prompt, int min, int max)
    {
        int value;
        bool isValid;

        do
        {
            Console.Write(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);
        }

        // Loop if parsing failed or the value is out of range.
        while (!isValid || value < min || value > max);
        return value;
    }
}
