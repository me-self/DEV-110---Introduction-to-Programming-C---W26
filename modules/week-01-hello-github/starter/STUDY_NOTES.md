# Week 1: Hello, GitHub - Study Notes

**Name:** Samuel Bellemare

## Development Environment Setup

**Software installed and versions:**
[List each piece of software you installed: .NET SDK, Visual Studio Code, Git, and any VS Code extensions]

Answer:
- Visual Studio Code (1.108.0)
- .NET SDK (9.0)
- ASP.NET core runtime (9.0)
- C# Dev Kit (1.90.2, Extension)
- C# (2.110.4, Extension dependency)
- .NET Install Tool (3.0.0, Extension dependency)
- EditorConfig for VS Code (0.17.4, Extension)
- Markdown All in One (3.6.3, Extension)
- indent-rainbow (8.3.1, Extension)
- Better Comments (3.0.2, Extension)
- (Git 2.52.0 comes shipped with Fedora, so I'm not including that)

**Operating system:**
[What OS are you using? Windows, macOS, or Linux?]

Answer: Linux (Fedora)

## Challenges and Solutions

**Biggest challenge during setup:**
[What was the hardest part? Installing software, configuring VS Code, understanding the terminal, or something else?]

Answer: Installing software

**How you solved it:**
[Explain what you did to overcome the challenge - search online, ask for help, restart your computer, etc.]

Answer: I first tried searching online, but eventually just decided to install VS code as a native package so it could access the .NET SDK (the flatpak package's sandboxing was interfering)

**Most confusing concept:**
[What was hardest to understand? Git commands, terminal navigation, C# syntax, or dotnet CLI?]

Answer: Git commands (managing branches in pariticular, as I had previously only done so via JetBrains' GUI, and even then, I barely used branches)

## Understanding C# Basics

**What does `Console.WriteLine()` do?**
[Explain in your own words what this command does]

Answer: `Console.WriteLine()` writes to standard output (usually the terminal).

**What is the purpose of `Program.cs`?**
[Why is this file important in a C# project?]

Answer: Program.cs is the entry point in a C# project.

**What does `dotnet run` do?**
[Explain what happens when you run this command]

Answer: The C# project gets built and executed.

## Git Workflow Understanding

**What is the difference between `git add`, `git commit`, and `git push`?**
[Explain each command and when you would use it]

Answer: `git add` stages file(s), these files are added via `git add .` (for all changes) or `git add [path/to/file]` and will be included in the next commit, it should be used to select changes to be included in a commit. `git commit` creates a new version / restore point (great for if you need to be able to reference an old version). And `git push` sends local commits to the remote repo (good for a remote backup and making the changes accessible to others).

**Why do we create branches?**
[Explain the purpose of creating a student branch]

Answer: by creating a student branch we can then create a pull request which can be reviewed before merging.

## What I Learned

**Key takeaways from this week:**
[What are the 3 most important things you learned?]

1. How to create git branches
2. How to protect the Main branch of a repo
3. How to auto-format with dotnet

**How this connects to professional development:**
[Why are these skills important for programmers?]

Answer: These are all especially important in collaborate environments. Creating git branches allows for collaboration on new features without risk of breaking the Main branch. Protecting the Main branch helps prevent accidents by stopping a direct push to Main. Consistency is *extremely* important, and auto-formatting helps a lot with that.

## Time Spent

**Total time:** 6 hours 43 minutes

**Breakdown:**

-   Installing and configuring software: 6 hours
-   Learning terminal/command line basics: 0 minutes
-   Writing the "Hello, GitHub!" program: < 1 minute
-   Understanding Git workflow: 40 minutes
-   Testing and fixing issues: 2 minutes
-   Writing documentation: 0 minutes

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: Installing and configuring software, by far, took the longest time. After installing VS code as a flatpak I first tried getting the .NET SDK to be accessible to it, but, even following the packager's instructions, I could not get it working. I then attempted to run VS code itself in a Podman container, in which I installed the SDK, but could not log in to Github from there, because VS code was attempting to open the authentication page in the container's default browser, which did of course *not* exist. So I then decided to create a VM that would have a more reasonable development environment (I'm using Fedora Silverblue on my host machine for the reliable updates, but it makes native packages more trouble to deal with). Then I decided to just install things on my host system, as it'd probably be less trouble than potentially having to get GPU passthrough working.
