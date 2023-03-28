using FitnessClub19KT.DB;
using FitnessClub19KT.Pages;
using FitnessClub19KT.Pages.ComponentsService;
using FitnessClub19KT.Windows;
using System.Windows;
using System.Windows.Input;

namespace FitnessClub19KT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void IsAuth();
        public static event IsAuth OnAuth;
        public static Authorization User;
        public MainWindow()
        {
            InitializeComponent();
            FrListService.Content = new ListServicePage();
            TblLogin.Text = User.Role.Title;
            OnAuth.Invoke();
        }
        public static MainWindow Auth(Authorization User)
        {
            MainWindow.User = User;
            return new MainWindow();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left )
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

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            FrListService.Content = new AddEditService();
            

            AddEditService addEditService = new AddEditService();
            addEditService.Show();
            this.Close();
        }

        private void BtnServiceList_Click(object sender, RoutedEventArgs e)
        {
            FrListService.Content = new ListServicePage();
        }

        private void BtnCartList_Click(object sender, RoutedEventArgs e)
        {
            FrListService.Content = new CartPage();
        }
    }
}
