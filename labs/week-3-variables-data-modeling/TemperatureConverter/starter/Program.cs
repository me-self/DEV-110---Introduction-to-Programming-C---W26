namespace TemperatureConverter;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=== Temperature Converter ===\n");

        Console.WriteLine("Enter your name: ");
        string userName = Console.ReadLine();

        Console.WriteLine($"Hello, {userName}! Let's convert some temperatures.");

        Console.WriteLine("Show detailed calculations? (yes/no): ");
        string detailChoice = Console.ReadLine().ToLower();
        bool showDetails = detailChoice == "yes" || detailChoice == "y";

        Console.WriteLine("Enter a temperature value: ");
        double inputTemp = double.Parse(Console.ReadLine());

        Console.WriteLine("Is this temperature in (C)elsius or (F)ahrenheit? ");
        string conversionChoice = Console.ReadLine().ToUpper();

        int conversionCount = 0;

        Console.WriteLine("\n=== Conversion Results ===\n");

        // If the user has indicated they are providing a temperature in celsius.
        if (conversionChoice == "C" || conversionChoice == "CELSIUS")
        {
            double convertedTemp = (inputTemp * 9d / 5d) + 32d;

            conversionCount++;

            Console.WriteLine($"Temperature in Celsius: {inputTemp:F2}°C");
            Console.WriteLine($"Temperature in Fahrenheit: {convertedTemp:F2}°F");

            if (showDetails)
            {
                Console.WriteLine("\nFormula used: F = C * 9/5 + 32");
                Console.WriteLine($"Calculation: {inputTemp:F2} * 9/5 + 32 = {convertedTemp:F2}");
            }

            Console.WriteLine("\n=== Temperature Analysis ===\n");

            double diffFromFreezing = inputTemp;
            double diffFromBoiling = 100d - inputTemp;
            Console.WriteLine($"Difference from water freezing point (0°C): {diffFromFreezing:F2}°C");
            Console.WriteLine($"Difference from water boiling point (100°C): {diffFromBoiling:F2}°C");

            if (inputTemp < 0)
            {
                Console.WriteLine("Status: below freezing (water is ice)");
            }
            else if (inputTemp < 100) // We know it is at least 0.
            {
                Console.WriteLine("Status: between freezing and boiling (water is liquid)");
            }
            else
            {
                Console.WriteLine("Status: Above boiling (water is steam)");
            }
        }
        else if (conversionChoice == "F" || conversionChoice == "FAHRENHEIT")
        {
            double convertedTemp = (inputTemp - 32) * 5d / 9d;

            conversionCount++;

            Console.WriteLine($"Temperature in Fahrenheit: {inputTemp:F2}°F");
            Console.WriteLine($"Temperature in Celsius: {convertedTemp:F2}°C");

            if (showDetails)
            {
                Console.WriteLine("\nFormula used: C = (F - 32) * 5/9");
                Console.WriteLine($"Calculation: ({inputTemp:F2} - 32) * 5/9 = {convertedTemp:F2}");
            }

            Console.WriteLine("\n=== Temperature Analysis ===\n");

            double diffFromFreezing = inputTemp - 32d;
            double diffFromBoiling = 212d - inputTemp;
            Console.WriteLine($"Difference from water freezing point (32°F): {diffFromFreezing:F2}°F");
            Console.WriteLine($"Difference from water boiling point (212°F): {diffFromBoiling:F2}°F");

            if (inputTemp < 32)
            {
                Console.WriteLine("Status: below freezing (water is ice)");
            }
            else if (inputTemp < 212) // We know it is at least 32.
            {
                Console.WriteLine("Status: between freezing and boiling (water is liquid)");
            }
            else
            {
                Console.WriteLine("Status: Above boiling (water is steam)");
            }


            // TODO: Calculate differences from water phase-change points
            // 1. Difference from freezing (32°F)
            // 2. Difference from boiling (212°F)


            // TODO: Determine water state based on temperature
            // Use if/else to check temperature ranges:
            // - Below 32°F: "Below freezing (water is ice)"
            // - Between 32°F and 212°F: "Between freezing and boiling (water is liquid)"
            // - Above 212°F: "Above boiling (water is steam)"

        }
        else
        {
            Console.WriteLine("Invalid unit! Enter 'C' for celsius or 'F' for fahrenheit.");
            conversionCount = 0;
        }

        if (conversionCount > 0)
        {
            Console.WriteLine($"\nPerformed {conversionCount} temperature conversion(s) for {userName}!");
        }

        Console.WriteLine("Thank you for using Temperature Converter!");
    }
}
