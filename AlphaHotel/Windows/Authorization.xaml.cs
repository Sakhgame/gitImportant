using AlphaHotel.Data;
using AlphaHotel.Pages;
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

namespace AlphaHotel.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        int attemptCoun = 0;
        AlphaHotelContext db = new AlphaHotelContext();
        
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                MessageBox.Show("вы не ввели логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(TbPassword.Text))
            {
                MessageBox.Show("вы не ввели пароль");
                TbLogin.Focus();
            }
            else {
                User user = db.Users.Where(u=>u.UserName == TbLogin.Text).FirstOrDefault();
                if (user == null) {
                    MessageBox.Show("Такого логина нет в системе");
                    return;
                }
                if((DateTime.Now - (DateTime)user.LastLoginDate).Days > 31){
                    MessageBox.Show("Слабая активность");
                    return;
                }
                if (attemptCoun >= 3) {
                    user.Blocked = true;
                    db.SaveChanges();
                    MessageBox.Show("Попытки входа исчерпаны");
                    return;
                }
                if (user.Blocked == true)
                {
                    MessageBox.Show("Пользователь заблокирован");
                    return;
                }
                if(user.Password.Trim() == TbPassword.Text.Trim())
                {
                    StaticObjects.user = user;
                    if (user.PasswordChanged)
                    {
                        ChangePassword changePassword = new ChangePassword();
                        changePassword.user = user;
                        changePassword.ShowDialog();
                    }
                    else
                    {
                        user.LastLoginDate = DateTime.Now;
                        db.SaveChanges();
                        MessageBox.Show("Вы успешно аторизировались");
                        if(StaticObjects.user.RoleID == 1) {
                            StaticObjects.dekstopframe.Navigate(new AdminPage());
                            this.Close();
                        }
                        else if(StaticObjects.user.RoleID == 2)
                        {
                            StaticObjects.dekstopframe.Navigate(new MenagerPage());
                            this.Close();
                        }
                    }
                }
                else
                {
                    attemptCoun++;
                    MessageBox.Show($"Вы ввели неверный пароль. Осталось попыток - {3 - attemptCoun}") ;
                }
                
            }
        }
    }
}
