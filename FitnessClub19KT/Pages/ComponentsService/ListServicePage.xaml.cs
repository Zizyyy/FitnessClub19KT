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
        List<string> sortList = new List<string>()
        {
            "По умолчанию",
            "По названию (от А до Я)",
            "По названию (от Я до А)",
            "По цене (по убыванию)",
            "По цене (по возрастанию)",
            "По длительности (по убыванию)",
            "По длительности (по возрастанию)"
        };

        public ListServicePage()
        {
            InitializeComponent();
            GetServiceList();

            CmbSort.ItemsSource = sortList; 
            CmbSort.SelectedIndex = 0;
        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = ClassHelper.EFClass.context.Service.ToList();

            //Sorting

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    serviceList = serviceList.OrderBy(i => i.IdService).ToList();
                    break;
                case 1:
                    serviceList = serviceList.OrderBy(i => i.Title).ToList();
                    break;
                case 2:
                    serviceList = serviceList.OrderByDescending(i => i.Title).ToList();
                    break;
                case 3:
                    serviceList = serviceList.OrderBy(i => i.Cost).ToList();
                    break;
                case 4:
                    serviceList = serviceList.OrderByDescending(i => i.Cost).ToList();
                    break;
                case 5:
                    serviceList = serviceList.OrderBy(i => i.DurationInMin).ToList();
                    break;
                case 6:
                    serviceList = serviceList.OrderByDescending(i => i.DurationInMin).ToList();
                    break;
                default:
                    serviceList = serviceList.OrderBy(i => i.IdService).ToList();
                    break;
            }

            //Search
            serviceList = serviceList.Where(i => i.Title.ToLower().ToUpper().Contains(TbSearch.Text.ToLower())).ToList();

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

        private void BtnAddToCart(object sender, RoutedEventArgs e)
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
            GetServiceList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetServiceList();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Service;
            ServiceCart serviceCart = new ServiceCart()
            {
                IdService = service.IdService,
                Description = service.Description,
                OrderService = service.OrderService,
            };
            if (CartClass.serviceCart.Contains(serviceCart)) {
                serviceCart = CartClass.serviceCart.First(x=>x.IdService == service.IdService);
                serviceCart.Count++;
            }
            CartClass.serviceCart.Add(serviceCart);
        }
    }
}
