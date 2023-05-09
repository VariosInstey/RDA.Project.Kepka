using RDA.Project.Kepka.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RDA.Project.Kepka.View.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        int i = 1;
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            i++;

            if (i > 6)
            {
                i = 1;
            }
            
           picHolder.Source = new BitmapImage(new Uri(@"/images/" + i + ".png", UriKind.Relative));
        }

        private void BtnMaterial_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.MyConnection?.Navigate(new MaterialPage());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://printdirect.ru/pechyat/odezhda/kepki-beysbolki");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            i--;

            if (i < 1)
            {
                i = 6;
            }

            picHolder.Source = new BitmapImage(new Uri(@"/images/" + i + ".png", UriKind.Relative));
        }
    }
}
