namespace BodyBuddy;

public static class MeasurementsMenu
{
    public static void Show(ref UserData userData, Action postUpdateAction)
    {
        double?[] measurements = [userData.Height, userData.Weight, userData.Wingspan, userData.Waist, userData.Hip];

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
        var inputFields = new ScrollTextEdit[options.Length - 1];

        int selection = 0;
        while (true)
        {
            Console.SetCursorPosition(0, menuTop);

            selection = Tui.OptionsMenu(options, selection, () =>
            {
                // Don't give the exit option an input field.
                for (int i = 0; i < inputFields.Length; i++)
                {
                    Console.SetCursorPosition(28, menuTop + i);
                    string text = measurements[i]?.ToString() ?? string.Empty;
                    inputFields[i] = new ScrollTextEdit(10, "Unset", text);
                    inputFields[i].Display();
                }
            });

            if (selection == options.Length - 1)
            {
                break;
            }

            double? maybeValue = null;
            bool isValid = false;
            inputFields[selection].Focus(field =>
            {
                isValid = double.TryParse(field.Text, out double value);

                // Only accept values over 0.
                isValid = isValid && value > 0;

                // If it's invalid and not just empty, highlight the cell red.
                if (!isValid && !field.Text.IsWhiteSpace())
                {
                    inputFields[selection].BoxColor = ConsoleColor.DarkRed;
                }
                else
                {
                    inputFields[selection].BoxColor = ConsoleColor.DarkGray;
                    maybeValue = isValid ? value : null;
                }
            });

            if (isValid || inputFields[selection].Text.IsWhiteSpace())
            {
                inputFields[selection].BoxColor = ConsoleColor.DarkGray;
                switch (selection)
                {
                    case 0:
                        userData.Height = maybeValue;
                        break;
                    case 1:
                        userData.Weight = maybeValue;
                        break;
                    case 2:
                        userData.Wingspan = maybeValue;
                        break;
                    case 3:
                        userData.Waist = maybeValue;
                        break;
                    case 4:
                        userData.Hip = maybeValue;
                        break;
                }
            }

            inputFields[selection].Display();

            postUpdateAction.Invoke();
        }
    }
}
