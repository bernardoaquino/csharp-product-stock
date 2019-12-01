using MySql.Data.MySqlClient; //Pega referência do MySql, transformando em um cliente para receber o BD
using System.Data;

namespace Produtos_11
{
    class ConexaoBD
    {
        private MySqlConnection conexao; //Variável que faz conexão com o MySql

        public void ConectarBD() //Void não retorna nada
        {
            //Persist secury info = false (Gera logs, mas não manda informações do BD(Objeto de conexão))
            conexao = new MySqlConnection("persist security info = false;server=localhost;database=produtos_11;uid=root;pwd=;");
            conexao.Open();
        }

        public void AlterarTabelas(string sql)
        {
            ConectarBD();
            MySqlCommand comandos = new MySqlCommand(sql, conexao); //Vai executar os comandos (variavel sql) na conexão - Insert / Update / Delete
            comandos.ExecuteNonQuery();
            conexao.Close();
        }

        public DataTable ConsultarTabelas(string sql)
        {
            ConectarBD();
            MySqlDataAdapter consulta = new MySqlDataAdapter(sql, conexao); //Pega o valor - Executa o comando Select
            DataTable resultado = new DataTable(); //Cria tabela para receber o valor
            consulta.Fill(resultado); //Transforma DataAdapter em DataTable
            conexao.Close();
            return resultado;
        }
    }
}
