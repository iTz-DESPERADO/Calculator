using System;

namespace Calculator;

public static class Calculator
{
    public static double Calculate(double firstNumber, double secondNumber, Operation operation)
    {
        return operation switch
        {
            Operation.Add => firstNumber + secondNumber,
            Operation.Subtract => firstNumber - secondNumber,
            Operation.Multiply => firstNumber * secondNumber,
            Operation.Divide =>  firstNumber / secondNumber,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
}

public enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide
}

public static class OperationExtensions
{
    public static string ToSymbol(this Operation operation)
    {
        return operation switch
        {
            Operation.Add => "+",
            Operation.Subtract => "-",
            Operation.Multiply => "*",
            Operation.Divide => "/",
            _ => "?"
        };
    }
}
