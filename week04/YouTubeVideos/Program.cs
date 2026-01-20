using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Change a Tire", "Sterling Steele", 420);
        v1.AddComment(new Comment("Jake", "Great tutorial!"));
        v1.AddComment(new Comment("Maria", "This helped me a lot."));
        v1.AddComment(new Comment("Tom", "Clear and easy to follow."));
        videos.Add(v1);

        Video v2 = new Video("C# Classes Explained", "CodeMaster", 600);
        v2.AddComment(new Comment("Alice", "Very helpful explanation."));
        v2.AddComment(new Comment("Ben", "Thanks for breaking it down."));
        v2.AddComment(new Comment("Sara", "Now I finally get it!"));
        videos.Add(v2);

        Video v3 = new Video("DIY Desk Build", "Workshop Wizard", 900);
        v3.AddComment(new Comment("Leo", "Looks awesome!"));
        v3.AddComment(new Comment("Nina", "I want to build one now."));
        v3.AddComment(new Comment("Chris", "What tools did you use?"));
        videos.Add(v3);

        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}