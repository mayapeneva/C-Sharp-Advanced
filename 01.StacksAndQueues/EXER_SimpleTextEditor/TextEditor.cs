using System;
using System.Collections.Generic;
using System.Text;

namespace EXER_SimpleTextEditor
{
    public class TextEditor
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var text = new StringBuilder();
            var commandsToUndo = new Stack<string[]>();
            var textToUndo = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                switch (int.Parse(command[0]))
                {
                    case 1: text.Append(command[1]);
                        commandsToUndo.Push(command);
                        break;
                    case 2:
                        var count = int.Parse(command[1]);
                        textToUndo.Push(text.ToString().Substring(text.Length - count));
                        text.Remove(text.Length - count, count);
                        commandsToUndo.Push(command);
                        break;
                    case 3:
                        var index = int.Parse(command[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        var undoCommand = commandsToUndo.Pop();
                        switch (int.Parse(undoCommand[0]))
                        {
                            case 1:
                                text.Remove(text.Length - undoCommand[1].Length, undoCommand[1].Length);
                                break;
                            case 2:
                                text.Append(textToUndo.Pop());
                                break;
                        }
                        break;
                }
            }
        }
    }
}
