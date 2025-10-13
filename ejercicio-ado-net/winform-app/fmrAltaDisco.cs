using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;
using System.IO;

namespace winform_app
{
    public partial class fmrAltaDisco : Form
    {
        private Disco disco = null;
        private OpenFileDialog archivo = null;
        public fmrAltaDisco()
        {
            InitializeComponent();
        }
        public fmrAltaDisco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                if (disco == null)
                    disco = new Disco();

                disco.Titulo = txtTitulo.Text;
                disco.FechaLanzamiento = dtpFecha.Value;
                disco.CantidadCanciones = int.Parse(txtCantidad.Text);
                disco.UrlImagenTapa = txtUrlTapaDisco.Text;
                disco.Genero = (Estilo)cboEstilo.SelectedItem;
                disco.Tipo = (TipoEdicion)cboTipo.SelectedItem;

                if (disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificacion Exitosa", "Modificando");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Carga Exitosa", "Agregando");
                }

                if (archivo != null && !(txtUrlTapaDisco.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["discos-app"] + archivo.SafeFileName);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void fmrAltaDisco_Load(object sender, EventArgs e)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

            try
            {
                cboEstilo.DataSource = estiloNegocio.listar();
                cboEstilo.ValueMember = "Id";
                cboEstilo.DisplayMember = "Descripcion";
                cboTipo.DataSource = tipoEdicionNegocio.listar();
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";

                if (disco != null)
                {
                    txtTitulo.Text = disco.Titulo;
                    dtpFecha.Value = disco.FechaLanzamiento;
                    txtUrlTapaDisco.Text = disco.UrlImagenTapa;
                    txtCantidad.Text = disco.CantidadCanciones.ToString();
                    cargarImagen(disco.UrlImagenTapa);
                    cboEstilo.SelectedValue = disco.Tipo.Id;
                    cboTipo.SelectedValue = disco.Genero.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void txtUrlTapaDisco_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlTapaDisco.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbUrlTapaDisco.Load(imagen);

            }
            catch (Exception)
            {
                pbUrlTapaDisco.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlTapaDisco.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }

        }
    }
}
