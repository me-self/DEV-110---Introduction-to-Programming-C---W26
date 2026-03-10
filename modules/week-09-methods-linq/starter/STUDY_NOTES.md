# Week 9: Score Stats (Methods + LINQ) - Study Notes

**Name:** Samuel Bellemare

## Methods and Decomposition

**Why is it helpful to break a program into small methods?**
[Think about readability, testing, and debugging]

Answer: Small methods are easier to understand since they only contain the relevant data and logic. They are easier to test since the potential bugs to look out for are much more predictable and it's easier to debug since it's easier to narrow down to the cause of a bug when the relevant part is already independent and easy to test seperately.

## LINQ (Stats + Method Chaining)

**Which LINQ methods did you use for basic statistics?**
[Examples: Min, Max, Average, Count with predicates]

Answer: I used `Count` (gets the number of elements), `Min` (gets the element with the lowest value), `Max` (get the element with the highest value), and Average (gets the average of all element values).

**Which LINQ methods did you chain together for reports?**
[Examples: Where + OrderByDescending, OrderByDescending + Take]

Answer: `Where` was chained with `OrderByDescending` to get only the passing scores + sorting them from highest to lowest, to get only the failing scores, from highest to lowest. `OrderByDescending` was chained with `Take`, so that the highest scores would come first, making it so that `Take` would collect scores in order of highest to lowest (getting the top scores).

**Why is it helpful to put score logic in a class (ScoreReport) instead of keeping everything in Program?**
[Think about organization, reuse, and readability]

Answer: In this specific project, the main benefits of putting score logic in a class are organization and readability. It helps keep a clear divide between the usage and the implementation of a `ScoreReport`, prevents scores from being modified after the `ScoreReport` is created, providing a friendlier, more readable abstraction. Reuse isn't as big of a factor here since we never have multiple `ScoreReport`s at once or need to store it or use it as an argument to anything else, but it does open the possibility to do more, such as storing `ScoreReport`s.

## What I Learned

**Key takeaways from this week:**
[3-5 main things you learned]

1. The distinction between parameters and arguments. I thought the terms were interchangeable, and would generally just refer to a parameter as an argument, and to an argument as an "argument's value".
2. Defining methods that have default parameter values (arguments).
3. Using named arguments when calling a method (useful with #2).
4. Using LINQ query syntax (still definitely prefer method syntax though).
5. Learned what C#'s lamba syntax looks like.

**Which concept felt easiest (methods or LINQ) and why?**

Answer: Methods, since they're quite familiar and follow the same syntax as the rest of the language. If we're talking about LINQ as a whole, I found the LINQ query syntax quite confusing, since it's essentially a whole other language in the language.

## Time Spent

**Total time:** 3 hours

**Breakdown:**

- Understanding the starter code: 0.5 hours
- Implementing the print methods: 0.5 hours
- LINQ method chaining: 0.5 hours
- Testing and debugging: 1 hours
- Writing documentation: 0.5 hours

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: Testing, since there were many different methods to test.

## Reflection

**What would you improve next time?**

Answer: Printing the Passing and Failing scores uses very similar logic, so I could've probably created an additional method that takes a lambda as an argument (so I can pass the condition) and returns the formatted scores rather than having that logic mostly duplicated.

**How did methods make this program easier to work on?**

Answer: Methods made this program easier to work on by dividing it into more manageable pieces. I didn't have to keep everything in mind at once, I could go one method at a time.
