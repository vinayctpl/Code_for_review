using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;

namespace FarmingApp
{
    /// <summary>
    /// Interaction logic for DataEntry.xaml
    /// </summary>
    public partial class DataEntry : Window
    {
        string _DataFilePath;
        public DataEntry()
        {
            InitializeComponent();
            _DataFilePath = System.IO.Path.GetFullPath(".") + "\\data.txt";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = null ;
            StreamWriter sw = null; ;
            string nameOfPlant = txtNameOfPlant.Text;
            string distanceBetweenPlants = txtDistanceBtwPlants.Text;
            string yieldPeriod = txtYeildPeriod.Text;
            string growingPeriod = txtGrowingPeriod.Text;
            string plantTimeInNursery = txtTimeInNursery.Text;
            string plantProductivity = txtPlantProductivity.Text;
            fs = new FileStream(_DataFilePath, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            string fileString = nameOfPlant + "," + distanceBetweenPlants + "," + yieldPeriod + "," + growingPeriod + "," + plantTimeInNursery+","+plantProductivity+"\r\n";
            sw.WriteLine(fileString);
            txtNameOfPlant.Text = "";
            txtDistanceBtwPlants.Text = "";
            txtYeildPeriod.Text = "";
            txtGrowingPeriod.Text = "";
            txtTimeInNursery.Text = "";
            txtPlantProductivity.Text = "";
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void txtNameOfPlant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
