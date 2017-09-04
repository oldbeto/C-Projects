using ren.Comercio.Model;
using System.Windows;
using ren.Comercio.Repositorio;

namespace ControladorPedidos
{
    public partial class formUsuarios : Window
    {
        RepositorioUsuarios repositorio;

        public formUsuarios()
        {
            InitializeComponent();
            repositorio = new RepositorioUsuarios();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            formCadastroUsuarios formUsuarios = new formCadastroUsuarios();
            formUsuarios.ShowDialog();
            CarregarLista();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            if (listUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um item para edicao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var usuario = (Usuario)listUsuarios.SelectedItem;
                var formCadastroProdutos = new formCadastroUsuarios(usuario);
                formCadastroProdutos.ShowDialog();
            }

            CarregarLista();
        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarLista();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (listUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um item para exclusao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o item selecionado?", "Atencao", MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
                {
                    var usuario = (Usuario)listUsuarios.SelectedItem;
                    repositorio.Excluir(usuario);
                }
            }
            CarregarLista();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarLista();
        }


        private void CarregarLista()
        {
            listUsuarios.DataContext = repositorio.Listar();
        }
    }

 }
