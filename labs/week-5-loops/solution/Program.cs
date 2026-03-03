/**********************************************
*    Course: DEV 110
*    Instructor: Zak Brinlee
*    Term: Winter 2026
*
*    Programmer: Zak Brinlee
*    Assignment: Loops - Ticket Booth Simulator Lab
*
*    What does this program do?:
*    Simulates a ticket booth where each group selects ticket types
*    and quantities, then prints group totals and a final summary.
*
*/

Console.WriteLine("=== Ticket Booth Simulator ===\n");

int rounds = ReadIntInRange("How many groups? (1-3): ", 1, 3);

double grandTotal = 0.0;
int totalTickets = 0;

for (int round = 1; round <= rounds; round++)
{
    Console.WriteLine($"\nGroup {round} of {rounds}");

    double groupTotal = 0.0;
    int groupTickets = 0;
    bool addMore = true;

    while (addMore)
    {
        Console.WriteLine("\nTicket Types:");
        Console.WriteLine("1) Adult ($12.00)");
        Console.WriteLine("2) Student ($8.00)");
        Console.WriteLine("3) Child ($5.00)");

        int ticketType = ReadIntInRange("Choose ticket type (1-3): ", 1, 3);
        int quantity = ReadIntInRange("How many tickets? (1-10): ", 1, 10);

        string ticketLabel = "";
        double ticketPrice = 0.0;

        switch (ticketType)
        {
            case 1:
                ticketLabel = "Adult";
                ticketPrice = 12.00;
                break;
            case 2:
                ticketLabel = "Student";
                ticketPrice = 8.00;
                break;
            case 3:
                ticketLabel = "Child";
                ticketPrice = 5.00;
                break;
        }

        double lineTotal = ticketPrice * quantity;
        groupTotal += lineTotal;
        groupTickets += quantity;

        Console.WriteLine($"{ticketLabel} x{quantity} = {lineTotal:C2}");

        string moreInput = ReadYesNo("Add more tickets? (y/n): ");
        addMore = moreInput == "y";
    }

    Console.WriteLine($"Group tickets: {groupTickets}");
    Console.WriteLine($"Group total: {groupTotal:C2}");

    grandTotal += groupTotal;
    totalTickets += groupTickets;
}

Console.WriteLine("\n=== Summary ===");
Console.WriteLine($"Total tickets: {totalTickets}");
Console.WriteLine($"Grand total: {grandTotal:C2}");
Console.WriteLine("Thanks for visiting!");

static int ReadIntInRange(string prompt, int min, int max)
{
    int value;
    bool isValid;

    do
    {
        Console.Write(prompt);
        isValid = int.TryParse(Console.ReadLine(), out value);

        if (!isValid || value < min || value > max)
        {
            Console.WriteLine($"Please enter a number from {min} to {max}.");
        }
    } while (!isValid || value < min || value > max);

    return value;
}

static string ReadYesNo(string prompt)
{
    string input;

    do
    {
        Console.Write(prompt);
        input = Console.ReadLine().Trim().ToLower();

        if (input != "y" && input != "n")
        {
            Console.WriteLine("Please enter 'y' or 'n'.");
        }
    } while (input != "y" && input != "n");

    return input;
}
