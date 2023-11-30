using System;

class Program
{
    static void Main()
    {
        ActivityMenu();
    }

    static void ActivityMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice (1-4): ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        BreathingActivity.Execute();
                        break;
                    case 2:
                        ReflectionActivity.Execute();
                        break;
                    case 3:
                        ListingActivity.Execute();
                        break;
                    case 4:
                        Console.WriteLine("Thanks for using the activity app!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 4);
    }
}