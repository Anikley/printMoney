// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("NUMERIC MONEY INTO PRINTING FORM");
        Console.WriteLine("Please, type money value more then 0 and less then 2000000000 (like 1357256.32) --> ");

        var printedValue = Console.ReadLine();
        try
        {
            var money = new Money(double.Parse(printedValue ?? string.Empty));
            Console.WriteLine(money.ToString());
        }
        catch (Exception exc)
        {
            Console.WriteLine($"{exc.Message}");
        }
    }
}
