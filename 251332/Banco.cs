using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _251332
{
    public class Banco
    {
        public static MySqlConnection Conexao;

        public static MySqlCommand Comando;

        public static MySqlDataAdapter Adaptador;

        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=root");
                Conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar a conexão com o banco de dados: " + ex.Message);
            }
        }

        public static void CriarBanco()
        {

            try
            {
                AbrirConexao();


                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS VENDAS_191125;USE VENDAS_191125", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS CIDADES" +
                                            "(ID INTEGER AUTO_INCREMENT PRIMARY KEY, " +
                                            "NOME VARCHAR(40), " +
                                            "UF CHAR(02))", Conexao);
                Comando.ExecuteNonQuery();

                FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o banco de dados ou a tabela: " + ex.Message);
            }


            try
            {
                AbrirConexao();


                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS VENDAS_191125;USE VENDAS_191125", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS USUARIOS" +
                                            "(ID INTEGER AUTO_INCREMENT PRIMARY KEY, " +
                                            "NOME VARCHAR(40), " +
                                            "LOGIN VARCHAR(30), " +
                                            "SENHA VARCHAR(20), " +
                                            "FUNCAO VARCHAR(50)) ", Conexao);
                Comando.ExecuteNonQuery();

                FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o banco de dados ou a tabela: " + ex.Message);
            }


        }
    }
}
