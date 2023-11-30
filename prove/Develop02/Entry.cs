using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public void Display()
    {
        Console.WriteLine("Date: " + Date);
        Console.WriteLine("Prompt: " + Prompt);
        Console.WriteLine("Response: " + Response);
    }
}