/*
Stores:
- The date (as a string, per assignment simplification)
- The prompt text
- The user’s response
- The user's mood (enhancement)
*/
using System.Linq.Expressions;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public string _mood;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine();
    }
}