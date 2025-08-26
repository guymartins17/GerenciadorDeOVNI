using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeOVNI
{
    public partial class Gerenciador : Form
    {
        // Objetos globais:
        BibliotecaOVNI.OVNI ovni;

        public Gerenciador(BibliotecaOVNI.OVNI ovni) // Obrigatóriamente deve-se iniciar passando um OVNI:
        {
            InitializeComponent();
            // "Copiando" o ovni vindo da outra janela para um obj global:
            this.ovni = ovni;

            // Atualizar as informações:
            AtualizarInformacoes();

            // Popular o comboBox com os planetas válidos:
            cmbPlanetas.Items.AddRange(BibliotecaOVNI.OVNI.PlanetasValidos);
        }

        public void AtualizarInformacoes()
        {
            lblTripulantes.Text = $"Tripulantes: {ovni.QtdTripulantes}";
            lblAbduzidos.Text = $"Abduzidos: {ovni.QtdAbduzidos}";
            lblSituacao.Text = $"Situação: {(ovni.Situacao ? "Ligado" : "Desligado")}";
            lblPlanetaAtual.Text = $"Planeta Atual: {ovni.PlanetaAtual}";
            cmbPlanetas.Text = ovni.PlanetaAtual;

            // Atualizar os botões Ligar e Desligar:
            btnDesligar.Enabled = ovni.Situacao;
            btnLigar.Enabled = !ovni.Situacao;

            // Ativar/desativar o grb de acordo de acordo com o status da nave:
            grbAbduzidos.Enabled = ovni.Situacao;
            grbPlaneta.Enabled = ovni.Situacao;
            grbTripulantes.Enabled = ovni.Situacao;

            // Verificar se a nave está na terra:
            if(ovni.PlanetaAtual == "Terra")
            {
                // 
                pibTerra.Image = Properties.Resources.earth;
            }
            else
            {
                pibTerra.Image = null;
            }
        }

        private void btnLigar_Click(object sender, EventArgs e)
        {
            if (ovni.Ligar())
            {
                MessageBox.Show("O OVNI foi ligado!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("O OVNI já está ligado!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnDesligar_Click(object sender, EventArgs e)
        {
            if (ovni.Desligar())
            {
                MessageBox.Show("O OVNI foi desligado!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("O OVNI já está desligado!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnAddTripulantes_Click(object sender, EventArgs e)
        {
            if (ovni.AdicionarTripulante())
            {
                MessageBox.Show("Tripulante Adicionado!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("A nave já está lotada de tripulantes!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnRemoverTripulantes_Click(object sender, EventArgs e)
        {
            if (ovni.RemoverTripulante())
            {
                MessageBox.Show("Tripulante Removido!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Todos os tripulantes foram removidos!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnAddAbduzidos_Click(object sender, EventArgs e)
        {
            if (ovni.Abduzir())
            {
                MessageBox.Show("Abduzido com Sucesso!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Impossível Abduzir!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnRemoverAbduzidos_Click(object sender, EventArgs e)
        {
            if (ovni.Desabduzir())
            {
                MessageBox.Show("Desaduzido com Sucesso!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Impossível Desabduzir!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnMudarPlaneta_Click(object sender, EventArgs e)
        {
            if (ovni.MudarPlaneta(cmbPlanetas.Text))
            {
                MessageBox.Show("Você mudou de Planeta!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível mudar de planeta!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }

        private void btnRetornarPlaneta_Click(object sender, EventArgs e)
        {
            if (ovni.RetornarAoPlanetaDeOrigem(cmbPlanetas.Text))
            {
                MessageBox.Show("Você voltou ao planeta de origem!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível voltar planeta de origem!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Atualizar as informaçoes:
            AtualizarInformacoes();
        }
    }
}
