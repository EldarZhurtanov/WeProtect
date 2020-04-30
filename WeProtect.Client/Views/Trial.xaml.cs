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
using WeProtect.Client.ViewModels;

namespace WeProtect.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для Trial.xaml
    /// </summary>
    public partial class Trial : UserControl
    {
        public Trial()
        {
            InitializeComponent();
            this.Loaded += Trial_Loaded;
        }

        private void Trial_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as TrialViewModel).LicenseAtivatedSuccessfully += Trial_LicenseAtivatedSuccessfully;
        }

        private void Trial_LicenseAtivatedSuccessfully()
        {
            LicenseGrid.Width = new GridLength(0, GridUnitType.Star);
        }
    }
}
