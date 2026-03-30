# Final Project — Data Model Planning Template

_Fill this out **before** writing any code. Think through your app's data first._

---

## Scenario (1–2 sentences)

_What does your app do? Who uses it and why?_

It calculates various body measurements and ratios based on user inputs, including BMI, BRI, WHR, WHtR, and Ape Index. Above all, it should be convenient: it should *not* require that every measure is filled out right away, but should instead calculate as much as is possible with what is provided.

---

## Inputs (with types)

_List **at least 5** named inputs your app collects or works with. Include the data type for each._

_Example format:_
_- `movieTitle` (string) — the name of the movie the user enters_

- `height` (float) — the height of the user in inches
- `weight` (float) - the weight of the user in pounds
- `wingspan` (float) — the wingspan of the user in inches
- `waistCircumference` (float) — the waist circumference of the user in inches
- `hipCircumference` (float) — the hip circumference of the user in inches
- `profileName` (string) — the name of the profile under which to store the measurements

---

## Calculated or Derived Values

_List any values your program computes from the inputs (totals, averages, counts, formatted strings, etc.)._
_If your app doesn't calculate anything, write "None" and explain why._

- BMI
- BRI
- WHR
- WHtR
- Ape Index

---

## Outputs (what the user sees)

_Describe what the program displays. Include menu options, summary views, confirmation messages, etc._

- User management menu
- Confirmation prompts for certain actions
- Menu for editing measurements
- View of calculated ratios

---

## Edge Case to Consider (at least 1)

_What could go wrong or behave unexpectedly? How will your app handle it?_

_Examples: file not found, user enters a letter instead of a number, empty list, duplicate entry._

- Conflicting user names
- Save directory not found
- Save file(s) not found
- User enters not float values for measurements
