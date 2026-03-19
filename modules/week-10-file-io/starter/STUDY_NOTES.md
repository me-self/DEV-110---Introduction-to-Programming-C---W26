# Week 10: Habit Tracker (File I/O) — Study Notes

**Name:** Samuel Bellemare

## File I/O — Reading

**What does `File.ReadAllLines` return, and how did you use it?**
[Think about the return type and what you did with each element]

Answer: `File.ReadAllLines` returns an array of strings where each element is a line of the file. Each line represents an entry, so I iterate through the lines, splitting each line at the commas to get the values in that entry (the name, status, and frequency).

**Why is it important to skip blank lines when reading a CSV file?**
[What would happen if you tried to split an empty string on `','`?]

Answer: If I tried to split an empty string, the array would have only one element, making the indices used on it out of range.

## File I/O — Writing

**What does `File.WriteAllLines` do, and what arguments does it take?**
[Describe the path argument and what goes in the string array]

Answer: `File.WriteAllLines` takes a file path (relative or absolute) as a string, and an array of strings (the lines to write to the file, where each line is a string element).

**What is `Select(...).ToArray()` doing in `SaveHabits`?**
[Break down the two steps: what does `Select` produce, and why call `ToArray()`?]

Answer: `Select` produces an `IEnumerable<T>` where `T` is the type returned by the lamda (in this case, a string representing a line to be written to the file). We use `ToArray` to convert `IEnumerable<string>` to `string[]` since that's the type needed by `WriteAllLines`.

## Exception Handling

**What is a `FileNotFoundException` and when does it occur?**
[Describe the scenario where C# throws this specific exception]

Answer: If no file exists at the path provided to `File.ReadAllLines`, the `FileNotFoundException` exception will thrown.

**Why do we catch `FileNotFoundException` specifically instead of using `catch (Exception)`?**
[Think about what catching all exceptions can hide from you]

Answer: Catching all exceptions could be misleading since that block can also throw an exception in the case of indexing out of range, for instance.

## What I Learned

**Key takeaways from this week:**
[List 3 main things you learned]

1. Reading and writing to files in C#
2. Using try and catch
3. Using Path.Combine to build paths

**What was the trickiest part of this assignment and how did you work through it?**

Answer: The trickiest part was probably figuring out why I was always getting 0%. I worked through it with some print debugging to see what values I was dealing with to try narrowing the issue down. That's how I found it wasn't a formatting issue. And eventually figured it was getting truncated.

## Time Spent

**Total time:** 5.25 hours

**Breakdown:**

- Understanding the starter code and CSV formats: 0.25 hours
- Implementing LoadHabits: 0.5 hours
- Implementing PrintHabits / PrintSummary: 1.5 hours
- Implementing AddHabit / UpdateHabit / SaveHabits: 1 hours
- Testing and debugging: 1 hours
- Writing study notes: 1 hours

**Most time-consuming part:**

Answer: Implementing PrintSummary took the longest. There was a lot more formatting work involved in that, and it took me a while to figure out why the rates kept showing up at 0% until I realized it was due to me not casting the left operand to a float.
