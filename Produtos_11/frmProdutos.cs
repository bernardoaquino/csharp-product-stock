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
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        ConexaoBD bd = new ConexaoBD();
        string sql;
        string foto;
        DateTime data;

        public void Listar()
        {
            sql = "select * from produtos";
            dgv_listar.DataSource = bd.ConsultarTabelas(sql);
        }

        public void Limpar()
        {
            txt_codigo.Clear();
            txt_descricao.Clear();
            txt_quantidade.Clear();
            txt_valor.Clear();
            dtp_data.Text = DateTime.Now.ToString();
            ptx_foto.Load("H:/TEP/Terceiro_Trimestre/semfoto.jpeg");
            txt_codigo.Focus();
            foto = null;
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            if(ofd_foto.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Verificar se escolheu arquivo
            {
                ptx_foto.Load(ofd_foto.FileName);
                foto = ofd_foto.FileName;
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            double valor;
            int quantidade;

            if (double.TryParse(txt_valor.Text,out valor) && int.TryParse(txt_quantidade.Text,out quantidade) && foto != null) { //Tenta passar o conteúdo pra double, se não conseguir da erro

                data = DateTime.Parse(dtp_data.Text); //Formatando data
                foto = foto.Replace(@"\", @"\\"); //@ está procurando um caractere especial - BD não aceita uma / 

                sql = string.Format("insert into produtos values(null, '{0}', '{1}', '{2}', '{3}', '{4}')", 
                                    txt_descricao.Text,txt_valor.Text,txt_quantidade.Text,data.ToString("yyyy-MM-dd"),foto); //MM - Mês; mm - Hora

                bd.AlterarTabelas(sql);
                MessageBox.Show("Produto Cadastrado com Sucesso...","Cadastro",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Listar();
                Limpar();
            }else
            {
                MessageBox.Show("Conteúdo do campo inválido ou em branco...","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            sql = string.Format("select * from produtos where id = '{0}' or descricao = '{1}'", txt_codigo.Text,txt_descricao.Text);
            DataTable resultado = new DataTable();
            resultado = bd.ConsultarTabelas(sql);

            if(resultado.Rows.Count > 0 ) //Verifica se o resultado retornou alguma linha
            {
                txt_codigo.Text = resultado.Rows[0]["id"].ToString();
                txt_descricao.Text = resultado.Rows[0]["descricao"].ToString();
                txt_quantidade.Text = resultado.Rows[0]["quantidade"].ToString();
                txt_valor.Text = resultado.Rows[0]["valor"].ToString();
                dtp_data.Text = resultado.Rows[0]["dt"].ToString();
                ptx_foto.Load(resultado.Rows[0]["imagem"].ToString());
                foto = resultado.Rows[0]["imagem"].ToString();
            }
            else
            {
                MessageBox.Show("Produto não cadastrado.", "Busca",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            double valor;
            int quantidade;

            if (double.TryParse(txt_valor.Text,out valor) && int.TryParse(txt_quantidade.Text,out quantidade) && foto != null && txt_codigo.Text != "")
            {
                data = DateTime.Parse(dtp_data.Text);
                foto = foto.Replace(@"\", @"\\");

                sql = string.Format("update produtos set descricao = '{0}', valor = '{1}', quantidade = '{2}', dt = '{3}', imagem = '{4}' where id = '{5}'",
                    txt_descricao.Text, txt_valor.Text, txt_quantidade.Text, data.ToString("yyyy-MM-dd"), foto, txt_codigo.Text);

                bd.AlterarTabelas(sql);
                MessageBox.Show("Produto Alterado com Sucesso...", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                Listar();
            }
            else
            {
                MessageBox.Show("Produto não pode ser alterado.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            sql = "delete from produtos where id = '" + txt_codigo.Text + "'";
            bd.AlterarTabelas(sql);
            MessageBox.Show("Produto Excluido com sucesso...", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Limpar();
            Listar();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_listar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_codigo.Text = dgv_listar.Rows[e.RowIndex].Cells[0].Value.ToString(); //e.RowIndex - Pega a linha que esta clickando
            txt_descricao.Text = dgv_listar.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_valor.Text = dgv_listar.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_quantidade.Text = dgv_listar.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtp_data.Text = dgv_listar.Rows[e.RowIndex].Cells[4].Value.ToString();
            ptx_foto.Load(dgv_listar.Rows[e.RowIndex].Cells[5].Value.ToString()); //Carrega Foto
            foto = dgv_listar.Rows[e.RowIndex].Cells[5].Value.ToString(); //Manipula o caminho
        }
    }
}
