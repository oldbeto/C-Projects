using ren.Comercio.Model;
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
using ren.Comercio.Repositorio;

namespace ControladorPedidos
{
    /// <summary>
    /// Interaction logic for formCadastroProdutos.xaml
    /// </summary>
    public partial class formCadastroProdutos : Window
    {

        RepositorioProduto repo;

        public formCadastroProdutos()
        {
            InitializeComponent();
            repo = new RepositorioProduto();
            this.DataContext = new Produto();
        }

        public formCadastroProdutos(Produto produto)
        {
            InitializeComponent();
            repo = new RepositorioProduto();


        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            var produto = (Produto)this.DataContext;

            produto.marca = (Marca)cbMarca.SelectedItem;

            if(lbCodigo.Content == null)
            {
                // novo

            }
            else
            {
                // edicao

            }         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbMarca.DataContext = repo.Listar();
        }
    }
}
