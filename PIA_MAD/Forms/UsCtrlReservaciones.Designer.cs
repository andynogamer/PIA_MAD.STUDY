namespace PIA_MAD.Forms
{
    partial class UsCtrlReservaciones
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label7 = new System.Windows.Forms.Label();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbFiltro = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.Busqueda = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.CiudadesDisponibles = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HotelesCiudad = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpHoy = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.dtpMañana = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.ClientesEncontrados = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.siticoneContextMenuStrip1 = new Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip();
            this.dgvHabitaciones = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.Reservarbtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.numericUpDownAnticipo = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.siticoneAnimateWindow1 = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(this.components);
            this.dgvHotelesDispo = new System.Windows.Forms.DataGridView();
            this.siticonePanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesEncontrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnticipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotelesDispo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "RESERVACIONES";
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.siticoneButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.siticoneButton1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.Location = new System.Drawing.Point(1082, 0);
            this.siticoneButton1.Margin = new System.Windows.Forms.Padding(4);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.Size = new System.Drawing.Size(240, 74);
            this.siticoneButton1.TabIndex = 0;
            this.siticoneButton1.Text = "GUARDAR";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 54;
            this.label7.Text = "Ciudad";
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.Controls.Add(this.siticoneButton1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 728);
            this.siticonePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.Size = new System.Drawing.Size(1322, 74);
            this.siticonePanel1.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbFiltro);
            this.panel1.Controls.Add(this.Busqueda);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1322, 74);
            this.panel1.TabIndex = 46;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cmbFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFiltro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbFiltro.ItemHeight = 30;
            this.cmbFiltro.Items.AddRange(new object[] {
            "RFC",
            "Correo",
            "Apellido"});
            this.cmbFiltro.Location = new System.Drawing.Point(966, 18);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(140, 36);
            this.cmbFiltro.TabIndex = 78;
            // 
            // Busqueda
            // 
            this.Busqueda.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Busqueda.DefaultText = "";
            this.Busqueda.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Busqueda.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Busqueda.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Busqueda.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Busqueda.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Busqueda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Busqueda.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Busqueda.Location = new System.Drawing.Point(390, 10);
            this.Busqueda.Name = "Busqueda";
            this.Busqueda.PasswordChar = '\0';
            this.Busqueda.PlaceholderText = "";
            this.Busqueda.SelectedText = "";
            this.Busqueda.Size = new System.Drawing.Size(528, 55);
            this.Busqueda.TabIndex = 77;
            this.Busqueda.TextChanged += new System.EventHandler(this.Busqueda_TextChanged);
            // 
            // CiudadesDisponibles
            // 
            this.CiudadesDisponibles.BackColor = System.Drawing.Color.Transparent;
            this.CiudadesDisponibles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CiudadesDisponibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CiudadesDisponibles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CiudadesDisponibles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CiudadesDisponibles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CiudadesDisponibles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CiudadesDisponibles.ItemHeight = 30;
            this.CiudadesDisponibles.Location = new System.Drawing.Point(144, 228);
            this.CiudadesDisponibles.Margin = new System.Windows.Forms.Padding(4);
            this.CiudadesDisponibles.Name = "CiudadesDisponibles";
            this.CiudadesDisponibles.Size = new System.Drawing.Size(288, 36);
            this.CiudadesDisponibles.TabIndex = 60;
            this.CiudadesDisponibles.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox5_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(665, 228);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 61;
            this.label4.Text = "Hotel";
            // 
            // HotelesCiudad
            // 
            this.HotelesCiudad.BackColor = System.Drawing.Color.Transparent;
            this.HotelesCiudad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HotelesCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HotelesCiudad.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.HotelesCiudad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.HotelesCiudad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.HotelesCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.HotelesCiudad.ItemHeight = 30;
            this.HotelesCiudad.Location = new System.Drawing.Point(669, 382);
            this.HotelesCiudad.Margin = new System.Windows.Forms.Padding(4);
            this.HotelesCiudad.Name = "HotelesCiudad";
            this.HotelesCiudad.Size = new System.Drawing.Size(582, 36);
            this.HotelesCiudad.TabIndex = 62;
            this.HotelesCiudad.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox6_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 345);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 65;
            this.label6.Text = "Fecha Fin ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 293);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 21);
            this.label8.TabIndex = 64;
            this.label8.Text = "Fecha Inicio";
            // 
            // dtpHoy
            // 
            this.dtpHoy.Checked = true;
            this.dtpHoy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHoy.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpHoy.Location = new System.Drawing.Point(143, 282);
            this.dtpHoy.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHoy.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHoy.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHoy.Name = "dtpHoy";
            this.dtpHoy.Size = new System.Drawing.Size(289, 44);
            this.dtpHoy.TabIndex = 68;
            this.dtpHoy.Value = new System.DateTime(2025, 4, 6, 12, 55, 39, 147);
            this.dtpHoy.ValueChanged += new System.EventHandler(this.siticoneDateTimePicker1_ValueChanged);
            // 
            // dtpMañana
            // 
            this.dtpMañana.Checked = true;
            this.dtpMañana.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpMañana.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpMañana.Location = new System.Drawing.Point(140, 334);
            this.dtpMañana.Margin = new System.Windows.Forms.Padding(4);
            this.dtpMañana.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpMañana.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpMañana.Name = "dtpMañana";
            this.dtpMañana.Size = new System.Drawing.Size(289, 44);
            this.dtpMañana.TabIndex = 69;
            this.dtpMañana.Value = new System.DateTime(2025, 4, 6, 12, 55, 41, 298);
            this.dtpMañana.ValueChanged += new System.EventHandler(this.siticoneDateTimePicker2_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 613);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 73;
            this.label10.Text = "Anticipo: ";
            // 
            // ClientesEncontrados
            // 
            this.ClientesEncontrados.AllowUserToAddRows = false;
            this.ClientesEncontrados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.ClientesEncontrados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientesEncontrados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ClientesEncontrados.ColumnHeadersHeight = 4;
            this.ClientesEncontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ClientesEncontrados.DefaultCellStyle = dataGridViewCellStyle9;
            this.ClientesEncontrados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ClientesEncontrados.Location = new System.Drawing.Point(113, 103);
            this.ClientesEncontrados.Name = "ClientesEncontrados";
            this.ClientesEncontrados.ReadOnly = true;
            this.ClientesEncontrados.RowHeadersVisible = false;
            this.ClientesEncontrados.RowHeadersWidth = 51;
            this.ClientesEncontrados.RowTemplate.Height = 24;
            this.ClientesEncontrados.Size = new System.Drawing.Size(901, 109);
            this.ClientesEncontrados.TabIndex = 78;
            this.ClientesEncontrados.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.ClientesEncontrados.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.ClientesEncontrados.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.ClientesEncontrados.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.ClientesEncontrados.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.ClientesEncontrados.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.ClientesEncontrados.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ClientesEncontrados.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ClientesEncontrados.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ClientesEncontrados.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesEncontrados.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.ClientesEncontrados.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ClientesEncontrados.ThemeStyle.HeaderStyle.Height = 4;
            this.ClientesEncontrados.ThemeStyle.ReadOnly = true;
            this.ClientesEncontrados.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.ClientesEncontrados.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ClientesEncontrados.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesEncontrados.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ClientesEncontrados.ThemeStyle.RowsStyle.Height = 24;
            this.ClientesEncontrados.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.ClientesEncontrados.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.ClientesEncontrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.siticoneDataGridView1_CellContentClick);
            // 
            // siticoneContextMenuStrip1
            // 
            this.siticoneContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.siticoneContextMenuStrip1.Name = "siticoneContextMenuStrip1";
            this.siticoneContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.ColorTable = null;
            this.siticoneContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.siticoneContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.siticoneContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.siticoneContextMenuStrip1_Opening);
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvHabitaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvHabitaciones.ColumnHeadersHeight = 4;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHabitaciones.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvHabitaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHabitaciones.Location = new System.Drawing.Point(17, 442);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.RowHeadersVisible = false;
            this.dgvHabitaciones.RowHeadersWidth = 51;
            this.dgvHabitaciones.RowTemplate.Height = 50;
            this.dgvHabitaciones.Size = new System.Drawing.Size(901, 142);
            this.dgvHabitaciones.TabIndex = 79;
            this.dgvHabitaciones.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHabitaciones.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHabitaciones.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHabitaciones.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHabitaciones.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHabitaciones.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHabitaciones.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHabitaciones.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHabitaciones.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHabitaciones.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHabitaciones.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHabitaciones.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHabitaciones.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvHabitaciones.ThemeStyle.ReadOnly = false;
            this.dgvHabitaciones.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHabitaciones.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHabitaciones.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHabitaciones.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHabitaciones.ThemeStyle.RowsStyle.Height = 50;
            this.dgvHabitaciones.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHabitaciones.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.siticoneDataGridView1_CellContentClick_1);
            // 
            // Reservarbtn
            // 
            this.Reservarbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Reservarbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Reservarbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Reservarbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Reservarbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Reservarbtn.ForeColor = System.Drawing.Color.White;
            this.Reservarbtn.Location = new System.Drawing.Point(834, 613);
            this.Reservarbtn.Name = "Reservarbtn";
            this.Reservarbtn.Size = new System.Drawing.Size(180, 45);
            this.Reservarbtn.TabIndex = 80;
            this.Reservarbtn.Text = "Reservar";
            this.Reservarbtn.Click += new System.EventHandler(this.Reservarbtn_Click);
            // 
            // numericUpDownAnticipo
            // 
            this.numericUpDownAnticipo.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDownAnticipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDownAnticipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownAnticipo.Location = new System.Drawing.Point(140, 610);
            this.numericUpDownAnticipo.Name = "numericUpDownAnticipo";
            this.numericUpDownAnticipo.Size = new System.Drawing.Size(100, 36);
            this.numericUpDownAnticipo.TabIndex = 81;
            this.numericUpDownAnticipo.ValueChanged += new System.EventHandler(this.siticoneNumericUpDown1_ValueChanged);
            // 
            // dgvHotelesDispo
            // 
            this.dgvHotelesDispo.AllowUserToAddRows = false;
            this.dgvHotelesDispo.AllowUserToDeleteRows = false;
            this.dgvHotelesDispo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHotelesDispo.Location = new System.Drawing.Point(552, 256);
            this.dgvHotelesDispo.Name = "dgvHotelesDispo";
            this.dgvHotelesDispo.ReadOnly = true;
            this.dgvHotelesDispo.RowHeadersWidth = 51;
            this.dgvHotelesDispo.RowTemplate.Height = 24;
            this.dgvHotelesDispo.Size = new System.Drawing.Size(699, 122);
            this.dgvHotelesDispo.TabIndex = 82;
            // 
            // UsCtrlReservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHotelesDispo);
            this.Controls.Add(this.numericUpDownAnticipo);
            this.Controls.Add(this.Reservarbtn);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.ClientesEncontrados);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpMañana);
            this.Controls.Add(this.dtpHoy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.HotelesCiudad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CiudadesDisponibles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UsCtrlReservaciones";
            this.Size = new System.Drawing.Size(1322, 802);
            this.Load += new System.EventHandler(this.UsCtrlReservaciones_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesEncontrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnticipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotelesDispo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private System.Windows.Forms.Label label7;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox CiudadesDisponibles;
        private System.Windows.Forms.Label label4;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox HotelesCiudad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker dtpHoy;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker dtpMañana;
        private System.Windows.Forms.Label label10;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView ClientesEncontrados;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Busqueda;
        private Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip siticoneContextMenuStrip1;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView dgvHabitaciones;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Reservarbtn;
        private Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown numericUpDownAnticipo;
        private Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbFiltro;
        private System.Windows.Forms.DataGridView dgvHotelesDispo;
    }
}
