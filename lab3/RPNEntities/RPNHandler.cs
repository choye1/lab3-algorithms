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
            try
            {
                // ввод значения переменной
                float valueOfVariable = variable;
                float result = 0;
                List<Tokens> RPN = new List<Tokens>();
                var calculator = new RpnCalculator(userInput);
                try { RPN = calculator.GetRPN(); }
                catch { throw new Exception("Произошла ошибка во время построения RPN"); }
                try { result = calculator.CalculateExpression(RPN, valueOfVariable); }
                catch { throw new Exception("Произошла ошибка во время вычисления RPN"); }
                return result;
            }
            catch
            {
                throw new Exception("Произошла ошибка во время инициализации RPN");
            }
        }

        public string GetRPN()
        {
            StringBuilder res = new StringBuilder();

            try
            {
                var calculator = new RpnCalculator(userInput);
                List<Tokens> RPN = new List<Tokens>();

                try { RPN = calculator.GetRPN(); }
                catch { throw new Exception("Произошла ошибка во время построения RPN"); }

                foreach (var token in RPN)
                {
                    res.Append(token.ToString());
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка во время инициализации RPN");
            }

            return res.ToString();
        }
    }
}
