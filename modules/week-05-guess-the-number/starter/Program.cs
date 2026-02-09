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

            // Keep prompting the user for guesses until their guess is correct.
            while (guess != secret)
            {
                guess = ReadIntInRange($"Guess a number (1-{maxValue}): ", 1, maxValue);

                // Once we've got a new guess submitted we can increment our
                // guess counter now so it's up to date if the player wins.
                guessCount++;

                // Give feedback on the guess.
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

    // Repeatedly prompts the user with `prompt` from an int from `min` to `max`
    // until a valid, in range int is provided.
    private static int ReadIntInRange(string prompt, int min, int max)
    {
        int value;
        bool isValid;

        // Loop if parsing failed or the value is out of range.
        do
        {
            Console.Write(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);
        }
        while (!isValid || value < min || value > max);

        return value;
    }
}
