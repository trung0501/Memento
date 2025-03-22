using System;
using System.Collections.Generic;

// Memento: Storing the state of the object
class TextEditorMemento
{
    public string Content { get; }

    public TextEditorMemento(string content)
    {
        Content = content;
    }
}

// Originator: The main object has a change
class TextEditor
{
    private string _content = "";

    public void Type(string words)
    {
        _content += words + " ";
    }

    public string GetContent()
    {
        return _content;
    }

    // Save the current state
    public TextEditorMemento Save()
    {
        return new TextEditorMemento(_content);
    }

    // Restore status from Memento
    public void Restore(TextEditorMemento memento)
    {
        _content = memento.Content;
    }
}

// Caretaker: History management
class EditorHistory
{
    private Stack<TextEditorMemento> _history = new Stack<TextEditorMemento>();

    public void Save(TextEditor editor)
    {
        _history.Push(editor.Save());
    }

    public void Undo(TextEditor editor)
    {
        if (_history.Count > 0)
        {
            editor.Restore(_history.Pop());
        }
    }
}

// Use Memento Pattern
class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();
        EditorHistory history = new EditorHistory();

        editor.Type("Hello");
        history.Save(editor);

        editor.Type("Trung");
        history.Save(editor);

        editor.Type("!!!");
        Console.WriteLine("Current content: " + editor.GetContent()); // Hello Trung !!!

        history.Undo(editor);
        Console.WriteLine("After Undo: " + editor.GetContent()); // Hello Trung

        history.Undo(editor);
        Console.WriteLine("After Undo again: " + editor.GetContent()); // Hello
    }
}
