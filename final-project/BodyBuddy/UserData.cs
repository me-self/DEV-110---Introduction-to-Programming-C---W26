namespace BodyBuddy;

public class UserData
{
    public double? Height { get; set; }

    public double? Weight { get; set; }

    public double? Wingspan { get; set; }

    public double? Waist { get; set; }

    public double? Hip { get; set; }

    public string[] AsLines()
    {
        string[] lines = [
            Height.ToString() ?? string.Empty,
            Weight.ToString() ?? string.Empty,
            Wingspan.ToString() ?? string.Empty,
            Waist.ToString() ?? string.Empty,
            Hip.ToString() ?? string.Empty
        ];
        return lines;
    }
}
