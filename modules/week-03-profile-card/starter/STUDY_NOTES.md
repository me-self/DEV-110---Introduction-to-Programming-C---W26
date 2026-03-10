# Week 3: Personal Profile Card - Study Notes

**Name:** Samuel Bellemare

## Understanding Variables and Data Types

**What are the four main data types you used in this assignment?**
[List string, int, double, and bool - explain what each stores and give examples from your profile card]

Answer: a `string` is a set of chararacters (such as a name or a job title), an `int` is an integer (like a whole number, but signed, it can be used to represent an age, or, of course, a favorite number), a `double` is a floating point number so it can represent decimal values too (such as a height), a `bool` is great when you only need two states (it can either be true or false, such as whether you are a full time student).

**Why did you use `double` for GPA instead of `int`?**
[Explain the difference and why decimal precision matters for GPA]

Answer: GPA isn't a whole number, so we can't represent it with an int. We need do use a double so a GPA like 3.8 for instance, would be accepted.

**How did you convert the yes/no input into a boolean?**
[Explain the comparison operation you used]

Answer: I used the `==` since that evaluates to `true` if both operands are the same, allowing me to check if the user input is a specific string, and translating that to a `true` or `false`.

## Data Modeling Decisions

**How did you organize the information into logical groups?**
[Explain why you grouped certain pieces of information together (personal, academic, etc.)]

Answer: Grouping pieces of data helps keep things clear. It's easier to find what you're looking for that way.

**Which pieces of information did you calculate rather than ask for?**
[List the derived data: birth year, years to graduation, height conversion, honor status, age in months]

Answer: They're listed above? birth year, years to graduation, height in feet and inches, honor status, and age in months.

**Why is it better to calculate birth year from age rather than ask for both?**
[Explain data consistency and reducing redundant input]

Answer: Asking for more data gives the user more work, and increases risk of user error. A program should save the user work.

## Challenges and Solutions

**Biggest challenge with this assignment:**
[What was the hardest part? Type conversion, calculations, formatting, choosing data types?]

Answer: Probably the formatting. Getting a border around the output when the input could be of any length required a lot of consideration.

**How you solved it:**
[Explain your approach to overcoming the challenge]

Answer: I wrote helper functions to make the task less repetive and cleaner.

**Most confusing concept:**
[What was hardest to understand? Type casting, modulus for height, boolean logic, or formatting?]

Answer: Formatting was also the most confusing, as I didn't know how best to get the border around the card.

## Type Conversion and Calculations

**How do you convert string input to a number?**
[Explain Parse methods: int.Parse(), double.Parse()]

Answer: The Parse() method will convert a string to the type the method Parse() method is defined on (or error if invalid). TryParse() returns `true` on success or `false` on failure allowing you to prompt the user again; it sets the second argument to the parsed value.

**What calculation did you use to convert height from inches to feet and inches?**
[Explain: feet = inches / 12, remaining = inches % 12]

Answer: `(int)(inches / 12)` allowed me to convert inches to feet, truncated by the cast since I don't want partial feet. `inches % 12` got me the remainder (any inches that weren't included in the number of feet).

**How did you determine if someone is an honor student?**
[Explain the boolean comparison: gpa >= 3.5]

Answer: `gpa >= 3.5` evaluates to `true` if `gpa` is greater or equal to `3.5`, and `false` otherwise.

## Output Formatting

**How did you format the GPA to show exactly 2 decimal places?**
[Explain the :F2 format specifier]

Answer: The `:F2` format specifier is used in string interpolation to display 2 decimal places.

**How did you display different text based on whether someone is full-time or part-time?**
[Explain the conditional/ternary operator you used]

Answer: I used the ternary operator `... : ... ? ...` which returns the 2nd operand if the first operand is `true`, or the 3rd operand if the first operand is `false`. I made the 2nd and 3rd operands string be the string message corresponding to `true` and `false` respectively.

**What techniques did you use to make the output look organized?**
[Discuss alignment, spacing, section headers, borders]

Answer: I made use of borders, aligned using padding. Some borders seperate sections to provide spacing between them. The section headers were placed at the top of each section to make it clear what the section is.

