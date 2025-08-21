using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class LancamentoPix
    {
        private DateTime dataHoraLacamento;
        private char tipoLancamento; // 'D' para depósito, 'S' para saque
        private decimal valorLancamento;
        private string mensagem;
        private string pessoa;

        public DateTime DataHoraLancamento
        {
            get { return dataHoraLacamento; }
            set { dataHoraLacamento = value; }
        }

        public char TipoLancamento
        {
            get { return tipoLancamento; }
            set
            {
                if (value == 'D' || value == 'C')
                    tipoLancamento = value;
                else
                    throw new ArgumentException("Tipo de lançamento inválido. Use 'D' para débito ou 'C' para crédito.");
            }
        }

        public decimal ValorLancamento
        {
            get { return valorLancamento; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Valor do lançamento não pode ser negativo.");
                valorLancamento = value;
            }
        }

        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        public string Pessoa
        {
            get { return pessoa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Pessoa não pode ser vazia.");
                pessoa = value;
            }
        }

        public String ComprovantePix()
        {
            String Texto;
            Texto = $"Data/Hora: {dataHoraLacamento}\n" +
                    $"Tipo: {(tipoLancamento == 'D' ? "Débito" : "Crédito")}\n" +
                    $"Valor: {valorLancamento:C}\n" +
                    $"Pessoa: {pessoa}\n" +
                    $"Mensagem: {mensagem}";
        }
    }
}
