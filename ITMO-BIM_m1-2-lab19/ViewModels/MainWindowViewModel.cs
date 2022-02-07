using ITMO_BIM_m1_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITMO_BIM_m1_2.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        //static readonly string dbl_mask = @"\d*(,\d*)?";
        static readonly string dbl_mask = @"\d+(,\d+)?";
        readonly Regex dblRGX = new Regex(dbl_mask);
        readonly Regex valid1numRGX = new Regex(@"^\-?" + dbl_mask + "$");
        readonly Regex valid2numRGX = new Regex(@"^\-?" + dbl_mask + @"(\+|\-|\*|\/)" + dbl_mask + "$");
        
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string input; //входные данные - выражение (инфиксная запись)
        public string Input
        {
            get => input;
            set
            {
                input = value;
                if (input!= null && valid1numRGX.IsMatch(input))
                {
                    NumA = Convert.ToDouble(dblRGX.Matches(input)[0].Value);
                }
                OnPropertyChanged();
            }
        }

        private double numA; // Операнд №1
        public double NumA
        {
            get => numA;
            set
            {
                numA = value;
                //OnPropertyChanged();
            }
        }

        //private char op; // Оператор
        //public char Op
        private string op; // Оператор
        public string Op
        {
            get => op;
            set
            {
                op = value;
                //OnPropertyChanged();
            }
        }

        private double numB; // Операнд №2
        public double NumB
        {
            get => numB;
            set
            {
                numB = value;
                //OnPropertyChanged();
            }
        }

        private double result;
        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            ClearCommand = new RelayCommand(OnClearCommandExecute, CanClearCommandExecuted);

            Num0_Command = new RelayCommand(OnNum0_CommandExecute);
            Num1_Command = new RelayCommand(OnNum1_CommandExecute);
            Num2_Command = new RelayCommand(OnNum2_CommandExecute);
            Num3_Command = new RelayCommand(OnNum3_CommandExecute);
            Num4_Command = new RelayCommand(OnNum4_CommandExecute);
            Num5_Command = new RelayCommand(OnNum5_CommandExecute);
            Num6_Command = new RelayCommand(OnNum6_CommandExecute);
            Num7_Command = new RelayCommand(OnNum7_CommandExecute);
            Num8_Command = new RelayCommand(OnNum8_CommandExecute);
            Num9_Command = new RelayCommand(OnNum9_CommandExecute);

            CommaCommand = new RelayCommand(OnCommaCommandExecute, CanCommaCommandExecuted);

            SignCommand = new RelayCommand(OnSignCommandExecute, CanSignCommandExecuted);
            Pow2_Command = new RelayCommand(OnPow2_CommandExecute, CanPow2_CommandExecuted);
            PlusCommand = new RelayCommand(OnPlusCommandExecute, CanPlusCommandExecuted);
            MinusCommand = new RelayCommand(OnMinusCommandExecute, CanMinusCommandExecuted);
            DivideCommand = new RelayCommand(OnDivideCommandExecute, CanDivideCommandExecuted);
            MultiplyCommand = new RelayCommand(OnMultiplyCommandExecute, CanMultiplyCommandExecuted);

            CalcCommand = new RelayCommand(OnCalcCommandExecute, CanCalcCommandExecuted);

        }

        public ICommand ClearCommand { get; }
        private void OnClearCommandExecute(object p)
        {
            Input = null;
            Result = 0;
            NumA = 0.0;
            NumB = 0.0;
            Op = null;
        }
        private bool CanClearCommandExecuted(object p)
        {
            if (Input == null)
                return false;
            else
                return true;
        }

        public ICommand Num0_Command { get; }
        private void OnNum0_CommandExecute(object p)
        {
            Input += "0";
        }

        public ICommand Num1_Command { get; }
        private void OnNum1_CommandExecute(object p)
        {
            Input += "1";
        }

        public ICommand Num2_Command { get; }
        private void OnNum2_CommandExecute(object p)
        {
            Input += "2";
        }

        public ICommand Num3_Command { get; }
        private void OnNum3_CommandExecute(object p)
        {
            Input += "3";
        }

        public ICommand Num4_Command { get; }
        private void OnNum4_CommandExecute(object p)
        {
            Input += "4";
        }

        public ICommand Num5_Command { get; }
        private void OnNum5_CommandExecute(object p)
        {
            Input += "5";
        }

        public ICommand Num6_Command { get; }
        private void OnNum6_CommandExecute(object p)
        {
            Input += "6";
        }

        public ICommand Num7_Command { get; }
        private void OnNum7_CommandExecute(object p)
        {
            Input += "7";
        }

        public ICommand Num8_Command { get; }
        private void OnNum8_CommandExecute(object p)
        {
            Input += "8";
        }

        public ICommand Num9_Command { get; }
        private void OnNum9_CommandExecute(object p)
        {
            Input += "9";
        }


        public ICommand CommaCommand { get; }
        private void OnCommaCommandExecute(object p)
        {
            Input += ",";
        }
        private bool CanCommaCommandExecuted(object p)
        {
            Regex nuMendingRGX = new Regex(@"\d$");
            if (input!=null && nuMendingRGX.IsMatch(input))
                return true;
            else
                return false;
        }


        public ICommand SignCommand { get; }
        private void OnSignCommandExecute(object p)
        {
            if (input.StartsWith("-"))
                Input = Input.Substring(1);
            else
                Input = "-" + Input;
        }
        private bool CanSignCommandExecuted(object p)
        {            
            if (Input != null && valid1numRGX.IsMatch(input))
                return true;
            else
                return false;
        }


        public ICommand Pow2_Command { get; }
        private void OnPow2_CommandExecute(object p)
        {
            Result = Arif.Pow2(NumA);
        }
        private bool CanPow2_CommandExecuted(object p)
        {
            if (input != null && valid1numRGX.IsMatch(input))
                return true;
            else
                return false;
        }


        public ICommand PlusCommand { get; }
        private void OnPlusCommandExecute(object p)
        {
            Input += "+";
        }
        public bool CanPlusCommandExecuted(object p)
        {
            if (Input != null && valid1numRGX.IsMatch(Input))
                return true;
            else
                return false;
        }

        public ICommand MinusCommand { get; }
        private void OnMinusCommandExecute(object p)
        {
            Input += "-";
        }
        public bool CanMinusCommandExecuted(object p)
        {
            if (Input != null && valid1numRGX.IsMatch(Input))
                return true;
            else
                return false;
        }

    public ICommand DivideCommand { get; }
        private void OnDivideCommandExecute(object p)
        {
            Input += "/";
        }
        public bool CanDivideCommandExecuted(object p)
        {
            if (Input != null && valid1numRGX.IsMatch(Input))
                return true;
            else
                return false;
        }

    public ICommand MultiplyCommand { get; }
        private void OnMultiplyCommandExecute(object p)
        {
            Input += "*";
        }
        public bool CanMultiplyCommandExecuted(object p)
        {
            if (Input != null && valid1numRGX.IsMatch(Input))
                return true;
            else
                return false;
        }

    public ICommand CalcCommand { get; }
        private void OnCalcCommandExecute(object p)
        {
            switch (Op)
            {
                case "+":
                    {
                        Result = Arif.Addition(NumA,NumB);
                        break;
                    }
                case "-":
                    {
                        Result = Arif.Subtraction(NumA, NumB);
                        break;
                    }
                case "/":
                    {
                        Result = Arif.Division(NumA, NumB);
                        break;
                    }
                case "*":
                    {
                        Result = Arif.Multiplication(NumA, NumB);
                        break;
                    }
                default:
                    break;
            }
        }
        private bool CanCalcCommandExecuted(object p)
        {
            if (input != null && valid2numRGX.IsMatch(input))
            {
                string NumAstr = dblRGX.Matches(input)[0].Value;
                NumA = Convert.ToDouble(NumAstr);
                string str = input;
                if (input.StartsWith("-"))
                {
                    NumA = -NumA;
                    str = str.Substring(1);
                }
                NumB = Convert.ToDouble(dblRGX.Matches(input)[1].Value);
                Op = str.Substring(NumAstr.Length, 1);
                return true;
            }
            else
                return false;
        }
    }
}