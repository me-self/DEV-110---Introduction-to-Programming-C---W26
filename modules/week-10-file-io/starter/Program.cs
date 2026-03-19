/*******************************************************************************
 * Course: DEV 110
 * Instructor: Zak Brinlee
 * Term: Winter 2026
 *
 * Programmer: Samuel Bellemare
 * Assignment: Week 10: Habit Tracker (File I/O)
 *
 * What does this program do?:
 * A menu-driven Habit Tracker that loads habits from a CSV file and lets you
 * view, add, update, and save your habits back to disk.
 * ******************************************************************************/

using System.Globalization;

namespace HabitTracker;

/// <summary>
/// Main program class for the Habit Tracker application.
/// Your work this week: implement the eight TODO methods below.
/// The Main method, menu loop, and ReadIntInRange helper are fully provided.
/// </summary>
public class Program
{
    /// <summary>
    /// Entry point — prompts for file paths, loads habits, then runs the menu.
    /// Fully provided; no changes needed here.
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Habit Tracker: File I/O ===");
        Console.WriteLine();

        // Prompt for the path to the habits CSV file
        Console.Write("Enter habits file path: ");
        string path = (Console.ReadLine() ?? string.Empty).Trim();
        Console.WriteLine();

        // Load all habits (you will implement LoadHabits below)
        List<Habit> habits = LoadHabits(path);

        Console.WriteLine();

        // Menu loop — keeps running until the user chooses Save & Quit
        bool running = true;
        while (running)
        {
            Console.WriteLine("--- Menu ---");
            Console.WriteLine("1. View Habits");
            Console.WriteLine("2. View Summary");
            Console.WriteLine("3. Add Habit");
            Console.WriteLine("4. Update Habit");
            Console.WriteLine("5. Save & Quit");
            Console.Write("Choice (1-5): ");

            int choice = ReadIntInRange(1, 5);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    PrintHabits(habits);
                    break;
                case 2:
                    PrintSummary(habits);
                    break;
                case 3:
                    AddHabit(habits);
                    break;
                case 4:
                    UpdateHabit(habits);
                    break;
                case 5:
                    SaveHabits(path, habits);
                    running = false;
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }

    /// <summary>
    /// Collects a list of habits from the file at the given path.
    /// </summary>
    /// <param name="path">The path of the file to read from.</param>
    /// <returns>The list of collected habits.</returns>
    private static List<Habit> LoadHabits(string path)
    {
        List<Habit> habits = new List<Habit>();

        try
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                // If it's empty or null we just skip this line.
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');
                // Trim all parts.
                parts.Select(part => part.Trim());

                // If the line isn't in the expected format, we skip it.
                if (parts.Length != 3)
                {
                    Console.WriteLine($"Skipping invalid entry: \"{line}\"");
                    continue;
                }

                string name = parts[0];
                string status = parts[1];
                string frequency = parts[2];

                bool isCompleted = status.Equals("done", StringComparison.OrdinalIgnoreCase);

                Habit habit = new Habit(name, isCompleted, frequency);
                habits.Add(habit);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found — {path}");
        }

