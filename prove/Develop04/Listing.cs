using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity
{
    public static void Execute()
    {
        Console.WriteLine("Listing Activity - Reflect on the Good Things in Your Life");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[randomIndex]);

        Console.WriteLine($"Get ready to list... (You have {duration} seconds)");
        Countdown(5);

        Console.WriteLine("Start listing:");

        int count = 0;
        string input;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write($"{count + 1}. ");
            input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            ++count;
        }

        Console.WriteLine($"You listed {count} items. Well done!");
        Console.Write($"Well done! You completed the Listing Activity for {duration} seconds.");
        ShowSpinner(3);
    }

    static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; --i)
        {
            Console.Write($"{i} ".PadRight(Console.WindowWidth - 3));
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        Console.WriteLine();
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