using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _251332.Models
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO CIDADES" +
                                                                        "(NOME, UF)" +
                                                                        "VALUES" +
                                                                        "(@NOME, @UF)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome);
                Banco.Comando.Parameters.AddWithValue("@UF", uf);
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
                Banco.Comando = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM CIDADES " +
                                                                        "WHERE NOME LIKE @NOME " +
                                                                        "ORDER BY NOME", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome + "%");

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


        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySql.Data.MySqlClient.MySqlCommand("UPDATE CIDADES SET " +
                                                                        "NOME = @NOME, " +
                                                                        "UF = @UF " +
                                                                        "WHERE ID = @ID", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome);
                Banco.Comando.Parameters.AddWithValue("@UF", uf);
                Banco.Comando.Parameters.AddWithValue("@ID", id);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }

    
}
