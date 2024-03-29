﻿using _13_data_access_fluent_api;
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

namespace _14_fluent_api_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirplaneDb context;
        public MainWindow()
        {
            InitializeComponent();
            context = new AirplaneDb();
        }

        private void showFlights(object sender, RoutedEventArgs e)
        {
           grid.ItemsSource = context.Flights.ToList();
        }
        private void showAirplanes(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Airplanes.ToList();
        }
        private void showClients(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource= context.Clients.ToList();
        }
    }
}