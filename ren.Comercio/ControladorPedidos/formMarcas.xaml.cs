﻿using System;
using ren.Comercio.Model;
using System.Windows;
using ren.Comercio.Repositorio;

namespace ControladorPedidos
{

    public partial class formMarcas : Window
    {

        RepositorioMarca repositorio;
        public formMarcas()
        {
            InitializeComponent();
            repositorio = new RepositorioMarca();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            if (listMarca.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um item para edicao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var marca = (Marca)listMarca.SelectedItem;
                var formMarca = new formCadastroMarca(marca);
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
            listMarca.DataContext = repositorio.Listar();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new formCadastroMarca();
            formMarca.ShowDialog();
            CarregarLista();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (listMarca.SelectedItem == null)
                {
                    MessageBox.Show("Favor selecionar um item para exclusao!", "Atencao", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    var marcaSelecionada = (Marca)listMarca.SelectedItem;

                    if (MessageBox.Show("Tem certeza que deseja excluir " + marcaSelecionada.nome + " ?", "Atencao", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        repositorio.Excluir(marcaSelecionada);
                    }
                }
    
            }
            catch (Exception ex) {
                MessageBox.Show("Nao foi possivel excluir: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            CarregarLista();
        }
    }
}
