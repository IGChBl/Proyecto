﻿namespace Proyecto
{
    partial class frmHistorialFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialFacturas));
            this.dgvHistorialFacturas = new System.Windows.Forms.DataGridView();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.btnElimiarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialFacturas
            // 
            this.dgvHistorialFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialFacturas.Location = new System.Drawing.Point(166, 41);
            this.dgvHistorialFacturas.Name = "dgvHistorialFacturas";
            this.dgvHistorialFacturas.RowHeadersWidth = 51;
            this.dgvHistorialFacturas.RowTemplate.Height = 24;
            this.dgvHistorialFacturas.Size = new System.Drawing.Size(469, 292);
            this.dgvHistorialFacturas.TabIndex = 0;
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerDetalles.Location = new System.Drawing.Point(166, 369);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(116, 23);
            this.btnVerDetalles.TabIndex = 1;
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // btnElimiarFactura
            // 
            this.btnElimiarFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElimiarFactura.Location = new System.Drawing.Point(504, 369);
            this.btnElimiarFactura.Name = "btnElimiarFactura";
            this.btnElimiarFactura.Size = new System.Drawing.Size(131, 23);
            this.btnElimiarFactura.TabIndex = 2;
            this.btnElimiarFactura.Text = "Eliminar Factura";
            this.btnElimiarFactura.UseVisualStyleBackColor = true;
            // 
            // frmHistorialFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnElimiarFactura);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.dgvHistorialFacturas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHistorialFacturas";
            this.Text = "Historial de Facturas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistorialFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialFacturas;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnElimiarFactura;
    }
}