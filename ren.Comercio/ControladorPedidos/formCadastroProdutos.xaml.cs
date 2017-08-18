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

        RepositorioProduto repoProduto;
        RepositorioMarca repoMarca;

        public formCadastroProdutos()
        {
            InitializeComponent();
            repoProduto = new RepositorioProduto();
            repoMarca = new RepositorioMarca();

            this.DataContext = new Produto();
        }

        public formCadastroProdutos(Produto produto)
        {
            InitializeComponent();
            repoProduto = new RepositorioProduto();


        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            var produto = (Produto)this.DataContext;

            produto.marca = (Marca)cbMarca.SelectedItem;

            if(lbCodigo.Content == null)
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
