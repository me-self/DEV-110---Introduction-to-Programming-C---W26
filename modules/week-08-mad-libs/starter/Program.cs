/*******************************************************************************
- Course: DEV 110
- Instructor: Zak Brinlee
- Term: Winter 2026
-
- Programmer: Samuel Bellemare
- Assignment: Week 8: Mad Libs (Structure + Debugging)
-
- What does this program do?:
- Runs a two-template Mad Libs app that practices structure and debugging.
- */

namespace MadLibs;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Mad Libs: Structure + Debugging ===");
        Console.WriteLine();

        bool playAgain;
        do
        {
            StoryTemplate template = ChooseTemplate();
            Console.WriteLine();

            string[] words = CollectWords(template);

            string story = template.GenerateStory(words);
            Console.WriteLine(story);
            Console.WriteLine();

            playAgain = ReadYesNo("Play again? (y/n): ");
            Console.WriteLine();
        }
        while (playAgain);
    }

    private static StoryTemplate ChooseTemplate()
    {
        Console.WriteLine("1) Debugging at the Zoo");
        Console.WriteLine("2) The Standup Meeting");
        int choice = ReadIntInRange("Choose a template (1-2): ", 1, 2);
        return choice == 1 ?
            new StoryTemplate(
                "Debugging at the Zoo",
                [
                    "Enter an adjective: ",
                    "Enter an animal (plural): ",
                    "Enter a verb ending in -ing: ",
                    "Enter a programming language: ",
                    "Enter a debugging tool (example: breakpoint): ",
                    "Enter a number: ",
                    "Enter an emotion: ",
                    "Enter an exclamation: "
                ],
                "Today I visited the silly zoo. I saw {1} {2} while writing {3}. I used a {4} {5} times until the bug disappeared. I felt {6} and yelled, \"{7}!\"")
        :
            new StoryTemplate(
                "The Standup Meeting",
                [
                    "Enter a name: ",
                    "Enter an adjective: ",
                    "Enter a noun: ",
                    "Enter a verb (past tense): ",
                    "Enter a number: ",
                    "Enter a plural noun: ",
                    "Enter a type of bug (example: null reference): ",
                    "Enter a snack: "
                ],
                "You and {0} were on your way to the {1} {2}'s meeting, but as you approached, you realized it {3} {4} times near {5}. Clearly, this was unusual, likely the result of a {6}, so with {7} by your side, you resolved it.");
    }

    private static string[] CollectWords(StoryTemplate template)
    {
        Logger.Info($"Collecting {template.Prompts.Length} words for: {template.Title}");

        // Storing the length in another variable just for cleaner access.
        int totalWordCount = template.Prompts.Length;

        string[] collectedWords = new string[totalWordCount];
        for (int i = 0; i < totalWordCount; i++)
        {
            collectedWords[i] = ReadNonEmptyString(template.Prompts[i]);
        }

        Console.WriteLine();
        return collectedWords;
    }

    private static bool ReadYesNo(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
        }
        while (input != "y" && input != "n");

        // Only other possibility is "n" since we were able to exit the loop.
        bool accepted = input == "y" ? true : false;
        return accepted;
    }

    private static int ReadIntInRange(string prompt, int min, int max)
    {
        bool isValid;
        int value;
        do
        {
            Console.Write(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);
        }

        // Loop if the input is invalid or out of range.
        while (!isValid || value < min || value > max);
        return value;
    }

    private static string ReadNonEmptyString(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = (Console.ReadLine() ?? string.Empty).Trim();
        }

        // Since we trim, this loops if the string was empty or just whitespace.
        while (input == string.Empty);
        return input;
    }
}
