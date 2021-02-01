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

namespace Hosler_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for CalculatorWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Units { sqmi, sqkm };

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            Textbox_Area.Focus();

            UnitChange();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double density = 0;

            if (ValidInputs(out string feedback))
            {
                density = Math.Round(Convert.ToDouble(Textbox_Population.Text) / Convert.ToDouble(Textbox_Area.Text));

                Textbox_Density.Text = Convert.ToString(density);
            }
            else
            {
                MessageBox.Show(feedback);
            }
        }

        //ValidInputs borrowed from John Velis code
        private bool ValidInputs(out string feedback)
        {
            bool validInputs = true;
            feedback = "";

            if (!double.TryParse(Textbox_Area.Text, out double tempArea))
            {
                validInputs = false;
                feedback += "The area is not a valid number";
            }
            if (!double.TryParse(Textbox_Population.Text, out double tempPop))
            {
                validInputs = false;
                feedback += "The population is not a valid number";
            }

            return validInputs;
        }

        private void Toggle_Units_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UnitChange();
            }
        }

        private void UnitChange()
        {
            if ((bool) Toggle_Miles.IsChecked)
            {
                Label_Type.Content = "thousand people per SQ MI";
            }
            else if ((bool)Toggle_Kilometers.IsChecked)
            {
                Label_Type.Content = "thousand people per SQ KM";
            }
        }
    }
}
