public class ScrollEntry
{
    public ScrollEntry(int viewSize, string text)
    {
        this.viewSize = viewSize;
        Text = text;
    }

    public void Display()
    {
        Console.Write(Text[viewStart..(viewStart + viewSize)]);
    }

    public void Focus()
    {
        ConsoleKey pressedKey;
        do
        {
            pressedKey = Console.ReadKey().Key;
        }
        while (pressedKey != ConsoleKey.Enter);
    }

    private int viewSize;
    private int viewStart = 0;
    private int relativeCursor = 0;
    public string Text { get; set; }
}
