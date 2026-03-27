namespace BodyBuddy;

public static class App
{
    private const string _saveDir = "body_buddy_data";

    public static void Run()
    {
        PrepareEnvironment();

        User currentUser = SelectUser();
        bool running = true;
        int selection = 0;
        while (running)
        {
            Tui.WriteBold($"Current User: {currentUser.Name}\n");
            selection = Tui.OptionsMenu(
                ["Edit/Add a Measurement",
                "Display Ratios",
                "Switch User",
                ("<- Exit", ConsoleColor.DarkGray)],
                selection);
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
        const string usersFilePath = "users.txt";

        List<User> users;
        if (File.Exists(usersFilePath))
        {
            // Collect all non-empty usernames in the proper format.
            // Each entry should look like so:
            // `uuid: my username`
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

            File.WriteAllLines(usersFilePath, users.Select(u => u.AsFileEntry()).ToArray());
        });
        Console.Clear();
        Console.WriteLine($"Welcome {user.Name}!");
        return user;
    }

    private static UserData GetUserData(User user)
    {
        var userData = new UserData();

        string userDataFilePath = $"{user.ID}.txt";
        if (!File.Exists(userDataFilePath))
        {
            return userData;
        }

        string[] lines = File.ReadAllLines(userDataFilePath);
        if (lines.Length < 5)
        {
            return userData;
        }

        userData.Height = double.TryParse(lines[0], out double height) ? height : null;
        userData.Weight = double.TryParse(lines[1], out double weight) ? weight : null;
        userData.Wingspan = double.TryParse(lines[2], out double wingspan) ? wingspan : null;
        userData.Waist = double.TryParse(lines[3], out double waist) ? waist : null;
        userData.Hip = double.TryParse(lines[4], out double hip) ? hip : null;

        return userData;
    }

    private static void ModifyMeasurements(User user)
    {
        UserData userData = GetUserData(user);

        MeasurementsMenu.Show(ref userData, () =>
        {
            File.WriteAllLines($"{user.ID}.txt", userData.AsLines());
        });
    }

    private static string FormatRatio(double? ratio, string fallback)
    {
        return ratio.HasValue ? ratio.Value.ToString("F2") : fallback;
    }

    private static void DisplayRatios(User user)
    {
        UserData userData = GetUserData(user);

        double? bmi = Ratios.GetBmi(userData.Weight, userData.Height);
        double? bri = Ratios.GetBri(userData.Height, userData.Waist);
        double? whr = Ratios.GetWhr(userData.Waist, userData.Hip);
        double? whtr = Ratios.GetWhtr(userData.Height, userData.Waist);
        double? apeIndex = Ratios.GetApeIndex(userData.Height, userData.Wingspan);

        Tui.WriteBold("Your Ratios\n");
        Tui.OptionsMenu([
            $"BMI: {FormatRatio(bmi, "requires height and weight")}",
            $"BRI: {FormatRatio(bri, "requires height and waist")}",
            $"WHR: {FormatRatio(whr, "requires waist and hip")}",
            $"WHtR: {FormatRatio(whtr, "requires height and waist")}",
            $"Ape Index: {FormatRatio(apeIndex, "requires height and wingspan")}",
            ("<- Back", ConsoleColor.DarkGray)
            ]);
    }
}
