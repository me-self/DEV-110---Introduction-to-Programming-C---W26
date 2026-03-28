namespace BodyBuddy;

/// <summary>
/// Represents a text menu entry with optional colors.
/// </summary>
public class MenuEntry
{
    public MenuEntry(string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        Text = text;
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
    }

    public string Text { get; set; }

    public ConsoleColor? ForegroundColor { get; set; }

    public ConsoleColor? BackgroundColor { get; set; }

    // Allow the user to enter a string as a MenuEntry.
    public static implicit operator MenuEntry(string text)
    {
        return new MenuEntry(text);
    }

    // Allow the user to enter a tuple of (string, ConsoleColor) as a MenuEntry.
    public static implicit operator MenuEntry((string Text, ConsoleColor ForegroundColor) entry)
    {
        return new MenuEntry(entry.Text, entry.ForegroundColor);
    }

    // Allow the user to enter a tuple of (string, ConsoleColor, ConsoleColor) as a MenuEntry.
    public static implicit operator MenuEntry((string Text, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor) entry)
    {
        return new MenuEntry(entry.Text, entry.ForegroundColor, entry.BackgroundColor);
    }
}
