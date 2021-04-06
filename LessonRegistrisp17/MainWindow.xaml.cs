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
using System.IO;

namespace LessonRegistrisp17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string lName;
            string fName;
            string age;
            lName = txtLastName.Text;
            fName = txtFirstName.Text;
            age = txtAge.Text;

            // проверка на пустые поля
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Заполните поле Фамилия");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Заполните поле ИМЯ");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Заполните поле Возраст");
                return;
            }

            // запрет цифр в именах

            uint valint;
            if (uint.TryParse(txtLastName.Text, out valint))
            {
                MessageBox.Show("Некорректное значение пля ФАМИЛИЯ");
                return;
            }

            if (uint.TryParse(txtFirstName.Text, out valint))
            {
                MessageBox.Show("Некорректное значение пля ИМЯ");
                return;
            }

            // проверка на правильность ввода возраста

            uint val;
            if (!uint.TryParse(txtAge.Text, out val))
            {
                MessageBox.Show("Некорректный возраст");
                return;
            }

            // проверка возраста

            if (Int32.Parse(txtAge.Text) > 150)
            {
                MessageBox.Show("Некорректный возраст");
                return;
            }

            using (StreamWriter sw = new StreamWriter("userData.txt", true))
            {
                sw.WriteLine($"{lName};{fName};{age}");
            }
            MessageBox.Show($"Пользователь, {lName} {fName}, добавлен");
        }

        private void btnUserList_Click(object sender, RoutedEventArgs e)
        {
            UserDataWindow userDataWindow = new UserDataWindow();
            userDataWindow.ShowDialog();
        }
    }
}
