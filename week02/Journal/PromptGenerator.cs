/*
- Hold a list of prompt strings (at least five)
- Return a random one when asked
*/

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person you interacted with today?");
        _prompts.Add("What was the best part of your day?");
        _prompts.Add("How did you see the hand of the Lord in your life today?");
        _prompts.Add("What was the strongest emotion you felt today?");
        _prompts.Add("If you had one thing you could do over today, what would it be?");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}