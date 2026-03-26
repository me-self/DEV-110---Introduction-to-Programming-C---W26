public class ScrollTextEdit
{
    public ScrollTextEdit(int viewSize, string text)
    {
        elementRow = Console.CursorTop;
        elementStart = Console.CursorLeft;
        // Adding 2 since that's the space for the arrows.
        textStart = elementStart + 2;
        this.viewSize = viewSize;
        Text = text;
        cursorLogical = text.Length;
    }

    public void Display()
    {
        string viewSlice = Text.PadRight(viewSize);
        int viewEnd = viewStart + viewSize;

        // If the text has shrunken, we move the view accordingly.
        if (viewEnd > viewSlice.Length)
        {
            viewStart = viewSlice.Length - viewSize;
            viewEnd = viewSlice.Length;
        }

        viewSlice = viewSlice[viewStart..viewEnd];


        // Draw an arrow indicating there is undrawn text to the left.
        Console.SetCursorPosition(elementStart, elementRow);
        Console.Write((viewStart > 0) ? "< " : "  ");

        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write(viewSlice);
        Console.ResetColor();

        // Draw an arrow indicating there is undrawn text to the right.
        Console.Write((viewEnd < Text.Length) ? " >" : "  ");

        int visualCursor = cursorLogical - viewStart;
        Console.CursorLeft = textStart + visualCursor;
    }

    public void ShiftLeft()
    {
        // Return immediately if we can't move further left.
        if (cursorLogical == 0)
        {
            return;
        }

        cursorLogical--;

        // If text shrunk and is now less than the cursor.
        if (cursorLogical > Text.Length)
        {
            cursorLogical = Text.Length;
            viewStart = int.Max(0, Text.Length - viewSize);
        }

        // If we're at the left of the view region, we shift that left too.
        if (cursorLogical < viewStart)
        {
            viewStart--;
        }
    }

    public void ShiftRight()
    {
        // Return immediately if we can't move further right.
        if (cursorLogical == Text.Length)
        {
            return;
        }

        if (cursorLogical == viewStart + viewSize)
        {
            viewStart++;
        }
        cursorLogical++;
    }

    public void Focus()
    {
        ConsoleKey pressedKey;
        do
        {
            Display();
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            pressedKey = keyInfo.Key;
            char keyChar = keyInfo.KeyChar;
            // If the char isn't a control char, we insert it at the cursor.
            if (!char.IsControl(keyChar))
            {
                Text = Text.Insert(cursorLogical, keyChar.ToString());
                ShiftRight();
            }

            switch (pressedKey)
            {
                // Remove the character behind the cursor.
                case ConsoleKey.Backspace:
                    if (cursorLogical > 0 && Text.Length > 0)
                    {
                        Text = Text.Remove(cursorLogical - 1, 1);
                        ShiftLeft();
                    }
                    break;
                // Remove the character at the cursor.
                case ConsoleKey.Delete:
                    if (Text.Length > cursorLogical)
                    {
                        Text = Text.Remove(cursorLogical, 1);
                    }
                    break;
                // Shift the cursor (and maybe view) left.
                case ConsoleKey.LeftArrow:
                    if (cursorLogical > 0)
                    {
                        ShiftLeft();
                    }
                    break;
                // Shift the cursor (and maybe view) right.
                case ConsoleKey.RightArrow:
                    if (cursorLogical < Text.Length)
                    {
                        ShiftRight();
                    }
                    break;
            }
        }
        while (pressedKey != ConsoleKey.Enter);
    }

    private int elementRow = 0;
    private int elementStart = 0;
    private int textStart = 0;
    private int viewSize;
    private int viewStart = 0;
    private int cursorLogical = 0;
    public string Text { get; set; }
}
