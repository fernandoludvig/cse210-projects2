class Scripture
{
    private string reference;
    private string text;
    private List<ScriptureWord> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public string Reference { get { return reference; } }
    public List<ScriptureWord> Words { get { return words; } }

    public bool AreAllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    public void HideRandomWord()
    {
        var visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            var randomIndex = new Random().Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
        }
    }

    public override string ToString()
    {
        return $"{reference}: {string.Join(" ", words)}";
    }
}