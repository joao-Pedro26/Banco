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
    public partial class frmPix : Form
    {

        LancamentoPix pix = new LancamentoPix();
        public frmPix()
        {
            InitializeComponent();
            pix.DataHoraLancamento = DateTime.Now;

        }

        private void numValorLancamento_ValueChanged(object sender, EventArgs e)
        {
            pix.ValorLancamento = numValorLancamento.Value;
        }

        private void txtPessoa_TextChanged(object sender, EventArgs e)
        {
           pix.Pessoa = txtPessoa.Text;
        }


        private void txtMensagem_TextChanged(object sender, EventArgs e)
        {
            pix.Mensagem = txtMensagem.Text;
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTipo.Text) && txtTipo.Text.Length == 1)
            {
                try
                {
                    pix.TipoLancamento = Convert.ToChar(txtTipo.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tipo de lançamento inválido. Use 'D' para débito ou 'C' para crédito." +
                                    "\n\nMais detalhes:" + ex.Message,
                                    "Erro no Tipo de Lançamento",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var detalhes = pix.ComprovantePix();
                var mensagem = "✅ Lançamento efetuado com sucesso!" +
                               Environment.NewLine +
                               Environment.NewLine +
                               "🔎 Detalhes do Lançamento:" +
                               Environment.NewLine +
                               detalhes;

                MessageBox.Show(
                    mensagem,
                    "Comprovante Pix",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao realizar o lançamento!" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Mais detalhes: " + ex.Message,
                    "Erro no Lançamento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
