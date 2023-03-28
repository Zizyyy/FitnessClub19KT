using FitnessClub19KT.ClassHelper;
using FitnessClub19KT.DB;
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

namespace FitnessClub19KT.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Window
    { 
        private bool IsEdit = false;
        private Client editClient;
        List<string> listGender = new List<string>()
        {
            "-Не выбран-",
            "Мужской",
            "Женский"
        };

        public AddEditClient()
        {
            InitializeComponent();
            CmbGender.ItemsSource = listGender;
            CmbGender.SelectedIndex = 0;
            IsEdit = false;
        }
        public AddEditClient(Client client)
        {
            InitializeComponent();

            TblTitleWindow.Text = "Редактирование клиента";
            BtnAddEdit.Content = "ИЗМЕНИТЬ";
            TbFirstName.Text = client.FirstName.ToString();
            TbLastName.Text = client.LastName.ToString();
            TbPatronymic.Text = client.Patronymic.ToString();
            DpBirthday.Text = Convert.ToString(client.BirthdayDate);
            CmbGender.Text = Convert.ToString((CmbGender.SelectedItem as Gender).IdGender);
            TbEmail.Text = client.Email.ToString();
            TbPhone.Text = client.Phone.ToString();

            IsEdit = true;
            editClient = client;
        }
        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit == true)
            {
                editClient.FirstName = editClient.FirstName;
                editClient.LastName = editClient.LastName;
                editClient.Patronymic = editClient.Patronymic;
                editClient.BirthdayDate = Convert.ToDateTime(editClient.BirthdayDate);
                editClient.Phone = editClient.Phone;
                editClient.Email = editClient.Email;
                EFClass.context.SaveChanges();
                MessageBox.Show("Услуга успешно изменена", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            } 
            else
            {
                Client client = new Client();
                client.FirstName = TbFirstName.Text;
                client.LastName = TbLastName.Text;
                client.Patronymic = TbPatronymic.Text;
                client.Email = TbEmail.Text;
                client.Phone = TbPhone.Text;
                client.BirthdayDate = DpBirthday.SelectedDate.Value;
                client.IdGender = (CmbGender.SelectedItem as Gender).IdGender;
                
                EFClass.context.Client.Add(client);

                EFClass.context.SaveChanges();

                MessageBox.Show("Услуга успешно Добавлена", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
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
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }

    }
}
