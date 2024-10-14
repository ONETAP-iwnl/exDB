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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        MagazinEntities db;

        MainWindow mw;
        ManagerWindow _manager;

        public AuthorizationWindow()
        {
            InitializeComponent();
            db = new MagazinEntities(); //инициализация бд при создании окна
            mw = new MainWindow(); //иницилизация окна МайнВиндоу
            _manager = new ManagerWindow();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            db = MagazinEntities.GetContext();

            var user = db.Users.Where(d => d.Login == LogTB.Text &&  d.Password == PaswwordTB.Password).FirstOrDefault();

            if(user != null)
            {
                if(user.Role.Equals("администратор", StringComparison.OrdinalIgnoreCase))
                {
                    this.Close();
                    mw.Show();
                }
                else if(user.Role.Equals("менеджер", StringComparison.OrdinalIgnoreCase))
                {
                    this.Close();
                    _manager.Show();
                }
            }
            else
            {
                MessageBox.Show("Введенные данные не верны");
            }
        }
    }
}
