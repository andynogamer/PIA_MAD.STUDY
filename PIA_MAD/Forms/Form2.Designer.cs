namespace PIA_MAD.Forms
{
    partial class Form2
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
            this.siticoneHtmlLabel1 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.siticoneHtmlLabel2 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.siticoneHtmlLabel3 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.siticoneHtmlLabel4 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.siticoneHtmlLabel5 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.cmbPais = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.cmdEstado = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.cmbMunicipio = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.cmbCiudad = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.cmbColonia = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.PaisText = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.EstadoText = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.CiudadText = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.MunicipioText = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.ColoniaText = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticoneButton2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticoneButton3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticoneButton4 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticoneButton5 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.SuspendLayout();
            // 
            // siticoneHtmlLabel1
            // 
            this.siticoneHtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneHtmlLabel1.Location = new System.Drawing.Point(38, 34);
            this.siticoneHtmlLabel1.Name = "siticoneHtmlLabel1";
            this.siticoneHtmlLabel1.Size = new System.Drawing.Size(30, 18);
            this.siticoneHtmlLabel1.TabIndex = 0;
            this.siticoneHtmlLabel1.Text = "Pais";
            // 
            // siticoneHtmlLabel2
            // 
            this.siticoneHtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneHtmlLabel2.Location = new System.Drawing.Point(38, 97);
            this.siticoneHtmlLabel2.Name = "siticoneHtmlLabel2";
            this.siticoneHtmlLabel2.Size = new System.Drawing.Size(46, 18);
            this.siticoneHtmlLabel2.TabIndex = 1;
            this.siticoneHtmlLabel2.Text = "Estado";
            // 
            // siticoneHtmlLabel3
            // 
            this.siticoneHtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneHtmlLabel3.Location = new System.Drawing.Point(38, 152);
            this.siticoneHtmlLabel3.Name = "siticoneHtmlLabel3";
            this.siticoneHtmlLabel3.Size = new System.Drawing.Size(46, 18);
            this.siticoneHtmlLabel3.TabIndex = 2;
            this.siticoneHtmlLabel3.Text = "Ciudad";
            // 
            // siticoneHtmlLabel4
            // 
            this.siticoneHtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneHtmlLabel4.Location = new System.Drawing.Point(38, 196);
            this.siticoneHtmlLabel4.Name = "siticoneHtmlLabel4";
            this.siticoneHtmlLabel4.Size = new System.Drawing.Size(60, 18);
            this.siticoneHtmlLabel4.TabIndex = 3;
            this.siticoneHtmlLabel4.Text = "Municipio";
            // 
            // siticoneHtmlLabel5
            // 
            this.siticoneHtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.siticoneHtmlLabel5.Location = new System.Drawing.Point(38, 251);
            this.siticoneHtmlLabel5.Name = "siticoneHtmlLabel5";
            this.siticoneHtmlLabel5.Size = new System.Drawing.Size(49, 18);
            this.siticoneHtmlLabel5.TabIndex = 4;
            this.siticoneHtmlLabel5.Text = "Colonia";
            // 
            // cmbPais
            // 
            this.cmbPais.BackColor = System.Drawing.Color.Transparent;
            this.cmbPais.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPais.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPais.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPais.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPais.ItemHeight = 30;
            this.cmbPais.Location = new System.Drawing.Point(134, 34);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(190, 36);
            this.cmbPais.TabIndex = 5;
            this.cmbPais.SelectedIndexChanged += new System.EventHandler(this.cmbPais_SelectedIndexChanged);
            // 
            // cmdEstado
            // 
            this.cmdEstado.BackColor = System.Drawing.Color.Transparent;
            this.cmdEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmdEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmdEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmdEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmdEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmdEstado.ItemHeight = 30;
            this.cmdEstado.Location = new System.Drawing.Point(134, 79);
            this.cmdEstado.Name = "cmdEstado";
            this.cmdEstado.Size = new System.Drawing.Size(190, 36);
            this.cmdEstado.TabIndex = 6;
            this.cmdEstado.SelectedIndexChanged += new System.EventHandler(this.cmdEstado_SelectedIndexChanged);
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.BackColor = System.Drawing.Color.Transparent;
            this.cmbMunicipio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMunicipio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMunicipio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMunicipio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMunicipio.ItemHeight = 30;
            this.cmbMunicipio.Location = new System.Drawing.Point(134, 179);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(190, 36);
            this.cmbMunicipio.TabIndex = 8;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.BackColor = System.Drawing.Color.Transparent;
            this.cmbCiudad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCiudad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCiudad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCiudad.ItemHeight = 30;
            this.cmbCiudad.Location = new System.Drawing.Point(134, 134);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(190, 36);
            this.cmbCiudad.TabIndex = 7;
            this.cmbCiudad.SelectedIndexChanged += new System.EventHandler(this.cmbCiudad_SelectedIndexChanged);
            // 
            // cmbColonia
            // 
            this.cmbColonia.BackColor = System.Drawing.Color.Transparent;
            this.cmbColonia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColonia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbColonia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbColonia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbColonia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbColonia.ItemHeight = 30;
            this.cmbColonia.Location = new System.Drawing.Point(134, 233);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(190, 36);
            this.cmbColonia.TabIndex = 9;
            this.cmbColonia.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox5_SelectedIndexChanged);
            // 
            // PaisText
            // 
            this.PaisText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PaisText.DefaultText = "";
            this.PaisText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PaisText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PaisText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PaisText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PaisText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PaisText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PaisText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PaisText.Location = new System.Drawing.Point(375, 33);
            this.PaisText.Name = "PaisText";
            this.PaisText.PasswordChar = '\0';
            this.PaisText.PlaceholderText = "";
            this.PaisText.SelectedText = "";
            this.PaisText.Size = new System.Drawing.Size(200, 36);
            this.PaisText.TabIndex = 10;
            // 
            // EstadoText
            // 
            this.EstadoText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EstadoText.DefaultText = "";
            this.EstadoText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EstadoText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EstadoText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EstadoText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EstadoText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EstadoText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EstadoText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EstadoText.Location = new System.Drawing.Point(375, 79);
            this.EstadoText.Name = "EstadoText";
            this.EstadoText.PasswordChar = '\0';
            this.EstadoText.PlaceholderText = "";
            this.EstadoText.SelectedText = "";
            this.EstadoText.Size = new System.Drawing.Size(200, 36);
            this.EstadoText.TabIndex = 11;
            // 
            // CiudadText
            // 
            this.CiudadText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CiudadText.DefaultText = "";
            this.CiudadText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CiudadText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CiudadText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CiudadText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CiudadText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CiudadText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CiudadText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CiudadText.Location = new System.Drawing.Point(375, 134);
            this.CiudadText.Name = "CiudadText";
            this.CiudadText.PasswordChar = '\0';
            this.CiudadText.PlaceholderText = "";
            this.CiudadText.SelectedText = "";
            this.CiudadText.Size = new System.Drawing.Size(200, 36);
            this.CiudadText.TabIndex = 12;
            // 
            // MunicipioText
            // 
            this.MunicipioText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MunicipioText.DefaultText = "";
            this.MunicipioText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.MunicipioText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.MunicipioText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MunicipioText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MunicipioText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MunicipioText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MunicipioText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MunicipioText.Location = new System.Drawing.Point(375, 179);
            this.MunicipioText.Name = "MunicipioText";
            this.MunicipioText.PasswordChar = '\0';
            this.MunicipioText.PlaceholderText = "";
            this.MunicipioText.SelectedText = "";
            this.MunicipioText.Size = new System.Drawing.Size(200, 36);
            this.MunicipioText.TabIndex = 13;
            // 
            // ColoniaText
            // 
            this.ColoniaText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ColoniaText.DefaultText = "";
            this.ColoniaText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ColoniaText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ColoniaText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ColoniaText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ColoniaText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ColoniaText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ColoniaText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ColoniaText.Location = new System.Drawing.Point(375, 233);
            this.ColoniaText.Name = "ColoniaText";
            this.ColoniaText.PasswordChar = '\0';
            this.ColoniaText.PlaceholderText = "";
            this.ColoniaText.SelectedText = "";
            this.ColoniaText.Size = new System.Drawing.Size(200, 36);
            this.ColoniaText.TabIndex = 14;
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.Location = new System.Drawing.Point(603, 34);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.Size = new System.Drawing.Size(147, 34);
            this.siticoneButton1.TabIndex = 15;
            this.siticoneButton1.Text = "Agregar";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // siticoneButton2
            // 
            this.siticoneButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton2.ForeColor = System.Drawing.Color.White;
            this.siticoneButton2.Location = new System.Drawing.Point(603, 74);
            this.siticoneButton2.Name = "siticoneButton2";
            this.siticoneButton2.Size = new System.Drawing.Size(147, 34);
            this.siticoneButton2.TabIndex = 16;
            this.siticoneButton2.Text = "Agregar";
            this.siticoneButton2.Click += new System.EventHandler(this.siticoneButton2_Click);
            // 
            // siticoneButton3
            // 
            this.siticoneButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton3.ForeColor = System.Drawing.Color.White;
            this.siticoneButton3.Location = new System.Drawing.Point(603, 134);
            this.siticoneButton3.Name = "siticoneButton3";
            this.siticoneButton3.Size = new System.Drawing.Size(147, 34);
            this.siticoneButton3.TabIndex = 17;
            this.siticoneButton3.Text = "Agregar";
            this.siticoneButton3.Click += new System.EventHandler(this.siticoneButton3_Click);
            // 
            // siticoneButton4
            // 
            this.siticoneButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton4.ForeColor = System.Drawing.Color.White;
            this.siticoneButton4.Location = new System.Drawing.Point(603, 179);
            this.siticoneButton4.Name = "siticoneButton4";
            this.siticoneButton4.Size = new System.Drawing.Size(147, 34);
            this.siticoneButton4.TabIndex = 18;
            this.siticoneButton4.Text = "Agregar";
            this.siticoneButton4.Click += new System.EventHandler(this.siticoneButton4_Click);
            // 
            // siticoneButton5
            // 
            this.siticoneButton5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton5.ForeColor = System.Drawing.Color.White;
            this.siticoneButton5.Location = new System.Drawing.Point(603, 233);
            this.siticoneButton5.Name = "siticoneButton5";
            this.siticoneButton5.Size = new System.Drawing.Size(147, 34);
            this.siticoneButton5.TabIndex = 19;
            this.siticoneButton5.Text = "Agregar";
            this.siticoneButton5.Click += new System.EventHandler(this.siticoneButton5_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 505);
            this.Controls.Add(this.siticoneButton5);
            this.Controls.Add(this.siticoneButton4);
            this.Controls.Add(this.siticoneButton3);
            this.Controls.Add(this.siticoneButton2);
            this.Controls.Add(this.siticoneButton1);
            this.Controls.Add(this.ColoniaText);
            this.Controls.Add(this.MunicipioText);
            this.Controls.Add(this.CiudadText);
            this.Controls.Add(this.EstadoText);
            this.Controls.Add(this.PaisText);
            this.Controls.Add(this.cmbColonia);
            this.Controls.Add(this.cmbMunicipio);
            this.Controls.Add(this.cmbCiudad);
            this.Controls.Add(this.cmdEstado);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.siticoneHtmlLabel5);
            this.Controls.Add(this.siticoneHtmlLabel4);
            this.Controls.Add(this.siticoneHtmlLabel3);
            this.Controls.Add(this.siticoneHtmlLabel2);
            this.Controls.Add(this.siticoneHtmlLabel1);
            this.Name = "Form2";
            this.Text = "Direcciones";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel siticoneHtmlLabel1;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel siticoneHtmlLabel2;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel siticoneHtmlLabel3;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel siticoneHtmlLabel4;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel siticoneHtmlLabel5;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbPais;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmdEstado;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbMunicipio;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbCiudad;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cmbColonia;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox PaisText;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox EstadoText;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox CiudadText;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox MunicipioText;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox ColoniaText;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton4;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton5;
    }
}