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

namespace winform_app
{
    public partial class fmsDiscos : Form
    {
        private List<Disco> listaDiscos;
        public fmsDiscos()
        {
            InitializeComponent();
        }

        private void fmsDiscos_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Titulo");
            cboCampo.Items.Add("Cantidad de canciones");
            cboCampo.Items.Add("Genero");

        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDiscos.CurrentRow != null)
                {
                    Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    cargarImagen(seleccionado.UrlImagenTapa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbDiscos.Load(imagen);

            }
            catch (Exception)
            {
                pbDiscos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
        private void cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            try
            {
                listaDiscos = negocio.listar();
                dgvDiscos.DataSource = listaDiscos;
                cargarImagen(listaDiscos[0].UrlImagenTapa);
                ocultar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       

        private void ocultar()
        {
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            fmrAltaDisco alta = new fmrAltaDisco();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

            fmrAltaDisco modificar = new fmrAltaDisco(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool opcion = false)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            Disco seleccionado;
            try
            {
                DialogResult resultado = MessageBox.Show("¿Desea eliminar el disco?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

                    if (opcion)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminarFisico(seleccionado.Id);
                }
                cargar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool validarFiltros()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Cantidad de canciones")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debe cargar el filtro para numericos");
                    return true;
                }
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo numeros para filtrar por un campo numerico");
                    return true;
                }
            }
            return false;
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char letra in cadena)
            {
                if (!(char.IsNumber(letra)))
                    return false;
            }
            return true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            try
            {
                if (validarFiltros())
                {
                    return;
                }
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length >= 3)
                listaFiltrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Genero.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            else
                listaFiltrada = listaDiscos;

            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;
            ocultar();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Cantidad de canciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            fmrBajaDisco baja = new fmrBajaDisco();
            baja.ShowDialog();
            cargar();
        }
    }

}
