/*******************************************************************************
- Course: DEV 110
- Instructor: Zak Brinlee
- Term: Winter 2026
-
- Programmer: Samuel Bellemare
- Assignment: Week 7: Class Roster Builder (Arrays)
-
- What does this program do?:
- Builds a class roster using parallel arrays and a simple menu.
- */

namespace ClassRoster;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Class Roster ===");
        Console.WriteLine();

        const int ROSTER_CAPACITY = 3;

        string[] rosterNames = new string[ROSTER_CAPACITY];
        int[] rosterCredits = new int[ROSTER_CAPACITY];
        int count = 0;

        int choice = 0;
        while (choice != 4)
        {
            // Print the menu options (every loop)
            Console.WriteLine("1) Add multiple students");
            Console.WriteLine("2) Print class roster");
            Console.WriteLine("3) Print roster (sorted)");
            Console.WriteLine("4) Exit");

            choice = ReadIntInRange("Choose an option: ", 1, 4);

            switch (choice)
            {
                case 1:
                    // ===== OPTION 1: Add multiple students =====
                    if (count == ROSTER_CAPACITY)
                    {
                        Console.WriteLine("Roster is full. Cannot add more students.");
                        // Could use an `else`, but `break`ing here instead
                        // reduces nesting, making things more readable.
                        break;
                    }

                    // Get how many students should be added.
                    int remainingSlots = ROSTER_CAPACITY - count;
                    int studentsToAddCount = ReadIntInRange($"How many students do you want to add? (1-{remainingSlots}): ", 1, remainingSlots);

                    // Create entries for new new students.
                    string[] newNames = new string[studentsToAddCount];
                    int[] newCredits = new int[studentsToAddCount];
                    for (int i = 0; i < studentsToAddCount; i++)
                    {
                        Console.Write($"Enter name for student {i + 1}: ");
                        newNames[i] = Console.ReadLine();
                        newCredits[i] = ReadIntInRange($"Enter credits for {newNames[i]} (0-200): ", 0, 200);
                    }

                    // Add new student entries to the roster.
                    for (int i = 0; i < studentsToAddCount; i++)
                    {
                        // Index the roster starting at count (the first empty slot).
                        rosterNames[count + i] = newNames[i];
                        rosterCredits[count + i] = newCredits[i];
                    }
                    // Update the count now that we've added the entries to the roster.
                    count += studentsToAddCount;

                    // We're done now.
                    Console.WriteLine("Students added.");
                    break;
                case 2:
                    // ===== OPTION 2: Print class roster =====
                    if (count == 0)
                    {
                        Console.WriteLine("Roster is empty.");
                        // Could use an `else`, but `break`ing here instead
                        // reduces nesting, making things more readable.
                        break;
                    }

                    // Generate and print output.
                    string[] rosterLines = BuildRosterLines(rosterNames, rosterCredits, count);
                    Console.WriteLine("Class Roster:");
                    foreach (string rosterLine in rosterLines)
                    {
                        Console.WriteLine(rosterLine);
                    }

                    break;
                case 3:
                    // ===== OPTION 3: Print roster (sorted) =====
                    if (count == 0)
                    {
                        Console.WriteLine("Roster is empty.");
                        // Could use an `else`, but `break`ing here instead
                        // reduces nesting, making things more readable.
                        break;
                    }
                    Console.WriteLine("Sort by:");
                    Console.WriteLine("1) Name");
                    Console.WriteLine("2) Credits");
                    int sort_choice = ReadIntInRange("Choose an option: ", 1, 2);
                    string[] sortedNames;
                    int[] sortedCredits;
                    CopyUsedRoster(rosterNames, rosterCredits, count, out sortedNames, out sortedCredits);
                    switch (sort_choice)
                    {
                        case 1:
                            // Sort by name (case insensitive).
                            Array.Sort(sortedNames, sortedCredits, StringComparer.OrdinalIgnoreCase);
                            break;
                        case 2:
                            // Sort by credits.
                            Array.Sort(sortedCredits, sortedNames);
                            break;
                    }

                    Console.WriteLine("Class Roster (Sorted):");
                    foreach (string line in BuildRosterLines(sortedNames, sortedCredits, count))
                    {
                        Console.WriteLine(line);
                    }

                    break;
                case 4:
                    // ===== OPTION 4: Exit =====
                    Console.WriteLine("Goodbye.");
                    // We return so that we don't get a blank line.
                    return;
            }

            // Add a blank line between menu actions.
            Console.WriteLine();
        }
    }

    private static int ReadIntInRange(string prompt, int min, int max)
    {
        int value;
        bool isValid;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            isValid = int.TryParse(input, out value);
        }
        while (!isValid || value < min || value > max);

        return value;
    }


    private static string[] BuildRosterLines(string[] names, int[] credits, int count)
    {
        string[] roster_lines = new string[count];

        for (int i = 0; i < count; i++)
        {
            roster_lines[i] = $"{names[i]}: {credits[i]} credits";
        }

        return roster_lines;
    }

    private static void CopyUsedRoster(
        string[] sourceNames,
        int[] sourceCredits,
        int count,
        out string[] names,
        out int[] credits)
    {
        names = new string[count];
        credits = new int[count];

        for (int i = 0; i < count; i++)
        {
            names[i] = sourceNames[i];
            credits[i] = sourceCredits[i];
        }
    }
}
