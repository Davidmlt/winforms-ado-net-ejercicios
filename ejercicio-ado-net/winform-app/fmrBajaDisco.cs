using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app
{
    public partial class fmrBajaDisco : Form
    {
        private List<Disco> listaDiscos;
        public fmrBajaDisco()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            try
            {
                listaDiscos = negocio.listaRecuperados();
                dgvBaja.DataSource = listaDiscos;
                ocultar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultar()
        {
            dgvBaja.Columns["UrlImagenTapa"].Visible = false;
            dgvBaja.Columns["Id"].Visible = false;
        }

        private void fmrBajaDisco_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnRecuperarLogico_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            Disco seleccionado;
            try
            {
                seleccionado = (Disco)dgvBaja.CurrentRow.DataBoundItem;
                negocio.recuperarEliminado(seleccionado.Id);
                cargar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
