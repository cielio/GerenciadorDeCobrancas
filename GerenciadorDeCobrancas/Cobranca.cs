using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeCobrancas
{

    public enum StatusCobranca : int
    {
        Deve = 0,
        Pago = 1
    }

    public class Cobranca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public DateTime Data { get; set; }
        public StatusCobranca StatusCobranca { get; set; }
        public List<Conta> Contas { get; set; } = new List<Conta>();
        public string Observacao { get; set; }


        public double TotalContas => Total();


        public Cobranca(StatusCobranca statusCobranca, string nome, DateTime data, string observacao)
        {

            StatusCobranca = statusCobranca;
            Nome = nome;
            Data = data;
            Observacao = observacao;
        }

        public void AddConta(Conta conta)
        {
            Contas.Add(conta);
        }

        public double Total()
        {
            return Contas.Sum(conta => conta.Valor);
        }
    }
}
