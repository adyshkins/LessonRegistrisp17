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
using System.IO;

namespace LessonRegistrisp17
{
    /// <summary>
    /// Логика взаимодействия для UserDataWindow.xaml
    /// </summary>
    public partial class UserDataWindow : Window
    {
        List<Person> peopleList = new List<Person>();
        public UserDataWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("userData.txt"))
            {
                for (int i = 0; i < File.ReadAllLines("userData.txt").Count(); i++)
                {
                    string user = sr.ReadLine();

                    string[] userArray = user.Split(';');

                    peopleList.Add(new Person()
                    {
                        Id = i + 1,
                        LastName = userArray[0],
                        FirstName = userArray[1],
                        Age = Int32.Parse(userArray[2])
                    }
                    );
                }
            }

            dgUsers.ItemsSource = peopleList;
        }
    }
}
