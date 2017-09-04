using System;
using System.Windows;
using ren.Comercio.Repositorio;
using ren.Comercio.Model;

namespace ControladorPedidos
{
    public partial class formClientes : Window
    {
        RepositorioCliente repositorio;

        public formClientes()
        {
            InitializeComponent();
            repositorio = new RepositorioCliente();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            if (listClientes.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um item para edicao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var cliente = (Cliente)listClientes.SelectedItem;
                var formMarca = new formCadastroCliente(cliente);
                formMarca.ShowDialog();
                CarregarLista();
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
            listClientes.DataContext = repositorio.Listar();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            var formClientes = new formCadastroCliente();
            formClientes.ShowDialog();
            CarregarLista();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (listClientes.SelectedItem == null)
                {
                    MessageBox.Show("Favor selecionar um item para exclusao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    var marcaSelecionada = (Cliente)listClientes.SelectedItem;

                    if (MessageBox.Show("Tem certeza que deseja excluir " + marcaSelecionada.nome + " ?", "Atencao", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        repositorio.Excluir(marcaSelecionada);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            CarregarLista();
        }
    }
}
