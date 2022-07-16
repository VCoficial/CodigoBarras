namespace CodigoDeBarras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PBCodBarra = new System.Windows.Forms.PictureBox();
            this.TxtCodBarra = new System.Windows.Forms.TextBox();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.TxtBuscarCodBarra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnInsertar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBCodBarra)).BeginInit();
            this.SuspendLayout();
            // 
            // PBCodBarra
            // 
            this.PBCodBarra.Location = new System.Drawing.Point(12, 12);
            this.PBCodBarra.Name = "PBCodBarra";
            this.PBCodBarra.Size = new System.Drawing.Size(334, 118);
            this.PBCodBarra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBCodBarra.TabIndex = 0;
            this.PBCodBarra.TabStop = false;
            // 
            // TxtCodBarra
            // 
            this.TxtCodBarra.Location = new System.Drawing.Point(17, 136);
            this.TxtCodBarra.Name = "TxtCodBarra";
            this.TxtCodBarra.Size = new System.Drawing.Size(161, 20);
            this.TxtCodBarra.TabIndex = 1;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(190, 134);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerar.TabIndex = 2;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // TxtBuscarCodBarra
            // 
            this.TxtBuscarCodBarra.Location = new System.Drawing.Point(55, 162);
            this.TxtBuscarCodBarra.Name = "TxtBuscarCodBarra";
            this.TxtBuscarCodBarra.Size = new System.Drawing.Size(161, 20);
            this.TxtBuscarCodBarra.TabIndex = 3;
            this.TxtBuscarCodBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBuscarCodBarra_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Buscar";
            // 
            // BtnInsertar
            // 
            this.BtnInsertar.Location = new System.Drawing.Point(271, 134);
            this.BtnInsertar.Name = "BtnInsertar";
            this.BtnInsertar.Size = new System.Drawing.Size(75, 23);
            this.BtnInsertar.TabIndex = 7;
            this.BtnInsertar.Text = "Insertar";
            this.BtnInsertar.UseVisualStyleBackColor = true;
            this.BtnInsertar.Click += new System.EventHandler(this.BtnInsertar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(222, 160);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpiar.TabIndex = 8;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 189);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnInsertar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBuscarCodBarra);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.TxtCodBarra);
            this.Controls.Add(this.PBCodBarra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Generador de Codigo";
            ((System.ComponentModel.ISupportInitialize)(this.PBCodBarra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBCodBarra;
        private System.Windows.Forms.TextBox TxtCodBarra;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.TextBox TxtBuscarCodBarra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnInsertar;
        private System.Windows.Forms.Button BtnLimpiar;
    }
}

