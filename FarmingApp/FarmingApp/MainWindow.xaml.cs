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
using System.IO;
using Microsoft.Win32;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.CompoundDocumentFormat;
namespace FarmingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _DataFilePath;
        public MainWindow()
        {
            InitializeComponent();
            _DataFilePath = System.IO.Path.GetFullPath(".") + "\\data.txt";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double distanceBtwPlants, numberOfPlantsRequired, minAreaRequired, yeildPeriod, growingPeriod, plantTimeInNursery;
            double totalLifespan,plantProductivity;
            double afterFirst;
            string nameOfPlant = txtNameOfPlant.Text;
            string requirement = txtRequirement.Text;
            if (nameOfPlant=="" || nameOfPlant.Length==0)
            {
                // throw an error
            }
            if(requirement=="" || requirement.Length==0)
            {
                //throw an error
            }
            bool isExists = false;
            string requiredLine = "";
            string[] lines = File.ReadAllLines(_DataFilePath);
            foreach(string line in lines)
            {
                string[] words = line.Split(",");
                if (words[0] == nameOfPlant)
                {
                    isExists = true;
                    requiredLine = line;
                }
            }
            if(isExists==false)
            {
                // throw an error
            }
            //distanceBtwPlants = double.Parse(txtDistanceBtwPlants.Text);
            if(requiredLine.Length==0 || requiredLine=="")
            {
                //throw an error
                //this case will not occur but in very stange condition it can occur, so for precaution I am taking this case
            }
            string[] requiredLines = requiredLine.Split(",");
            distanceBtwPlants = double.Parse(requiredLines[1]);
            yeildPeriod = double.Parse(requiredLines[2]);
            growingPeriod = double.Parse(requiredLines[3]);
            plantTimeInNursery = double.Parse(requiredLines[4]);
            plantProductivity = double.Parse(requiredLines[5]);
            //System.Diagnostics.Trace.WriteLine(yeildPeriod + " " + growingPeriod);

            numberOfPlantsRequired = Math.Ceiling((double.Parse(requirement) * yeildPeriod)/plantProductivity);
            minAreaRequired = (numberOfPlantsRequired * Math.Pow(distanceBtwPlants,2))/Math.Pow(12,2);
            totalLifespan = yeildPeriod + growingPeriod;
            afterFirst = yeildPeriod + plantTimeInNursery + 1;
            txtPlants.Content = numberOfPlantsRequired+" Plants Required";
            txtArea.Content = minAreaRequired.ToString("0.00")+" feet Area Required";
            txtTotalLifeSpan.Content = totalLifespan + " weeks life span";
            txtAfterFirst.Content = afterFirst + " weeks put next plant from nursery into field";
        }

        private void DataEntry_Button_Click(object sender, RoutedEventArgs e)
        {
            DataEntry de = new DataEntry();
            de.Show();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();
            if(result==true)
            {
                string filename = openFileDialog.FileName;
                txtBrowse.Text = filename;
                txtBrowse.Text = "Processing the file (Please wait...)";
                Workbook workbook = Workbook.Load(filename);
                Worksheet worksheet = workbook.Worksheets[0];
                for(int rowIndex=worksheet.Cells.FirstRowIndex+1;rowIndex<=worksheet.Cells.LastRowIndex;rowIndex++)
                {
                    Row row = worksheet.Cells.GetRow(rowIndex);
                    int sno = Int32.Parse(row.GetCell(0).ToString()) ;
                    string nameOfPlant = row.GetCell(1).ToString();
                    double distanceBtwPlants = Double.Parse(row.GetCell(2).ToString());
                    double yieldPeriod = Double.Parse(row.GetCell(3).ToString());
                    double growingPeriod = Double.Parse(row.GetCell(4).ToString());
                    double nurseryTime = Double.Parse(row.GetCell(5).ToString());
                    double plantProductivity = Double.Parse(row.GetCell(6).ToString());
                    double requirement = Double.Parse(row.GetCell(7).ToString());
                    double numberOfPlantsRequired = Math.Ceiling((requirement * yieldPeriod) / plantProductivity);
                    double minAreaRequired = (numberOfPlantsRequired * Math.Pow(distanceBtwPlants, 2)) / Math.Pow(12, 2);
                    double totalLifespan = yieldPeriod + growingPeriod;
                    double afterFirst = yieldPeriod + nurseryTime+ 1;
                    row.SetCell(0, new Cell(rowIndex.ToString()));
                    row.SetCell(1, new Cell(nameOfPlant));
                    row.SetCell(2, new Cell(distanceBtwPlants));
                    row.SetCell(3, new Cell(yieldPeriod));
                    row.SetCell(4, new Cell(growingPeriod));
                    row.SetCell(5, new Cell(nurseryTime));
                    row.SetCell(6, new Cell(plantProductivity));
                    row.SetCell(7, new Cell(requirement));
                    row.SetCell(8, new Cell(numberOfPlantsRequired));
                    row.SetCell(9, new Cell(minAreaRequired.ToString("0.00")));
                    row.SetCell(10, new Cell(totalLifespan));
                    row.SetCell(11, new Cell(afterFirst));

                }
                worksheet.Cells.ColumnWidth[0, 1] = 3000;
                worksheet.Cells.ColumnWidth[0, 2] = 10000;
                workbook.Save(filename);
                txtBrowse.Text = "Finished (check file)";
            }
        }
    }
}
