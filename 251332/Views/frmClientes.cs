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
    public partial class frmClientes : Form
    {
        Cidade ci;
        Cliente Cl;

        void limpaControles()
            {
            txtID.Clear();
            txtNome.Clear();
            cboCidades.SelectedIndex = -1;
            txtUF.Clear();
            mskCPF.Clear();
            txtRenda.Clear();
            dtpDataNasc.Value = DateTime.Now;
            picFoto.ImageLocation = "";
            chkVenda.Checked = false;
        }
        public frmClientes()
        {
            InitializeComponent();
        }

  
    }
}
