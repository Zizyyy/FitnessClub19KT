using FitnessClub19KT.ClassHelper;
using FitnessClub19KT.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace FitnessClub19KT.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Window
    {

        private string pathImage = null;
        private bool IsEdit = false;
        private Service editService;

        public AddEditService()
        {
            InitializeComponent();
            IsEdit = false;

        }

        public AddEditService(Service service)
        {
            //конструктор для изменений
            InitializeComponent();

            TblTitleWindow.Text = "Редактирование";
            BtnAddEdit.Content = "Сохранить";

            TbTitleService.Text = service.Title.ToString();
            TbCostService.Text = service.Cost.ToString();
            TbDescripService.Text = service.Description.ToString();
            TbDurationService.Text = service.DurationInMin.ToString();

            if (service.PhotoPath != null)
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream(Convert.ToByte(service.PhotoPath)))
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        bitmapImage.StreamSource = stream;
                        bitmapImage.EndInit();

                        if (service.PhotoPath != null)
                        {
                            ImgService.Source = bitmapImage;
                        }
                    }
                }
                catch(Exception e)
                {
                    ImgService.Source = null;
                }
            }

            IsEdit = true;
            editService = service;
        }
        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
        }
        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbTitleService.Text))
            {
                MessageBox.Show("Поле \"Название\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbCostService.Text))
            {
                MessageBox.Show("Поле \"Стоимость\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbDurationService.Text))
            {
                MessageBox.Show("Поле \"Длительность\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (IsEdit == true)
            {
                editService.Title = TbTitleService.Text;
                editService.Cost = Convert.ToDecimal(TbCostService.Text);
                editService.DurationInMin = Convert.ToInt32(TbDurationService.Text);
                editService.Description = TbDescripService.Text;
                if (pathImage != null)
                {
                    editService.PhotoPath = pathImage;
                }
                EFClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно изменена", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                Service service = new Service();
                service.Title = TbTitleService.Text;
                service.Cost = Convert.ToDecimal(TbCostService.Text);
                service.DurationInMin = Convert.ToInt32(TbDurationService.Text);
                service.Description = TbDescripService.Text;
                service.PhotoPath = pathImage;

                EFClass.context.Service.Add(service);
                EFClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно добавлена","Добавление",MessageBoxButton.OK, MessageBoxImage.Information);
                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
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

        private void TblBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
