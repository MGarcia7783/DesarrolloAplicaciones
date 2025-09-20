namespace Sistema.UI.Formularios
{
    partial class frmTerminarPedido
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chkEfectivo = new System.Windows.Forms.CheckBox();
            this.chkTarjeta = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalVenta = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEfectivo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTarjeta = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCambio = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.iconCancelar = new FontAwesome.Sharp.IconButton();
            this.iconAceptar = new FontAwesome.Sharp.IconButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(93)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(426, 66);
            this.label1.TabIndex = 8;
            this.label1.Text = "Terminar Venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEfectivo
            // 
            this.chkEfectivo.AutoSize = true;
            this.chkEfectivo.Checked = true;
            this.chkEfectivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEfectivo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEfectivo.Location = new System.Drawing.Point(165, 93);
            this.chkEfectivo.Name = "chkEfectivo";
            this.chkEfectivo.Size = new System.Drawing.Size(82, 24);
            this.chkEfectivo.TabIndex = 9;
            this.chkEfectivo.Text = "Efectivo";
            this.chkEfectivo.UseVisualStyleBackColor = true;
            this.chkEfectivo.CheckedChanged += new System.EventHandler(this.chkEfectivo_CheckedChanged);
            // 
            // chkTarjeta
            // 
            this.chkTarjeta.AutoSize = true;
            this.chkTarjeta.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTarjeta.Location = new System.Drawing.Point(277, 93);
            this.chkTarjeta.Name = "chkTarjeta";
            this.chkTarjeta.Size = new System.Drawing.Size(74, 24);
            this.chkTarjeta.TabIndex = 10;
            this.chkTarjeta.Text = "Tarjeta";
            this.chkTarjeta.UseVisualStyleBackColor = true;
            this.chkTarjeta.CheckedChanged += new System.EventHandler(this.chkTarjeta_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalVenta, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEfectivo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTarjeta, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCambio, 1, 3);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 138);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 188);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 47);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total de Venta:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 47);
            this.label3.TabIndex = 1;
            this.label3.Text = "Pago en Efectivo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 47);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pago con Tarjeta:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 47);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cambio Total:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.BorderRadius = 8;
            this.txtTotalVenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalVenta.DefaultText = "0.00";
            this.txtTotalVenta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalVenta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalVenta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalVenta.DisabledState.Parent = this.txtTotalVenta;
            this.txtTotalVenta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalVenta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalVenta.FocusedState.Parent = this.txtTotalVenta;
            this.txtTotalVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTotalVenta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalVenta.HoverState.Parent = this.txtTotalVenta;
            this.txtTotalVenta.Location = new System.Drawing.Point(142, 5);
            this.txtTotalVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.PasswordChar = '\0';
            this.txtTotalVenta.PlaceholderText = "";
            this.txtTotalVenta.ReadOnly = true;
            this.txtTotalVenta.SelectedText = "";
            this.txtTotalVenta.SelectionStart = 4;
            this.txtTotalVenta.ShadowDecoration.Parent = this.txtTotalVenta;
            this.txtTotalVenta.Size = new System.Drawing.Size(235, 36);
            this.txtTotalVenta.TabIndex = 4;
            this.txtTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BorderRadius = 8;
            this.txtEfectivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEfectivo.DefaultText = "0.00";
            this.txtEfectivo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEfectivo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEfectivo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEfectivo.DisabledState.Parent = this.txtEfectivo;
            this.txtEfectivo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEfectivo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEfectivo.FocusedState.Parent = this.txtEfectivo;
            this.txtEfectivo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEfectivo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEfectivo.HoverState.Parent = this.txtEfectivo;
            this.txtEfectivo.Location = new System.Drawing.Point(142, 52);
            this.txtEfectivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.PasswordChar = '\0';
            this.txtEfectivo.PlaceholderText = "";
            this.txtEfectivo.SelectedText = "";
            this.txtEfectivo.SelectionStart = 4;
            this.txtEfectivo.ShadowDecoration.Parent = this.txtEfectivo;
            this.txtEfectivo.Size = new System.Drawing.Size(235, 36);
            this.txtEfectivo.TabIndex = 5;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEfectivo_KeyDown);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BorderRadius = 8;
            this.txtTarjeta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTarjeta.DefaultText = "0.00";
            this.txtTarjeta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTarjeta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTarjeta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarjeta.DisabledState.Parent = this.txtTarjeta;
            this.txtTarjeta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarjeta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarjeta.FocusedState.Parent = this.txtTarjeta;
            this.txtTarjeta.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTarjeta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarjeta.HoverState.Parent = this.txtTarjeta;
            this.txtTarjeta.Location = new System.Drawing.Point(142, 99);
            this.txtTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.PasswordChar = '\0';
            this.txtTarjeta.PlaceholderText = "";
            this.txtTarjeta.SelectedText = "";
            this.txtTarjeta.SelectionStart = 4;
            this.txtTarjeta.ShadowDecoration.Parent = this.txtTarjeta;
            this.txtTarjeta.Size = new System.Drawing.Size(235, 36);
            this.txtTarjeta.TabIndex = 6;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarjeta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTarjeta_KeyDown);
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
            this.txtTarjeta.Leave += new System.EventHandler(this.txtTarjeta_Leave);
            // 
            // txtCambio
            // 
            this.txtCambio.BorderRadius = 8;
            this.txtCambio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCambio.DefaultText = "0.00";
            this.txtCambio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCambio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCambio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCambio.DisabledState.Parent = this.txtCambio;
            this.txtCambio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCambio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCambio.FocusedState.Parent = this.txtCambio;
            this.txtCambio.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCambio.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCambio.HoverState.Parent = this.txtCambio;
            this.txtCambio.Location = new System.Drawing.Point(142, 146);
            this.txtCambio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.PasswordChar = '\0';
            this.txtCambio.PlaceholderText = "";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.SelectedText = "";
            this.txtCambio.SelectionStart = 4;
            this.txtCambio.ShadowDecoration.Parent = this.txtCambio;
            this.txtCambio.Size = new System.Drawing.Size(235, 36);
            this.txtCambio.TabIndex = 7;
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.61225F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.65306F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.65306F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.081633F));
            this.tableLayoutPanel2.Controls.Add(this.iconCancelar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.iconAceptar, 1, 0);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(24, 337);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(396, 50);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // iconCancelar
            // 
            this.iconCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconCancelar.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.iconCancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCancelar.IconSize = 30;
            this.iconCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconCancelar.Location = new System.Drawing.Point(253, 3);
            this.iconCancelar.Name = "iconCancelar";
            this.iconCancelar.Padding = new System.Windows.Forms.Padding(5);
            this.iconCancelar.Size = new System.Drawing.Size(123, 44);
            this.iconCancelar.TabIndex = 2;
            this.iconCancelar.Text = "Cancelar";
            this.iconCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.iconCancelar, "Cerrar ventana");
            this.iconCancelar.UseVisualStyleBackColor = true;
            this.iconCancelar.Click += new System.EventHandler(this.iconCancelar_Click);
            // 
            // iconAceptar
            // 
            this.iconAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconAceptar.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconAceptar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconAceptar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconAceptar.IconSize = 30;
            this.iconAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconAceptar.Location = new System.Drawing.Point(124, 3);
            this.iconAceptar.Name = "iconAceptar";
            this.iconAceptar.Padding = new System.Windows.Forms.Padding(5);
            this.iconAceptar.Size = new System.Drawing.Size(123, 44);
            this.iconAceptar.TabIndex = 0;
            this.iconAceptar.Text = "Aceptar";
            this.iconAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.iconAceptar, "Imprimir recibo");
            this.iconAceptar.UseVisualStyleBackColor = true;
            this.iconAceptar.Click += new System.EventHandler(this.iconAceptar_Click);
            // 
            // frmTerminarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 423);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.chkTarjeta);
            this.Controls.Add(this.chkEfectivo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmTerminarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTerminarPedido";
            this.Load += new System.EventHandler(this.frmTerminarPedido_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkTarjeta;
        private System.Windows.Forms.CheckBox chkEfectivo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalVenta;
        private Guna.UI2.WinForms.Guna2TextBox txtEfectivo;
        private Guna.UI2.WinForms.Guna2TextBox txtTarjeta;
        private Guna.UI2.WinForms.Guna2TextBox txtCambio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton iconCancelar;
        private FontAwesome.Sharp.IconButton iconAceptar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}