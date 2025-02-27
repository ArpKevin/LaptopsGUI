using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaptopsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Laptop> laptopok = new();
        int megtekintesekSzama = 0;
        public MainWindow()
        {
            InitializeComponent();

            int laptopSorszam = 0;
            foreach (var item in File.ReadAllLines(@"..\..\..\src\laptops.txt").Skip(1))
            {
                laptopok.Add(new Laptop(item, laptopSorszam));
                laptopSorszam++;
            }

            laptopokListbox.ItemsSource = laptopok;
            laptopokListbox.SelectedIndex = 0;

            hanyGyartoHanyGepeLabel.Content = $"VÁLASSZON {laptopok.Select(l => l.Manufacturer.ManufacturerCode).Distinct().Count()} GYÁRTÓ {laptopok.Count()} LAPTOPJA KÖZÜL!";
        }

        private void laptopokListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var valasztottLaptop = laptopok.FirstOrDefault(l => l.ID == laptopokListbox.SelectedIndex);

            var kepatlo = valasztottLaptop.Screen.Split(" - ")[0];
            var felbontas = valasztottLaptop.Screen.Split(" - ")[1];

            reszletesAdatokListbox.Items.Clear();

            reszletesAdatokListbox.Items.Add($"Kategória\n\t{valasztottLaptop.Category.CategoryName}\n" +
            $"Képátló\n\t{kepatlo}\n" +
            $"Felbontás\n\t{felbontas}\n" +
            $"Processzor\n\t{valasztottLaptop.CPU}\n" +
            $"RAM\n\t{valasztottLaptop.RAM} GB\n" +
            $"Háttértár(ak)\n\t{valasztottLaptop.Storage}" +
            $"\nOperációs rendszer\n\t{valasztottLaptop.OS}" +
            $"\nÁr\n\t{Math.Round(valasztottLaptop.Price * 4.12, 0)} Ft");

            megtekintesekSzama++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ön {megtekintesekSzama} termékünket tekintette meg. Visszavárjuk!");
            Application.Current.Shutdown();
        }
    }
}