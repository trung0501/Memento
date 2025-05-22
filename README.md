1. Program name: Simple text editor using Memento Design Pattern

2. Program Purpose: The program simulates a simple text editor, allowing users to compose content and return previous states of the text. The goal is to store and restore the document status safely without changing or directly accessing the content inside the object.

3. The main component of the program:

   . TextEditorMemento: Records the state (text content) at a certain point in time.

   . TextEditor: Is the main object (Originator), allowing users to edit text, save and restore the state.

   . EditorHistory: Manages the history of state records (Caretaker), allowing saving and undoing.

   . Program: The Main function is used to run the program and simulate the actions: entering text, saving state, and undoing. 

4. Principle of operation:

   . Users enter the text through the Type() method of Texteditor.

   . When the current state of the text needs to be saved, the program calls Save() → creates a TextEditorMemento that saves the current content.

   . The EditorHistory object stores the mementos in a stack in chronological order.

   . When the user performs Undo, the program calls Undo() to get the last memento from the stack and restore the state of the TextEditor.
