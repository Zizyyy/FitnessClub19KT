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
using FitnessClub19KT.Pages;
using FitnessClub19KT.Windows;
using FitnessClub19KT.ClassHelper;

namespace FitnessClub19KT.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EFClass.context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Title";
            CmbGender.SelectedIndex = 0;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Поле \"Фамилия\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле \"Имя\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPhone.Text))
            {
                MessageBox.Show("Поле \"Телефон\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MessageBox.Show("Поле \"Электронная почта\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(DpBirthday.Text))
            {
                MessageBox.Show("Поле \"Дата рождения\" не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Client client = new Client();

            client.FirstName = TbFirstName.Text;
            client.LastName = TbLastName.Text;
            client.Patronymic = TbPatronymic.Text;
            client.Birthday = DpBirthday.SelectedDate.Value; 
            client.Phone= TbPhone.Text;
            client.IdGender = (CmbGender.SelectedItem as Gender).IdGender;

            ClassHelper.EFClass.context.Client.Add(client);

            ClassHelper.EFClass.context.SaveChanges();
            MessageBox.Show("Ок");
        }
    }
}
