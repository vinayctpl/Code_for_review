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
    }
}
