namespace ProfileCard;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║         STUDENT PROFILE CARD               ║");
        Console.WriteLine("╚════════════════════════════════════════════╝\n");

        const int CURRENT_YEAR = 2026;

        // Request some personal info.
        Console.WriteLine("To create your profile card, we'll need a bit of personal information.");
        Console.Write("Enter your full name: ");
        string fullName = Console.ReadLine();
        Console.Write("Enter your hometown (city, state): ");
        string homeTown = Console.ReadLine();
        Console.Write("Enter your favorite color: ");
        string favoriteColor = Console.ReadLine();
        Console.Write("Enter your dream job: ");
        string dreamJob = Console.ReadLine();

        // Just a bit of spacing.
        Console.WriteLine();

        // Request some academic info.
        Console.WriteLine("We'll also need some of your academic information.");
        Console.Write("Enter your major: ");
        string major = Console.ReadLine();
        Console.Write("Enter your GPA: ");
        double gpa;

        // Keep prompting until TryParse succeeds and the GPA is in the desired
        // range.
        while (!(double.TryParse(Console.ReadLine(), out gpa) && gpa >= 0 && gpa <= 4))
        {
            Console.WriteLine("Invalid input. GPA must be a number from 0 to 4!");
            Console.Write("Enter your GPA: ");
        }

        Console.Write("Enter your graduation year: ");
        int graduationYear;

        // Keep prompting until TryParse succeeds and we have a positive
        // graduation year.
        while (!(int.TryParse(Console.ReadLine(), out graduationYear) && graduationYear >= 0))
        {
            Console.WriteLine("Invalid input. Year must be a whole number!");
            Console.Write("Enter your graduation year: ");
        }

        bool isFullTimeStudent;
        while (true)
        {
            // Ask if the user is a full-time student then try matching it to a bool.
            Console.Write("Are you a full-time student? (y/n): ");
            switch (Console.ReadLine().ToLower())
            {
                // Accept either "y" or "yes".
                case "yes":
                case "y":
                    isFullTimeStudent = true;
                    break;

                // Accept either "n" or "no".
                case "no":
                case "n":
                    isFullTimeStudent = false;
                    break;
                default:
                    Console.WriteLine("Invalid response. Must be (y)es or (n)o!");

                    // Skip to the next iteration of the loop to try again.
                    continue;
            }

            // If we broke out of the switch, rather than skipping to the next
            // iteration can we exit.
            break;
        }

        // Just a bit of spacing.
        Console.WriteLine();

        // Request a few more details.
        Console.WriteLine("Almost there! We just a few more details.");
        Console.Write("Enter your age: ");
        int age;

        // Keep prompting until TryParse succeeds and the age is positive.
        // Don't want to make too many assumptions here, so we just check that
        // the person is at least born.
        while (!(int.TryParse(Console.ReadLine(), out age) && age >= 0))
        {
            Console.WriteLine("Invalid input. Year must be a whole number!");
            Console.Write("Enter your age: ");
        }

        Console.Write("Enter your height (inches): ");
        double heightInches;

        // Keep prompting until TryParse succeeds and (making the bold
        // assumption) that height is at least 1 inch. ;)
        while (!(double.TryParse(Console.ReadLine(), out heightInches) && heightInches >= 1))
        {
            Console.WriteLine("Invalid input. Must be a whole number of at least 1!");
            Console.Write("Enter your height (inches): ");
        }

        Console.Write("Enter your favorite number: ");
        int favoriteNumber;

        // Keep prompting until TryParse succeeds. Your favorite number can be
        // negative, that's ok. :)
        while (!int.TryParse(Console.ReadLine(), out favoriteNumber))
        {
            Console.WriteLine("Invalid input. Your favorite number must be an integer!");
            Console.Write("Enter your favorite number: ");
        }

        // Calculate additional info.
        int birthYear = CURRENT_YEAR - age;
        int yearsToGraduation = graduationYear - CURRENT_YEAR;
        (int, double) feetAndInchesTall = ((int)(heightInches / 12), heightInches % 12);
        bool isHonorStudent = gpa >= 3.5;
        int monthsOld = age * 12;

        // Display the profile card.
        // Get the biggest string length supplied by the user.
        int maxUserStringLength = int.Max(
            int.Max(
            int.Max(
            int.Max(
            fullName.Length,
            homeTown.Length),
            favoriteColor.Length),
            dreamJob.Length),
            major.Length);

        // Adding 20 chars just so we have space to print labels.
        int contentWidth = int.Max(30, 20 + maxUserStringLength);
        Console.Write("╔═");

        // Draw border based on content width.
        for (int i = 0; i < contentWidth; i++)
        {
            Console.Write("═");
        }

        Console.WriteLine("═╗");

        WriteCardLine($"{fullName.ToUpper()}'S PROFILE CARD", contentWidth);
        WriteCardSeperator(contentWidth);

        WriteCardLine("PERSONAL INFORMATION", contentWidth);
        WriteCardLine($"Name: {fullName}", contentWidth);
        WriteCardLine($"Home town: {homeTown}", contentWidth);
        WriteCardLine($"Favorite color: {favoriteColor}", contentWidth);
        WriteCardLine($"Dream job: {dreamJob}", contentWidth);
        WriteCardLine($"Age: {age}", contentWidth);
        WriteCardLine($"Height: {heightInches} in.", contentWidth);
        WriteCardLine($"Favorite number: {favoriteNumber}", contentWidth);
        WriteCardSeperator(contentWidth);

        WriteCardLine("ACADEMIC DETAILS", contentWidth);
        WriteCardLine($"Major: {major}", contentWidth);
        WriteCardLine($"GPA: {gpa:F2}", contentWidth);
        WriteCardLine($"Graduation year: {graduationYear}", contentWidth);
        WriteCardLine(isFullTimeStudent ? "Full time student" : "Part time student", contentWidth);
        WriteCardSeperator(contentWidth);

        WriteCardLine("CALCULATED STATISTICS", contentWidth);
        WriteCardLine($"Birth year: {birthYear}", contentWidth);
        WriteCardLine($"Years to graduation: {yearsToGraduation}", contentWidth);
        WriteCardLine($"Height: {feetAndInchesTall.Item1} ft. {feetAndInchesTall.Item2:F2} in.", contentWidth);
        WriteCardLine($"Honor student: {(isHonorStudent ? "Yes ✓" : "No ✗")}", contentWidth);
        WriteCardLine($"Months old: {monthsOld}", contentWidth);

        Console.Write("╚═");

        // Draw border based on content width.
        for (int i = 0; i < contentWidth; i++)
        {
            Console.Write("═");
        }

        Console.WriteLine("═╝");
        Console.WriteLine("Profile complete! Good luck with your studies!");
    }

    // Helper function for padding and adding borders when printing.
    private static void WriteCardLine(string text, int contentWidth)
    {
        Console.Write("║ ");
        Console.Write(text.PadRight(contentWidth));
        Console.WriteLine(" ║");
    }

    // Helper function for drawing lines seperating segments of the card.
    private static void WriteCardSeperator(int contentWidth)
    {
        Console.Write("║═");
        for (int i = 0; i < contentWidth; i++)
        {
            Console.Write("═");
        }

        Console.WriteLine("═║");
    }
}
