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
        private Button btnShowLess,btnExpand;
        private StackPanel specialBtnStackPanel;
        public MainWindow()
        {
            InitializeComponent();
            InitializeUIComponent();
            CreateUI();
        }
        private void InitializeUIComponent()
        {
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
            TextBox textBox = new TextBox()
            {
                Text = "0",
                Style = FindResource("TextBoxStyle") as Style,
                Name="inputTextBox"
            };
            Border border2 = new Border()
            {
                Style = FindResource("BorderStyle") as Style
            };
            TextBox textBox2 = new TextBox()
            {
                Text = "0",
                Style = FindResource("TextBoxStyle") as Style,
                Name="ResultTextBox"
            };
            border1.Child = textBox;
            border2.Child = textBox2;
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
