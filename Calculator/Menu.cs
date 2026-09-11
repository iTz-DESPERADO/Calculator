using System;

namespace Calculator;

public sealed class Menu
{
    private readonly CalculatorInput _input = new();
    private readonly ConsoleColor _selectionColor = ConsoleColor.Red;

    public void ShowMenu()
    {
        Console.CursorVisible = false;

        try
        {
            while (true)
            {
                Render();

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.LeftArrow:
                        _input.MoveLeft();
                        break;

                    case ConsoleKey.RightArrow:
                        _input.MoveRight();
                        break;

                    case ConsoleKey.UpArrow:
                        _input.ChangeOperation(-1);
                        break;

                    case ConsoleKey.DownArrow:
                        _input.ChangeOperation(1);
                        break;

                    case ConsoleKey.Backspace:
                        _input.Backspace();
                        break;

                    case ConsoleKey.Enter:
                        _input.Calculate();
                        break;

                    default:
                        _input.AddCharacter(keyInfo.KeyChar);
                        break;
                }
            }
        }
        finally
        {
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Clear();
        }
    }

    private void Render()
    {
        Console.Clear();

        Console.WriteLine("\t\t\t\t==============================================");
        Console.WriteLine("\t\t\t\t                Simple Calculator             ");
        Console.WriteLine("\t\t\t\t==============================================\n");

        Console.Write("\t\t\t\t        ");

        WriteSelectable($"[{_input.FirstNumberDisplay}]", 0);
        Console.Write("   ");
        WriteSelectable(_input.Operation.ToSymbol(), 1);
        Console.Write("   ");
        WriteSelectable($"[{_input.SecondNumberDisplay}]", 2);
        Console.Write($"   =   [{_input.ResultDisplay}]");

        Console.WriteLine("\n\n");
        Console.WriteLine("\t\t\t\t        ← →   Move");
        Console.WriteLine("\t\t\t\t        ↑ ↓   Change operation");
        Console.WriteLine("\t\t\t\t        Enter Calculate");
        Console.WriteLine("\t\t\t\t        Esc   Exit");

        if (!string.IsNullOrWhiteSpace(_input.ErrorMessage))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\t\t\t\t        {_input.ErrorMessage}");
            Console.ResetColor();
        }

        Console.WriteLine("\n\t\t\t\t==============================================");
    }

    private void WriteSelectable(string value, int index)
    {
        if (_input.CurrentIndex == index)
            Console.ForegroundColor = _selectionColor;

        Console.Write(value);
        Console.ResetColor();
    }
}
