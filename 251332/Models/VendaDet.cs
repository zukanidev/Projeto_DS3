using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _251332.Models
{
    public class VendaDet
    {
        public int Id { get; set; }
        public int idVendaCab { get; set; }
        public int idProduto { get; set; }
        public int qtde { get; set; }
        public double valorUnitario { get; set; }

    public void Incluir()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySql.Data.MySqlClient.MySqlCommand(
                    "INSERT INTO VendaDet (idVendaCab, idProduto, qtde, valorUnitario)" +
                    "VALUES (@idVendaCab, @idProduto, @qtde, @valorUnitario)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@idVendaCab", idVendaCab);
                Banco.Comando.Parameters.AddWithValue("@idProduto", idProduto);
                Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.Comando.Parameters.AddWithValue("@valorUnitario", valorUnitario);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
         
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message,"Erro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
              
            }
        }
    }
}
