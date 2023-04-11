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

using FitnessClub19KT.ClassHelper;
using FitnessClub19KT.DB;

namespace FitnessClub19KT.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainCoachWindow.xaml
    /// </summary>
    public partial class MainCoachWindow : Window
    {
        public delegate void IsAuth();
        public static event IsAuth OnAuth;
        public static Authorization User;
        public List<Order> OrdList;
        public static MainCoachWindow Auth(Authorization User)
        {
            MainCoachWindow.User = User;
            return new MainCoachWindow();
        }
        public MainCoachWindow()
        {
            InitializeComponent();
            TblLogin.Text = User.Role.Title;
            OnAuth.Invoke();
            GetList();

        }

        public void GetList()
        {
            OrdList = EFClass.context.Order.Include("Client").ToList();
            LvSchedul.ItemsSource = OrdList;
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
