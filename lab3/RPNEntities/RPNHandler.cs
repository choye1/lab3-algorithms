using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNEntities
{
    public class RPNHandler
    {
        string userInput = null;
        float variable = 1;
        public RPNHandler(string userInput, float x) 
        { 
            this.userInput = userInput;
            this.variable = x;
        }
        public RPNHandler(string userInput)
        {
            this.userInput = userInput;
        }

        public float GetResult()
        {
            // ввод значения переменной
            float valueOfVariable = variable;
            var calculator = new RpnCalculator(userInput);
            List<Tokens> RPN = calculator.GetRPN();
            float result = calculator.CalculateExpression(RPN, valueOfVariable);
            return result;
        }
    }
}
