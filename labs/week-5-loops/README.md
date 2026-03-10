# Week 5 Lab - Ticket Booth Simulator

## 🎯 Learning Objectives

In this code-along lab, you will practice:

1. **`do-while` loops** (input validation)
2. **`while` loops** (repeating ticket entries)
3. **`for` loops** (fixed number of groups)
4. **User input** with `Console.ReadLine()`
5. **Type conversion** with `int.TryParse()`
6. **Menu selection** with `switch`
7. **Tracking totals** across rounds

## 📚 What You'll Build

A **Ticket Booth Simulator** program that:

- Greets the user
- Asks how many groups will buy tickets
- Repeats a ticket menu for each group
- Calculates line totals and group totals
- Displays a final summary

## 🚀 Getting Started

### Step 1: Navigate to the Project

```bash
cd labs/week-5-loops/starter
```

### Step 2: Open Program.cs

Open the file and follow the TODO comments from top to bottom.

### Step 3: Follow Along with Your Instructor

Write the code as you go. Test often!

## 📝 Variable Names to Use

Please use these variables to match the instructor demo:

- `rounds` (int)
- `round` (int)
- `ticketType` (int)
- `quantity` (int)
- `ticketLabel` (string)
- `ticketPrice` (double)
- `lineTotal` (double)
- `groupTotal` (double)
- `groupTickets` (int)
- `grandTotal` (double)
- `totalTickets` (int)
- `addMore` (bool)
- `moreInput` (string)

## 🧪 Test Your Program

Run the program after each section:

```bash
dotnet run
```

### Sample Run

```
=== Ticket Booth Simulator ===

How many groups? (1-3): 2

Group 1 of 2

Ticket Types:
1) Adult ($12.00)
2) Student ($8.00)
3) Child ($5.00)
Choose ticket type (1-3): 2
How many tickets? (1-10): 3
Student x3 = $24.00
Add more tickets? (y/n): n
Group tickets: 3
Group total: $24.00

Group 2 of 2

Ticket Types:
1) Adult ($12.00)
2) Student ($8.00)
3) Child ($5.00)
Choose ticket type (1-3): 1
How many tickets? (1-10): 2
Adult x2 = $24.00
Add more tickets? (y/n): y

Ticket Types:
1) Adult ($12.00)
2) Student ($8.00)
3) Child ($5.00)
Choose ticket type (1-3): 3
How many tickets? (1-10): 1
Child x1 = $5.00
Add more tickets? (y/n): n
Group tickets: 3
Group total: $29.00

=== Summary ===
Total tickets: 6
Grand total: $53.00
Thanks for visiting!
```

## ✅ Success Criteria

You are done when:

- All TODOs are completed
- Your program runs without errors
- All three loop types are used (`do-while`, `while`, `for`)
- Ticket totals and group totals are correct
- A final summary is displayed at the end
