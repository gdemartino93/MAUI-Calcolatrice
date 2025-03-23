using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI_Calcolatrice.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel
    {
        private const string SpecialCharacters = "+-*/.=%";

        public string Formula { get; set; } = string.Empty;
        public string Result { get; set; } = "0";
        public ICommand OperationCommand => new Command((number) =>
        {
            string input = number?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
                return;

            switch (input)
            {
                case "AC":
                    ClearFormula();
                    ClearResult();
                    return;

                case "RemoveLast":
                    RemoveLastChar();
                    return;
            }

            if (IsDoubleSpecialCharacter(input)) return;

            Formula += input;
        });
        public ICommand CalculateCommand => new Command(() =>
        {
            if (string.IsNullOrEmpty(Formula))
            {
                ClearFormula();
                ClearResult();
                return;
            }

            string result = Calculator.Calculate(Formula).Result.ToString();
            Result = result;
        });

        private void ClearFormula()
        {
            Formula = string.Empty;
        }

        private void ClearResult()
        {
            Result = "0";
        }

        private void RemoveLastChar()
        {
            if (!string.IsNullOrEmpty(Formula))
            {
                Formula = Formula[..^1];
            }
        }

        private bool IsDoubleSpecialCharacter(string input)
        {
            if (string.IsNullOrEmpty(Formula)) return false;

            char lastChar = Formula[^1];
            return SpecialCharacters.Contains(lastChar) && SpecialCharacters.Contains(input);
        }

    }
}
