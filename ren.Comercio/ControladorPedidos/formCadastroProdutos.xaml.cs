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

        Produto produto = new Produto();
        RepositorioPadrao repo;

        public formCadastroProdutos()
        {
            InitializeComponent();
            repo = new RepositorioPadrao();
        }

        public formCadastroProdutos(Produto produto)
        {
            InitializeComponent();
            repo = new RepositorioPadrao();

            lbCodigo.Content = produto.codigo.ToString();
            txtNome.Text = produto.nome;
            txtQtdEstoque.Text = produto.qtdEstoque.ToString();
            txtQtdMinimaEstoque.Text = produto.qtdMinimaEstoque.ToString();
            txtValorCompra.Text = produto.valorCompra.ToString();
            txtValorVenda.Text = produto.valorVenda.ToString();
            //marca

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            if(lbCodigo.Content == null)
            {
                // novo
                produto.nome = txtNome.Text;
                produto.valorCompra = Convert.ToDecimal(txtValorCompra.Text);
                produto.valorVenda = Convert.ToDecimal(txtValorVenda.Text);
                produto.qtdEstoque = Int32.Parse(txtQtdEstoque.Text);
                produto.qtdMinimaEstoque = Int32.Parse(txtQtdMinimaEstoque.Text);
                produto.marca = (Marca)cbMarca.SelectedItem;
            }
            else
            {
                // edicao
                produto.codigo = Int32.Parse(lbCodigo.Content.ToString());
                produto.nome = txtNome.Text;
                produto.valorCompra = Convert.ToDecimal(txtValorCompra.Text);
                produto.valorVenda = Convert.ToDecimal(txtValorVenda.Text);
                produto.qtdEstoque = Int32.Parse(txtQtdEstoque.Text);
                produto.qtdMinimaEstoque = Int32.Parse(txtQtdMinimaEstoque.Text);
                produto.marca = (Marca)cbMarca.SelectedItem;
            }         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbMarca.DataContext = repo.Listar();
        }
    }
}
