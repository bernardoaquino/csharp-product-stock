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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Login objlogin = new Login();

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            //Chamada do método Validar_login implantado para retornar verdadeiro ou falso
            if(objlogin.Validar_login(txt_usuario.Text, txt_senha.Text))
            {
                //Torna o formulário de login invisível
                this.Visible = false;
                frmMenu menu = new frmMenu();
                menu.ShowDialog();
                //Torna o formulario de login visível
                this.Visible = true;
            }else
            {
                MessageBox.Show("Usuário ou senha invalido...", "Erro login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
