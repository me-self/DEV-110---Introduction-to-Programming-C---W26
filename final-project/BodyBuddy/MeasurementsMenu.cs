namespace BodyBuddy;

public static class MeasurementsMenu
{
    public static void Show()
    {
        float?[] measurements = new float?[5];

        Tui.WriteBold("Editing Measurements\n");
        int menuTop = Console.CursorTop;
        MenuEntry[] options = [
            "Height (in): ",
            "Weight (lbs): ",
            "Wingspan (in): ",
            "Waist Circumference (in): ",
            "Hip Circumference (in): ",
            ("<- Back", ConsoleColor.DarkGray)
        ];

        // Don't give the exit option an input field.
        ScrollTextEdit[] inputFields = new ScrollTextEdit[options.Length - 1];
        for (int i = 0; i < inputFields.Length; i++)
        {
            Console.SetCursorPosition(28, menuTop + i);
            string text = measurements[i]?.ToString() ?? string.Empty;
            inputFields[i] = new ScrollTextEdit(10, "Unset", text);
            inputFields[i].Display();
        }

        while (true)
        {
            Console.SetCursorPosition(0, menuTop);

            int selection = Tui.OptionsMenu(options);

            if (selection == options.Length - 1)
            {
                break;
            }

            inputFields[selection].Focus();
        }
    }
}
