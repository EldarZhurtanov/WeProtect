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
    /// Логика взаимодействия для BuyOnly.xaml
    /// </summary>
    public partial class BuyOnly : UserControl
    {
        public BuyOnly()
        {
            InitializeComponent();
            this.Loaded += BuyOnly_Loaded;
        }

        private void BuyOnly_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as BuyOnlyViewModel).LicenseAtivatedSuccessfully += Trial_LicenseAtivatedSuccessfully;
        }

        private void Trial_LicenseAtivatedSuccessfully()
        {
            LicenseGrid.Width = new GridLength(0, GridUnitType.Star);
        }
    }
}
