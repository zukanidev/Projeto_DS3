using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _251332.Models;

namespace _251332.Views
{
    public partial class frmUsuarios : Form
    {
        Usuario u;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNomeUsuario.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtFuncao.Clear();
            txtNomeUsuario.Focus();
        }

        void carregarGrid(string pesquisa)
        {
            u = new Usuario()
            {
                nome = pesquisa
            };
            dgvUsuarios.DataSource = u.Consultar();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            
           limpaControles();
           carregarGrid("");
         
        }

   
    }
}
