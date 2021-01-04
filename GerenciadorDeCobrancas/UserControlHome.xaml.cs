using GerenciadorDeCobrancas.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GerenciadorDeCobrancas
{
    /// <summary>
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();
            var Cobrancas = GetCobrancas();
            if (Cobrancas.Count > 0)
                ListViewProducts.ItemsSource = Cobrancas;
        }

        private List<Cobranca> GetCobrancas()
        {
            using CobrancaContext cobrancaContext = new CobrancaContext();

            CobrancaServicos cobrancaServicos = new CobrancaServicos(cobrancaContext);

            //string quarto = "Quarto 1";

            //DateTime date = DateTime.Parse("03/01/2021");
            //string observacao = "Tessdfsfsdfsfs";

            //Cobranca cobranca = new Cobranca(StatusCobranca.Deve, quarto, date, observacao);


            //    cobranca.AddConta(new Conta("Aluguel", 1500));
            //     cobranca.AddConta(new Conta("Luz", 1500));
            //    cobranca.AddConta(new Conta("Agua", 1500));
            //     cobranca.AddConta(new Conta("Gas", 1500));


            //cobrancaServicos.Insert(cobranca);



            return cobrancaServicos.FindAll(); ;
        }

        private void ContentControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var product = ((FrameworkElement)sender).DataContext as Cobranca;
        }
    }
}
