# Week 7: Class Roster Builder (Arrays) - Study Notes

**Name:** Samuel Bellemare

## Arrays and `count`

**What are “parallel arrays” and how did you use them in this assignment?**
[Explain how rosterNames and rosterCredits stay lined up by index]

Answer: Parallel arrays are arrays related by their index. In other words, the index acts as an identifier for a certain set of values, in this case a `string` name, and `int` credit with the same index are related pieces of data (they relate to the same entry).

**What is the purpose of the `count` variable?**
[Explain how it tracks how many roster slots are “in use”]

Answer: The `Length` provides that capacity of the array, but the capacity is not necessarily the number of elements that have actually had an entry written to them, so the seperate `count` variable serves as a way to track how many elements have an entry written to them and should be read.

**Where did you use `count` in loops and why?**
[Explain why you loop 0..count-1 instead of using the full array length]

Answer: Indices in C#, as with most languages (apart from Lua, and maybe a few others), start at 0, so the last index is always one less than the number of elements. For instance if you have an array with 1 element, the Length is 1, but, because indexing starts at the 0, the first (and last element) is at 0.

## Printing and Sorting

**How did you print the class roster using a `foreach` loop?**
[Describe building an array of roster lines and then printing each line]

Answer: the `BuildRosterLines` method uses a `for` loop since the index is needed to be able to access parallel arrays. After that, there is only one array to deal with, and the index is not needed for anything else, so a `foreach` is suitable for iterating through the output lines.

**How did you sort the roster while keeping names and credits aligned?**
[Describe copying the used roster into new arrays and using Array.Sort on parallel arrays]

Answer: `Sort` does sorting based on the first array passed to it, and moves the corresponding items from the other array too.

## What I Learned

**Key takeaways from this week:**
[3-5 main things you learned]

1. Creating arrays in C#
2. Initalizing arrays in C#
3. THIS IS A PLACEHOLDER BECAUSE THE ONE BELOW DOESN'T MATCH THE REGEX IN THE TEST
4. `List` is C#'s equivalent to Rust's `Vec` or C++'s `vector`
5. How to use the `Sort` method

**Which loop felt most natural to use and why?**

Answer: still the `while` loop since that one is pretty much always identical across languages.

## Time Spent

**Total time:** 3 hours 45 minutes

**Breakdown:**

- Planning the arrays/menu: 20 minutes
- Input validation: 5 minutes
- Add + print roster features: 2 hours
- Sorting feature: 20 minutes
- Testing and debugging: 30 minutes
- Writing documentation: 30 minutes

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: Adding entries to the roster. I spend a while trying to figure out why I was getting an index of of range error, until I released I had used `count` as the size of the new arrays, rather than `studentsToAddCount`.

## Reflection

**What would you do differently next time?**

Answer: Not something different in implementation, but I think I should probably write things top to bottom next time instead of doing it in kind of whatever order since that would've likely avoided the bug I mentioned above since the main reason I didn't spot that was cause I implemented things in a weird order.

**How did using `for` and `foreach` improve your understanding of arrays?**

Answer: Given that arrays are generally pretty identical across languages, using `for` and `foreach` hasn't changed my understanding of arrays themselves very much, but it has helped me get familiar with identifying where a `for` or `foreach` is most appropriate when working with arrays.
