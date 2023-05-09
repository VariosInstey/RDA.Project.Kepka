using RDA.Project.Kepka.Core;
using RDA.Project.Kepka.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RDA.Project.Kepka.View.Pages.Login_Reg
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private User _user = new User();
        public RegPage()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.MyConnection?.Navigate(new MainPage());
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext())
            {
                var login = TbLogin.Text;
                var password = PbPassword.Password;

                try
                {
                    if (string.IsNullOrEmpty(TbLogin.Text) ||
                        password.Length < 6 ||
            string.IsNullOrEmpty(PbPassword.Password))



                    {
                        MessageBox.Show($"Не все строки заполнены или пароль меньше 6 символов!");
                    }
                    else
                    {
                        db.Users.Add(new User()
                        {
                            Login = login,
                            Password = password
                        });
                        db.SaveChanges();
                        MessageBox.Show($"Пользователь создан - {_user.Login}!");
                        CoreNavigate.MyConnection?.Navigate(new LoginPage());
                    }


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}

 

