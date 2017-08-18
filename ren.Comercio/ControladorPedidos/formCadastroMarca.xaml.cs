using System;
using ren.Comercio.Model;
using ren.Comercio.Repositorio;
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
    /// Interaction logic for formMarca.xaml
    /// </summary>
    public partial class formCadastroMarca : Window
    {
        Marca marca = new Marca();

        public formCadastroMarca()
        {
            InitializeComponent();
        }

        public formCadastroMarca(Marca marca)
        {
            InitializeComponent();
            lbCodigo.Content = marca.codigo.ToString();
            txtNome.Text = marca.nome;

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            RepositorioPadrao repo = new RepositorioPadrao();

            try
            {
                if (lbCodigo.Content.ToString() == "")
                {
                    //Novo codigo
                    marca = new Marca
                    {
                        nome = txtNome.Text
                    };
                    repo.Adicionar(marca);
                }


                else
                {
                    this.marca.codigo = Int32.Parse(lbCodigo.Content.ToString());
                    this.marca.nome = txtNome.Text;
                    //edicao de codigo
                    repo.Atualizar(marca);
                }
                MessageBox.Show("Marca salva com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Nao foi possivel Salvar!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
