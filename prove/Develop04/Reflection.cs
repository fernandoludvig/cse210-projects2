using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity
{
    public static void Execute()
    {
        Console.WriteLine("Reflection Activity - Reflect on Strength and Resilience");
        Console.WriteLine("Think of a time when you...");

        string[] prompts = {
            "stood up for someone else.",
            "did something really difficult.",
            "helped someone in need.",
            "did something truly selfless."
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[randomIndex]);

        List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        foreach (var question in questions)
        {
            Console.Write(question + " ");
            ShowSpinner(3);
        }

        Console.Write($"Well done! You completed the Reflection Activity for {GetDuration()} seconds.");
        ShowSpinner(3);
    }

    static int GetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        return int.Parse(Console.ReadLine());
    }

    static void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int i = 0;
        for (int j = 0; j < seconds * 10; ++j)
        {
            Console.Write(spinner[i] + " ");
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            i = (i + 1) % 4;
        }
        Console.WriteLine();
    }
}