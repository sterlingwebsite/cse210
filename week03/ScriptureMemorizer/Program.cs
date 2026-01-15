/*
Student Name: Sterling Steele
Assignment: W03 Project: Scripture Memorizer Program
Class: CSE 210
Enhancements:
- scripture library
    I added a class that contains a list of scriptures. The program chooses one of the scriptures at random to use for the memorizing program.
- difficulty mode
    Options include easy, medium, and hard with the option to hide one, two, or three words at a time, respectively.
    The user is allowed to change the difficulty after a reset.

- reset option
    The user can restart the memorization process with the same scripture. The user need only type 'reset'.

- improved word-hiding logic
    The program will not re-hide words (unless the user resets the program). If the user chooses to hide three words at a time, the program will not hide words that are already hidden. This ensures the program hides exactly the amount of words the difficulty level specifies.

- progress indicator
    a progress indicator shows how many words are hidden vs. how many words there are in all.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        ScriptureLibrary library = new ScriptureLibrary();
        var entry = library.GetRandomScripture();

        Scripture scripture = new Scripture(entry.reference, entry.text);

        int difficulty = ChooseDifficulty();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine($"\nProgress: {scripture.GetHiddenWordCount()} / {scripture.GetTotalWordCount()} words hidden");
            Console.WriteLine("Press Enter to hide words, type 'reset' to start over, or 'quit' to exit.");

            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            if (input == "reset")
            {
                scripture.Reset();

                difficulty = ChooseDifficulty();

                continue;
            }

            scripture.HideRandomWords(difficulty);

            if (scripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Good job!");
                break;
            }
        }
    }

    static int ChooseDifficulty()
    {
        Console.WriteLine("Choose difficulty (easy, medium, hard): ");
        string choice = Console.ReadLine().ToLower();

        if (choice == "medium")
        {
            Console.WriteLine("Medium will hide two random words at a time.");
            Console.ReadLine();
            return 2;
        }
        if (choice == "hard")
        {
            Console.WriteLine("Hard will hide three random words at a time.");
            Console.ReadLine();
            return 3;
        }
        Console.WriteLine("Easy will hide one random word at a time.");
        Console.ReadLine();
        return 1;
    }
}