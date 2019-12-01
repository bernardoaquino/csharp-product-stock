using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Produtos_11
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        //Instanciar classe login
        Login login = new Login();

        public void AbrirProdutos()
        {
            this.Visible = false;
            frmProdutos produtos = new frmProdutos();
            produtos.ShowDialog();
            this.Visible = true;
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirProdutos();
        }

        private void ptx_produto_Click(object sender, EventArgs e)
        {
            AbrirProdutos();
        }

        private void lbl_produtos_Click(object sender, EventArgs e)
        {
            AbrirProdutos();
        }

        //Clique duplo no formulário para abrir o metodo _Load
        private void frmMenu_Load(object sender, EventArgs e)
        {
            //Chamada do método que retorna o usuário logado
            lbl_msg.Text = "Bem vindo " + login.getUsuario();
        }
    }
}
