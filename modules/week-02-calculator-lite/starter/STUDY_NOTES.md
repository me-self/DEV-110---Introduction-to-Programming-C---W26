# Week 2: Calculator Lite - Study Notes

**Name:** Samuel Bellemare

## Understanding Data Types

**What are the four data types you used in this assignment?**
[List each data type (string, bool, int, double) and explain what kind of data each one stores]

Answer:
- string: stores a series of characters
- bool: either `true` or `false`
- int: an integer (like a whole number, signed)
- double: a signed, floating point number (can store all real numbers)

**Why did we use `double` instead of `int` for the calculations?**
[Explain the difference between int and double, and why double is better for this calculator]

Answer: Contrary to a `double`, an `int` has no floating point (no decimal value). A `double` is better suited for this calculator because it does not truncate results, while an `int` would truncate e.g. `9/2`'s result of `4.5` to `4`.

**How do you convert a string to a boolean?**
[Explain how you converted the user's "yes/no" input into a true/false value]

Answer: I use the `==` operator, which evaluates to `true` if both operands are equal, and `false` otherwise. I make use of the or (`||`) operator to get true if either comparison (`yes` or `y`) evaluates to true.

## Challenges and Solutions

**Biggest challenge with this assignment:**
[What was the hardest part? Understanding data types, getting user input, performing calculations, formatting output, or handling division by zero?]

Answer: The combination of formatting output and handling division by zero was the hardest. To be able to format to either 0 or 2 decimal places, I need to keep the result as a `double`, but when I get a division by zero I can't calculate a value for said `double`, this meant I would either have to: calculate the result on demand (twice) or calculate it ahead of time with a default value in case of division by zero (the approach I took).

**How you solved it:**
[Explain what you did to overcome the challenge - reviewed documentation, asked for help, tested different approaches, etc.]

Answer: I tested different approaches. Honestly, I'm still not *totally* happy with the approach I took, but it is functional.

**Most confusing concept:**
[What was hardest to understand? Parsing input, modulus operator, percentage formula, conditional formatting, or something else?]

Answer: The percentage formula. I've never encountered it before.

## Understanding Arithmetic Operations

**What is the difference between the modulus operator (%) and division (/)?**
[Explain what each operator does and give an example]

Answer: The modulus operator (`%`) provides the remainder (e.g. `6 % 4 = 2`) while division (`/`) provides the quotient (`6 / 4 = 1.5`).

**How do you calculate the average of two numbers?**
[Write the formula in your own words]

Answer: `(x + y) / 2`

**What is the formula for percentage difference?**
[Explain the formula you used: ((num1 - num2) / num1) * 100]

Answer: This formula gives the difference to num2 as a percent of num1.

## Input and Output

**How do you read user input in C#?**
[Explain what Console.ReadLine() does and what type of data it returns]

Answer: `Console.ReadLine()` reads standard input up to the next newline and returns it as a `string`.

**How do you convert string input to a number?**
[Explain the Parse methods you used, like double.Parse()]

Answer: the `Parse` methods allow for converting a `string` to type on which the method is defined, and returning it. Additionally, there is `TryParse` which returns `true` on success, or `false` on failure, which is ideal for user input since you can handle invalid input.

**What is string interpolation and how did you use it?**
[Explain the $ symbol and curly braces {} in Console.WriteLine()]

Answer: the `$` symbol allows for the use of interpolation using curly braces `{}`. Within the curly braces, refering to a variable name inserts the value into the string rather than the name itself, avoiding the need for string concatenation.

## Conditional Logic

**How do you format numbers with 2 decimal places vs whole numbers?**
[Explain the :F2 and :F0 format specifiers]

Answer: `:F2` and `:F0` are applied to variables in string interpolation to format floating point values to a certain number of places (`:F2` displaying 2, and `:F0` displaying 0)

**Why is it important to check for division by zero?**
[Explain what happens if you try to divide by zero and how you handled it]

Answer: Division of a `double` by zero results in `infinity` (or `NaN` for `%`).

**How did you use the boolean variable to control formatting?**
[Explain how you used if/else to format output differently based on user preference]

Answer: I use an if statement to only calculate the results of equations with a non-zero divisor. Then another if to only display the equation and result if the divisor is non-zero, else display the Division by zero error message.

## What I Learned

**Key takeaways from this week:**
[What are the 3-5 most important things you learned?]

1. I learned about format specifiers that allow for specifying how to display value (limiting the decimal places displayed).
2. I learned that division by zero with `double`s doesn't cause a runtime error.
3. I learned about the percentage difference formula which I did not know about before.
4. I learned what `out` in `TryParse` does.

**Which data type concept was most useful?**
[Explain which data type (string, bool, int, or double) you found most interesting and why]

Answer: `double`, the behavior on division by zero (not a runtime error) is interesting, and the format specifiers that can be used are neat.

**How does conditional formatting improve user experience?**
[Why is it helpful to let users choose decimal precision?]

Answer: This limits the complexity to only what the user needs, making the interface clearer, but flexible when needed.

## Testing and Debugging

**What test cases did you use to verify your program works?**
[List the different inputs you tested - positive numbers, negative numbers, decimals, zero, etc.]

Answer: I tested both num1 and num2 as 0, positive ints, negative ints, positive doubles, and negative doubles.

**What bugs or errors did you encounter and fix?**
[Describe any errors you got and how you fixed them]

Answer: Some of my formatting was off since I had missed 2 `F2`s after copying the it from one if branch to the other. I did a search for all `F2`s to make sure I wouldn't leave any improper formatting in.

## Time Spent

**Total time:** 2 hours 45 minutes

**Breakdown:**

-   Understanding data types: 5 minutes
-   Reading and parsing user input: 20 minutes
-   Implementing arithmetic operations: 5 minutes
-   Adding conditional formatting: 1 hour
-   Handling division by zero: 1 hour
-   Testing and debugging: 5 minutes
-   Writing documentation: 10 minutes (assuming this means comments since we don't have other kinds of documentation?)

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: The combination of conditional formatting and handling division by zero since they both involve branching, making it difficult to mix them and avoid code duplication. This had me trying to come up with better solutions for quite a while.

## Reflection

**What would you do differently next time?**
[What would you change in your approach or code?]

Answer: I would probably check for division by zero with `IsInfinity`, `IsNegativeInfinity`, and `IsNaN` instead of the two if approach I took.

**How does this assignment prepare you for more complex programs?**
[Why are these skills important for future programming tasks?]

Answer: This assignment was good practice in making an adaptive interface, a skill that is very important for improving UX in all kinds of software.
