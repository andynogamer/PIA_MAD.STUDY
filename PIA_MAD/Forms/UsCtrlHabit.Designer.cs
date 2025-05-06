namespace PIA_MAD.Forms
{
    partial class UsCtrlHabit
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
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbHoteles = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTiposHab = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TipHabitacion = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.NumHabitacion = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Cantidad = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Caracterisiticas = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.siticoneAnimateWindow1 = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(this.components);
            this.siticoneButton2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.Habitaciones = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.siticoneButton3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.Estatus = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.siticonePanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 21);
            this.label4.TabIndex = 59;
            this.label4.Text = "Tipo de Habitación";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(505, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 21);
            this.label9.TabIndex = 33;
            this.label9.Text = "Hotel";
            // 
            // cmbHoteles
            // 
            this.cmbHoteles.BackColor = System.Drawing.Color.Transparent;
            this.cmbHoteles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoteles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHoteles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHoteles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHoteles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbHoteles.ItemHeight = 30;
            this.cmbHoteles.Location = new System.Drawing.Point(581, 16);
            this.cmbHoteles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbHoteles.Name = "cmbHoteles";
            this.cmbHoteles.Size = new System.Drawing.Size(459, 36);
            this.cmbHoteles.TabIndex = 1;
            this.cmbHoteles.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "HABITACIONES";
            // 
            // cmbTiposHab
            // 
            this.cmbTiposHab.BackColor = System.Drawing.Color.Transparent;
            this.cmbTiposHab.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTiposHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiposHab.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTiposHab.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTiposHab.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTiposHab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTiposHab.ItemHeight = 30;
            this.cmbTiposHab.Location = new System.Drawing.Point(465, 108);
            this.cmbTiposHab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTiposHab.Name = "cmbTiposHab";
            this.cmbTiposHab.Size = new System.Drawing.Size(459, 36);
            this.cmbTiposHab.TabIndex = 58;
            this.cmbTiposHab.SelectedIndexChanged += new System.EventHandler(this.cmbTiposHab_SelectedIndexChanged);
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
            this.siticoneButton1.Location = new System.Drawing.Point(868, 0);
            this.siticoneButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.Size = new System.Drawing.Size(240, 74);
            this.siticoneButton1.TabIndex = 0;
            this.siticoneButton1.Text = "GUARDAR";
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.Controls.Add(this.siticoneButton1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 577);
            this.siticonePanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.Size = new System.Drawing.Size(1108, 74);
            this.siticonePanel1.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbHoteles);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 74);
            this.panel1.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 428);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 48;
            this.label2.Text = "No. Habitación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 485);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 21);
            this.label3.TabIndex = 50;
            this.label3.Text = "Tipo de Habitación";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(499, 429);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 52;
            this.label5.Text = "Estatus";
            // 
            // TipHabitacion
            // 
            this.TipHabitacion.BackColor = System.Drawing.Color.Transparent;
            this.TipHabitacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TipHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipHabitacion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TipHabitacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TipHabitacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TipHabitacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.TipHabitacion.ItemHeight = 30;
            this.TipHabitacion.Location = new System.Drawing.Point(199, 474);
            this.TipHabitacion.Margin = new System.Windows.Forms.Padding(4);
            this.TipHabitacion.Name = "TipHabitacion";
            this.TipHabitacion.Size = new System.Drawing.Size(288, 36);
            this.TipHabitacion.TabIndex = 63;
            this.TipHabitacion.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox3_SelectedIndexChanged);
            // 
            // NumHabitacion
            // 
            this.NumHabitacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NumHabitacion.DefaultText = "";
            this.NumHabitacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NumHabitacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NumHabitacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NumHabitacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NumHabitacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NumHabitacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NumHabitacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NumHabitacion.Location = new System.Drawing.Point(165, 182);
            this.NumHabitacion.Margin = new System.Windows.Forms.Padding(4);
            this.NumHabitacion.Name = "NumHabitacion";
            this.NumHabitacion.PasswordChar = '\0';
            this.NumHabitacion.PlaceholderText = "";
            this.NumHabitacion.SelectedText = "";
            this.NumHabitacion.Size = new System.Drawing.Size(99, 44);
            this.NumHabitacion.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 21);
            this.label6.TabIndex = 65;
            this.label6.Text = "No. Habitación";
            // 
            // Cantidad
            // 
            this.Cantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Cantidad.DefaultText = "";
            this.Cantidad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Cantidad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Cantidad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Cantidad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Cantidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Cantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Cantidad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Cantidad.Location = new System.Drawing.Point(465, 182);
            this.Cantidad.Margin = new System.Windows.Forms.Padding(4);
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.PasswordChar = '\0';
            this.Cantidad.PlaceholderText = "";
            this.Cantidad.SelectedText = "";
            this.Cantidad.Size = new System.Drawing.Size(99, 44);
            this.Cantidad.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(284, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 21);
            this.label7.TabIndex = 67;
            this.label7.Text = "Cantidad a registrar";
            // 
            // Caracterisiticas
            // 
            this.Caracterisiticas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Caracterisiticas.DefaultText = "";
            this.Caracterisiticas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Caracterisiticas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Caracterisiticas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Caracterisiticas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Caracterisiticas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Caracterisiticas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Caracterisiticas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Caracterisiticas.Location = new System.Drawing.Point(165, 259);
            this.Caracterisiticas.Margin = new System.Windows.Forms.Padding(4);
            this.Caracterisiticas.Name = "Caracterisiticas";
            this.Caracterisiticas.PasswordChar = '\0';
            this.Caracterisiticas.PlaceholderText = "";
            this.Caracterisiticas.SelectedText = "";
            this.Caracterisiticas.Size = new System.Drawing.Size(289, 44);
            this.Caracterisiticas.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 272);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 21);
            this.label10.TabIndex = 70;
            this.label10.Text = "Caracteristicas";
            // 
            // siticoneButton2
            // 
            this.siticoneButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.siticoneButton2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.siticoneButton2.ForeColor = System.Drawing.Color.White;
            this.siticoneButton2.Location = new System.Drawing.Point(913, 417);
            this.siticoneButton2.Margin = new System.Windows.Forms.Padding(4);
            this.siticoneButton2.Name = "siticoneButton2";
            this.siticoneButton2.Size = new System.Drawing.Size(161, 55);
            this.siticoneButton2.TabIndex = 72;
            this.siticoneButton2.Text = "Actualizar";
            this.siticoneButton2.Click += new System.EventHandler(this.siticoneButton2_Click);
            // 
            // Habitaciones
            // 
            this.Habitaciones.BackColor = System.Drawing.Color.Transparent;
            this.Habitaciones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Habitaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Habitaciones.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Habitaciones.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Habitaciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Habitaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Habitaciones.ItemHeight = 30;
            this.Habitaciones.Location = new System.Drawing.Point(165, 417);
            this.Habitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.Habitaciones.Name = "Habitaciones";
            this.Habitaciones.Size = new System.Drawing.Size(288, 36);
            this.Habitaciones.TabIndex = 73;
            this.Habitaciones.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox5_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(353, 16);
            this.label11.TabIndex = 74;
            this.label11.Text = "*Las habitaciones se registraran con el estatus disponible.";
            // 
            // siticoneButton3
            // 
            this.siticoneButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.siticoneButton3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.siticoneButton3.ForeColor = System.Drawing.Color.White;
            this.siticoneButton3.Location = new System.Drawing.Point(853, 259);
            this.siticoneButton3.Margin = new System.Windows.Forms.Padding(4);
            this.siticoneButton3.Name = "siticoneButton3";
            this.siticoneButton3.Size = new System.Drawing.Size(161, 55);
            this.siticoneButton3.TabIndex = 75;
            this.siticoneButton3.Text = "Guardar";
            this.siticoneButton3.Click += new System.EventHandler(this.siticoneButton3_Click);
            // 
            // Estatus
            // 
            this.Estatus.BackColor = System.Drawing.Color.Transparent;
            this.Estatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Estatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Estatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Estatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Estatus.ItemHeight = 30;
            this.Estatus.Items.AddRange(new object[] {
            "Disponible",
            "Ocupada",
            "Mantenimiento",
            "Reservada"});
            this.Estatus.Location = new System.Drawing.Point(581, 417);
            this.Estatus.Margin = new System.Windows.Forms.Padding(4);
            this.Estatus.Name = "Estatus";
            this.Estatus.Size = new System.Drawing.Size(288, 36);
            this.Estatus.TabIndex = 76;
            // 
            // UsCtrlHabit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Estatus);
            this.Controls.Add(this.siticoneButton3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Habitaciones);
            this.Controls.Add(this.siticoneButton2);
            this.Controls.Add(this.Caracterisiticas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NumHabitacion);
            this.Controls.Add(this.TipHabitacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTiposHab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UsCtrlHabit";
            this.Size = new System.Drawing.Size(1108, 651);
            this.Load += new System.EventHandler(this.UsCtrlHabit_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbHoteles;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbTiposHab;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox TipHabitacion;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox NumHabitacion;
        private System.Windows.Forms.Label label6;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Cantidad;
        private System.Windows.Forms.Label label7;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Caracterisiticas;
        private System.Windows.Forms.Label label10;
        private Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton2;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox Habitaciones;
        private System.Windows.Forms.Label label11;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton3;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox Estatus;
    }
}
