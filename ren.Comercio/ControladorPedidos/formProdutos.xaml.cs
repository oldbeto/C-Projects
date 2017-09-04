using System;
using ren.Comercio.Model;
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
    /// Interaction logic for Produtos.xaml
    /// </summary>
    public partial class formProdutos : Window
    {

        RepositorioProduto repositorio;
        
        public formProdutos()
        {   
            InitializeComponent();
            repositorio = new RepositorioProduto();
        }

        private void btMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new formMarcas();
            formMarca.ShowDialog();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            if (listProdutos.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um item para edicao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var produto = (Produto)listProdutos.SelectedItem;
                var formCadastroProdutos = new formCadastroProdutos(produto);
                formCadastroProdutos.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarLista();
        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            listProdutos.DataContext = repositorio.Listar();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            formCadastroProdutos formCadastro = new formCadastroProdutos();
            formCadastro.ShowDialog();
            CarregarLista();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (listProdutos.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um item para exclusao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o item selecionado?", "Atencao", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes)) {
                    var produto = (Produto)listProdutos.SelectedItem;
                    repositorio.Excluir(produto);
                }
            }

            CarregarLista();
        }
    }
}
