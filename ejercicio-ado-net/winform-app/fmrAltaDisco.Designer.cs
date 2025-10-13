namespace winform_app
{
    partial class fmrAltaDisco
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEstilo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblUrlImagenTapa = new System.Windows.Forms.Label();
            this.txtUrlTapaDisco = new System.Windows.Forms.TextBox();
            this.pbUrlTapaDisco = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUrlTapaDisco)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(146, 55);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(43, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(43, 103);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(146, 16);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha de Lanzamiento:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(43, 157);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(150, 16);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad de Canciones:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(46, 256);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(331, 259);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(199, 52);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(215, 22);
            this.txtTitulo.TabIndex = 0;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(199, 154);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(215, 22);
            this.txtCantidad.TabIndex = 3;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(199, 103);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(215, 22);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblEstilo
            // 
            this.lblEstilo.AutoSize = true;
            this.lblEstilo.Location = new System.Drawing.Point(146, 189);
            this.lblEstilo.Name = "lblEstilo";
            this.lblEstilo.Size = new System.Drawing.Size(43, 16);
            this.lblEstilo.TabIndex = 9;
            this.lblEstilo.Text = "Estilo:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(84, 224);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(105, 16);
            this.lblTipo.TabIndex = 10;
            this.lblTipo.Text = "Tipo de Edicion:";
            // 
            // cboEstilo
            // 
            this.cboEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(199, 189);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(215, 24);
            this.cboEstilo.TabIndex = 4;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(195, 224);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(219, 24);
            this.cboTipo.TabIndex = 5;
            // 
            // lblUrlImagenTapa
            // 
            this.lblUrlImagenTapa.AutoSize = true;
            this.lblUrlImagenTapa.Location = new System.Drawing.Point(71, 130);
            this.lblUrlImagenTapa.Name = "lblUrlImagenTapa";
            this.lblUrlImagenTapa.Size = new System.Drawing.Size(118, 16);
            this.lblUrlImagenTapa.TabIndex = 13;
            this.lblUrlImagenTapa.Text = "Url Tapa de disco:";
            // 
            // txtUrlTapaDisco
            // 
            this.txtUrlTapaDisco.Location = new System.Drawing.Point(199, 127);
            this.txtUrlTapaDisco.Name = "txtUrlTapaDisco";
            this.txtUrlTapaDisco.Size = new System.Drawing.Size(215, 22);
            this.txtUrlTapaDisco.TabIndex = 2;
            this.txtUrlTapaDisco.Leave += new System.EventHandler(this.txtUrlTapaDisco_Leave);
            // 
            // pbUrlTapaDisco
            // 
            this.pbUrlTapaDisco.Location = new System.Drawing.Point(448, 55);
            this.pbUrlTapaDisco.Name = "pbUrlTapaDisco";
            this.pbUrlTapaDisco.Size = new System.Drawing.Size(294, 227);
            this.pbUrlTapaDisco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUrlTapaDisco.TabIndex = 15;
            this.pbUrlTapaDisco.TabStop = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(420, 127);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(21, 23);
            this.btnAgregarImagen.TabIndex = 16;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // fmrAltaDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 285);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pbUrlTapaDisco);
            this.Controls.Add(this.txtUrlTapaDisco);
            this.Controls.Add(this.lblUrlImagenTapa);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.cboEstilo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblEstilo);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTitulo);
            this.Name = "fmrAltaDisco";
            this.Text = "Disco Nuevo";
            this.Load += new System.EventHandler(this.fmrAltaDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUrlTapaDisco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblEstilo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblUrlImagenTapa;
        private System.Windows.Forms.TextBox txtUrlTapaDisco;
        private System.Windows.Forms.PictureBox pbUrlTapaDisco;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}