/*******************************************************************************
- Course: DEV 110
- Instructor: Zak Brinlee
- Term: Winter 2026
-
- Programmer: Samuel Bellemare
- Assignment: Week 8: Mad Libs (Structure + Debugging)
-
- What does this program do?:
- Represents a Mad Libs story template with prompts and story text.
- */

namespace MadLibs;

public class StoryTemplate
{
    public StoryTemplate(string title, string[] prompts, string templateText)
    {
        Title = title;
        Prompts = prompts;
        TemplateText = templateText;
    }

    public string Title { get; }

    public string[] Prompts { get; }

    public string TemplateText { get; }

    public string GenerateStory(string[] words)
    {
        // Throw an exception if the arguments are invalid (not of matching length).
        if (words.Length != Prompts.Length)
        {
            throw new ArgumentException("Mismatched number of words to prompts!");
        }
        // We know `words` is the correct length or the exception would've been thrown.
        return FormatStory(words);
    }

    // TODO 2: Implement FormatStory method (private helper)
    // This method should:
    // - Convert string[] words to object[] (required for string.Format)
    // - Call string.Format with TemplateText and the object array
    // - Return the formatted story
    private string FormatStory(string[] words)
    {
        throw new NotImplementedException();
    }
}
