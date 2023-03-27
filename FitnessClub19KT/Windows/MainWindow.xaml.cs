using FitnessClub19KT.Pages.ComponentsService;
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

using FitnessClub19KT.Pages;
using FitnessClub19KT.ClassHelper;
using FitnessClub19KT.DB;
using FitnessClub19KT.Windows;

namespace FitnessClub19KT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrList.Content = new ListServicePage();
        }
        //
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
            //FrListService.Content = new AddEditServicePage();
            this.Close();

            AddEditService addEditService = new AddEditService();
            addEditService.Show();
        }

        private void BtnServiceList_Click(object sender, RoutedEventArgs e)
        {
            FrList.Content = new ListServicePage();
        }

        private void BtnClientList_Click(object sender, RoutedEventArgs e)
        {
            FrList.Content = new ListClient();
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            FrList.Content = new CartPage();
        }
    }
}
