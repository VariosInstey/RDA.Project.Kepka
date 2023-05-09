using RDA.Project.Kepka.Core;
using RDA.Project.Kepka.Model;
using RDA.Project.Kepka.View.Pages.Menu;
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

namespace RDA.Project.Kepka.View.Pages.Login_Reg
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.MyConnection?.Navigate(new MainPage());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Login = TbLogin.Text;
                var Password = PbPassword.Password;
                using (DataContext db = new DataContext())
                {
                    bool userFound = db.Users.Any(u => u.Login == Login && u.Password == Password);
                    if (userFound)
                    {
                        MessageBox.Show("Успешная авторизация!",
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                        CoreNavigate.MyConnection?.Navigate(new MenuPage());
                    }
                    else
                    {
                        MessageBox.Show("Ошибка данных",
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Системное сообщение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }

        }
    }
}
