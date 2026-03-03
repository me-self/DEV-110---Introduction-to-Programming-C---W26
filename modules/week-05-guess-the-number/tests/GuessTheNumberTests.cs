using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessTheNumber.Tests;

[TestClass]
public class GuessTheNumberTests
{
    private StringWriter _output;
    private TextWriter _originalOutput;

    [TestInitialize]
    public void Setup()
    {
        _output = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_output);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOutput);
        _output.Dispose();
    }

    private void ProvideInput(params string[] inputs)
    {
        var input = new StringReader(string.Join(Environment.NewLine, inputs));
        Console.SetIn(input);
    }

    private static int CountMatches(string input, string pattern)
    {
        return Regex.Matches(input, pattern, RegexOptions.IgnoreCase).Count;
    }

    [TestMethod]
    public void Test01_ProgramCompiles()
    {
        Assert.IsTrue(true, "✅ Project compiled successfully");
    }

    [TestMethod]
    public void Test02_ValidatesInputsAndRunsRounds()
    {
        ProvideInput(
            "5", "10",           // max value: invalid then valid
            "0", "2",            // rounds: invalid then valid
                                 // Round 1 guesses (includes all 1-10, plus 0)
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
            // Round 2 guesses (includes all 1-10, plus 0)
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
        );

        Program.Main(Array.Empty<string>());
        string output = _output.ToString();
        string outputLower = output.ToLower();

        int maxPromptCount = CountMatches(output, "max");
        int roundsPromptCount = CountMatches(output, "round");
        bool hasRound1 = Regex.IsMatch(outputLower, @"round\s+1");
        bool hasRound2 = Regex.IsMatch(outputLower, @"round\s+2");

        Assert.IsTrue(
            maxPromptCount >= 2 && roundsPromptCount >= 3 && hasRound1 && hasRound2,
            "❌ Input validation or rounds loop missing\n" +
            "💡 Tip: Use do-while for max/rounds validation and a for loop for rounds");
    }

    [TestMethod]
    public void Test03_GuessingLoopProvidesFeedback()
    {
        ProvideInput(
            "10", "1",           // max value, rounds
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
        );

        Program.Main(Array.Empty<string>());
        string outputLower = _output.ToString().ToLower();

        bool hasTooLow = outputLower.Contains("too low");
        bool hasCorrect = outputLower.Contains("correct");
        int guessPromptCount = CountMatches(outputLower, "guess");

        Assert.IsTrue(
            hasTooLow && hasCorrect && guessPromptCount >= 2,
            "❌ Guessing loop feedback missing\n" +
            "💡 Tip: Use a while loop to keep asking until the correct guess");
    }

    [TestMethod]
    public void Test04_StudyNotesFileExists()
    {
        string testDir = Path.GetDirectoryName(typeof(GuessTheNumberTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);
        bool exists = File.Exists(studyNotesPath);

        Assert.IsTrue(
            exists,
            "\n❌ Missing STUDY_NOTES.md file!\n" +
            "📝 The file should exist in the starter folder\n" +
            "💡 Location: modules/week-05-guess-the-number/starter/STUDY_NOTES.md");
    }

    [TestMethod]
    public void Test05_StudyNotesAllSectionsCompleted()
    {
        string testDir = Path.GetDirectoryName(typeof(GuessTheNumberTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);

        if (File.Exists(studyNotesPath))
        {
            string content = File.ReadAllText(studyNotesPath);

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(content.Split(new[] { "**Name:**" }, StringSplitOptions.None)[1].Split('\n')[0].Trim()),
                "\n❌ Please fill in your name at the top of STUDY_NOTES.md");

            string[] sections = content.Split("Answer:");
            int totalAnswerSections = sections.Length - 1;
            int filledAnswers = 0;

            for (int i = 1; i < sections.Length; i++)
            {
                string afterAnswer = sections[i].Trim();
                int nextSectionIndex = afterAnswer.IndexOf("**");
                if (nextSectionIndex > 0)
                {
                    afterAnswer = afterAnswer.Substring(0, nextSectionIndex).Trim();
                }

                if (!string.IsNullOrWhiteSpace(afterAnswer) && afterAnswer.Length > 5)
                {
                    filledAnswers++;
                }
            }

            Assert.IsTrue(
                filledAnswers >= totalAnswerSections - 2,
                $"\n❌ STUDY_NOTES.md has incomplete answers! (Completed: {filledAnswers}/{totalAnswerSections})\n" +
                "💡 Tip: Fill in all 'Answer:' sections with thoughtful responses");

            bool hasTakeaway1 = Regex.IsMatch(content, @"1\.\s+\w{3,}");
            bool hasTakeaway2 = Regex.IsMatch(content, @"2\.\s+\w{3,}");
            bool hasTakeaway3 = Regex.IsMatch(content, @"3\.\s+\w{3,}");

            Assert.IsTrue(
                hasTakeaway1 && hasTakeaway2 && hasTakeaway3,
                "\n❌ Please complete the 'Key takeaways' list (items 1, 2, and 3)");

            bool hasTimeTotal = content.Contains("**Total time:**") &&
                               Regex.IsMatch(content, @"\*\*Total time:\*\*\s+\d+");

            Assert.IsTrue(
                hasTimeTotal,
                "\n❌ Please fill in the 'Total time' section\n" +
                "💡 Tip: Example: **Total time:** 3 hours");
        }
        else
        {
            Assert.Inconclusive("STUDY_NOTES.md file does not exist yet");
        }
    }
}
