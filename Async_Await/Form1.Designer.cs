namespace Async_Await
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.rtbTexto = new System.Windows.Forms.RichTextBox();
            this.pbCargando = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(20, 11);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(592, 134);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Informador";
            // 
            // rtbTexto
            // 
            this.rtbTexto.Location = new System.Drawing.Point(29, 158);
            this.rtbTexto.Name = "rtbTexto";
            this.rtbTexto.Size = new System.Drawing.Size(739, 209);
            this.rtbTexto.TabIndex = 1;
            this.rtbTexto.Text = "";
            // 
            // pbCargando
            // 
            this.pbCargando.Image = global::Async_Await.Properties.Resources.load;
            this.pbCargando.Location = new System.Drawing.Point(630, 12);
            this.pbCargando.Name = "pbCargando";
            this.pbCargando.Size = new System.Drawing.Size(135, 129);
            this.pbCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCargando.TabIndex = 2;
            this.pbCargando.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(317, 396);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(194, 31);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Carga Asincrona";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.pbCargando);
            this.Controls.Add(this.rtbTexto);
            this.Controls.Add(this.lblInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.RichTextBox rtbTexto;
        private System.Windows.Forms.PictureBox pbCargando;
        private System.Windows.Forms.Button btnCargar;
    }
}

