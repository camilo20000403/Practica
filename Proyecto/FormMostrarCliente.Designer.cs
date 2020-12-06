namespace Proyecto
{
    partial class FormMostrarCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMostrarCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.DtgTodos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtCedula = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.CmbModificar = new System.Windows.Forms.ComboBox();
            this.TxtModificar = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LISTA DE CLIENTES";
            // 
            // DtgTodos
            // 
            this.DtgTodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTodos.Location = new System.Drawing.Point(53, 82);
            this.DtgTodos.Name = "DtgTodos";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.DtgTodos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgTodos.Size = new System.Drawing.Size(648, 385);
            this.DtgTodos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(421, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "MODIFICAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(720, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // TxtCedula
            // 
            this.TxtCedula.Location = new System.Drawing.Point(201, 522);
            this.TxtCedula.Name = "TxtCedula";
            this.TxtCedula.Size = new System.Drawing.Size(171, 20);
            this.TxtCedula.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(65, 513);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "BUSCAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CmbModificar
            // 
            this.CmbModificar.FormattingEnabled = true;
            this.CmbModificar.Items.AddRange(new object[] {
            "SELECCIONE",
            "Primer nombre",
            "Segundo nombre",
            "Primer apellido",
            "Segundo apellido",
            "Direccion",
            "Celular"});
            this.CmbModificar.Location = new System.Drawing.Point(558, 522);
            this.CmbModificar.Name = "CmbModificar";
            this.CmbModificar.Size = new System.Drawing.Size(121, 21);
            this.CmbModificar.TabIndex = 7;
            // 
            // TxtModificar
            // 
            this.TxtModificar.Location = new System.Drawing.Point(699, 522);
            this.TxtModificar.Name = "TxtModificar";
            this.TxtModificar.Size = new System.Drawing.Size(100, 20);
            this.TxtModificar.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(54, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 37);
            this.button2.TabIndex = 9;
            this.button2.Text = "Todos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMostrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1056, 615);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtModificar);
            this.Controls.Add(this.CmbModificar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TxtCedula);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DtgTodos);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMostrarCliente";
            this.Text = "FormMostrarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.DtgTodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtgTodos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtCedula;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox CmbModificar;
        private System.Windows.Forms.TextBox TxtModificar;
        private System.Windows.Forms.Button button2;
    }
}