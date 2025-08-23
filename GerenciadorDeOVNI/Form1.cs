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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            // Instanciar o form:
            TelaInicial telaInicial = new TelaInicial();
            // Mostra o form:
            telaInicial.ShowDialog();

            // Fechar a tela de fundo:
            Application.Exit();
        }
    }
}
