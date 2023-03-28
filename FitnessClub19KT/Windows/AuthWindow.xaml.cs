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
using System.Windows.Shapes;

using FitnessClub19KT.Pages;
using FitnessClub19KT.ClassHelper;

namespace FitnessClub19KT.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            FrAuthReg.Content = new AuthorizationPage();
            MainWindow.OnAuth += () => this.Close();
        }

        
        private void TblLog_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrAuthReg.Content = new AuthorizationPage();
        }
        private void TblReg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrAuthReg.Content = new RegistrationPage();
        }
        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ButtonExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ButtonMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
