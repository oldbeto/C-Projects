using ren.Comercio.Model;
using ren.Comercio.Repositorio;
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

namespace ControladorPedidos
{
    /// <summary>
    /// Interaction logic for formCadastroUsuarios.xaml
    /// </summary>
    public partial class formCadastroUsuarios : Window

    {

        RepositorioUsuarios repoUsuario;

        public formCadastroUsuarios(Usuario usuario)
        {
            InitializeComponent();
            repoUsuario = new RepositorioUsuarios();

            this.DataContext = usuario;
            lbCodigo.Content = usuario.codigo.ToString();
            
        }

        public formCadastroUsuarios()
        {
            InitializeComponent();
            repoUsuario = new RepositorioUsuarios();
            this.DataContext = new Usuario();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            var usuario = (Usuario)this.DataContext;

            if ((lbCodigo.Content == null) || (lbCodigo.Content.ToString() == "0"))
            {
                // novo
                try
                {
                    repoUsuario.Adicionar(usuario);
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
                usuario.codigo = Int32.Parse(lbCodigo.Content.ToString());
                repoUsuario.Atualizar(usuario);
                MessageBox.Show("Atualizado com Sucesso!", "Sucesso !", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Close();
        }
    }
}
