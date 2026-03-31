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
        Cliente cl;

        void carregarGrid(string pesquisa)
        {
            cl = new Cliente()
            {
                nome = pesquisa 
            };
            dgvClientes.DataSource = cl.Consultar();
        }
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

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ci = new Cidade();
            cboCidades.DataSource = ci.Consultar();
            cboCidades.DisplayMember = "nome";
            cboCidades.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            dgvClientes.Columns["idCidade"].Visible = false;
            dgvClientes.Columns["foto"].Visible = false;
        }

        private void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCidades.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidades.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "C:/ETEC/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            cl = new Cliente()
            {
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };

            cl.Incluir();

            limpaControles();
            carregarGrid("");

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
            txtNome.Text = dgvClientes.CurrentRow.Cells["nome"].Value.ToString();
            cboCidades.Text = dgvClientes.CurrentRow.Cells["cidade"].Value.ToString();
            txtUF.Text = dgvClientes.CurrentRow.Cells["uf"].Value.ToString();
            chkVenda.Checked = (bool)dgvClientes.CurrentRow.Cells["venda"].Value;
            mskCPF.Text = dgvClientes.CurrentRow.Cells["cpf"].Value.ToString();
            dtpDataNasc.Text = dgvClientes.CurrentRow.Cells["dataNasc"].Value.ToString();
            txtRenda.Text = dgvClientes.CurrentRow.Cells["renda"].Value.ToString();
            picFoto.ImageLocation = dgvClientes.CurrentRow.Cells["foto"].Value.ToString();
        }
    }
}
