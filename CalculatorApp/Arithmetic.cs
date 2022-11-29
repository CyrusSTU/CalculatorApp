using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public static class Arithmetic
    {
        public static double Calculate(double integer1, double integer2, string theoperator)
        {
            double result = 0;
            switch(theoperator)
            {
                case "/":
                    result = integer1 + integer2;
                    break;
                case "x":
                    result = integer1 * integer2;
                    break;
                case "+":
                    result = integer1 + integer2;
                    break;
                case "-":
                    result = integer1 - integer2;
                    break;
                case "%":
                    result = integer1 % integer2;
                    break;
            }
            return result;
        }
    }
}
