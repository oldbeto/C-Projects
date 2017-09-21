using ren.Comercio.Model;
using System;
using System.Windows;
using ren.Comercio.Repositorio;

namespace ControladorPedidos
{
    public partial class formCadastroProdutos : Window
    {

        RepositorioProduto repoProduto;
        RepositorioMarca repoMarca;

        public formCadastroProdutos()
        {
            InitializeComponent();
            repoProduto = new RepositorioProduto();
            repoMarca = new RepositorioMarca();

            this.DataContext = new Produto();
        }

        //Editar
        public formCadastroProdutos(Produto produto)
        {
            InitializeComponent();
            repoProduto = new RepositorioProduto();
            repoMarca = new RepositorioMarca();

            this.DataContext = produto;
            cbMarca.SelectedValue = produto.marca.codigo;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            var produto = (Produto)this.DataContext;
            produto.marca = (Marca)cbMarca.SelectedItem;

            if(lbCodigo.Content == null || lbCodigo.Content.ToString() == "0")
            {
                // novo
                try
                {
                    repoProduto.Adicionar(produto);
                    MessageBox.Show("Adicionado com Sucesso!", "Sucesso !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nao foi possivel Salvar!" + ex.Message, "Erro ao Salvar", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                // edicao
                produto.codigo = Int32.Parse(lbCodigo.Content.ToString());
                repoProduto.Atualizar(produto);
                MessageBox.Show("Atualizado com Sucesso!", "Sucesso !", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Close();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbMarca.DataContext = repoMarca.Listar();
        }
    }
}
