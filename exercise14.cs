// Exercism practica 14 Isandel Abreu

//Calculator Conundrum 

using System;

public static class SimpleCalculator
{
    public static string Calculate(int a, int b, string operation)
        => operation switch {
            "/" when b == 0 => "Division by zero is not allowed.",
            null => throw new ArgumentNullException(),
            "" => throw new ArgumentException(),	
            _ => null
        } ?? $"{a} {operation} {b} = {
            operation switch{
                "+" => SimpleOperation.Addition(a,b),
                "*" => SimpleOperation.Multiplication(a,b),
                "/" when b != 0 => SimpleOperation.Division(a,b),
                _ => throw new ArgumentOutOfRangeException(), 
        }}";
}





public static class SimpleOperation
{
    public static int Division(int operand1, int operand2)
    {
        return operand1 / operand2;
    }

    public static int Multiplication(int operand1, int operand2)
    {
        return operand1 * operand2;
    }

    public static int Addition(int operand1, int operand2)
    {
        return operand1 + operand2;
    }
}




//SimpleOperation
/*

public static class SimpleOperation
{
    public static int Division(int operand1, int operand2)
    {
        return operand1 / operand2;
    }

    public static int Multiplication(int operand1, int operand2)
    {
        return operand1 * operand2;
    }

    public static int Addition(int operand1, int operand2)
    {
        return operand1 + operand2;
    }
}

*/
