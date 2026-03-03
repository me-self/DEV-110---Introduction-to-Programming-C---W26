# Week 8: Mad Libs (Structure + Debugging) - Study Notes

**Name:** Samuel Bellemare

## Program Structure

**What helper methods did you create (and what does each one do)?**
[List your methods and briefly describe each]

Answer: `ChooseTemplate` prompts the user to select an option (1 or 2) and returns the corresponding instance of `StoryTemplate`. `CollectWords` goes through every prompt, printing them and collecting the input into an array. `ReadYesNo` prompts the user until they enter "y" or "n" (case insensitive), and returns true or false respectively. `ReadIntInRange` prompts the user until the input can be parsed as an int and is in range. `ReadNonEmptyString` prompts the user until the string is not empty (having only whitespace is considered empty due to `Trim`ing). `FormatStory` inserts the words into the story's template text. `GenerateStory` calls `FormatStory` after checking that the number of words supplied matches the number of prompts.

**Why is it helpful to move code out of `Main` and into helper methods?**
[Explain how this improves readability and reduces bugs]

Answer: Moving code into helper methods improves readability by reducing uses down to just a method name and (potentially) arguments. It also reduces bugs since the behavior must only be implemented once, and is easier to test thoroughly since it's seperated from the rest of the logic.

## Data Modeling

**What is the purpose of the `StoryTemplate` class in this assignment?**
[Explain what data it stores and why]

Answer: `StoryTemplate` represents data specific to a story: the title, prompts, and the text template. Having this class makes it easier to implement multiple stories by standardizing how stories are represented and used by the program; no need to alter logic to create another story.

**How did using a template make it easier to support two different stories?**
[Explain how the same logic can work with different prompts/text]

Answer: Using a template makes it easy to insert the words wherever need be with the same logic since the template dictates where words are added in.

## Testing and Debugging

**Where did you set a breakpoint while debugging this program (what line or method)?**
[Be specific - example: inside GenerateStory, at the beginning of CollectWords, etc.]

Answer: After calling `ChooseTemplate` so that following methods (such as `CollectWords`) wouldn't throw an error.

**What did you learn from stepping through your code line by line?**
[Describe how watching execution helped you understand flow or find bugs]

Answer: Stepping through my code line by line was particularily helpful in learning how to use a debugger. I've scarcely used debuggers before (and even then, only in JetBrains' IDEs).

**What bug or logic mistake did you encounter (and how did you fix it)?**
[Describe a real issue you ran into and how breakpoints/stepping helped]

Answer: Not really a bug or logic mistake, but using breakpoints and stepping helped me test the parts I had written without reaching an unimplemented error from things I hadn't gotten to implementing yet.

## What I Learned

**Key takeaways from this week:**
[3 main things you learned]

1. I learned what `protected` is (only accessible to the containing class and derivatives)
2. XML comments. Really nice knowing there's built-in doc comments in C#
3. I learned how to throw an exception
4. I learned what the `static` keyword does in C# (making classes and/or members not per-instance)

**What part of this assignment helped you understand program structure the most?**
[Breaking into methods, using public/private methods, separating concerns, etc.]

Answer: Seperating into classes did the most to help me understand program structure since that's probably the biggest difference in the structure from other languages I've used.

## Time Spent

**Total time:** 5 hours

**Breakdown:**

- Planning structure (methods/classes): 30 minutes
- Input validation: 1 hour
- Story templates + formatting: 2 hours
- Testing and debugging: 1 hour (took a bit to get the debugger working)
- Writing documentation: 30 minutes

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: Story templates took the longest since it used classes, and that's the area I was least familiar with since that's something that differs quite a bit across languages, that is, if they even exist at all.

## Reflection

**What would you improve if you had more time?**
[Ideas: more templates, better formatting, more validation, etc.]

Answer: Maybe some validation that `TemplateText` matches the number of prompts.

**How did breaking your program into smaller parts help you debug?**
[Explain the connection between structure and debugging]

Answer: When working with smaller parts, it's easier to debug because you can just focus on that step's input(s) and output(s). It's easier to find what could be going wrong in a more limited context, and it can be tested individually.
