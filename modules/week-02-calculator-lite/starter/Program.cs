using System.IO.Compression;

namespace CalculatorLite;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Calculator Lite ===\n");

        // Get the user's name and greet them.
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"\nHello, {userName}!");

        // Get number preference from the user.
        Console.Write("Use decimal precision? (yes/no): ");
        string decimalPrecisionChoice = Console.ReadLine().ToLower();
        bool useDecimalPrecision = decimalPrecisionChoice == "y" || decimalPrecisionChoice == "yes";

        // Get numbers from the user.
        double firstNum = GetInputNumber("\nEnter your first number: ", useDecimalPrecision);
        double secondNum = GetInputNumber("\nEnter your second number: ", useDecimalPrecision);

        // Newline for stylistic purposes.
        Console.WriteLine();

        // Store our results since they're used in two places.
        double sum = firstNum + secondNum;
        double difference = firstNum - secondNum;
        double product = firstNum * secondNum;
        double average = (firstNum + secondNum) / 2;
        // Initialize these all to zero by default in case we can't calculate them.
        double quotient = 0;
        double remainder = 0;
        double percentage_difference = 0;

        // There's a minimum of four calculations.
        int totalCalculations = 4;

        // Calculate these if there's no division by zero.
        if (secondNum != 0)
        {
            quotient = firstNum / secondNum;
            remainder = firstNum % secondNum;
            totalCalculations += 2;
        }
        if (firstNum != 0)
        {
            percentage_difference = (firstNum - secondNum) / firstNum * 100;
            totalCalculations++;
        }

        // Display equations and results.
        if (useDecimalPrecision)
        {
            Console.WriteLine($"Sum: {firstNum:F2} + {secondNum:F2} = {sum:F2}");
            Console.WriteLine($"Difference: {firstNum:F2} - {secondNum:F2} = {difference:F2}");
            Console.WriteLine($"Product: {firstNum:F2} * {secondNum:F2} = {product:F2}");

            // Check to make sure this wasn't a division by zero.
            if (secondNum != 0)
            {
                Console.WriteLine($"Quotient: {firstNum:F2} / {secondNum:F2} = {quotient:F2}");
                Console.WriteLine($"Remainder: {firstNum:F2} % {secondNum:F2} = {remainder:F2}");
            }
            else
            {
                Console.WriteLine("Quotient: Cannot divide by zero");
                Console.WriteLine("Remainder: Cannot divide by zero");
            }

            Console.WriteLine($"Average: ({firstNum:F2} + {secondNum:F2}) / 2.00 = {average:F2}");

            // Check to make sure this wasn't a division by zero.
            if (firstNum != 0)
            {
                Console.WriteLine($"Percentage difference: ({firstNum:F2} - {secondNum:F2}) / {firstNum:F2} * 100.00 = {percentage_difference:F2}%");
            }
            else
            {
                Console.WriteLine("Percentage difference: Cannot divide by zero");
            }
        }
        else
        {
            Console.WriteLine($"Sum: {firstNum:F0} + {secondNum:F0} = {sum:F0}");
            Console.WriteLine($"Difference: {firstNum:F0} - {secondNum:F0} = {difference:F0}");
            Console.WriteLine($"Product: {firstNum:F0} * {secondNum:F0} = {product:F0}");

            // Check to make sure this wasn't a division by zero.
            if (secondNum != 0)
            {
                Console.WriteLine($"Quotient: {firstNum:F0} / {secondNum:F0} = {quotient:F0}");
                Console.WriteLine($"Remainder: {firstNum:F0} % {secondNum:F0} = {remainder:F0}");
            }
            else
            {
                Console.WriteLine("Quotient: Cannot divide by zero");
                Console.WriteLine("Remainder: Cannot divide by zero");
            }

            Console.WriteLine($"Average: ({firstNum:F0} + {secondNum:F0}) / 2 = {average:F0}");

            // Check to make sure this wasn't a division by zero.
            if (firstNum != 0)
            {
                Console.WriteLine($"Percentage difference: ({firstNum:F0} - {secondNum:F0}) / {firstNum:F0} = {percentage_difference:F0}%");
            }
            else
            {
                Console.WriteLine("Percentage difference: Cannot divide by zero");
            }
        }

        Console.WriteLine($"\nPerformed {totalCalculations} calculations for {userName}!");

        Console.WriteLine("\nThank you for using Calculator Lite!");
    }

    // Helper function since we do the same thing twice.
    static double GetInputNumber(string prompt, bool precise, int attempts = 0)
    {
        // If we failed to parse we display a hint.
        if (attempts > 0)
        {
            if (precise)
            {
                Console.WriteLine("Invalid input. Input must be a number!");
            }
            else
            {
                // Slightly more specific hint for this.
                Console.WriteLine("Invalid input. Input must be an integer!");
            }
        }
        Console.Write(prompt);
        if (precise)
        {
            double number;
            bool parseSuccess = double.TryParse(Console.ReadLine(), out number);
            // If parsing succeeds, we return number, otherwise we try again.
            return parseSuccess ? number : GetInputNumber(prompt, precise, attempts + 1);
        }
        // > If no decimals: use int.Parse() then cast to double
        //
        // Only accept integers if the user didn't enable the precise option.
        // Hoping I understood that correctly.
        else
        {
            int number;
            bool parseSuccess = int.TryParse(Console.ReadLine(), out number);
            // No need to check for the second parse, this int -> double shouldn't fail.
            return parseSuccess ? (double)number : GetInputNumber(prompt, precise, attempts + 1);
        }
    }
}
