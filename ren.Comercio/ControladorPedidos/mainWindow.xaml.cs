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

namespace ControladorPedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class mainWindow : Window
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void btProdutos_Click(object sender, RoutedEventArgs e)
        {
            var formProduto = new formProdutos();
            formProduto.Show();
        }

        private void btClientes_Click(object sender, RoutedEventArgs e)
        {
            var formClientes = new formClientes();
            formClientes.ShowDialog();
        }

        private void btUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var formUsuarios = new formUsuarios();
            formUsuarios.ShowDialog();
        }
    }
}
