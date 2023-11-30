using System;
using System.Threading;

class BreathingActivity
{
    public static void Execute()
    {
        Console.WriteLine("Breathing Activity - Relaxation through Breath");
        Console.WriteLine("Clear your mind and focus on your breathing.");

        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        for (int i = 0; i < duration; ++i)
        {
            Console.Write("Breathe in... ");
            Countdown(3);
            Console.Write("Breathe out... ");
            Countdown(3);
        }

        Console.WriteLine($"Well done! You completed the Breathing Activity for {duration} seconds.");
        ShowSpinner(3);
    }

    static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; --i)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
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