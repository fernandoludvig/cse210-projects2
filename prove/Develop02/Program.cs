using System;

class Program
{
    static void Main(string[] args)
    {
         Journal journal = new Journal();
        string filename;

        while (true)
        {
            Console.WriteLine("Journal Application Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select a prompt or enter your own: ");
                        List<string> prompts = new List<string>
                        {
                            "Who was the most interesting person I interacted with today?",
                            "What was the best part of my day?",
                            "How did I see the hand of the Lord in my life today?",
                            "What was the strongest emotion I felt today?",
                            "If I had one thing I could do over today, what would it be?"
                        };

                        for (int i = 0; i < prompts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {prompts[i]}");
                        }

                        Console.Write("Enter the prompt number or your own: ");
                        if (int.TryParse(Console.ReadLine(), out int promptChoice) && promptChoice >= 1 && promptChoice <= prompts.Count)
                        {
                            Console.WriteLine("Enter your response: ");
                            string response = Console.ReadLine();
                            Entry newEntry = new Entry(prompts[promptChoice - 1], response);
                            journal.AddEntry(newEntry);
                        }
                        else
                        {
                            Console.Write("Enter your own prompt: ");
                            string prompt = Console.ReadLine();
                            Console.Write("Enter your response: ");
                            string response = Console.ReadLine();
                            Entry newEntry = new Entry(prompt, response);
                            journal.AddEntry(newEntry);
                        }
                        break;
                    case 2:
                        journal.Display();
                        break;
                    case 3:
                        Console.Write("Enter the filename to save the journal: ");
                        filename = Console.ReadLine();
                        journal.SaveToFile(filename);
                        break;
                    case 4:
                        Console.Write("Enter the filename to load the journal from: ");
                        filename = Console.ReadLine();
                        journal.LoadFromFile(filename);
                        break;
                    case 5:
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}