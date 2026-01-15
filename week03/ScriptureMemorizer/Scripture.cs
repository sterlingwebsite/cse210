using System.Dynamic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();

        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0)
            return;

        for (int i = 0; i < count; i++)
        {
            if (visibleWords.Count == 0)
                break;

            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AreAllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        string referenceText = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", displayWords);

        return $"{referenceText} {scriptureText}";
    }

    public int GetHiddenWordCount()
    {
        return _words.Count(w => w.IsHidden());
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    public void Reset()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }
}