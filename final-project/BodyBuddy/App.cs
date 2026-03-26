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

    private static void ModifyMeasurements(User user)
    {
        double height;
        double weight;
        double wingspan;
        double waist;
        double hip;

        string userDataFilePath = $"{user.ID}.txt";
        if (File.Exists(userDataFilePath))
        {
            string[] lines = File.ReadAllLines(userDataFilePath);
            if (lines.Length >= 5)
            {
                height = double.Parse(lines[0]);
                weight = double.Parse(lines[1]);
                wingspan = double.Parse(lines[2]);
                waist = double.Parse(lines[3]);
                hip = double.Parse(lines[4]);
            }
        }
        MeasurementsMenu.Show();
    }

    private static void DisplayRatios(User user)
    {
        Tui.WriteBold("Your Ratios\n");
        int selection = Tui.OptionsMenu([
            $"BMI: {Ratios.GetBmi(176, 69) ?? '*'}",
            $"BRI: {Ratios.GetBri(69, 32) ?? '*'}",
            $"WHR: {Ratios.GetWhr(32, 41) ?? '*'}",
            $"WHtR: {Ratios.GetWhtr(69, 32) ?? '*'}",
            $"Ape Index: {Ratios.GetApeIndex(null, null) ?? '*'}",
            ("<- Back", ConsoleColor.DarkGray)
            ]);
    }
}
