namespace BodyBuddy;

using PostSelectFunc = System.Action<BodyBuddy.ActionCategory, BodyBuddy.User>;

public enum ActionCategory
{
    Add,
    Rename,
    Remove,
}

/// <summary>
/// This menu allows the user to modify and select from a list of users.
/// </summary>
public static class UserMenu
{
    /// <summary>
    /// Displays the user menu.
    /// </summary>
    /// <param name="users">The list of users to operate on.</param>
    /// <param name="postActionUpdate">A function called after each action.</param>
    /// <returns></returns>
    public static User Show(ref List<User> users, PostSelectFunc? postSelectUpdate = null)
    {
        int selection = 0;
        while (true)
        {
            Tui.WriteBold("Select a User:\n");

            MenuEntry[] userManagementOptions = [
                ("+ Add a New User", ConsoleColor.DarkGreen),
                ("/ Rename Users", ConsoleColor.DarkYellow),
                ("- Remove Users", ConsoleColor.DarkRed),
                ("<- Exit", ConsoleColor.DarkGray)
                ];
            IEnumerable<MenuEntry> userMenuOptions = users.Select(user => new MenuEntry(user.Name));
            userMenuOptions = userMenuOptions.Concat(userManagementOptions);

            selection = Tui.OptionsMenu(userMenuOptions.ToArray(), selection);

            // These options all come after the user options.
            int addUserIndex = userMenuOptions.Count() - 4;
            int renameUserIndex = userMenuOptions.Count() - 3;
            int removeUserIndex = userMenuOptions.Count() - 2;
            int exitIndex = userMenuOptions.Count() - 1;

            if (selection < users.Count())
            {
                return users[selection];
            }
            else if (selection == addUserIndex)
            {
                AddUser(ref users, postSelectUpdate);
            }
            else if (selection == renameUserIndex)
            {
                RenameUser(ref users, postSelectUpdate);
            }
            else if (selection == removeUserIndex)
            {
                RemoveUser(ref users, postSelectUpdate);
            }
            else if (selection == exitIndex)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Option not implemented!");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }

            Console.Clear();
        }
    }

    private static void AddUser(ref List<User> users, PostSelectFunc? postSelectUpdate = null)
    {
        string newUserName;
        do
        {
            Console.Clear();
            Tui.WriteBold("Adding a New User\n");
            Console.Write("Enter the new user's name: ");
            newUserName = Console.ReadLine() ?? string.Empty;
        }
        while (string.IsNullOrWhiteSpace(newUserName));
        newUserName = newUserName.Trim();
        users.Add(new User(newUserName));
        postSelectUpdate?.Invoke(ActionCategory.Add, users.Last());
    }

    private static void RenameUser(ref List<User> users, PostSelectFunc? postSelectUpdate = null)
    {
        int selection = 0;
        while (true)
        {
            Console.Clear();
            Tui.WriteBold("Renaming Users\n");
            MenuEntry[] options = users.Select(user => { return new MenuEntry(user.Name, ConsoleColor.Yellow); }).ToArray();
            options = options.Append(("<- Go Back", ConsoleColor.DarkGray)).ToArray();
            selection = Tui.OptionsMenu(options, selection);

            // User wants to go back.
            if (selection == users.Count)
            {
                return;
            }

            User user = users[selection];

            Console.Write($"Renaming {user.Name}. Enter a new name: ");
            string newName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(newName))
            {
                user.Name = newName.Trim();
            }

            postSelectUpdate?.Invoke(ActionCategory.Rename, user);
        }
    }

    private static void RemoveUser(ref List<User> users, PostSelectFunc? postSelectUpdate = null)
    {
        int selection = 0;
        while (true)
        {
            Console.Clear();
            Tui.WriteBold("Removing Users\n");
            MenuEntry[] options = users.Select(user => { return new MenuEntry(user.Name, ConsoleColor.Red); }).ToArray();
            options = options.Append(("<- Go Back", ConsoleColor.DarkGray)).ToArray();
            selection = Tui.OptionsMenu(options, selection);

            // User wants to go back.
            if (selection == users.Count)
            {
                return;
            }

            User user = users[selection];

            string confirmPrompt =
                $"Are you sure you want to delete \"{user.Name}\"? This action cannot be undone.";

            if (Tui.ConfirmationPrompt(confirmPrompt))
            {
                Console.WriteLine($"User \"{user.Name}\" has been deleted.");
                users.RemoveAt(selection);
            }

            postSelectUpdate?.Invoke(ActionCategory.Remove, user);
        }
    }
}
