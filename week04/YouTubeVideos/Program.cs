using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video("Learning C#", "Alice", 600);
            video1.AddComment(new Comment("Bob", "Great video!"));
            video1.AddComment(new Comment("Charlie", "Very informative."));
            video1.AddComment(new Comment("Diana", "Thanks for sharing!"));

            Video video2 = new Video("Advanced C# Concepts", "Eve", 900);
            video2.AddComment(new Comment("Frank", "This was a bit over my head."));
            video2.AddComment(new Comment("Grace", "Loved the examples!"));

            Video video3 = new Video("C# Design Patterns", "Hank", 750);
            video3.AddComment(new Comment("Ivy", "Can't wait to try these out."));
            video3.AddComment(new Comment("Jack", "Well explained!"));
            video3.AddComment(new Comment("Kathy", "Very useful content."));

            Video video4 = new Video("C# Async Programming", "Liam", 800);
            video4.AddComment(new Comment("Mia", "This cleared up a lot of confusion."));
            video4.AddComment(new Comment("Noah", "Excellent tutorial!"));
            video4.AddComment(new Comment("Olivia", "Helped me a lot, thanks!"));

            List<Video> videos = new List<Video> { video1, video2, video3, video4 };

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.GetTitle()}");
                Console.WriteLine($"Author: {video.GetAuthor()}");
                Console.WriteLine($"Length (seconds): {video.GetLengthInSeconds()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"\t{comment.GetAuthor()}: {comment.GetText()}");
                }
                Console.WriteLine();
            }
        }
    }
}