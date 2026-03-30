using System;
using System.Collections.Generic;
using System.Text;

namespace _06_InterfaceAbstraction
{
    public class Calculation : ICalculation
    {
        private string _operation;

        public Calculation(string operation)
        {
            _operation = operation;
        }

        public double Calculate(double a, double b)
        {
            switch (_operation)
            {
                case "+":
                    return a + b;

                case "-":
                    return a - b;

                case "*":
                    return a * b;

                case "/":
                    if (b == 0)
                        throw new DivideByZeroException("0-a bölmək olmaz!");
                    return a / b;

                default:
                    throw new InvalidOperationException("Yanlış əməliyyat!");
            }
        }
    }
}
