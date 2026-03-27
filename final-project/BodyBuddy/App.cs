namespace BodyBuddy;

public static class App
{
    private const string _saveDir = "body_buddy_data";

    public static void Run()
    {
        PrepareEnvironment();

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
                    ModifyMeasurements(currentUser);
                    break;
                case 1:
                    Console.Clear();
                    DisplayRatios(currentUser);
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

    /// <summary>
    /// Creates and moves into the save directory.
    /// </summary>
    private static void PrepareEnvironment()
    {
        if (File.Exists(_saveDir))
        {
            Tui.WriteBold($"Could not create directory at {_saveDir}! File exists at this location.\n");
            if (Tui.ConfirmationPrompt("Would you like to delete the file?"))
            {
                File.Delete(_saveDir);
            }
            else
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }
        }

        Directory.CreateDirectory(_saveDir);
        Directory.SetCurrentDirectory(_saveDir);
    }

    private static User SelectUser()
    {
        string usersFilePath = "users.txt";

        List<User> users;
        if (File.Exists(usersFilePath))
        {
            // Collect all non-empty usernames in the proper format.
            // Each entry should look like so:
            // `uuid: my user name`
            IEnumerable<string> userEntries = File.ReadAllLines(usersFilePath)
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

            File.WriteAllLines(usersFilePath, users.Select(user => user.AsFileEntry()).ToArray());
        });
        Console.Clear();
        Console.WriteLine($"Welcome {user.Name}!");
        return user;
    }

    private static void ModifyMeasurements(User user)
    {
        UserData userData = new UserData();

        string userDataFilePath = $"{user.ID}.txt";
        if (File.Exists(userDataFilePath))
        {
            string[] lines = File.ReadAllLines(userDataFilePath);
            if (lines.Length >= 5)
            {
                userData.Height = double.Parse(lines[0]);
                userData.Weight = double.Parse(lines[1]);
                userData.Wingspan = double.Parse(lines[2]);
                userData.Waist = double.Parse(lines[3]);
                userData.Hip = double.Parse(lines[4]);
            }
        }

        MeasurementsMenu.Show(ref userData, () =>
        {
            File.WriteAllLines(userDataFilePath, userData.AsLines());
        });
    }

    private static void PrintRatio(string label, double? ratio)
    {
        Console.Write($"{label}: ");
        if (ratio.HasValue)
        {
            Console.WriteLine(ratio.Value);
        }
        else
        {
            Console.WriteLine("");
        }
    }

    private static void DisplayRatios(User user)
    {
        Tui.WriteBold("Your Ratios\n");
        int selection = Tui.OptionsMenu([
            $"BMI: {Ratios.GetBmi(176, 69)}",
            $"BRI: {Ratios.GetBri(69, 32)?.ToString() ?? "..."}",
            $"WHR: {Ratios.GetWhr(32, 41)?.ToString() ?? "..."}",
            $"WHtR: {Ratios.GetWhtr(69, 32)?.ToString() ?? "..."}",
            $"Ape Index: {Ratios.GetApeIndex(null, null)?.ToString() ?? "..."}",
            ("<- Back", ConsoleColor.DarkGray)
            ]);
    }
}
