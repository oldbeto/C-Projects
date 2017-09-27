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
using ren.Comercio.Model;

namespace ControladorPedidos
{
    /// <summary>
    /// Interaction logic for formCadastroCompra.xaml
    /// </summary>
    public partial class formCadastroCompra : Window
    {
        RepositorioCompra repoCompra;

        public formCadastroCompra()
        {
            InitializeComponent();
            repoCompra = new RepositorioCompra();

            this.DataContext = new Compra();
        }

        //Editar
        public formCadastroCompra(Compra compra)
        {
            InitializeComponent();
            repoCompra = new RepositorioCompra();

            this.DataContext = compra;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            var compra = (Compra)this.DataContext;

            if (lbCodigo.Content == null || lbCodigo.Content.ToString() == "0")
            {
                // novo
                try
                {
                    repoCompra.Adicionar(compra);
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
                compra.codigo = Int32.Parse(lbCodigo.Content.ToString());
                repoCompra.Atualizar(compra);
                MessageBox.Show("Atualizado com Sucesso!", "Sucesso !", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
}
