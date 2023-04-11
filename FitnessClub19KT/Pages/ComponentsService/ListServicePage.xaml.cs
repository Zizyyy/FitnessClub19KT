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
        List<string> listSort = new List<string>()
        {
            "По умолчанию",
            "От А до Я",
            "От Я до А",
            "По цене (По убыванию)",
            "По цене (По возрастанию)",
            "По длительности (По убыванию)",
            "По длительности (По возрастания)"
        };


        public ListServicePage()
        {
            InitializeComponent();
            GetServiceList();

            CmbSort.ItemsSource = listSort;
            CmbSort.SelectedIndex = 0;
        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = ClassHelper.EFClass.context.Service.ToList();

            //Search
            serviceList = serviceList.Where(x => x.Title.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            //Sort
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    serviceList = serviceList.OrderBy(x => x.IdService).ToList();
                    break;
                case 1:
                    serviceList = serviceList.OrderBy(x => x.Title).ToList();
                    break;
                case 2:
                    serviceList = serviceList.OrderByDescending(x => x.Title).ToList();
                    break;
                case 3:
                    serviceList = serviceList.OrderBy(x => x.Cost).ToList();
                    break;
                case 4:
                    serviceList = serviceList.OrderByDescending(x => x.Cost).ToList();
                    break;
                case 5:
                    serviceList = serviceList.OrderBy(x => x.DurationInMin).ToList();
                    break;
                case 6:
                    serviceList = serviceList.OrderByDescending(x => x.DurationInMin).ToList();
                    break;
            }
         
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

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetServiceList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetServiceList();
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddEditService addEditService = new AddEditService();
            addEditService.Show();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button == null )
            {
                return;
            }

            var service = button.DataContext as Service;

            CartClass.AddToList(new ServiceCart(service));
            MessageBox.Show($"Услуга {service.Title.ToString()} успешно добавлена в корзину", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