        return habits;
    }

    /// <summary>
    /// Prints all habits with a status marker.
    /// </summary>
    /// <param name="habits">The list of habits to print out.</param>
    private static void PrintHabits(List<Habit> habits)
    {
        Console.WriteLine("--- Your Habits ---");
        foreach (Habit habit in habits)
        {
            habit.DisplayInfo();
        }
    }

    /// <summary>
    /// Displays a summary of habit completion.
    /// </summary>
    /// <param name="habits">The habits from which to build the summary.</param>
    private static void PrintSummary(List<Habit> habits)
    {
        Console.WriteLine("--- Summary ---");

        // Get daily counts.
        int dailyTotal = habits.Count(h => h.Frequency == "daily");
        int dailyCompleted = habits.Count(h => h.Frequency == "daily" && h.IsCompleted);

        // Default to a full completion rate in the case of 0 tasks.
        float dailyRate = 1;
        if (dailyTotal != 0)
        {
            dailyRate = (float)dailyCompleted / dailyTotal; // Cast to float avoid truncation.
        }
        string dailyRateFormatted = (dailyRate * 100).ToString("F1", CultureInfo.InvariantCulture);

        // Get weekly counts.
        int weeklyTotal = habits.Count(h => h.Frequency == "weekly");
        int weeklyCompleted = habits.Count(h => h.Frequency == "weekly" && h.IsCompleted);

        // Default to a full completion rate in the case of 0 tasks.
        float weeklyRate = 1;
        if (weeklyTotal != 0)
        {
            weeklyRate = (float)weeklyCompleted / weeklyTotal; // Cast to float avoid truncation.
        }
        string weeklyRateFormatted = (weeklyRate * 100).ToString("F1", CultureInfo.InvariantCulture);

        const int LabelRegion = 10;
        string summaryFormat = $"{{0,-{LabelRegion}}} {{1,0}}/{{2,0}} completed ({{3,0}}%)";
        Console.WriteLine(summaryFormat, "Daily:", dailyCompleted, dailyTotal, dailyRateFormatted);
        Console.WriteLine(summaryFormat, "Weekly:", weeklyCompleted, weeklyTotal, weeklyRateFormatted);
    }

    /// <summary>
    /// Prompts the user for a name and frequency, then adds a new habit to the list.
    /// </summary>
    /// <param name="habits">The list in which to add the new habit.</param>
    private static void AddHabit(List<Habit> habits)
    {
        Console.WriteLine("--- Add Habit ---");

        // Prompt for a name until we get something more than whitespace.
        string name;
        do
        {
            Console.Write("Habit name: ");
            name = (Console.ReadLine() ?? "").Trim();
        }
        while (name == "");

        // Prompt until we get "D" or "W".
        string frequencyInput;
        do
        {
            Console.Write("Frequency ((D)aily or (W)eekly): ");
            frequencyInput = (Console.ReadLine() ?? "").Trim().ToUpper();

        }
        while (frequencyInput != "D" && frequencyInput != "W");

        // If it's not "D", it must be "W"
        string frequency = (frequencyInput == "D") ? "daily" : "weekly";

        // Create and add the habit.
        Habit habit = new Habit(name, false, frequency);
        habits.Add(habit);

        Console.WriteLine($"Added: {name} ({frequency})");
    }

    /// <summary>
    /// Prompts the user to select a habit. The completion status is toggled and the name is updated if provided.
    /// </summary>
    /// <param name="habits">The list of habits to offer to update.</param>
    private static void UpdateHabit(List<Habit> habits)
    {
        if (habits.Count() == 0)
        {
            Console.WriteLine("No habits to update.");
            return;
        }

        Console.WriteLine("--- Update Habit ---");

        // Print out the list of habits, numbered.
        for (int i = 0; i < habits.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {habits[i].Name}");
        }
        Console.Write("Enter habit number: ");
        int selection = ReadIntInRange(1, habits.Count) - 1;

        // Overwrite the existing habit name if a new name is provided.
        Console.Write($"New name (press Enter to keep \"{habits[selection].Name}\"): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            habits[selection].Name = newName.Trim();
        }

        habits[selection].IsCompleted = !habits[selection].IsCompleted;
        string newState = habits[selection].IsCompleted ? "completed" : "pending";
        Console.WriteLine($"Updated: {habits[selection].Name} — now {newState}");
    }

    /// <summary>
    /// Saves the provided habits to a file at the given path.
    /// </summary>
    /// <param name="path">The path at which to save the habits.</param>
    /// <param name="habits">The list of habits to save to the file.</param>
    private static void SaveHabits(string path, List<Habit> habits)
    {
        string[] lines = habits.Select(h => $"{h.Name},{(h.IsCompleted ? "done" : "pending")},{h.Frequency}").ToArray();
        File.WriteAllLines(path, lines);
        Console.WriteLine($"Habits saved to {path}.");
    }

    /// <summary>
    /// Reads an integer from the console, repeating until a valid value
    /// in [min, max] is entered. Fully provided — no changes needed.
    /// </summary>
    private static int ReadIntInRange(int min, int max)
    {
        while (true)
        {
            string line = (Console.ReadLine() ?? string.Empty).Trim();
            if (int.TryParse(line, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.Write($"Please enter a number between {min} and {max}: ");
        }
    }
}

