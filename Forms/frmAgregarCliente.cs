﻿using Proyecto.Models;
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
    public partial class frmAgregarCliente : Form
    {
        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {

        }
        public static class ClienteData
        {
            public static List<Cliente> Clientes = new List<Cliente>();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string telefono = tbTelefono.Text;
            string email = tbEmail.Text;

            // Validación del Teléfono
            if (telefono.Length != 8 || !System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{8}$")) // expresión regular para validar un número de teléfono de 8 dígitos
            {
                MessageBox.Show("El número de teléfono debe ser de 8 dígitos y contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el proceso de guardado si la validación falla
            }

            // Validación del Correo Electrónico
            if (!email.Contains("@") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // expresión regular para validar un correo electrónico
            {
                MessageBox.Show("Ingrese un correo electrónico válido que contenga '@' y un dominio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el proceso de guardado si la validación falla
            }
            // Crear una nueva instancia de Cliente con los datos ingresados
            Cliente nuevoCliente = new Cliente
            {
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text
            };

            // Agregar el cliente a la lista estática
            ClienteData.Clientes.Add(nuevoCliente);

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Cliente agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos de texto
            tbNombre.Clear();
            tbApellido.Clear();
            tbTelefono.Clear();
            tbEmail.Clear();
            tbDireccion.Clear();
        }
    }
}
