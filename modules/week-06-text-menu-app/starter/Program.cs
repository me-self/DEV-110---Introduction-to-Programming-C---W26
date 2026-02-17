/*******************************************************************************
- Course: DEV 110
- Instructor: Zak Brinlee
- Term: Winter 2026
-
- Programmer: YourName
- Assignment: Week 6: Text Menu App
-
- What does this program do?:
- Runs a text-heavy menu app that demonstrates string formatting and output patterns.
- */

using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextMenuApp;

public class Program
{
    public static void Main(string[] args)
    {
        // Define banner components.
        string title = "Text Menu Studio";
        string subtitle = "Strings + Console Output Patterns";
        string divider = new string('=', 48);

        // Display the banner.
        Console.WriteLine($"{divider}\n{title.ToUpper()}\n{subtitle}\n{divider}");

        int choice = 0;

        while (choice != 6)
        {
            // TODO 3: Print the menu box
            // Required menu option texts (tests check for these):
            // - 1) Greeting Card
            // - 2) Name Tag Formatter
            // - 3) Phrase Analyzer
            // - 4) Fancy Receipt Line
            // - 5) Menu Banner Builder
            // - 6) Exit
            Console.WriteLine($"- 1) Greeting Card");
            Console.WriteLine($"- 2) Name Tag Formatter");
            Console.WriteLine($"- 3) Phrase Analyzer");
            Console.WriteLine($"- 4) Fancy Receipt Line");
            Console.WriteLine($"- 5) Menu Banner Builder");
            Console.WriteLine($"- 6) Exit");

            choice = ReadIntInRange("Choose an option (1-6): ", 1, 6);

            switch (choice)
            {
                case 1:
                    // Greeting card.
                    const int CONTENT_WIDTH = 80;
                    const string CARD_ROW = "║ {0} ║"; // A format string for rows of the card.
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine().Trim();
                    Console.Write("Enter a short message: ");
                    string shortMessage = Console.ReadLine();
                    string greeting = $"HI {name.ToUpper()}!";
                    string nameField = $"Name: {name}";
                    string messageField = $"Message: {shortMessage}";

                    // Display the card.
                    Console.WriteLine($"╔═{new string('═', CONTENT_WIDTH)}═╗");
                    Console.WriteLine(string.Format(CARD_ROW, ResizeWithEllipses(greeting, CONTENT_WIDTH)));
                    Console.WriteLine(string.Format(CARD_ROW, ResizeWithEllipses(nameField, CONTENT_WIDTH)));
                    Console.WriteLine(string.Format(CARD_ROW, ResizeWithEllipses(messageField, CONTENT_WIDTH)));
                    Console.WriteLine($"╚═{new string('═', CONTENT_WIDTH)}═╝");
                    break;
                case 2:
                    // Name tag formatter.
                    const int TAG_WIDTH = 42;
                    const string TAG_ROW = "[ {0} ]";
                    Console.Write("Enter first name: ");
                    string firstName = Console.ReadLine().Trim();
                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine().Trim();
                    string fullName = firstName + lastName;

                    // Get the first chars of the first an last name.
                    string upperInitials = new string([firstName[0], lastName[0]]).ToUpper();
                    string lowerInitials = upperInitials.ToLower();

                    Console.WriteLine(string.Format(TAG_ROW, ResizeWithEllipses($"Name: {fullName}", TAG_WIDTH)));
                    Console.WriteLine(string.Format(TAG_ROW, ResizeWithEllipses($"Initials: {upperInitials}", TAG_WIDTH)));
                    Console.WriteLine(string.Format(TAG_ROW, ResizeWithEllipses($"Lowercase: {lowerInitials}", TAG_WIDTH)));
                    break;
                case 3:
                    // Phrase analyzer.
                    Console.Write("Enter a phrase: ");
                    string phrase = Console.ReadLine().Trim();
                    bool containsA = phrase.ToLower().Contains('a');
                    string[] words = phrase.Split(' ');

                    // Print info about the phrase.
                    Console.WriteLine($"Length: {phrase.Length}");
                    Console.WriteLine($"Contains the letter 'a': {(containsA ? '✓' : '✗')}");
                    Console.WriteLine($"Dash seperated phrase: {phrase.Replace(' ', '-')}");
                    Console.WriteLine($"Word list: {string.Join(',', words)}");
                    break;
                case 4:
                    // Fancy Receipt Line.
                    Console.Write("Enter item name: ");
                    string itemName = ResizeWithEllipses(Console.ReadLine().Trim(), 20);
                    double itemPrice = ReadDouble("Enter price: ");
                    int itemQuantity = ReadIntInRange("Enter quantity (1-9): ", 1, 9);
                    double totalCost = itemPrice * itemQuantity;
                    string entry = string.Format("| {0, -20} {1, 4} {2, 11:C2} |", itemName, itemQuantity, totalCost);

                    // Display the receipt.
                    Console.WriteLine("+---------------------------------------+");
                    Console.WriteLine("| ITEM                QTY        TOTAL  |");
                    Console.WriteLine("+---------------------------------------+");
                    Console.WriteLine(entry);
                    Console.WriteLine("+---------------------------------------+");
                    break;
                case 5:
                    Console.Write("Enter a title: ");
                    string bannerTitle = Console.ReadLine().ToUpper();
                    Console.Write("Enter a subtitle: ");
                    string bannerSubtitle = Console.ReadLine();
                    int bannerWidth = ReadIntInRange("Enter width (30-60): ", 30, 60);

                    // Title and subtitle shouldn't exceed the width of our banner.
                    bannerTitle = ResizeWithEllipses(bannerTitle, bannerWidth);
                    bannerSubtitle = ResizeWithEllipses(bannerSubtitle, bannerWidth);

                    // Get the title and subtitle with various alignments.
                    string titleLeft = bannerTitle.PadRight(bannerWidth);
                    string subtitleLeft = bannerSubtitle.PadRight(bannerWidth);
                    int leftPaddingToCenter = (bannerWidth + bannerTitle.Length) / 2;
                    string titleCenter = bannerTitle.PadLeft(leftPaddingToCenter).PadRight(bannerWidth);
                    string subtitleCenter = bannerSubtitle.PadLeft(leftPaddingToCenter).PadRight(bannerWidth);
                    string titleRight = bannerTitle.PadLeft(bannerWidth);
                    string subtitleRight = bannerSubtitle.PadLeft(bannerWidth);
                    string horizontalBorder = new string('=', bannerWidth);

                    // Print left-aligned banner.
                    Console.WriteLine("Left: ");
                    Console.WriteLine($"|={horizontalBorder}=|");
                    Console.WriteLine($"| {titleLeft} |");
                    Console.WriteLine($"| {subtitleLeft} |");
                    Console.WriteLine($"|={horizontalBorder}=|");
                    Console.WriteLine();

                    // Print center-aligned banner.
                    Console.WriteLine("Centered: ");
                    Console.WriteLine($"|={horizontalBorder}=|");
                    Console.WriteLine($"| {titleCenter} |");
                    Console.WriteLine($"| {subtitleLeft} |");
                    Console.WriteLine($"|={horizontalBorder}=|");
                    Console.WriteLine();

                    // Print right-aligned banner.
                    Console.WriteLine("Right: ");
                    Console.WriteLine($"|={horizontalBorder}=|");
                    Console.WriteLine($"| {titleRight} |");
                    Console.WriteLine($"| {subtitleLeft} |");
                    Console.WriteLine($"|={horizontalBorder}=|");
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Enter a closing word: ");
                    string closingWord = Console.ReadLine();
                    bool isGoodbye = closingWord.Equals("goodbye", StringComparison.OrdinalIgnoreCase);

                    // Get the minimum of these since we might not have at least 3 chars.
                    int upToThree = int.Min(closingWord.Length, 3);
                    string firstThree = closingWord.Substring(0, upToThree);
                    bool endsWithExclaim = closingWord.EndsWith('!');
                    int firstSpaceIndex = closingWord.IndexOf(' ');
                    bool containsSpace = firstSpaceIndex != -1;

                    // Print the results of our operations.
                    Console.WriteLine("Said goodbye? {0}", isGoodbye ? "Yes" : "No");
                    Console.WriteLine($"First three characters: {firstThree}");
                    Console.WriteLine("Ended with an exclaimation mark? {0}", endsWithExclaim ? "Yes" : "No");
                    Console.WriteLine(containsSpace ? $"First space at index {firstSpaceIndex}" : "No spaces.");
                    Console.WriteLine("Goodbye!");

                    continue;
            }

            // Exit doesn't print a new line since it `continue`s.
            Console.WriteLine();
        }
    }

    // A helper function for getting strings of a specified length elegantly.
    private static string ResizeWithEllipses(string text, int targetLength)
    {
        const string ELLIPSES = "...";

        // Add any necessary whitespace.
        text = text.PadRight(targetLength);

        // If the string is longer than our target, we shrink down just small
        // enough to fit an ellipses.
        if (text.Length > targetLength)
        {
            text = text.Substring(0, targetLength - ELLIPSES.Length) + ELLIPSES;
        }

        return text;
    }

    private static int ReadIntInRange(string prompt, int min, int max)
    {
        bool isValid;
        int value;

        do
        {
            Console.Write(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);

            // If the input isn't an int or is out of range, we print a message
            // and loop again.
            if (!isValid || value < min || value > max)
            {
                Console.WriteLine($"Input must be a number from {min} to {max}.");
                isValid = false;
            }
        }
        while (!isValid);

        return value;
    }

    private static double ReadDouble(string prompt)
    {
        bool isValid;
        int value;

        // Get user input and keep looping until we get a double.
        do
        {
            Console.Write(prompt);
            isValid = int.TryParse(Console.ReadLine(), out value);
            if (!isValid)
            {
                Console.WriteLine("Input must be a number!");
            }
        }
        while (!isValid);
        return value;
    }
}
