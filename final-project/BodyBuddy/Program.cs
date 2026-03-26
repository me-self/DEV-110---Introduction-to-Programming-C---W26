namespace BodyBuddy;

// We just set up the enviroment here the jump into App's loop.
public class Program
{
    static Program()
    {
        // If the user exits early with Ctrl+C, we should switch back to the main buffer.
        Console.CancelKeyPress += (_, __) =>
        {
            SwitchToMainBuffer();
        };

        AppDomain.CurrentDomain.ProcessExit += (_, __) =>
        {
            SwitchToMainBuffer();
        };
    }

    public static void Main(string[] args)
    {
        // Switch to an alternative buffer so we can draw our TUI without clearing out the main buffer.
        SwitchToAltBuffer();
        App.Run();
        SwitchToMainBuffer();
    }

    private static void SwitchToMainBuffer()
    {
        const string MAIN_BUFFER = "\x1b[?1049l";
        Console.Write(MAIN_BUFFER);
    }

    private static void SwitchToAltBuffer()
    {
        const string ALT_BUFFER = "\x1b[?1049h";
        Console.Write(ALT_BUFFER);
        Console.Clear();
    }
}
