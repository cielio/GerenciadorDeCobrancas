using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeCobrancas
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int CobrancaId { get; set; }
        public Cobranca Cobranca { get; set; }

        public Conta()
        {
        }

        public Conta(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
            
        }
    }
}
