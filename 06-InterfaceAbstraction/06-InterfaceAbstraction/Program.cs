using _06_InterfaceAbstraction;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("1-ci ədəd ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write(" (+, -, *, /) ");
        string op = Console.ReadLine();

        Console.Write("2-ci ədəd ");
        double b = Convert.ToDouble(Console.ReadLine());

        ICalculation calc = new Calculation(op);

        double result = calc.Calculate(a, b);

        Console.WriteLine("Nəticə: " + result);
    }
}