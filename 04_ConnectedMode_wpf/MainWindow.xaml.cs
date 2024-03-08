using _05_data_access.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace _04_ConnectedMode_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportShopDB db;
        public MainWindow()
        {
            InitializeComponent();
            db = new SportShopDB(ConfigurationManager.ConnectionStrings["connSportShop"].ConnectionString);
        }

        private void getProducts(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.GetAllProducts();
        }

        private void idProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter) {
                int id = int.Parse(idProduct.Text);
                
                List<Product> prod = new List<Product>();
                prod.Add(db.getOneProduct(id));
                dataGrid.ItemsSource = prod;
            }
        }

    }
}
