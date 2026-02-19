using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _251332.Models
{
    internal class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string funcao { get; set; }


        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO USUARIOS" +
                                                                        "(NOME, LOGIN, SENHA, FUNCAO)" +
                                                                        "VALUES" +
                                                                        "(@NOME, @LOGIN, @SENHA, @FUNCAO)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome);
                Banco.Comando.Parameters.AddWithValue("@LOGIN", login);
                Banco.Comando.Parameters.AddWithValue("@SENHA", senha);
                Banco.Comando.Parameters.AddWithValue("@FUNCAO", funcao);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM USUARIOS " +
                                                                        "WHERE NOME LIKE @NOME " +
                                                                        "ORDER BY NOME", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome);

                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Banco.datTabela;
        }



    }
 }
