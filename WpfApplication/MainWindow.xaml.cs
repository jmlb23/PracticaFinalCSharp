using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TextBox txt;
        public MainWindow()
        {
            InitializeComponent();
            txt = txtId;
        }

        public Task<List<Customers>> Cust { get { return new Model1().Customers.Where(x => txtId.Text == "" ? true: x.CustomerID == txtId.Text).ToListAsync(); } }
        private async void Consulta1Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.ItemsSource = await Cust;
        }
        private async void Consulta2Click(object sender, RoutedEventArgs e)
        {
            var client = WebRequest.CreateHttp($"http://localhost:4714/Controller.ashx?id={txtId.Text}");
            client.Method = "GET";
            
            var response = (await client.GetResponseAsync()).GetResponseStream();
            var reader = new StreamReader(response);
            var json = await reader.ReadToEndAsync();
            var col = new JavaScriptSerializer();
            var obj = col.Deserialize<List<Customers>>(json);

            lstDisplay.ItemsSource = obj;
        }
        private async void Consulta3Click(object sender, RoutedEventArgs e)
        {
            var serv = new ServiceReference1.ServiceClient();
            var lst = await serv.GetClientsAsync(txtId.Text);
            lstDisplay.ItemsSource = lst;
        }
    }
}
