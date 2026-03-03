Planning Template

Scenario (1–2 sentences):
Create a Ticket Booth Simulator that lets each group buy different ticket types, repeats for a few groups, and totals tickets and cost.

Inputs (with types):

- rounds (int) — number of groups (1–3)
- ticketType (int) — 1=Adult, 2=Student, 3=Child
- quantity (int) — number of tickets (1–10)
- moreInput (string) → addMore (bool)

Calculated values (with formulas):

- ticketLabel (string) + ticketPrice (double):
    - 1 → Adult, 12.00
    - 2 → Student, 8.00
    - 3 → Child, 5.00
- lineTotal (double): ticketPrice × quantity
- groupTotal (double): sum of lineTotal for the current group
- groupTickets (int): sum of quantity for the current group
- grandTotal (double): sum of groupTotal across all groups
- totalTickets (int): sum of groupTickets across all groups

Outputs (what the user sees):

- Welcome banner
- Prompt for number of groups
- Ticket menu and prompts for type/quantity
- Line total after each ticket entry
- Group summary (tickets + total)
- Final summary (total tickets + grand total)

Edge case to consider (1):
User enters invalid numbers or letters for group count, ticket type, or quantity.
