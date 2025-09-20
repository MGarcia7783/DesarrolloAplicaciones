namespace Sistema.UI.Formularios
{
    partial class frmPedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconCerrar = new System.Windows.Forms.PictureBox();
            this.iconImprimir = new System.Windows.Forms.PictureBox();
            this.iconGuardar = new System.Windows.Forms.PictureBox();
            this.iconNuevo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.gunaCarrito = new Guna.UI2.WinForms.Guna2GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.dgvDetalle = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.gunaProducto = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblGrabaImpuesto = new System.Windows.Forms.Label();
            this.lblRecetaNumero = new System.Windows.Forms.Label();
            this.lblPrecioNumero = new System.Windows.Forms.Label();
            this.lblReceta = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.gunaCarrito.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.gunaProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(131)))), ((int)(((byte)(142)))));
            this.panel1.Controls.Add(this.iconCerrar);
            this.panel1.Controls.Add(this.iconImprimir);
            this.panel1.Controls.Add(this.iconGuardar);
            this.panel1.Controls.Add(this.iconNuevo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 96);
            this.panel1.TabIndex = 0;
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
            // iconImprimir
            // 
            this.iconImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconImprimir.Enabled = false;
            this.iconImprimir.Image = global::Sistema.UI.Properties.Resources.icon_print_48;
            this.iconImprimir.Location = new System.Drawing.Point(1148, 22);
            this.iconImprimir.Name = "iconImprimir";
            this.iconImprimir.Size = new System.Drawing.Size(52, 52);
            this.iconImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconImprimir.TabIndex = 5;
            this.iconImprimir.TabStop = false;
            this.toolTip1.SetToolTip(this.iconImprimir, "Imprimir factura");
            this.iconImprimir.Click += new System.EventHandler(this.iconImprimir_Click);
            // 
            // iconGuardar
            // 
            this.iconGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconGuardar.Enabled = false;
            this.iconGuardar.Image = global::Sistema.UI.Properties.Resources.icon_save_48;
            this.iconGuardar.Location = new System.Drawing.Point(1066, 22);
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
            this.iconNuevo.Location = new System.Drawing.Point(983, 22);
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
            this.label1.Size = new System.Drawing.Size(219, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Facturación / Boletas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(14, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(390, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Ventana de Atención al Cliente";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
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
            this.gunaCarrito.Location = new System.Drawing.Point(19, 111);
            this.gunaCarrito.Name = "gunaCarrito";
            this.gunaCarrito.ShadowDecoration.Parent = this.gunaCarrito;
            this.gunaCarrito.Size = new System.Drawing.Size(768, 655);
            this.gunaCarrito.TabIndex = 1;
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
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalle.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalle.Location = new System.Drawing.Point(19, 22);
            this.dgvDetalle.Name = "dgvDetalle";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.dgvDetalle;
            // 
            // gunaProducto
            // 
            this.gunaProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaProducto.BorderRadius = 8;
            this.gunaProducto.Controls.Add(this.lblStockTitulo);
            this.gunaProducto.Controls.Add(this.lblId);
            this.gunaProducto.Controls.Add(this.lblStock);
            this.gunaProducto.Controls.Add(this.lblGrabaImpuesto);
            this.gunaProducto.Controls.Add(this.lblRecetaNumero);
            this.gunaProducto.Controls.Add(this.lblPrecioNumero);
            this.gunaProducto.Controls.Add(this.lblReceta);
            this.gunaProducto.Controls.Add(this.lblPrecio);
            this.gunaProducto.Controls.Add(this.lblProducto);
            this.gunaProducto.Controls.Add(this.lblDetalle);
            this.gunaProducto.Controls.Add(this.txtBuscar);
            this.gunaProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gunaProducto.Location = new System.Drawing.Point(829, 111);
            this.gunaProducto.Name = "gunaProducto";
            this.gunaProducto.ShadowDecoration.Parent = this.gunaProducto;
            this.gunaProducto.Size = new System.Drawing.Size(450, 655);
            this.gunaProducto.TabIndex = 2;
            this.gunaProducto.Text = "Buscar Productos";
            // 
            // lblStockTitulo
            // 
            this.lblStockTitulo.AutoSize = true;
            this.lblStockTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStockTitulo.Location = new System.Drawing.Point(30, 425);
            this.lblStockTitulo.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblStockTitulo.Name = "lblStockTitulo";
            this.lblStockTitulo.Size = new System.Drawing.Size(126, 32);
            this.lblStockTitulo.TabIndex = 10;
            this.lblStockTitulo.Text = "Existencia:";
            this.lblStockTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStockTitulo.Visible = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblId.Location = new System.Drawing.Point(30, 533);
            this.lblId.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 32);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "0";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblId.Visible = false;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblStock.Location = new System.Drawing.Point(162, 425);
            this.lblStock.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(27, 32);
            this.lblStock.TabIndex = 8;
            this.lblStock.Text = "0";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStock.Visible = false;
            // 
            // lblGrabaImpuesto
            // 
            this.lblGrabaImpuesto.AutoSize = true;
            this.lblGrabaImpuesto.BackColor = System.Drawing.Color.Transparent;
            this.lblGrabaImpuesto.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrabaImpuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGrabaImpuesto.Location = new System.Drawing.Point(31, 579);
            this.lblGrabaImpuesto.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblGrabaImpuesto.Name = "lblGrabaImpuesto";
            this.lblGrabaImpuesto.Size = new System.Drawing.Size(26, 32);
            this.lblGrabaImpuesto.TabIndex = 7;
            this.lblGrabaImpuesto.Text = "E";
            this.lblGrabaImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGrabaImpuesto.Visible = false;
            // 
            // lblRecetaNumero
            // 
            this.lblRecetaNumero.AutoSize = true;
            this.lblRecetaNumero.BackColor = System.Drawing.Color.Transparent;
            this.lblRecetaNumero.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecetaNumero.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblRecetaNumero.Location = new System.Drawing.Point(238, 371);
            this.lblRecetaNumero.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblRecetaNumero.Name = "lblRecetaNumero";
            this.lblRecetaNumero.Size = new System.Drawing.Size(27, 32);
            this.lblRecetaNumero.TabIndex = 6;
            this.lblRecetaNumero.Text = "0";
            this.lblRecetaNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRecetaNumero.Visible = false;
            // 
            // lblPrecioNumero
            // 
            this.lblPrecioNumero.AutoSize = true;
            this.lblPrecioNumero.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecioNumero.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioNumero.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPrecioNumero.Location = new System.Drawing.Point(122, 322);
            this.lblPrecioNumero.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblPrecioNumero.Name = "lblPrecioNumero";
            this.lblPrecioNumero.Size = new System.Drawing.Size(27, 32);
            this.lblPrecioNumero.TabIndex = 5;
            this.lblPrecioNumero.Text = "0";
            this.lblPrecioNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrecioNumero.Visible = false;
            // 
            // lblReceta
            // 
            this.lblReceta.AutoSize = true;
            this.lblReceta.BackColor = System.Drawing.Color.Transparent;
            this.lblReceta.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReceta.Location = new System.Drawing.Point(29, 371);
            this.lblReceta.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblReceta.Name = "lblReceta";
            this.lblReceta.Size = new System.Drawing.Size(203, 32);
            this.lblReceta.TabIndex = 4;
            this.lblReceta.Text = "Venta con receta:";
            this.lblReceta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReceta.Visible = false;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecio.Location = new System.Drawing.Point(29, 322);
            this.lblPrecio.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(87, 32);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "Precio:";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrecio.Visible = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProducto.Location = new System.Drawing.Point(29, 192);
            this.lblProducto.MaximumSize = new System.Drawing.Size(380, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(130, 37);
            this.lblProducto.TabIndex = 2;
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
            this.lblDetalle.Location = new System.Drawing.Point(29, 136);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(97, 32);
            this.lblDetalle.TabIndex = 1;
            this.lblDetalle.Text = "Detalle:";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle.Visible = false;
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
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1300, 788);
            this.Controls.Add(this.gunaProducto);
            this.Controls.Add(this.gunaCarrito);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPedidos";
            this.Text = "frmPedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.Shown += new System.EventHandler(this.frmPedidos_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPedidos_KeyDown);
            this.Resize += new System.EventHandler(this.frmPedidos_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.gunaCarrito.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.gunaProducto.ResumeLayout(false);
            this.gunaProducto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox iconImprimir;
        public System.Windows.Forms.PictureBox iconGuardar;
        public System.Windows.Forms.PictureBox iconNuevo;
        public System.Windows.Forms.PictureBox iconCerrar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private Guna.UI2.WinForms.Guna2GroupBox gunaCarrito;
        public Guna.UI2.WinForms.Guna2DataGridView dgvDetalle;
        private Klik.Windows.Forms.v1.EntryLib.ELDivider elDivider1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GroupBox gunaProducto;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblRecetaNumero;
        private System.Windows.Forms.Label lblPrecioNumero;
        private System.Windows.Forms.Label lblReceta;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblGrabaImpuesto;
        private System.Windows.Forms.Label lblStockTitulo;
    }
}