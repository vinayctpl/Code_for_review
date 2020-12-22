using System;
using System.Collections;
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

namespace Calculator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox _InputTextBox, _ResultTextBox;
        private Button btnShowLess,btnExpand;
        private StackPanel specialBtnStackPanel;
        private int _Result;
        private String _LastOperation,_TempValue;
        public MainWindow()
        {
            InitializeComponent();
            InitializeUIComponent();
            InitializeVariables();
            CreateUI();
        }
        private void InitializeVariables()
        {
            this._Result = 0;
            this._LastOperation = "";
            this._TempValue = "";
        }
        private void InitializeUIComponent()
        {
            this._InputTextBox = null;
            this._ResultTextBox = null;
            btnShowLess = null;
            btnExpand = null;
            specialBtnStackPanel = null;
        }
        private void CreateUI()
        {
            RowDefinition gridRow = null;
            for (int i = 0; i < 6; i++)
            {
                gridRow = new RowDefinition();
                gridRow.Height = new GridLength(2, GridUnitType.Star);
                mainGrid.RowDefinitions.Add(gridRow);
            }
            
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            Border border1 = new Border()
            {
                Style = FindResource("BorderStyle") as Style
            };
            _InputTextBox = new TextBox()
            {
                Text = "0",
                Style = FindResource("TextBoxStyle") as Style,
                Name="inputTextBox"
            };
            Border border2 = new Border()
            {
                Style = FindResource("BorderStyle") as Style
            };
            this._ResultTextBox = new TextBox()
            {
                Text = "0",
                Style = FindResource("TextBoxStyle") as Style,
                Name="ResultTextBox"
            };
            border1.Child = _InputTextBox;
            border2.Child = _ResultTextBox;
            stackPanel.Children.Add(border1);
            stackPanel.Children.Add(border2);
            Grid.SetRow(stackPanel, 0);
            mainGrid.Children.Add(stackPanel);
            ArrayList buttonsList = new ArrayList()
            {
                '+','-','*','/','1','2','3','4','5','6','7','8',"Clr",'9','0','='
            };
            Border buttonBorder=null;
            Button button=null;
            int count = 0;
            StackPanel buttonStackPanel=null;
            for(int i=0;i<buttonsList.Count;i++)
            {
                if (i % 4 == 0)
                {
                    buttonStackPanel = new StackPanel()
                    {
                        Name = "buttonStackPanel" + count,
                        Orientation = Orientation.Horizontal,
                    };
                    Grid.SetRow(buttonStackPanel, count + 1);
                    mainGrid.Children.Add(buttonStackPanel);
                    count += 1;
                }
                if(buttonsList[i].GetType().Name=="Char" && Char.IsNumber(Convert.ToChar(buttonsList[i])))
                {
                    buttonBorder = new Border()
                    {
                        Style = FindResource("NumericBtnBorderStyle") as Style
                    };
                    button = new Button()
                    {
                        Style = FindResource("NumericButtonStyle") as Style
                    };
                }
                else if(buttonsList[i].GetType().Name=="Char")
                {
                    buttonBorder = new Border()
                    {
                        Style = FindResource("OperationBtnBorderStyle") as Style,
                    };
                    button = new Button()
                    {
                        Style = FindResource("OperationButtonStyle") as Style
                    };
                }
                else
                {
                    buttonBorder = new Border()
                    {
                        Style = FindResource("ClearBtnBorderStyle") as Style
                    };
                    button = new Button()
                    { 
                        Style=FindResource("ClearButtonStyle") as Style
                    };
                }
                button.Content = buttonsList[i];
                button.Click += new RoutedEventHandler(Btn_click);
                buttonBorder.Child = button;
                buttonStackPanel.Children.Add(buttonBorder);
            }
            double currentScreenSize = System.Windows.SystemParameters.WorkArea.Width - 20;
            btnExpand = new Button()
            {
                Content = "Expand",
                Style = FindResource("ExpandButtonStyle") as Style,
                MaxWidth = currentScreenSize
            };
            btnExpand.Click += new RoutedEventHandler(btnExpand_Click);
            Grid.SetRow(btnExpand,5);
            mainGrid.Children.Add(btnExpand);
        }

        private void Btn_click(object sender, RoutedEventArgs e)
        {
            Button tempButton = e.Source as Button;
            var a = tempButton.Content.GetType().Name;
            if(a=="String")
            {
                //In this we write functionalities for Clr, HEX, OCT, DEC, BIN
                String btnName = tempButton.Content as String;
                _TempValue = this._InputTextBox.Text;
                string result = "";
                switch (btnName)
                {
                    case "Clr":
                        InitializeVariables();
                        this._InputTextBox.Text = "0";
                        this._ResultTextBox.Text = "0";
                        return;
                    case "HEX":
                        result = Convert.ToString((Int32.Parse(_TempValue)), 16);
                        break;
                    case "OCT":
                        result = Convert.ToString(Int32.Parse(_TempValue), 8);
                        break;
                    case "BIN":
                        result = Convert.ToString(Int32.Parse(_TempValue), 2);
                        break;
                    case "DEC":
                        result = Convert.ToString(Int32.Parse(_TempValue), 10);
                        break;
                }
                this._ResultTextBox.Text = result;
                _LastOperation = "";
                this._InputTextBox.Text = "0";
            }
            else if(a=="Char")
            {
                Char btnName = (Char) tempButton.Content;
                System.Diagnostics.Trace.WriteLine("Char "+btnName);
                if (Char.IsNumber(btnName))
                {
                    // In this we will do, for what we want to do for number
                    int i = (int)(btnName - '0');
                    _TempValue = this._InputTextBox.Text;
                    if (_TempValue.Length > 9) return;
                    if(i==0)
                    {
                        if (Int32.Parse(_TempValue) == 0 || _TempValue.Length > 9) return;
                        this._InputTextBox.Text = _TempValue + "0";
                        return;
                    }
                    if (Int32.Parse(_TempValue) == 0) this._InputTextBox.Text = ""+btnName;
                    else this._InputTextBox.Text = _TempValue + btnName;
                }
                else
                {
                    //In this we will write functionalities for +, -, *, /, =
                    if (_LastOperation == "")
                    {
                        _Result = Calculate();
                        this._ResultTextBox.Text = "" + _Result;
                        this._InputTextBox.Text = "0";
                    }
                    switch(btnName)
                    {
                        case '+':
                            _LastOperation = "+";
                            break;
                        case '-':
                            _LastOperation = "-";
                            break;
                        case '*':
                            _LastOperation = "*";
                            break;
                        case '/':
                            _LastOperation = "/";
                            break;
                        case '=':
                            _Result = Calculate();
                            this._ResultTextBox.Text = "" + _Result;
                            this._InputTextBox.Text = "0";
                            break;
                    }
                }
            }
            
        }
        private int Calculate()
        {
            try
            {
                int currentValue = Int32.Parse(this._InputTextBox.Text);
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
            catch (DivideByZeroException de)
            {
                MessageBox.Show("Cannot divide by zero, please enter some other value");
            }
            return _Result;
        }
        private void btnExpand_Click(object sender, RoutedEventArgs e)
        {
            btnExpand.Visibility = Visibility.Collapsed;
            Application.Current.MainWindow.Height += 50;
            ArrayList al = new ArrayList()
            {
                "HEX","OCT","BIN","DEC"
            };
            specialBtnStackPanel = new StackPanel()
            {
                Name = "buttonStackPanel6",
                Orientation = Orientation.Horizontal
            };
            foreach(string s in al)
            {
                Border border = new Border()
                {
                    Style = FindResource("SpecialBtnBorderStyle") as Style
                };
                Button button = new Button()
                {
                    Style =FindResource("SpecialButtonStyle") as Style
                };
                button.Content = s;
                button.Click += new RoutedEventHandler(Btn_click);
                border.Child = button;
                specialBtnStackPanel.Children.Add(border);
            }
            Grid.SetRow(specialBtnStackPanel, 5);
            mainGrid.Children.Add(specialBtnStackPanel);
            RowDefinition gridRow = new RowDefinition();
            gridRow.Height = new GridLength(1, GridUnitType.Star);
            mainGrid.RowDefinitions.Add(gridRow);
            btnShowLess = new Button()
            {
                Content="Show Less",
                Style = FindResource("ExpandButtonStyle") as Style
            };
            btnShowLess.Click += new RoutedEventHandler(ShowLess_Click);
            Grid.SetRow(btnShowLess, 6);
            mainGrid.Children.Add(btnShowLess);
        }

        private void ShowLess_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Height -= 50;
            mainGrid.RowDefinitions.RemoveAt(6);
            btnShowLess.Visibility = Visibility.Hidden;
            btnExpand.Visibility = Visibility.Visible;
            specialBtnStackPanel.Visibility = Visibility.Hidden;
        }
    }
}
