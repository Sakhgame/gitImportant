using AlphaHotel.Data;
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
    /// Логика взаимодействия для Deskstop.xaml
    /// </summary>
    public partial class Deskstop : Window
    {
        public Deskstop()
        {
            InitializeComponent();
            StaticObjects.dekstopframe = DekstopFrame;
            new Authorization().ShowDialog();
        }
    }
}
