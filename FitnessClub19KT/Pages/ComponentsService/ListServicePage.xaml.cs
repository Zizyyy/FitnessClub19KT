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

namespace FitnessClub19KT.Pages.ComponentsService
{
    /// <summary>
    /// Логика взаимодействия для ListServicePage.xaml
    /// </summary>
    public partial class ListServicePage : Page
    {

        public ListServicePage()
        {
            InitializeComponent();
            GetServiceList();
        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = ClassHelper.EFClass.context.Service.ToList();

            LvService.ItemsSource = serviceList;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button == null)
            {
                return;
            }
            var service = button.DataContext as Service;

            AddEditService addEditService = new AddEditService(service);
            addEditService.Show();
            GetServiceList();
        }
    }
}
