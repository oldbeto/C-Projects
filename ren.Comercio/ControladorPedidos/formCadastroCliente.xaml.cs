using ren.Comercio.Repositorio;
using ren.Comercio.Model;
using System;
using System.Windows;

namespace ControladorPedidos
{
    public partial class formCadastroCliente : Window
    {
        RepositorioCliente repoCliente;

        public formCadastroCliente()
        {
            InitializeComponent();
            repoCliente = new RepositorioCliente();

            this.DataContext = new Cliente();
        }

        //Editar
        public formCadastroCliente(Cliente cliente)
        {
            InitializeComponent();
            repoCliente = new RepositorioCliente();

            this.DataContext = cliente;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            var cliente = (Cliente)this.DataContext;
           // cliente.marca = (Marca)cbMarca.SelectedItem;

            if ((lbCodigo.Content == null) || (lbCodigo.Content.ToString() == "0"))
            {
                // novo
                try
                {
                    repoCliente.Adicionar(cliente);
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
                cliente.codigo = Int32.Parse(lbCodigo.Content.ToString());
                repoCliente.Atualizar(cliente);
                MessageBox.Show("Atualizado com Sucesso!", "Sucesso !", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbEstado.Items.Add("AL");
            cbEstado.Items.Add("AP");
            cbEstado.Items.Add("AM");
            cbEstado.Items.Add("BA");
            cbEstado.Items.Add("CE");
            cbEstado.Items.Add("DF");
            cbEstado.Items.Add("ES");
            cbEstado.Items.Add("GO");
            cbEstado.Items.Add("MA");
            cbEstado.Items.Add("MT");
            cbEstado.Items.Add("MS");
            cbEstado.Items.Add("MG");
            cbEstado.Items.Add("PA");
            cbEstado.Items.Add("PB");
            cbEstado.Items.Add("PR");
            cbEstado.Items.Add("PE");
            cbEstado.Items.Add("PI");
            cbEstado.Items.Add("RJ");
            cbEstado.Items.Add("RN");
            cbEstado.Items.Add("RO");
            cbEstado.Items.Add("RR");
            cbEstado.Items.Add("RS");
            cbEstado.Items.Add("SC");
            cbEstado.Items.Add("SP");
            cbEstado.Items.Add("SE");
            cbEstado.Items.Add("TO");
        }
    }
}
