namespace BodyBuddy;

public class ScrollTextEdit
{
    public ScrollTextEdit(int viewSize, string placeholder, string text)
    {
        _elementRow = Console.CursorTop;
        _elementStart = Console.CursorLeft;
        // Adding 2 since that's the space for the arrows.
        _textStart = _elementStart + 2;
        _viewSize = viewSize;
        _placeholder = placeholder;
        Text = text;
        _cursorLogical = text.Length;
    }

    public void Display()
    {
        ConsoleColor textColor = Console.ForegroundColor;

        string viewSlice;
        if (Text.Length > 0)
        {
            viewSlice = Text.PadRight(_viewSize);
        }
        else
        {
            viewSlice = _placeholder.PadRight(_viewSize);
            textColor = ConsoleColor.Gray;
        }
        int viewEnd = _viewStart + _viewSize;

        // If the text has shrunken, we move the view accordingly.
        if (viewEnd > viewSlice.Length)
        {
            _viewStart = viewSlice.Length - _viewSize;
            viewEnd = viewSlice.Length;
        }

        viewSlice = viewSlice[_viewStart..viewEnd];

        // Draw an arrow indicating there is undrawn text to the left.
        Console.SetCursorPosition(_elementStart, _elementRow);
        Console.Write((_viewStart > 0) ? "< " : "  ");

        Console.BackgroundColor = BoxColor;
        Console.ForegroundColor = textColor;
        Console.Write(viewSlice);
        Console.ResetColor();

        // Draw an arrow indicating there is undrawn text to the right.
        Console.Write((viewEnd < Text.Length) ? " >" : "  ");

        int visualCursor = _cursorLogical - _viewStart;
        Console.CursorLeft = _textStart + visualCursor;
    }

    public void ShiftLeft()
    {
        // Return immediately if we can't move further left.
        if (_cursorLogical == 0)
        {
            return;
        }

        _cursorLogical--;

        // If text shrunk and is now less than the cursor.
        if (_cursorLogical > Text.Length)
        {
            _cursorLogical = Text.Length;
            _viewStart = int.Max(0, Text.Length - _viewSize);
        }

        // If we're at the left of the view region, we shift that left too.
        if (_cursorLogical < _viewStart)
        {
            _viewStart--;
        }
    }

    public void ShiftRight()
    {
        // Return immediately if we can't move further right.
        if (_cursorLogical == Text.Length)
        {
            return;
        }

        if (_cursorLogical == _viewStart + _viewSize)
        {
            _viewStart++;
        }
        _cursorLogical++;
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
                Text = Text.Insert(_cursorLogical, keyChar.ToString());
                ShiftRight();
            }

            switch (pressedKey)
            {
                // Remove the character behind the cursor.
                case ConsoleKey.Backspace:
                    if (_cursorLogical > 0 && Text.Length > 0)
                    {
                        Text = Text.Remove(_cursorLogical - 1, 1);
                        ShiftLeft();
                    }
                    break;
                // Remove the character at the cursor.
                case ConsoleKey.Delete:
                    if (Text.Length > _cursorLogical)
                    {
                        Text = Text.Remove(_cursorLogical, 1);
                    }
                    break;
                // Shift the cursor (and maybe view) left.
                case ConsoleKey.LeftArrow:
                    if (_cursorLogical > 0)
                    {
                        ShiftLeft();
                    }
                    break;
                // Shift the cursor (and maybe view) right.
                case ConsoleKey.RightArrow:
                    if (_cursorLogical < Text.Length)
                    {
                        ShiftRight();
                    }
                    break;
            }
        }
        while (pressedKey != ConsoleKey.Enter);
    }

    private readonly int _elementRow = 0;
    private readonly int _elementStart = 0;
    private readonly int _textStart = 0;
    private readonly int _viewSize;
    private readonly string _placeholder;
    private int _viewStart = 0;
    private int _cursorLogical = 0;
    public string Text { get; set; }
    public ConsoleColor BoxColor { get; set; } = ConsoleColor.DarkGray;
}
