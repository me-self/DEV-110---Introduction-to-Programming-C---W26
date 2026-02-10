# Week 5: Guess the Number - Study Notes

**Name:** Samuel Bellemare

## Loop Types

**How is a `do-while` loop different from a `while` loop?**
[Explain when each loop is best used]

Answer: `do-while`, unlike `while`, is best when you want the loop to run at least once, regardless of the condition. It has the condition evaluated following each iteration, rather than before.

**Where did you use a `do-while` loop in this assignment and why?**
[Describe the input validation use]

Answer: in this assignment, we want to get input at least once, then only repeat if the condition is true (if input failed to parse or was out of range), which `do-while` fits nicely (it runs at least once).

**Where did you use a `while` loop and why?**
[Describe the guessing loop]

Answer: a `while` loop is used for the user's guesses. We don't have a known number of iterations (the user could take any number of tries to guess), which the `while` loop is good for since it simply continues while true. A `do-while` loop *could* also work, but has no advantage over a `while` loop (since the condition is guaranteed to be false on the first iteration anyways) and would simply be more verbose. With a `do-while`, we wouldn't have to initalize `guess` ahead of time, so it could be practical if we wanted 0 to be a possible value for `secret`, without the risk of the skipping the loop altogether.

**Where did you use a `for` loop and why?**
[Describe the rounds loop]

Answer: a `for` loop is used to iterate through the number of rounds. This works well because there's a known number of iterations, and a `for` loop can cleanly define an increment a counter that continues until the our known number of rounds.

## Input Validation

**Why did you create a helper method for input validation?**
[Explain how it avoids repeating code for max value and rounds]

Answer: creating a method makes input validation much cleaner and easier to maintain, since the same implementation is reused, and all it requires is to pass values that must differ across calls (in this case, the prompt, min, and max). This makes things more readable and lower maintainence (you don't have to copy every change to multiple places).

**How did you make sure the max value was between 10 and 100?**
[Explain your range check logic]

Answer: 10 and 100 are passed to the `ReadIntInRange` function as the `min` and `max` arguments respectively. The `do-while` continues looping if the user's input is less than `min` or greater than `max`, ensuring we only exit the loop and return once the user provided value is in the desired range.

**How did you make sure the number of rounds was between 1 and 3?**
[Explain your range check logic]

Answer: Similarily to how it is ensured that the max value is in range, the `min` and `max`, arguments are each set, in this case, to 1 and 3 respectively. The `do-while` loop repeats if the provided number is less than `min` or greater than `max` ensuring we can never get a value out the min to max range returned.

**How did you handle invalid input (non-numbers)?**
[Explain how int.TryParse works]

Answer: `int.TryParse` returns a `true` on success and `false` on failure which can be used to decide to prompt the user again. The int itself written to the second argument which uses the `out` keyword so that the orginal variable is modified rather than just the copied value.

## Guessing Logic

**How did you compare the guess to the secret number?**
[Explain the if/else logic for too low, too high, and correct]

Answer: if guess is less than secret, I print `Too low.`, then I have an else if guess is greater than secret then I print `Too high.`. Last, I have an else, since the only remaining possibility is for it to be equal.

**How did you count the number of guesses?**
[Explain where you incremented the counter]

Answer: I increment the counter with `guessCount++` before providing feedback to the user since the win message must have an up-to-date guess count.

## Random Numbers

**How did you generate the secret number?**
[Explain Random and Next(min, max)]

Answer: `Random` is an object we create with a seed. On it are methods to get various kinds of random data, including `Next(min, max)` which returns an `int` in the given range from min to max.

**Why does `Random.Next(1, max + 1)` include the max value?**
[Explain why +1 is needed]

Answer: the range is non inclusive of the max value, so 1 must be added to include `max` itself in the possibilities.

## Testing and Debugging

**What inputs did you test to confirm your loops worked correctly?**
[List several test cases]

Answer: I tested numbers below the minimum, numbers above the maximum, and letters, and a combination of letters and numbers.

**What bugs or errors did you encounter and fix?**
[Describe any logic or loop errors]

Answer: I didn't end up encountering any errors, though I *almost* incremented `guessCount` after giving feedback, which would've made the number of guesses displayed on win one too low.

## What I Learned

**Key takeaways from this week:**
[3-5 main things you learned]

1. How to create an instance of Random
2. How to generate an int using Random
3. foreach loop

**Which loop felt most natural to use and why?**

Answer:

## Time Spent

**Total time:** 1 hour 30 minutes

**Breakdown:**

- Planning the loops: 10 minutes
- Input validation: 20 minutes
- Guessing logic: 20 minutes
- Testing and debugging: 10 minutes
- Writing documentation: 30 minutes

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: Writing documentation was the most time consuming part because this program had less code repetition (due to using the same `ReadIntInRange`), so the ratio of comments to code was greater.

## Reflection

**What would you do differently next time?**

Answer: Next time I might display an error message for invalid input, but I didn't do it this time because the assignment did not ask for that. Also since it was using a `do-while` every iteration is the same, so displaying an error would've shown it even on the first iteration, unless I were to have a nested if statement in there, but that would've meant a redundant `!isValid || value < min || value > max`, unless I were to make that same if statement `break` and take the condition out of the `do-while`, but that didn't seem to be what the assignment was asking for.

**How did using three different loop types improve your understanding of repetition?**

Answer:
