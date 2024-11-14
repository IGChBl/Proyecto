using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerarFactura generarFacturaForm = new frmGenerarFactura();
            generarFacturaForm.Show(); // Muestra el formulario de generación de factura
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarCliente agregarClienteForm = new frmAgregarCliente();
            agregarClienteForm.Show(); // Muestra el formulario de agregar cliente
        }
    }
}