## Real-World Data Modeling

**What other calculated fields could you add to a profile?**
[Think of other derived data: BMI from height/weight, time to birthday, etc.]

Answer: Age at graduation, and the person's intials could both be derived from the current input.

**Why is choosing the right data type important in real applications?**
[Explain memory, precision, and type safety]

Answer: types have different memory usage (e.g. int is 4 bytes, while double 8 bytes), using a double where only an int is needed would be wasteful, but the opposite should also be kept in mind: using an int where a double should be used will result in everything getting truncated (not good for something like the GPA). It is also important to use the right data type to avoid problems when casting: although casting from a smaller type to a larger one is generally straightforward, casting a larger type to a smaller one can be problematic (since it might not have enough bits to store the value the orginal type could store).

**How does this profile card relate to real-world applications?**
[Think about social media profiles, job applications, student records systems]

Answer: This has many things in common with social media profiles (e.g. you might set a timezone, and it will calculate your offset from other people, maybe it displays how long ago you joined). It has similarities to student records systems, showing things like GPA, full time or not, and various other pieces of information derived from fewer inputs. It also displays itself neatly formatted by section, as you'd expect from real-world applications.

## What I Learned

**Key takeaways from this week:**
[What are the 3-5 most important things you learned about variables and data modeling?]

1. Learning about C#'s constants was definitely a important one
2. What happens when trying to cast from a larger type to a smaller one
3. I learned the difference between flow and logic, which can help me model how data changes

**Which data type was most challenging to work with and why?**
[Reflect on your experience with string, int, double, or bool]

Answer: `double`. With a double, formatting is easier to accedentally mess up by forgetting the `:F2` format specifier, and, although not an issue in this project floating point types have other limitations (such as it not being suitable for most equality checks).

**How does understanding data types help you write better programs?**
[Explain the benefits of type safety and appropriate data representation]

Answer: type safety helps catch errors at compile-time. Appropriate data representation is, in turn, needed to ensure you can do what you need to do with your data.

## Testing and Debugging

**What test cases did you use to verify your calculations?**
[List different inputs you tested - edge cases, typical values, etc.]

Answer: I tested out of range values on inputs with a range, I tested numerical inputs with strings, and for the yes / no prompt, I tested with other strings, both uppercase and lowercase.

**What bugs or errors did you encounter and fix?**
[Describe any type conversion errors, calculation mistakes, or formatting issues]

Answer: Originally my calculation of feet wasn't truncating the value, so 18 inches would give 1.5 ft. 6 in.

**How did you validate that your data types were correct?**
[Explain how you checked that GPA, heights, ages worked correctly]

Answer: I used the bool returned by TryParse() along with the necessary range checks as while loop conditions to ensure the provided values were of the correct types and in range (in any).

## Time Spent

**Total time:** 4 hours 30 minutes

**Breakdown:**

-   Understanding data types and planning variables: 10 minutes
-   Collecting user input with correct types: 2 hours
-   Implementing calculations: 30 minutes
-   Formatting output: 1 hour
-   Testing and debugging: 30 minutes
-   Writing documentation: 20 minutes

**Most time-consuming part:** Collecting user input, since each must be validated differently.

Answer: Validating user input. It's different for nearly every input (expect strings), so I have to come up with and implement a different way to validate different kinds of input.

## Reflection

**What would you do differently if you started over?**
[Consider variable names, calculation order, organization, etc.]

Answer: I would've probably tried organizing more functionality into methods, to reduce certain code duplication and improve readability.

**How does proper data modeling make programs easier to maintain?**
[Think about readability, consistency, and reducing errors]

Answer: Data modeling improves readability because you can then plan ahead for what you need next, rather than sticking more things on top of something existing, this in turn, also improves consistency. Knowing what data you're dealing with at the start is also very useful in reducing logic errors (e.g. accedentally doing int division instead of float division).

**What real-world system would you like to model next?**
[Shopping cart, game character, recipe calculator, etc.]

Answer: Recipe calculator would be cool since I do like baking.
