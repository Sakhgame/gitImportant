using AlphaHotel.Data;
using AlphaHotel.Windows;
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

namespace AlphaHotel.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        AlphaHotelContext db = new AlphaHotelContext();
        public AdminPage()
        {
            InitializeComponent();
            DtGrid.ItemsSource = db.Users.ToList();
        }

        private void BtnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().ShowDialog();

        }

        private void BtnEditUsers_Click(object sender, RoutedEventArgs e)
        {
            User user = DtGrid.SelectedItem as User;
            EditUser editUser = new EditUser();
            editUser.user = user;
            editUser.ShowDialog();
        }

        private void BtnDeleteUsers_Click(object sender, RoutedEventArgs e)
        {
            if(StaticObjects.user.UserID == (DtGrid.SelectedItem as User).UserID)
            {
                MessageBox.Show("Перед удалением этого пользовател - смените пользователя");
            }
            else
            {
                if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    User user = DtGrid.SelectedItem as User;
                    db.Users.Remove(user);
                    db.SaveChanges();
                    DtGrid.ItemsSource = db.Users.ToList();
                }
            }
        }
    }
}
