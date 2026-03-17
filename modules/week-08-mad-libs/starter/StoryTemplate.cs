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

/// <summary>
/// Represents a MadLibs story, including the title, prompts, and surrounding text.
/// </summary>
public class StoryTemplate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StoryTemplate"/> class.
    /// Creates a new MadLibs story.
    /// </summary>
    /// <param name="title">The title of the story.</param>
    /// <param name="prompts">The word prompts the user should be presented.</param>
    /// <param name="templateText">The text for which to insert the user's words.</param>
    public StoryTemplate(string title, string[] prompts, string templateText)
    {
        Title = title;
        Prompts = prompts;
        TemplateText = templateText;
    }

    public string Title { get; }

    public string[] Prompts { get; }

    public string TemplateText { get; }

    /// <summary>
    /// Generates the story using the provided words before returning it.
    /// The number of words should match the number of prompts.
    /// </summary>
    /// <param name="words">The words to insert into the story.</param>
    /// <returns>The story as string generated from the template and given words.</returns>
    /// <exception cref="ArgumentException">Mismatched number of words to prompts!.</exception>
    public string GenerateStory(string[] words)
    {
        // Throw an exception if the arguments are invalid (not of matching length).
        if (words.Length != Prompts.Length)
        {
            Logger.Warn("Number of words must match the number of prompts!");
            throw new ArgumentException("Mismatched number of words to prompts!");
        }

        // We know `words` is the correct length or the exception would've been thrown.
        return FormatStory(words);
    }

    private string FormatStory(string[] words)
    {
        object[] wordObjects = words;
        return string.Format(TemplateText, wordObjects);
    }
}
