using System.Windows;
using CalcLogic;

namespace CalcDesktop
{
    public partial class MainWindow : Window
    {
        CCalc Calculator = new CCalc();
        double CurrentValue = 0;
        double StoredValue = 0;
        string Operation = "";
        bool enteringFirst = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        void DisplayValue()
        {
            if (Operation != "")
            {
                ValueTextBlock.Text = $"{StoredValue} {Operation} {CurrentValue}";
            }
            else
            {
                ValueTextBlock.Text = $"{CurrentValue}";
            }
        }

        void AddToken(char token)
        {
            if (CurrentValue == 0)
            {
                CurrentValue = double.Parse(token.ToString());
            }
            else
            {
                var val = CurrentValue.ToString();
                val += token;
                CurrentValue = double.Parse(val);
            }

            DisplayValue();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            AddToken('1');
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            AddToken('2');
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            AddToken('3');
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            AddToken('4');
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            AddToken('5');
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            AddToken('6');
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            AddToken('7');
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            AddToken('8');
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            AddToken('9');
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            AddToken('0');
        }

        private void ResetResult()
        {
            StoredValue = 0;
            CurrentValue = Calculator.Result();
            Operation = "";
            DisplayValue();
        }

        private void SetOperation(string operation)
        {
            enteringFirst = false;
            Operation = operation;
            StoredValue = CurrentValue;
            CurrentValue = 0;
            Calculator.Add(StoredValue);
            DisplayValue();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SetOperation("+");
        }

        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            SetOperation("-");
        }

        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            SetOperation("/");
        }

        private void BtnMult_Click(object sender, RoutedEventArgs e)
        {
            SetOperation("*");
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!enteringFirst)
            {
                switch (Operation)
                {
                    case "+":
                        Calculator.Add(CurrentValue);
                        break;
                    case "-":
                        Calculator.Substract(CurrentValue);
                        break;
                    case "/":
                        if (CurrentValue != 0)
                        {
                            Calculator.Divide(CurrentValue);
                        }
                        break;
                    case "*":
                        Calculator.Multiply(CurrentValue);
                        break;
                }

                ResetResult();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            StoredValue = 0;
            CurrentValue = 0;
            Operation = "";
            DisplayValue();
        }
    }
}
