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
    /// Логика взаимодействия для ListClient.xaml
    /// </summary>
    public partial class ListClient : Page
    {
        public ListClient()
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

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            //AddEditClient addEditClient = new AddEditClient();
            //addEditClient.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null )
            {
                return;
            }

            var client = button.DataContext as Client;

            //AddEditClient addEditClient = new AddEditClient();
            //addEditClient.Show();
            GetClientList();
        }
    }
}
