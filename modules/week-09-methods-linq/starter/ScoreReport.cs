/*******************************************************************************
- Course: DEV 110
- Instructor: Zak Brinlee
- Term: Winter 2026
-
- Programmer: Samuel Bellemare
- Assignment: Week 9: Score Stats (Methods + LINQ)
-
- What does this program do?:
- Defines a ScoreReport class students complete using LINQ methods.
- */

using System.Globalization;

namespace ScoreStats;

internal class ScoreReport
{
    private readonly int[] _scores;

    public ScoreReport(int[] scores, int threshold)
    {
        _scores = scores;
        Threshold = threshold;
    }

    public int Threshold { get; }

    public int Count => _scores.Length;

    /// <summary>
    /// Prints a complete report, consisting of: basic stats, passing count,
    /// failing count, the sorted scores, top 3 scores, passing scores, and
    /// failing scores.
    /// </summary>
    public void PrintReport()
    {
        PrintBasicStats();
        PrintPassingFailingCounts();
        Console.WriteLine();
        PrintScoresSorted();
        PrintTopScores(3);
        PrintPassingScores();
        PrintFailingScores();
    }

    /// <summary>
    /// Prints the number of scores, the lowest score, the highest score, and the average score.
    /// </summary>
    private void PrintBasicStats()
    {
        int count = _scores.Count();
        int min = _scores.Min();
        int max = _scores.Max();
        double average = _scores.Average();
        string formattedAverage = average.ToString("0.0", CultureInfo.InvariantCulture);

        Console.WriteLine($"Count: {count}");
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Average: {formattedAverage}");
    }

    /// <summary>
    /// Prints the number of passing scores and the number of failing scores.
    /// </summary>
    private void PrintPassingFailingCounts()
    {
        int passing = _scores.Count(score => score >= Threshold);
        int failing = _scores.Count(score => score < Threshold);
        Console.WriteLine($"Passing (>={Threshold}): {passing}");
        Console.WriteLine($"Failing (<{Threshold}): {failing}");
    }

    /// <summary>
    /// Sorts and display scores in order of lowest to highest.
    /// </summary>
    private void PrintScoresSorted()
    {
        IOrderedEnumerable<int> sortedScores = _scores.OrderBy(score => score);
        string formattedScores = string.Join(", ", sortedScores);
        Console.WriteLine($"Sorted (asc): {formattedScores}");
    }

    /// <summary>
    /// Prints the top X scores, where X is topCount.
    /// </summary>
    /// <param name="topCount">The number of top scores to display.</param>
    private void PrintTopScores(int topCount)
    {
        IEnumerable<int> topScores = _scores.OrderByDescending(score => score).Take(topCount);
        string formattedScores = string.Join(", ", topScores);
        Console.WriteLine($"Top {topCount}: {formattedScores}");
    }

    /// <summary>
    /// Displays all passing scores in decending order.
    /// </summary>
    private void PrintPassingScores()
    {
        IOrderedEnumerable<int> passingScores = _scores
            .Where(score => score >= Threshold)
            .OrderByDescending(score => score);
        string formattedScores = string.Join(", ", passingScores);
        Console.WriteLine($"Passing scores (desc): {formattedScores}");
    }

    /// <summary>
    /// Displays all failing scores in decending order.
    /// </summary>
    private void PrintFailingScores()
    {
        IOrderedEnumerable<int> failingScores = _scores.Where(score => score < Threshold).OrderByDescending(score => score);
        string formattedScores = string.Join(", ", failingScores);
        Console.WriteLine($"Failing scores (desc): {formattedScores}");
    }
}
