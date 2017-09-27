using System.Windows;
using ren.Comercio.Model;
using ren.Comercio.Repositorio;

namespace ControladorPedidos
{
    /// <summary>
    /// Interaction logic for formCompras.xaml
    /// </summary>
    public partial class formCompras : Window
    {
        RepositorioCompra repositorio;

        public formCompras()
        {
            InitializeComponent();
            repositorio = new RepositorioCompra();
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
                var compra = (Compra)listProdutos.SelectedItem;
                var formCadastroProdutos = new formCadastroProdutos(compra);
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
                if (MessageBox.Show("Tem certeza que deseja excluir o item selecionado?", "Atencao", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
                {
                    var compra = (Compra)listProdutos.SelectedItem;
                    repositorio.Excluir(compra);
                }
            }

            CarregarLista();
        }
    }
}
}
