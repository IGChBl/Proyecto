using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto.frmAgregarCliente;

namespace Proyecto
{
    public partial class frmGenerarFactura : Form
    {
        public frmGenerarFactura()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Generarfacturas_Load(object sender, EventArgs e)
        {
            // Cargar los clientes en el ComboBox
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = ClienteData.Clientes;
        }
    }
}
