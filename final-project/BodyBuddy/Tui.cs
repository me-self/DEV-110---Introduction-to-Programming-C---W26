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

    public static int OptionsMenu(MenuEntry[] options, int selection = 0, Action? redraw = null)
    {
        Console.CursorVisible = false;
        int menuTop = Console.CursorTop;
        selection = int.Min(selection, options.Length - 1);
        while (true)
        {
            // Allow the caller to also redraw.
            redraw?.Invoke();

            // Begin drawing the menu.
            Console.SetCursorPosition(0, menuTop);
            for (int i = 0; i < options.Length; i++)
            {
                if (Console.CursorTop == Console.BufferHeight - 1)
                {
                    break;
                }

                // Add an asterisk to the selected entry.
                char selectionMarker = (i == selection) ? '*' : ' ';
                Display.Write($"{selectionMarker} ");
                Console.ForegroundColor = options[i].ForegroundColor ?? Console.ForegroundColor;
                Console.BackgroundColor = options[i].BackgroundColor ?? Console.BackgroundColor;
                Display.WriteLine(options[i].Text);
                Console.ResetColor();
            }

            // Exit if the user has confirmed a selection.
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Enter)
            {
                break;
            }

            Display.ClearRows(menuTop, Console.CursorTop - 1);

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

            // Snap the selection into the visible menu.
            selection = int.Min(selection, Console.BufferHeight - 2 - menuTop);
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
        const string boldCode = "\e[1m";
        const string resetCode = "\e[0m";
        Display.Write($"{boldCode}{text}{resetCode}");
    }
}
