namespace Form_Mbcif.Forms
{
    partial class Ventana_tablas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCantidadIteraciones = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.estadoSistema = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "cantidad de iteraciones";
            // 
            // textBoxCantidadIteraciones
            // 
            this.textBoxCantidadIteraciones.Location = new System.Drawing.Point(12, 28);
            this.textBoxCantidadIteraciones.Name = "textBoxCantidadIteraciones";
            this.textBoxCantidadIteraciones.Size = new System.Drawing.Size(117, 20);
            this.textBoxCantidadIteraciones.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Realizar Iteraciones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(549, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "Relaciones del sistema";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Elementos del sistema";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.estadoSistema);
            this.groupBox1.Location = new System.Drawing.Point(268, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 44);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado del sistema";
            // 
            // estadoSistema
            // 
            this.estadoSistema.Location = new System.Drawing.Point(6, 19);
            this.estadoSistema.Name = "estadoSistema";
            this.estadoSistema.ReadOnly = true;
            this.estadoSistema.Size = new System.Drawing.Size(204, 20);
            this.estadoSistema.TabIndex = 0;
            // 
            // Ventana_tablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 782);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCantidadIteraciones);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Ventana_tablas";
            this.Text = "Ventana_tablas";
            this.Load += new System.EventHandler(this.Ventana_tablas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
       


        void tablas() {
            
            this.tablaElementos.Location=new System.Drawing.Point(20, 80);
            this.tablaElementos.Size=new System.Drawing.Size(500, 580);
            this.tablaElementos.ReadOnly = true;

            this.tablaRelaciones.Location=new System.Drawing.Point(550, 80);
            this.tablaRelaciones.Size=new System.Drawing.Size(650, 580);
            this.tablaRelaciones.ReadOnly = true;

            this.Controls.Add(this.tablaElementos);
            this.Controls.Add(this.tablaRelaciones);
            
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCantidadIteraciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox estadoSistema;
    }
}