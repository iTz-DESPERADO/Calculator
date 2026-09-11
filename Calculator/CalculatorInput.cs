using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator;

public sealed class CalculatorInput
{
    private readonly Operation[] _operations = Enum.GetValues<Operation>();

    private string _firstNumber = string.Empty;
    private string _secondNumber = string.Empty;
    private int _operationIndex;
    private int _currentIndex;

    public int CurrentIndex => _currentIndex;
    public Operation Operation => _operations[_operationIndex];
    public string FirstNumberDisplay => string.IsNullOrEmpty(_firstNumber) ? " " : _firstNumber;
    public string SecondNumberDisplay => string.IsNullOrEmpty(_secondNumber) ? " " : _secondNumber;
    public string ResultDisplay { get; private set; } = " ";
    public string? ErrorMessage { get; private set; }

    public void MoveLeft()
    {
        _currentIndex = Math.Max(0, _currentIndex - 1);
    }

    public void MoveRight()
    {
        _currentIndex = Math.Min(2, _currentIndex + 1);
    }

    public void ChangeOperation(int direction)
    {
        if (_currentIndex != 1)
            return;

        _operationIndex += direction;

        if (_operationIndex < 0)
            _operationIndex = _operations.Length - 1;
        else if (_operationIndex >= _operations.Length)
            _operationIndex = 0;

        ClearResult();
    }

    public void AddCharacter(char character)
    {
        if (_currentIndex == 1)
            return;

        if (character == '-')
        {
            ToggleSign();
            return;
        }

        if (!char.IsDigit(character) && character is not '.' and not ',')
            return;

        string currentValue = _currentIndex == 0 ? _firstNumber : _secondNumber;

        if (character is '.' or ',')
        {
            if (currentValue.Contains('.'))
                return;

            character = '.';

            if (string.IsNullOrEmpty(currentValue))
                currentValue = "0";
            else if (currentValue == "-")
                currentValue = "-0";
        }

        currentValue += character;

        SetCurrentNumber(currentValue);
        ClearResult();
    }

    private void ToggleSign()
    {
        string currentValue = _currentIndex == 0 ? _firstNumber : _secondNumber;

        currentValue = currentValue.StartsWith('-')
            ? currentValue[1..]
            : $"-{currentValue}";

        SetCurrentNumber(currentValue);
        ClearResult();
    }

    private void SetCurrentNumber(string value)
    {
        if (_currentIndex == 0)
            _firstNumber = value;
        else
            _secondNumber = value;
    }

    public void Backspace()
    {
        if (_currentIndex == 1)
            return;

        if (_currentIndex == 0 && _firstNumber.Length > 0)
            _firstNumber = _firstNumber[..^1];
        else if (_currentIndex == 2 && _secondNumber.Length > 0)
            _secondNumber = _secondNumber[..^1];

        ClearResult();
    }

    public void Calculate()
    {
        ErrorMessage = null;

        if (!double.TryParse(_firstNumber,NumberStyles.Float,CultureInfo.InvariantCulture,out double firstNumber) ||
            !double.TryParse(_secondNumber,NumberStyles.Float,CultureInfo.InvariantCulture,out double secondNumber))
        {
            ResultDisplay = " ";
            ErrorMessage = "Enter both numbers first.";
            return;
        }

        if(secondNumber == 0 && Operation == Operation.Divide)
        {
            ResultDisplay = " ";
            ErrorMessage = "Cannot divide by zero.";
            return;
        }
            double result = Calculator.Calculate(firstNumber, secondNumber, Operation);
            ResultDisplay = result.ToString("G15", CultureInfo.InvariantCulture);
       
    }

  

    private void ClearResult()
    {
        ResultDisplay = " ";
        ErrorMessage = null;
    }
}
