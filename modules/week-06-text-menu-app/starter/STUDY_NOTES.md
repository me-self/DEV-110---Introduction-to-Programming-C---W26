# Week 6: Text Menu App - Study Notes

**Name:** Samuel Bellemare

## Loop Types

**How is a `do-while` loop different from a `while` loop?**
[Explain when each loop is best used]

Answer: `do-while`, unlike `while` has the condition evaluated after the iteration, meaning it always runs at least once. A `while` loop is useful if it should only run if the condition is met, while a `do-while` is useful if you want the loop to run at least once no matter what.

**Where did you use a `do-while` loop in this assignment and why?**
[Describe how you validated the menu choice and numeric inputs]

Answer: `do-while` is useful in input, where the user should be prompted at least once regardless, then run again as long as the input is not valid (either parsing failed *or* the value was out of range).

**Where did you use a `while` loop and why?**
[Describe the menu loop and why it repeats]

Answer: The menu loop is a `while` loop because there's an unknown number of iterations, and, although a `do-while` would also work since the condition always starts as evaluating to `true` anyways, a `do-while` does not have any advantage over a while loop, so the one with simpler syntax (`while`) might as well used.

**Where did you use a `for` loop and why?**
[If you didn’t use a for loop, explain why it wasn’t needed]

Answer: I didn't use any for loops as I never had to go through a known number of iterations in this project.

## Input Validation

**Why did you create a helper method for input validation?**
[Explain how it avoids repeating code for multiple prompts]

Answer: Having helper methods not only helps reduce code duplication by reducing occurances to a simple `MethodName(arg1, arg2, etc...)` rather than having to repeat the whole verification logic, but also helps reduce bugs and ease maintainence by ensuring changes only have to made in one place.

**How did you validate the menu choice (1–6)?**
[Explain your range check logic and do-while loop]

Answer: Menu choice is read using `ReadIntInRange` which prompts for input once, and continues as long as `TryParse` fails, *or* the value is less than `min` (1), *or* greater than `max` (6).

**How did you handle invalid input (non-numbers)?**
[Explain how int.TryParse and double.TryParse work]

Answer: `int.TryParse` and `double.TryParse` both return `true` on success, and `false` on failure. The value is written to the second reference argument.

## String Operations

**Which string methods did you use across the different menu options?**
[List key methods like Trim, ToUpper, ToLower, Replace, Split, Join, Contains, PadLeft, PadRight, and formatting techniques]

Answer: I used `Trim` to get rid of surrounding whitespace, `ToUpper` for things in all caps (such as titles), `ToLower` for lowercase intials, and combined with `Contains` to check that a string contains the letter `a` either lower or uppercase. I used `Replace` to replace certain characters with another (in this case, spaces with dashes), `Split` to split a string into multiple strings instances of a given char (in this case, spaces). `Join` came in handy for combining an array of strings with a given delimiter in-between (`,` in this case). `PadLeft` adds whitespace to the left of the string to reach the provided string length (useful for alignment), with `PadRight` functioning similarly, but as the name implies, adding whitespace to the right instead. I used `Substring` to effectively truncate strings above a given length.

**Which four string methods did you demonstrate in Option 6 (String Analysis)?**
[Explain Equals with StringComparison, Substring, EndsWith, and IndexOf]

Answer: `StringComparison` is an enum whose variants are used to select how `Equals` compares the strings (in this project, it's a non-case sensitive way).

**What's the difference between string concatenation and interpolation?**
[Explain when you used each approach and which you prefer]

Answer: String concatenation appends one string to another, while string interpolation allows a value to be inserted into another string. Interpolation is generally much cleaner and has additional formatting features (such as specifying width and alignment). I used concatenation when appending one string to another was sufficient and no additional formatting was necessary (such as when combining first and last name).

## What I Learned

**Key takeaways from this week:**
[3-5 main things you learned]

1. using `string.Format`
2. how to use `Equals`
3. getting part of a string with `Substring`

**Which loop felt most natural to use and why?**

Answer:

## Time Spent

**Total time:** 5 hours 10 minutes

**Breakdown:**

- Planning the loops: 10 minutes
- Input validation: 30 minutes
- String formatting: 3 hours
- Testing and debugging: 1 hour
- Writing documentation: 30 minutes

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: String formatting took the longest since there are 6 different choices with very different formatting requirements, limiting the extent to which I could reuse logic.

## Reflection

**What would you do differently next time?**

Answer: I would probably have made more helper methods for formatting strings since I currently have more duplicated code than I'd like.

**How did using three different loop types improve your understanding of repetition?**

Answer: Well, in this one I only used two different loops, but, being used to Rust, which does not have a `do-while`, only a normal `while` I've been getting familiar with patterns that `do-while` is handy for.
