namespace BodyBuddy;

public static class App
{
    public static void Run()
    {
        User currentUser = SelectUser();
        bool running = true;
        while (running)
        {
            Tui.WriteBold($"Current User: {currentUser.Name}\n");
            int selection = Tui.OptionsMenu([
                "Edit/Add a Measurement",
                "Display Ratios",
                "Switch User",
                ("<- Exit", ConsoleColor.DarkGray)]);
            switch (selection)
            {
                case 0:
                    Console.Clear();
                    ModifyMeasurements();
                    break;
                case 1:
                    Console.Clear();
                    DisplayRatios();
                    break;
                case 2:
                    Console.Clear();
                    currentUser = SelectUser();
                    continue;
                case 3:
                    if (Tui.ConfirmationPrompt("Are you sure you want to exit?"))
                    {
                        running = false;
                    }

                    break;
            }

            Console.Clear();
        }
    }

    private static User SelectUser()
    {
        List<User> users;
        if (File.Exists("users.txt"))
        {
            // Collect all non-empty usernames in the proper format.
            // Each entry should look like so:
            // `uuid: my user name`
            IEnumerable<string> userEntries = File.ReadAllLines("users.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Where(line => line.Split(':').Length == 2);
            users = userEntries.Select(line =>
            {
                string[] parts = line.Split(':');
                string id = parts[0].Trim();
                string name = parts[1].Trim();
                return new User(id, name);
            }).ToList();
        }
        else
        {
            users = [new User("Default User")];
        }

        User user = UserMenu.Show(ref users, (category, user) =>
        {
            if (category == ActionCategory.Remove)
            {
                File.Delete($"{user.ID}.txt");
            }

            File.WriteAllLines("users.txt", users.Select(user => user.AsFileEntry()).ToArray());
        });
        Console.Clear();
        Console.WriteLine($"Welcome {user.Name}!");
        return user;
    }

    private static float DynamicEntry(int menuTop, int entryIndent, int entryIndex)
    {
        bool isValid;
        float result;
        do
        {
            // Adding two spaces to account for the selection marker.
            Console.SetCursorPosition(2 + entryIndent, menuTop + entryIndex);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            string input = Console.ReadLine() ?? string.Empty;
            Console.ResetColor();
            isValid = float.TryParse(input, out result);
        }
        while (!isValid);
        return result;
    }

    private static void ModifyMeasurements()
    {
        float[] measurements = new float[5];

        while (true)
        {
            Tui.WriteBold("Editing Measurements\n");
            int menuTop = Console.CursorTop;
            MenuEntry[] optionsNoValues = [
                "Height: ",
                "Weight: ",
                "Wingspan: ",
                "Waist Circumference: ",
                "Hip Circumference: ",
                ("<- Back", ConsoleColor.DarkGray)
                ];

            // TODO: Create scrollable input boxes lined up with the menu entries.
            //ScrollEntry scrollEntry = new ScrollEntry(5, "Very Long Text");
            //scrollEntry.Focus();

            int selection = Tui.OptionsMenu(optionsNoValues);

            if (selection == optionsNoValues.Length - 1)
            {
                break;
            }

            measurements[selection] = DynamicEntry(menuTop, optionsNoValues[selection].Text.Length, selection);
            Console.Clear();
        }
    }

    private static void DisplayRatios()
    {
        Tui.WriteBold("Your Ratios\n");
        int selection = Tui.OptionsMenu([
            $"BMI: {Ratios.GetBmi(176, 69) ?? '*'}",
            $"BRI: {Ratios.GetBri(176, 32) ?? '*'}",
            $"WHR: Not Set",
            $"WHtR: Not Set",
            $"Ape Index: Not Set",
            ("<- Back", ConsoleColor.DarkGray)
            ]);
    }
}
