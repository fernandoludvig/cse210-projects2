class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine("Date: " + entry.Date);
                writer.WriteLine("Prompt: " + entry.Prompt);
                writer.WriteLine("Response: " + entry.Response);
                writer.WriteLine("------------------------------------");
            }
        }
        Console.WriteLine("Journal saved to " + filename);
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries before loading new ones
        using (StreamReader reader = new StreamReader(filename))
        {
            Entry entry = null;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Date: "))
                {
                    DateTime date;
                    if (DateTime.TryParse(line.Substring(6), out date))
                    {
                        entry = new Entry("", "") { Date = date };
                        entries.Add(entry);
                    }
                }
                else if (line.StartsWith("Prompt: ") && entry != null)
                {
                    entry.Prompt = line.Substring(8);
                }
                else if (line.StartsWith("Response: ") && entry != null)
                {
                    entry.Response = line.Substring(10);
                }
            }
        }
        Console.WriteLine("Journal loaded from " + filename);
    }
}