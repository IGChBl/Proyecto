namespace Proyecto
{
    partial class frmActualizarEliminarFacturaErronea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarEliminarFacturaErronea));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCriterioBusqueda = new System.Windows.Forms.TextBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnActualizarFactura = new System.Windows.Forms.Button();
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Facturas (Numero de factura o cliente)";
            // 
            // txtCriterioBusqueda
            // 
            this.txtCriterioBusqueda.Location = new System.Drawing.Point(62, 109);
            this.txtCriterioBusqueda.Name = "txtCriterioBusqueda";
            this.txtCriterioBusqueda.Size = new System.Drawing.Size(149, 22);
            this.txtCriterioBusqueda.TabIndex = 1;
            // 
            // dgvResultados
            // 
            this.dgvResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(142, 183);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.RowTemplate.Height = 24;
            this.dgvResultados.Size = new System.Drawing.Size(240, 150);
            this.dgvResultados.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(240, 109);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnActualizarFactura
            // 
            this.btnActualizarFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizarFactura.Location = new System.Drawing.Point(49, 350);
            this.btnActualizarFactura.Name = "btnActualizarFactura";
            this.btnActualizarFactura.Size = new System.Drawing.Size(129, 23);
            this.btnActualizarFactura.TabIndex = 4;
            this.btnActualizarFactura.Text = "Actualizar Factura";
            this.btnActualizarFactura.UseVisualStyleBackColor = true;
            this.btnActualizarFactura.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarFactura.Location = new System.Drawing.Point(335, 350);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(124, 23);
            this.btnEliminarFactura.TabIndex = 5;
            this.btnEliminarFactura.Text = "Eliminar Factura";
            this.btnEliminarFactura.UseVisualStyleBackColor = true;
            this.btnEliminarFactura.Click += new System.EventHandler(this.btnEliminarFactura_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ingresese Numero de factura o Nombre del Cliente";
            // 
            // frmActualizarEliminarFacturaErronea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarFactura);
            this.Controls.Add(this.btnActualizarFactura);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.txtCriterioBusqueda);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActualizarEliminarFacturaErronea";
            this.Text = "Actualizar Factura Errónea";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Actualizar_o_Eliminar_Facturas_Erróneas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCriterioBusqueda;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnActualizarFactura;
        private System.Windows.Forms.Button btnEliminarFactura;
        private System.Windows.Forms.Label label2;
    }
}