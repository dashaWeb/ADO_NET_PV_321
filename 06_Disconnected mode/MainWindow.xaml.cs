using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace _06_Disconnected_mode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter da;
        DataSet set;
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=DESKTOP-83U7DVV\SQLEXPRESS; Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=2");
        }

        // Fill btn
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = commandText.Text;
            da = new SqlDataAdapter(sql, connection);
            set = new DataSet();
            var cmd = new SqlCommandBuilder(da); // auto generate insert, update, delete
            da.Fill(set, "MyTable");
            dataGrid.ItemsSource = set.Tables["MyTable"].DefaultView;
            /*commandText.Text = cmd.GetDeleteCommand().CommandText;*/
        }
        //Update btn
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            da.Update(set, "MyTable");
        }
    }
}
