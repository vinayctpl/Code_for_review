using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _TempValue;
        int _Result;
        string _LastOperation;
        public MainWindow()
        {
            InitializeComponent();
            InitializeValues();
        }
        private void InitializeValues()
        {
            _TempValue = "0";
            _Result = 0;
            this.labelResult.Text = "0";
            this.labelResult2.Text = "0";
            this._LastOperation = "";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "2";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue+"1";
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length == 0)
            {
                this.labelResult.Text = "0";
            }
            else if (_TempValue.Length == 1) this.labelResult.Text = "0";
            else this.labelResult.Text = _TempValue.Substring(0, _TempValue.Length - 1);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (Int32.Parse(_TempValue) == 0 || _TempValue.Length>9) return;
            this.labelResult.Text = _TempValue + "0";
        }

        
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            _TempValue = this.labelResult.Text;
            if (_TempValue.Length > 9) return;
            if (Int32.Parse(_TempValue) == 0)
            {
                this.labelResult.Text = "";
                _TempValue = this.labelResult.Text;
            }
            this.labelResult.Text = _TempValue + "9";
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            _Result = Calculate();
            this.labelResult2.Text = "" + _Result;
            this.labelResult.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            InitializeValues();
        }
        private int Calculate()
        {
            try
            {
                int currentValue = Int32.Parse(this.labelResult.Text);
                //System.Diagnostics.Trace.WriteLine(_LastOperation);
                if (_LastOperation == "+" || _LastOperation == "")
                {
                    _Result = _Result + currentValue;
                }
                else if (_LastOperation == "-")
                {
                    _Result = _Result - currentValue;
                }
                else if (_LastOperation == "*")
                {
                    _Result = _Result * currentValue;
                }
                else if (_LastOperation == "/")
                {
                    _Result = _Result / currentValue;
                }
            }
            catch(DivideByZeroException de)
            {
                MessageBox.Show("Cannot divide by zero, please enter some other value");
            }
            System.Diagnostics.Trace.WriteLine("3");
            return _Result;
        }
        private void checkFirstCase()
        {
            if(_LastOperation=="")
            {
                _Result = Calculate();
                this.labelResult2.Text = "" + _Result;
                this.labelResult.Text = "0";
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            checkFirstCase();
            //_Result = Calculate();
            //this.labelResult2.Text = "" + _Result;
            //this.labelResult.Text = "0";
            _LastOperation = "+";
        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            checkFirstCase();
            //_Result = Calculate();
            //this.labelResult2.Text = "" + _Result;
            //this.labelResult.Text = "0";
            _LastOperation = "-";
        }

        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            checkFirstCase();
            //_Result = Calculate();
            //this.labelResult2.Text = "" + _Result;
            //this.labelResult.Text = "0";
            _LastOperation = "*";
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            checkFirstCase();
            //_Result = Calculate();
            //this.labelResult2.Text = "" + _Result;
            //this.labelResult.Text = "0";
            _LastOperation = "/";
        }
    }
}
