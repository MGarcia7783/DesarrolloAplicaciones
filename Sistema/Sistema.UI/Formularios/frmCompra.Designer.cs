namespace Sistema.UI.Formularios
{
    partial class frmCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetalle = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaCarrito = new Guna.UI2.WinForms.Guna2GroupBox();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.iconCerrar = new System.Windows.Forms.PictureBox();
            this.iconGuardar = new System.Windows.Forms.PictureBox();
            this.iconNuevo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gunaDetalleCompra = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtObservacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFacturaCompra = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpFechaCompra = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.gunaProducto = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblGrabaImpuesto = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.lblPrecioTitulo = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            this.gunaCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNuevo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gunaDetalleCompra.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gunaProducto.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetalle.ColumnHeadersHeight = 35;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.Location = new System.Drawing.Point(19, 22);
            this.dgvDetalle.Name = "dgvDetalle";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowTemplate.Height = 35;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(733, 405);
            this.dgvDetalle.TabIndex = 2;
            this.dgvDetalle.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetalle.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetalle.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetalle.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalle.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetalle.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvDetalle.ThemeStyle.ReadOnly = false;
            this.dgvDetalle.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalle.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvDetalle.ThemeStyle.RowsStyle.Height = 35;
            this.dgvDetalle.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            this.dgvDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalle_EditingControlShowing);
            this.dgvDetalle.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDetalle_UserDeletedRow);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotal.Location = new System.Drawing.Point(290, 99);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(431, 54);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImpuesto.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImpuesto.Location = new System.Drawing.Point(291, 53);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(426, 33);
            this.lblImpuesto.TabIndex = 4;
            this.lblImpuesto.Text = "0.00";
            this.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubtotal.Location = new System.Drawing.Point(291, 5);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(426, 33);
            this.lblSubtotal.TabIndex = 3;
            this.lblSubtotal.Text = "0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 59);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.dgvDetalle;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(24, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 38);
            this.label3.TabIndex = 1;
            this.label3.Text = "Impuesto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(24, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Subtotal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblImpuesto);
            this.panel2.Controls.Add(this.lblSubtotal);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(19, 480);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 162);
            this.panel2.TabIndex = 4;
            // 
            // gunaCarrito
            // 
            this.gunaCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaCarrito.BackColor = System.Drawing.Color.Transparent;
            this.gunaCarrito.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaCarrito.BorderRadius = 8;
            this.gunaCarrito.Controls.Add(this.panel2);
            this.gunaCarrito.Controls.Add(this.elDivider1);
            this.gunaCarrito.Controls.Add(this.dgvDetalle);
            this.gunaCarrito.CustomBorderColor = System.Drawing.Color.Transparent;
            this.gunaCarrito.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunaCarrito.Location = new System.Drawing.Point(19, 123);
            this.gunaCarrito.Name = "gunaCarrito";
            this.gunaCarrito.ShadowDecoration.Parent = this.gunaCarrito;
            this.gunaCarrito.Size = new System.Drawing.Size(768, 655);
            this.gunaCarrito.TabIndex = 4;
            // 
            // elDivider1
            // 
            this.elDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.elDivider1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(93)))));
            this.elDivider1.LineSize = 4;
            this.elDivider1.Location = new System.Drawing.Point(19, 453);
            this.elDivider1.Name = "elDivider1";
            this.elDivider1.Size = new System.Drawing.Size(733, 23);
            this.elDivider1.TabIndex = 3;
            this.elDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // iconCerrar
            // 
            this.iconCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCerrar.Image = global::Sistema.UI.Properties.Resources.icon_salida_48;
            this.iconCerrar.Location = new System.Drawing.Point(1227, 22);
            this.iconCerrar.Name = "iconCerrar";
            this.iconCerrar.Size = new System.Drawing.Size(52, 52);
            this.iconCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconCerrar.TabIndex = 6;
            this.iconCerrar.TabStop = false;
            this.toolTip1.SetToolTip(this.iconCerrar, "Cerrar venatna");
            this.iconCerrar.Click += new System.EventHandler(this.iconCerrar_Click);
            // 
            // iconGuardar
            // 
            this.iconGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconGuardar.Enabled = false;
            this.iconGuardar.Image = global::Sistema.UI.Properties.Resources.icon_save_48;
            this.iconGuardar.Location = new System.Drawing.Point(1148, 22);
            this.iconGuardar.Name = "iconGuardar";
            this.iconGuardar.Size = new System.Drawing.Size(52, 52);
            this.iconGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconGuardar.TabIndex = 4;
            this.iconGuardar.TabStop = false;
            this.toolTip1.SetToolTip(this.iconGuardar, "Guardar registro");
            this.iconGuardar.Click += new System.EventHandler(this.iconGuardar_Click);
            // 
            // iconNuevo
            // 
            this.iconNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconNuevo.Enabled = false;
            this.iconNuevo.Image = global::Sistema.UI.Properties.Resources.icon_add_50;
            this.iconNuevo.Location = new System.Drawing.Point(1066, 22);
            this.iconNuevo.Name = "iconNuevo";
            this.iconNuevo.Size = new System.Drawing.Size(52, 52);
            this.iconNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconNuevo.TabIndex = 3;
            this.iconNuevo.TabStop = false;
            this.toolTip1.SetToolTip(this.iconNuevo, "Nuevo registro");
            this.iconNuevo.Click += new System.EventHandler(this.iconNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entrada de Productos";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(14, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(493, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Ventana de Actualización de Inventario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(131)))), ((int)(((byte)(142)))));
            this.panel1.Controls.Add(this.iconCerrar);
            this.panel1.Controls.Add(this.iconGuardar);
            this.panel1.Controls.Add(this.iconNuevo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 96);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.gunaDetalleCompra);
            this.panel3.Location = new System.Drawing.Point(829, 499);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 279);
            this.panel3.TabIndex = 6;
            // 
            // gunaDetalleCompra
            // 
            this.gunaDetalleCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaDetalleCompra.BorderColor = System.Drawing.Color.White;
            this.gunaDetalleCompra.BorderRadius = 8;
            this.gunaDetalleCompra.Controls.Add(this.txtObservacion);
            this.gunaDetalleCompra.Controls.Add(this.txtFacturaCompra);
            this.gunaDetalleCompra.Controls.Add(this.dtpFechaCompra);
            this.gunaDetalleCompra.Controls.Add(this.label7);
            this.gunaDetalleCompra.Controls.Add(this.label6);
            this.gunaDetalleCompra.Controls.Add(this.label5);
            this.gunaDetalleCompra.CustomBorderColor = System.Drawing.Color.White;
            this.gunaDetalleCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDetalleCompra.ForeColor = System.Drawing.Color.Transparent;
            this.gunaDetalleCompra.Location = new System.Drawing.Point(0, -6);
            this.gunaDetalleCompra.Name = "gunaDetalleCompra";
            this.gunaDetalleCompra.ShadowDecoration.Parent = this.gunaDetalleCompra;
            this.gunaDetalleCompra.Size = new System.Drawing.Size(450, 290);
            this.gunaDetalleCompra.TabIndex = 12;
            this.gunaDetalleCompra.Text = "Buscar Productos";
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.Transparent;
            this.txtObservacion.BorderRadius = 8;
            this.txtObservacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservacion.DefaultText = "";
            this.txtObservacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.DisabledState.Parent = this.txtObservacion;
            this.txtObservacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.FocusedState.Parent = this.txtObservacion;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.HoverState.Parent = this.txtObservacion;
            this.txtObservacion.Location = new System.Drawing.Point(29, 207);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.PlaceholderText = "";
            this.txtObservacion.SelectedText = "";
            this.txtObservacion.ShadowDecoration.Parent = this.txtObservacion;
            this.txtObservacion.Size = new System.Drawing.Size(385, 65);
            this.txtObservacion.TabIndex = 7;
            // 
            // txtFacturaCompra
            // 
            this.txtFacturaCompra.BackColor = System.Drawing.Color.Transparent;
            this.txtFacturaCompra.BorderRadius = 8;
            this.txtFacturaCompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFacturaCompra.DefaultText = "";
            this.txtFacturaCompra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFacturaCompra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFacturaCompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFacturaCompra.DisabledState.Parent = this.txtFacturaCompra;
            this.txtFacturaCompra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFacturaCompra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFacturaCompra.FocusedState.Parent = this.txtFacturaCompra;
            this.txtFacturaCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacturaCompra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFacturaCompra.HoverState.Parent = this.txtFacturaCompra;
            this.txtFacturaCompra.Location = new System.Drawing.Point(29, 129);
            this.txtFacturaCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFacturaCompra.Name = "txtFacturaCompra";
            this.txtFacturaCompra.PasswordChar = '\0';
            this.txtFacturaCompra.PlaceholderText = "";
            this.txtFacturaCompra.SelectedText = "";
            this.txtFacturaCompra.ShadowDecoration.Parent = this.txtFacturaCompra;
            this.txtFacturaCompra.Size = new System.Drawing.Size(320, 35);
            this.txtFacturaCompra.TabIndex = 6;
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.BackColor = System.Drawing.Color.Transparent;
            this.dtpFechaCompra.BorderRadius = 6;
            this.dtpFechaCompra.CheckedState.Parent = this.dtpFechaCompra;
            this.dtpFechaCompra.FillColor = System.Drawing.Color.WhiteSmoke;
            this.dtpFechaCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaCompra.HoverState.Parent = this.dtpFechaCompra;
            this.dtpFechaCompra.Location = new System.Drawing.Point(29, 50);
            this.dtpFechaCompra.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaCompra.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.ShadowDecoration.Parent = this.dtpFechaCompra;
            this.dtpFechaCompra.Size = new System.Drawing.Size(320, 36);
            this.dtpFechaCompra.TabIndex = 5;
            this.dtpFechaCompra.Value = new System.DateTime(2025, 9, 21, 6, 35, 32, 738);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(29, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Observación";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(29, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Factura de compra";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(29, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha de compra";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.panel3;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.gunaProducto);
            this.panel4.Location = new System.Drawing.Point(829, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 353);
            this.panel4.TabIndex = 7;
            // 
            // gunaProducto
            // 
            this.gunaProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaProducto.BorderRadius = 8;
            this.gunaProducto.Controls.Add(this.panel6);
            this.gunaProducto.Controls.Add(this.panel5);
            this.gunaProducto.Controls.Add(this.lblId);
            this.gunaProducto.Controls.Add(this.lblGrabaImpuesto);
            this.gunaProducto.Controls.Add(this.lblPrecioVenta);
            this.gunaProducto.Controls.Add(this.txtBuscar);
            this.gunaProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunaProducto.Location = new System.Drawing.Point(0, 1);
            this.gunaProducto.Name = "gunaProducto";
            this.gunaProducto.ShadowDecoration.Parent = this.gunaProducto;
            this.gunaProducto.Size = new System.Drawing.Size(450, 350);
            this.gunaProducto.TabIndex = 6;
            this.gunaProducto.Text = "Buscar Productos";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblId.Location = new System.Drawing.Point(374, 195);
            this.lblId.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 32);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "0";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblId.Visible = false;
            // 
            // lblGrabaImpuesto
            // 
            this.lblGrabaImpuesto.AutoSize = true;
            this.lblGrabaImpuesto.BackColor = System.Drawing.Color.Transparent;
            this.lblGrabaImpuesto.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrabaImpuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGrabaImpuesto.Location = new System.Drawing.Point(407, 195);
            this.lblGrabaImpuesto.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblGrabaImpuesto.Name = "lblGrabaImpuesto";
            this.lblGrabaImpuesto.Size = new System.Drawing.Size(26, 32);
            this.lblGrabaImpuesto.TabIndex = 7;
            this.lblGrabaImpuesto.Text = "E";
            this.lblGrabaImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGrabaImpuesto.Visible = false;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPrecioVenta.Location = new System.Drawing.Point(344, 195);
            this.lblPrecioVenta.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(27, 32);
            this.lblPrecioVenta.TabIndex = 6;
            this.lblPrecioVenta.Text = "0";
            this.lblPrecioVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrecioVenta.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.Transparent;
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.Parent = this.txtBuscar;
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.FocusedState.Parent = this.txtBuscar;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.HoverState.Parent = this.txtBuscar;
            this.txtBuscar.IconLeft = global::Sistema.UI.Properties.Resources.icons8_search_24;
            this.txtBuscar.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtBuscar.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtBuscar.Location = new System.Drawing.Point(29, 57);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderText = "Digite el código";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            this.txtBuscar.Size = new System.Drawing.Size(390, 36);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.IconLeftClick += new System.EventHandler(this.txtBuscar_IconLeftClick);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 15;
            this.guna2Elipse3.TargetControl = this.panel4;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.lblStockTitulo);
            this.panel5.Controls.Add(this.lblStock);
            this.panel5.Controls.Add(this.lblPrecioCompra);
            this.panel5.Controls.Add(this.lblPrecioTitulo);
            this.panel5.Location = new System.Drawing.Point(15, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(418, 100);
            this.panel5.TabIndex = 10;
            // 
            // lblStockTitulo
            // 
            this.lblStockTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStockTitulo.AutoSize = true;
            this.lblStockTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStockTitulo.Location = new System.Drawing.Point(15, 13);
            this.lblStockTitulo.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblStockTitulo.Name = "lblStockTitulo";
            this.lblStockTitulo.Size = new System.Drawing.Size(126, 32);
            this.lblStockTitulo.TabIndex = 14;
            this.lblStockTitulo.Text = "Existencia:";
            this.lblStockTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStockTitulo.Visible = false;
            // 
            // lblStock
            // 
            this.lblStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStock.AutoSize = true;
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblStock.Location = new System.Drawing.Point(147, 13);
            this.lblStock.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(27, 32);
            this.lblStock.TabIndex = 13;
            this.lblStock.Text = "0";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStock.Visible = false;
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCompra.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPrecioCompra.Location = new System.Drawing.Point(231, 58);
            this.lblPrecioCompra.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(27, 32);
            this.lblPrecioCompra.TabIndex = 12;
            this.lblPrecioCompra.Text = "0";
            this.lblPrecioCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrecioCompra.Visible = false;
            // 
            // lblPrecioTitulo
            // 
            this.lblPrecioTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrecioTitulo.AutoSize = true;
            this.lblPrecioTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecioTitulo.Location = new System.Drawing.Point(15, 58);
            this.lblPrecioTitulo.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblPrecioTitulo.Name = "lblPrecioTitulo";
            this.lblPrecioTitulo.Size = new System.Drawing.Size(210, 32);
            this.lblPrecioTitulo.TabIndex = 11;
            this.lblPrecioTitulo.Text = "Precio de compra:";
            this.lblPrecioTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrecioTitulo.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.lblProducto);
            this.panel6.Controls.Add(this.lblDetalle);
            this.panel6.Location = new System.Drawing.Point(15, 101);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(418, 100);
            this.panel6.TabIndex = 11;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProducto.Location = new System.Drawing.Point(15, 49);
            this.lblProducto.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(130, 37);
            this.lblProducto.TabIndex = 4;
            this.lblProducto.Text = "Producto";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProducto.Visible = false;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDetalle.Location = new System.Drawing.Point(15, 11);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(97, 32);
            this.lblDetalle.TabIndex = 3;
            this.lblDetalle.Text = "Detalle:";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle.Visible = false;
            // 
            // frmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 791);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.gunaCarrito);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCompra";
            this.Text = "frmCompra";
            this.Load += new System.EventHandler(this.frmCompra_Load);
            this.Shown += new System.EventHandler(this.frmCompra_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCompra_KeyDown);
            this.Resize += new System.EventHandler(this.frmCompra_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gunaCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNuevo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gunaDetalleCompra.ResumeLayout(false);
            this.gunaDetalleCompra.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.gunaProducto.ResumeLayout(false);
            this.gunaProducto.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2GroupBox gunaCarrito;
        private Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox iconCerrar;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.PictureBox iconGuardar;
        public System.Windows.Forms.PictureBox iconNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2GroupBox gunaDetalleCompra;
        private Guna.UI2.WinForms.Guna2TextBox txtObservacion;
        private Guna.UI2.WinForms.Guna2TextBox txtFacturaCompra;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2GroupBox gunaProducto;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblGrabaImpuesto;
        private System.Windows.Forms.Label lblPrecioVenta;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblStockTitulo;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.Label lblPrecioTitulo;
    }
}