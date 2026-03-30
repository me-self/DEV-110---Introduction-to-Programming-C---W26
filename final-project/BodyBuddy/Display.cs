namespace BodyBuddy;

public static class Display
{
    /// <summary>
    /// Write to the console but clipped rather than wrapped.
    /// </summary>
    /// <param name="text"></param>
    public static void Write(string text)
    {
        int maxWidth = Console.BufferWidth - 1;

        bool inEscape = false;
        string escapeSequence = string.Empty;

        foreach (char c in text)
        {
            if (inEscape)
            {
                escapeSequence += c;
                if (char.IsLetter(c))
                {
                    inEscape = false;
                    Console.Write(escapeSequence);
                }

                continue;
            }

            if (c == '\e')
            {
                inEscape = true;
                escapeSequence = "\e";
                continue;
            }

            if (char.IsControl(c) || Console.CursorLeft < maxWidth)
            {
                Console.Write(c);
            }
        }
    }

    public static void WriteLine(string text)
    {
        Write(text + Environment.NewLine);
    }

    public static void ClearRows(int top = 0, int? maybeBottom = null)
    {
        int bottom = maybeBottom ?? top;
        (int X, int Y) cursorPosition = Console.GetCursorPosition();
        top = int.Min(Console.BufferHeight - 1, top);
        bottom = int.Min(Console.BufferHeight - 1, bottom);
        Console.SetCursorPosition(0, top);
        for (int i = top; i <= bottom; i++)
        {
            Console.Write(new string(' ', Console.BufferWidth));
        }

        Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
    }
}
