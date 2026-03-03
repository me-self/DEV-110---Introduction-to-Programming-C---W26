# Week 5: Guess the Number - Loop Trio

## Summary

Build a simple “Guess the Number” game that uses all three loop types (`while`, `do-while`, and `for`). The game will run for a small number of rounds, validate inputs, and give feedback on each guess.

## Learning Objectives

- Use a `do-while` loop for input validation
- Use a `while` loop for repetition until a condition is met
- Use a `for` loop to repeat a fixed number of rounds
- Compare values and provide user feedback
- Track counts and display summary results

---

## Resources

- [C# While and Do-While Loops](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement)
- [C# For Loop](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement)
- [Random Class](https://learn.microsoft.com/en-us/dotnet/api/system.random)

---

## Assignment Requirements

Update a console program that follows this flow:

1. **Update the helper method for input validation**
    - Create `ReadIntInRange(prompt, min, max)`
    - Use a `do-while` loop and `int.TryParse`
    - Repeat until the value is within range

2. **Validate the maximum value using a `do-while` loop**
    - Prompt: `Enter a max value (10-100):`
    - Accept only values from 10 to 100 (inclusive)
    - Keep asking until valid input is entered

3. **Validate the number of rounds (1–3)**
    - Prompt: `How many rounds? (1-3):`
    - Accept only values from 1 to 3 (inclusive)

4. **Run the game for the chosen number of rounds using a `for` loop**

    Each round must:
    - Generate a secret number between 1 and `max` (inclusive)
    - Ask the user to guess until correct using a `while` loop
    - After each guess, print **“Too low.”** or **“Too high.”** when incorrect
    - Count the number of guesses
    - When correct, print: `Correct! You got it in X guesses.`

---

## Example Output

```
=== Guess the Number: Loop Trio ===

Enter a max value (10-100): 8
Enter a max value (10-100): 25
How many rounds? (1-3): 2

Round 1 of 2
Guess a number (1-25): 10
Too low.
Guess a number (1-25): 18
Too high.
Guess a number (1-25): 14
Correct! You got it in 3 guesses.

Round 2 of 2
Guess a number (1-25): 5
Too low.
Guess a number (1-25): 12
Correct! You got it in 2 guesses.

Thanks for playing!
```

---

## Getting Started

1. Navigate to the starter folder:

    ```bash
    # Mac/Linux:
    cd modules/week-05-guess-the-number/starter

    # Windows:
    cd modules\week-05-guess-the-number\starter
    ```

2. Review the TODO comments in `Program.cs`
3. Run your program:

    ```bash
    dotnet run
    ```

4. Test your work:

    ```bash
    # Mac/Linux:
    dotnet test ../tests

    # Windows:
    dotnet test ..\tests
    ```

---

## Grading Criteria

Your assignment will be automatically graded with tests that verify:

- Input validation for max value (10–100)
- Input validation for number of rounds (1–3)
- Correct use of `do-while`, `while`, and `for`
- Proper guessing loop behavior (too low / too high)
- Correct guess counting
- Output formatting and prompts

---

## Grading Criteria

Your assignment will be automatically graded with 5 test cases:

| Test Area                        | Points  | Tests  |
| -------------------------------- | ------- | ------ |
| **Basic Setup**                  |         |        |
| Program compiles                 | 10      | Test01 |
| **Loops + Validation**           |         |        |
| Input validation + rounds loop   | 30      | Test02 |
| Guessing loop feedback + prompts | 30      | Test03 |
| **Study Notes**                  |         |        |
| STUDY_NOTES.md exists            | 10      | Test04 |
| All sections completed           | 20      | Test05 |
| **Total**                        | **100** |        |

---

## Helpful Tips

### Loop Selection

- **`do-while`** is best when you need to ask _at least once_ before checking validity.
- **`while`** is best when repeating until a correct answer is found.
- **`for`** is best when you already know how many times to repeat.

### Input Validation (Helper Method)

```csharp
private static int ReadIntInRange(string prompt, int min, int max)
{
    int value;
    bool isValid;

    do
    {
        Console.Write(prompt);
        isValid = int.TryParse(Console.ReadLine(), out value);
    } while (!isValid || value < min || value > max);

    return value;
}
```

### Guess Counting

```csharp
int guessCount = 0;
while (guess != secret)
{
	guessCount++;
	// check guess here
}
```

---

## Bonus Challenges

- Add a “play again” option after all rounds finish
- Track the best (lowest) number of guesses
- Show a small scoreboard at the end
- Add simple ASCII art

---
