using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Convenience property for counts.
    public int Count => _entries.Count;

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        Console.WriteLine(new string('=', 40));
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                output.WriteLine(e.Serialize());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("File not found.", filename);
        }

        string[] lines = File.ReadAllLines(filename);

        _entries.Clear();
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            _entries.Add(Entry.Deserialize(line));
        }
    }
}
