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

namespace EX
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        MagazinEntities db;
        public ManagerWindow()
        {
            InitializeComponent();
            db = MagazinEntities.GetContext();
            DGTovar.ItemsSource = db.Tovar.ToList();
        }
    }
}
