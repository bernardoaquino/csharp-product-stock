using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Adicionar Biblioteca para utilização do DataTable
using System.Data;

namespace Produtos_11
{
    class Login
    {
        //Instanciar a classe de conexão com o banco de dados
        ConexaoBD bd = new ConexaoBD();

        //Variavel estatica - unica da classe
        //para armazenar o nome do usuario logado
        static string usuario;

        //Método para validar o login e a senha
        public bool Validar_login(string login, string senha)
        {
            string sql = string.Format("select * from usuarios where login = '{0}' and senha = '{1}'", login, senha);
            DataTable dt = bd.ConsultarTabelas(sql);

            //Verifica se a consulta retornou valores
            if(dt.Rows.Count > 0)
            {
                //Recupera o nome do usuario
                usuario = dt.Rows[0]["login"].ToString();
                //Retorna verdadeira
                return true;
            }else
            {
                //Retorna falso
                return false;
            }
        }

        //Método para retornar o nome do usuario logado
        public string getUsuario()
        {
            return usuario;
        }
    }
}
