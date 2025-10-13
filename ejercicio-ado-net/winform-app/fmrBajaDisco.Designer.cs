namespace winform_app
{
    partial class fmrBajaDisco
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
            this.dgvBaja = new System.Windows.Forms.DataGridView();
            this.btnRecuperarLogico = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaja
            // 
            this.dgvBaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaja.Location = new System.Drawing.Point(2, 12);
            this.dgvBaja.Name = "dgvBaja";
            this.dgvBaja.RowHeadersWidth = 51;
            this.dgvBaja.RowTemplate.Height = 24;
            this.dgvBaja.Size = new System.Drawing.Size(432, 158);
            this.dgvBaja.TabIndex = 0;
            // 
            // btnRecuperarLogico
            // 
            this.btnRecuperarLogico.Location = new System.Drawing.Point(38, 193);
            this.btnRecuperarLogico.Name = "btnRecuperarLogico";
            this.btnRecuperarLogico.Size = new System.Drawing.Size(95, 23);
            this.btnRecuperarLogico.TabIndex = 1;
            this.btnRecuperarLogico.Text = "Recuperar";
            this.btnRecuperarLogico.UseVisualStyleBackColor = true;
            this.btnRecuperarLogico.Click += new System.EventHandler(this.btnRecuperarLogico_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(275, 193);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(95, 23);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // fmrBajaDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 228);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnRecuperarLogico);
            this.Controls.Add(this.dgvBaja);
            this.Name = "fmrBajaDisco";
            this.Text = "Discos Eliminados";
            this.Load += new System.EventHandler(this.fmrBajaDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaja;
        private System.Windows.Forms.Button btnRecuperarLogico;
        private System.Windows.Forms.Button btnAtras;
    }
}