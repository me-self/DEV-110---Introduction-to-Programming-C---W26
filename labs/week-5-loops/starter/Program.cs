/*********************************************************************
*    Course: DEV 110
*    Instructor: Zak Brinlee
*    Term: Winter 2026
*
*    Programmer: YourName
*    Assignment: Ticket Booth Simulator Lab
*
*    What does this program do?:
*    Simulates a ticket booth where each group selects ticket types
*    and quantities, then prints group totals and a final summary.
*
*/
// Follow the TODOs to complete the program.

Console.WriteLine("=== Ticket Booth Simulator ===\n");

// TODO 1: Create a helper method named ReadIntInRange (bottom of file TODO: 1.1)
// Requirements:
// - Parameters: string prompt, int min, int max
// - Use a do-while loop
// - Use int.TryParse
// - Repeat until input is valid and within range
// - Return the valid int

// TODO 2: Create a helper method named ReadYesNo (bottom of file TODO: 2.1)
// Requirements:
// - Parameter: string prompt
// - Use a do-while loop
// - Accept only "y" or "n" (lowercase)
// - Return the valid string

// TODO 3: Ask how many groups (1-3) using ReadIntInRange
// Prompt: "How many groups? (1-3): "
// Store result in an int named rounds

// TODO 4: Create grand totals outside the loop
// double grandTotal = 0.0;
// int totalTickets = 0;

// TODO 5: Use a for loop to repeat for each group
// Example: for (int round = 1; round <= rounds; round++)
// Inside the loop, print: $"\nGroup {round} of {rounds}"

// TODO 6: Create group totals inside the for loop
// double groupTotal = 0.0;
// int groupTickets = 0;
// bool addMore = true;

// TODO 7: Use a while loop to add tickets while addMore is true
// Inside the loop:
// - Display the ticket menu
// - Get ticket type (1-3) using ReadIntInRange
// - Get quantity (1-10) using ReadIntInRange

// TODO 8: Use a switch to set ticketLabel and ticketPrice
// Ticket types:
// 1) Adult ($12.00)
// 2) Student ($8.00)
// 3) Child ($5.00)

// TODO 9: Calculate line total and update group totals
// double lineTotal = ticketPrice * quantity;
// groupTotal += lineTotal;
// groupTickets += quantity;
// Print: $"{ticketLabel} x{quantity} = {lineTotal:C2}"

// TODO 10: Ask if they want to add more tickets
// string moreInput = ReadYesNo("Add more tickets? (y/n): ");
// addMore = moreInput == "y";

// TODO 11: After the while loop, print group summary
// "Group tickets: X"
// "Group total: $Y"
// Update grandTotal and totalTickets

// TODO 12: After the for loop, print final summary
// "=== Summary ==="
// "Total tickets: X"
// "Grand total: $Y"
// "Thanks for visiting!"

// TODO 1.1: Add the ReadIntInRange helper method here

// TODO 2.1: Add the ReadYesNo helper method here
