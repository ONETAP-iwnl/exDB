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

namespace EX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MagazinEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = MagazinEntities.GetContext();
            DGSklad.ItemsSource = db.Sklad.ToList();
            DGTovar.ItemsSource = db.Tovar.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sklad _sklad = new Sklad
                {
                    NameSklad = NameSkladTB.Text,
                    Adress = AdressSkladTB.Text
                };
                db.Sklad.Add(_sklad);
                db.SaveChanges();
                DGSklad.ItemsSource = db.Sklad.ToList();

                MessageBox.Show($"Данные успешно сохранены!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Данные не верны: {ex.Message}");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Sklad selectSklad = DGSklad.SelectedItem as Sklad;
            if ( selectSklad != null )
            {
                db.Sklad.Remove(selectSklad);
                db.SaveChanges();
                DGSklad.ItemsSource= db.Sklad.ToList();
            }
            else
            {
                MessageBox.Show($"Выберите склад для удаления");
            }
        }

        private void tcbc_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedSkladName = tcbc.Text;

            var filtedSklad = db.Sklad.Where(_sklad => _sklad.NameSklad.Contains(selectedSkladName)).ToList();

            DGSklad.ItemsSource = filtedSklad;
        }

        private void AddNewTovar(object sender, RoutedEventArgs e)
        {
            try
            {
                Tovar _tovar = new Tovar
                {
                    NameTovar = NameToverTB.Text,
                    Description = DescriptionTB.Text,
                    ID_Sklad = 1

                };
                db.Tovar.Add(_tovar);
                db.SaveChanges();
                DGTovar.ItemsSource = db.Tovar.ToList();

                MessageBox.Show($"Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Данные не верны: {ex.Message}");
            }
        }

        private void tcbcTovar_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedTovarName = tcbcTovar.Text;

            var filtedTovar = db.Tovar.Where(_tovar => _tovar.NameTovar.Contains(selectedTovarName)).ToList();

            DGTovar.ItemsSource = filtedTovar;
        }

        private void DeleteButtonTovar_Click(object sender, RoutedEventArgs e)
        {
            Tovar selectTovar = DGTovar.SelectedItem as Tovar;
            if (selectTovar != null)
            {
                db.Tovar.Remove(selectTovar);
                db.SaveChanges();
                DGTovar.ItemsSource = db.Tovar.ToList();
            }
            else
            {
                MessageBox.Show($"Выберите склад для удаления");
            }
        }
    }
}
