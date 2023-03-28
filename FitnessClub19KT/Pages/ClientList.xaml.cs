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
using System.IO;

namespace FitnessClub19KT.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Page
    {
        public ClientList()
        {
            InitializeComponent();
            GetClientList();
        }

        private void GetClientList()
        {

            List<Client> clientList = new List<Client>();

            clientList = EFClass.context.Client.ToList();

            LvClient.ItemsSource = clientList; 
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Service;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetClientList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetClientList();
        }
    }
}
