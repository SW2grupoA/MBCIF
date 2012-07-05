namespace Form_Mbcif.Forms
{
    partial class Forms
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Nuevo_nivel");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sistema", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Eliminar_button = new System.Windows.Forms.Button();
            this.Cancelar_button = new System.Windows.Forms.Button();
            this.Ingresar_button = new System.Windows.Forms.Button();
            this.nombre_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updateStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.relacionesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.elementosToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.nivelesStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.repetidoStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.Eliminar_button);
            this.panel1.Controls.Add(this.Cancelar_button);
            this.panel1.Controls.Add(this.Ingresar_button);
            this.panel1.Controls.Add(this.nombre_textBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(204, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 207);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Elemento: ";
            this.label3.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Eliminar_button
            // 
            this.Eliminar_button.Location = new System.Drawing.Point(114, 168);
            this.Eliminar_button.Name = "Eliminar_button";
            this.Eliminar_button.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_button.TabIndex = 9;
            this.Eliminar_button.Text = "Eliminar";
            this.Eliminar_button.UseVisualStyleBackColor = true;
            this.Eliminar_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // Cancelar_button
            // 
            this.Cancelar_button.Location = new System.Drawing.Point(195, 168);
            this.Cancelar_button.Name = "Cancelar_button";
            this.Cancelar_button.Size = new System.Drawing.Size(75, 23);
            this.Cancelar_button.TabIndex = 8;
            this.Cancelar_button.Text = "Cancelar";
            this.Cancelar_button.UseVisualStyleBackColor = true;
            this.Cancelar_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ingresar_button
            // 
            this.Ingresar_button.Location = new System.Drawing.Point(33, 168);
            this.Ingresar_button.Name = "Ingresar_button";
            this.Ingresar_button.Size = new System.Drawing.Size(75, 23);
            this.Ingresar_button.TabIndex = 7;
            this.Ingresar_button.Text = "Ingresar";
            this.Ingresar_button.UseVisualStyleBackColor = true;
            this.Ingresar_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // nombre_textBox
            // 
            this.nombre_textBox.Location = new System.Drawing.Point(67, 53);
            this.nombre_textBox.Name = "nombre_textBox";
            this.nombre_textBox.Size = new System.Drawing.Size(173, 20);
            this.nombre_textBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "--";
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Info;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.FullRowSelect = true;
            this.treeView.Location = new System.Drawing.Point(12, 42);
            this.treeView.Name = "treeView";
            treeNode1.Name = "Nodo0";
            treeNode1.Text = "Nuevo_nivel";
            treeNode2.Name = "";
            treeNode2.Text = "Sistema";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView.Size = new System.Drawing.Size(176, 260);
            this.treeView.TabIndex = 3;
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripButton,
            this.updateStripButton,
            this.toolStripSeparator,
            this.relacionesToolStripButton,
            this.elementosToolStripButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(508, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // guardarToolStripButton
            // 
            this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton.Image")));
            this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripButton.Name = "guardarToolStripButton";
            this.guardarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.guardarToolStripButton.Text = "&Guardar";
            // 
            // updateStripButton
            // 
            this.updateStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateStripButton.Image = ((System.Drawing.Image)(resources.GetObject("updateStripButton.Image")));
            this.updateStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateStripButton.Name = "updateStripButton";
            this.updateStripButton.Size = new System.Drawing.Size(23, 22);
            this.updateStripButton.Text = "Actualizar";
            this.updateStripButton.Click += new System.EventHandler(this.Forms_Load);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // relacionesToolStripButton
            // 
            this.relacionesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.relacionesToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("relacionesToolStripButton.Image")));
            this.relacionesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relacionesToolStripButton.Name = "relacionesToolStripButton";
            this.relacionesToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.relacionesToolStripButton.Text = "&Relaciones";
            this.relacionesToolStripButton.Click += new System.EventHandler(this.relacionesToolStripButton_Click);
            // 
            // elementosToolStripButton
            // 
            this.elementosToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.elementosToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("elementosToolStripButton.Image")));
            this.elementosToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.elementosToolStripButton.Name = "elementosToolStripButton";
            this.elementosToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.elementosToolStripButton.Text = "&Elemento";
            this.elementosToolStripButton.Click += new System.EventHandler(this.elementosToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nivelesStripStatusLabel1,
            this.repetidoStripStatusLabel1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(508, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // nivelesStripStatusLabel1
            // 
            this.nivelesStripStatusLabel1.Name = "nivelesStripStatusLabel1";
            this.nivelesStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.nivelesStripStatusLabel1.Text = "Niveles";
            // 
            // repetidoStripStatusLabel1
            // 
            this.repetidoStripStatusLabel1.Name = "repetidoStripStatusLabel1";
            this.repetidoStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Forms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 331);
            this.ControlBox = false;
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Forms";
            this.Text = "Ingreso Sistemas";
            this.Load += new System.EventHandler(this.Forms_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nombre_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button Cancelar_button;
        private System.Windows.Forms.Button Ingresar_button;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton guardarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton relacionesToolStripButton;
        private System.Windows.Forms.ToolStripButton elementosToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button Eliminar_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripButton updateStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel nivelesStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel repetidoStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}