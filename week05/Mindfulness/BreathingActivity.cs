public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
                "This activity will help you relax by walking you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    public void RunBreathing()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreath in...");
            ShowCountDown(4);

            Console.Write("\nNow breathe out...");
            ShowCountDown(6);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}