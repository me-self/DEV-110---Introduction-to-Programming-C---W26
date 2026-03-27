namespace BodyBuddy;

/// <summary>
/// Provides helper methods for TUI menus.
/// </summary>
public static class Tui
{
    static Tui()
    {
        // If the user exits a menu with Ctrl+C, we want to restore the cursor visibility.
        Console.CancelKeyPress += (sender, e) =>
        {
            Console.CursorVisible = true;
        };
    }

    public static int OptionsMenu(MenuEntry[] options, int selection = 0)
    {
        Console.CursorVisible = false;
        selection = int.Min(selection, options.Length);
        while (true)
        {
            for (int i = 0; i < options.Length; i++)
            {
                // Add an asterisk to the selected entry.
                char selectionMarker = (i == selection) ? '*' : ' ';
                Console.Write($"{selectionMarker} ");
                Console.ForegroundColor = options[i].ForegroundColor ?? Console.ForegroundColor;
                Console.BackgroundColor = options[i].BackgroundColor ?? Console.BackgroundColor;
                Console.WriteLine(options[i].Text);
                Console.ResetColor();
            }

            // Clear out the char the user typed.
            Console.Write(' ');
            Console.SetCursorPosition(0, Console.CursorTop);

            // Exit if the user has confirmed a selection.
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Enter)
            {
                break;
            }

            // Allow arrow keys to move between options.
            if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.LeftArrow)
            {
                if (selection > 0)
                {
                    selection -= 1;
                }
            }
            else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.RightArrow)
            {
                if (selection < options.Length - 1)
                {
                    selection += 1;
                }
            }

            Console.SetCursorPosition(0, Console.CursorTop - options.Length);
        }

        Console.CursorVisible = true;
        return selection;
    }

    public static bool ConfirmationPrompt(string prompt)
    {
        Console.Write($"{prompt} (y/n): ");
        while (true)
        {
            string input = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
    }

    public static void WriteBold(string text)
    {
        const string BOLD_CODE = "\x1b[1m";
        const string RESET_CODE = "\x1b[0m";
        Console.Write($"{BOLD_CODE}{text}{RESET_CODE}");
    }
}
