class ScriptureWord
{
    private string word;
    private bool isHidden;

    public ScriptureWord(string word)
    {
        this.word = word;
        this.isHidden = false;
    }

    public bool IsHidden { get { return isHidden; } }

    public void Hide()
    {
        isHidden = true;
    }

    public override string ToString()
    {
        return isHidden ? "______" : word;
    }
}

abstract class ScriptureViewer
{
    protected Scripture scripture;

    public ScriptureViewer(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public abstract void Run();
}

class ConsoleScriptureViewer : ScriptureViewer
{
    public ConsoleScriptureViewer(Scripture scripture) : base(scripture) { }

    public override void Run()
    {
        do
        {
            Console.Clear();
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        } while (!scripture.AreAllWordsHidden());
    }
}