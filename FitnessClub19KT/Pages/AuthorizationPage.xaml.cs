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

using FitnessClub19KT.DB;
using FitnessClub19KT.ClassHelper;
using FitnessClub19KT.Windows;

namespace FitnessClub19KT.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            
        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var authuser = EFClass.context.Authorization.ToList()
                .Where(x => x.Login == TbLogin.Text && x.Password == PbPassword.Password)
                .FirstOrDefault();

            if (authuser.IdRole == 1)
            {
               MainWindow.Auth(authuser).Show();
            }
            else if (authuser.IdRole ==2 )
            {
                ManagementWindow.Auth(authuser).Show();
            } 
            else if (authuser.IdRole == 3)
            {

                MainCoachWindow.Auth(authuser).Show();
            }
            else
            {
                MessageBox.Show("Логин или пароль неправильный","Ошибка авторизации",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
