using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class frmCaixaEletronica : Form
    {
        Conta conta = new Conta();
        public frmCaixaEletronica()
        {
            InitializeComponent();
            conta.LimiteCredito = 1000;
            conta.Saldo = 5000; 
            AtualizaSaldoLimite();
        }

        private void AtualizaSaldoLimite()
        {
            lblSaldo.Text = conta.Saldo.ToString("C");
            lblSaldoLimite.Text = (conta.Saldo + conta.LimiteCredito).ToString("C");
        }
        private void btnSacar_Click(object sender, EventArgs e)
        {
            try
            {

            conta.Sacar(numValorSaque.Value);
            lblSaldo.Text = conta.Saldo.ToString("C"); // Exibindo o saldo formatado    
            MessageBox.Show("Saque realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Ocorreu um erro ao  realizar o saque!"+
                                "\n\nMais detalhes:" + ex.Message,
                                "Erro ao Sacar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            
            }
            finally
            {
                AtualizaSaldoLimite();

            }

        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            conta.Depositar(numValorDeposito.Value);
            AtualizaSaldoLimite();  
            MessageBox.Show("Depósito realizado com sucesso", "Sucesso", MessageBoxButtons.OK);

        }

        private void numLimiteCredito_Validating(object sender, CancelEventArgs e)
        {
            conta.LimiteCredito = numLimiteCredito.Value;
            AtualizaSaldoLimite();
        }
    }
}
