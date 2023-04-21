namespace Sistema
{
    partial class Form_ajuste_cliente
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_nombre_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_apellidop_cliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_apellidom_cliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_domicilio_cliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_editar_cliente = new System.Windows.Forms.Button();
            this.btn_insertar = new System.Windows.Forms.Button();
            this.txt_id_cliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(762, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txt_nombre_cliente
            // 
            this.txt_nombre_cliente.Location = new System.Drawing.Point(79, 51);
            this.txt_nombre_cliente.Name = "txt_nombre_cliente";
            this.txt_nombre_cliente.Size = new System.Drawing.Size(183, 20);
            this.txt_nombre_cliente.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // txt_apellidop_cliente
            // 
            this.txt_apellidop_cliente.Location = new System.Drawing.Point(111, 100);
            this.txt_apellidop_cliente.Name = "txt_apellidop_cliente";
            this.txt_apellidop_cliente.Size = new System.Drawing.Size(183, 20);
            this.txt_apellidop_cliente.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellido Paterno:";
            // 
            // txt_apellidom_cliente
            // 
            this.txt_apellidom_cliente.Location = new System.Drawing.Point(111, 151);
            this.txt_apellidom_cliente.Name = "txt_apellidom_cliente";
            this.txt_apellidom_cliente.Size = new System.Drawing.Size(183, 20);
            this.txt_apellidom_cliente.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido materno:";
            // 
            // txt_domicilio_cliente
            // 
            this.txt_domicilio_cliente.Location = new System.Drawing.Point(79, 208);
            this.txt_domicilio_cliente.Name = "txt_domicilio_cliente";
            this.txt_domicilio_cliente.Size = new System.Drawing.Size(183, 20);
            this.txt_domicilio_cliente.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Domicilio:";
            // 
            // btn_editar_cliente
            // 
            this.btn_editar_cliente.Location = new System.Drawing.Point(339, 77);
            this.btn_editar_cliente.Name = "btn_editar_cliente";
            this.btn_editar_cliente.Size = new System.Drawing.Size(75, 23);
            this.btn_editar_cliente.TabIndex = 11;
            this.btn_editar_cliente.Text = "Editar";
            this.btn_editar_cliente.UseVisualStyleBackColor = true;
            this.btn_editar_cliente.Click += new System.EventHandler(this.btn_editar_cliente_Click);
            // 
            // btn_insertar
            // 
            this.btn_insertar.Location = new System.Drawing.Point(339, 25);
            this.btn_insertar.Name = "btn_insertar";
            this.btn_insertar.Size = new System.Drawing.Size(75, 23);
            this.btn_insertar.TabIndex = 12;
            this.btn_insertar.Text = "insertar";
            this.btn_insertar.UseVisualStyleBackColor = true;
            this.btn_insertar.Click += new System.EventHandler(this.btn_insertar_Click);
            // 
            // txt_id_cliente
            // 
            this.txt_id_cliente.Location = new System.Drawing.Point(79, 12);
            this.txt_id_cliente.Name = "txt_id_cliente";
            this.txt_id_cliente.Size = new System.Drawing.Size(183, 20);
            this.txt_id_cliente.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID:";
            // 
            // Form_ajuste_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_id_cliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_insertar);
            this.Controls.Add(this.btn_editar_cliente);
            this.Controls.Add(this.txt_domicilio_cliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_apellidom_cliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_apellidop_cliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nombre_cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_ajuste_cliente";
            this.Text = "Form_ajuste_cliente";
            this.Load += new System.EventHandler(this.Form_ajuste_cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_nombre_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_apellidop_cliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_apellidom_cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_domicilio_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_editar_cliente;
        private System.Windows.Forms.Button btn_insertar;
        private System.Windows.Forms.TextBox txt_id_cliente;
        private System.Windows.Forms.Label label1;
    }
}