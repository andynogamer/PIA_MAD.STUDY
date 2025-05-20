namespace PIA_MAD.Forms
{
    partial class UsCtrlCancelaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CheckIn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.txtCodigoReservacion = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.dgvReservaciones = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.siticoneHtmlLabel1 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckIn
            // 
            this.CheckIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CheckIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CheckIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CheckIn.ForeColor = System.Drawing.Color.White;
            this.CheckIn.Location = new System.Drawing.Point(721, 13);
            this.CheckIn.Name = "CheckIn";
            this.CheckIn.Size = new System.Drawing.Size(180, 45);
            this.CheckIn.TabIndex = 13;
            this.CheckIn.Text = "Cancelar";
            this.CheckIn.Click += new System.EventHandler(this.CheckIn_Click);
            // 
            // txtCodigoReservacion
            // 
            this.txtCodigoReservacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoReservacion.DefaultText = "";
            this.txtCodigoReservacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigoReservacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigoReservacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoReservacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoReservacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoReservacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoReservacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoReservacion.Location = new System.Drawing.Point(345, 21);
            this.txtCodigoReservacion.Name = "txtCodigoReservacion";
            this.txtCodigoReservacion.PasswordChar = '\0';
            this.txtCodigoReservacion.PlaceholderText = "";
            this.txtCodigoReservacion.SelectedText = "";
            this.txtCodigoReservacion.Size = new System.Drawing.Size(358, 36);
            this.txtCodigoReservacion.TabIndex = 12;
            this.txtCodigoReservacion.TextChanged += new System.EventHandler(this.txtCodigoReservacionIN_TextChanged);
            // 
            // dgvReservaciones
            // 
            this.dgvReservaciones.AllowUserToAddRows = false;
            this.dgvReservaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReservaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReservaciones.ColumnHeadersHeight = 4;
            this.dgvReservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReservaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReservaciones.Location = new System.Drawing.Point(345, 79);
            this.dgvReservaciones.Name = "dgvReservaciones";
            this.dgvReservaciones.ReadOnly = true;
            this.dgvReservaciones.RowHeadersVisible = false;
            this.dgvReservaciones.RowHeadersWidth = 51;
            this.dgvReservaciones.RowTemplate.Height = 24;
            this.dgvReservaciones.Size = new System.Drawing.Size(556, 94);
            this.dgvReservaciones.TabIndex = 9;
            this.dgvReservaciones.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservaciones.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReservaciones.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReservaciones.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReservaciones.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReservaciones.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservaciones.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReservaciones.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvReservaciones.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReservaciones.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservaciones.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservaciones.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReservaciones.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvReservaciones.ThemeStyle.ReadOnly = true;
            this.dgvReservaciones.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservaciones.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReservaciones.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservaciones.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReservaciones.ThemeStyle.RowsStyle.Height = 24;
            this.dgvReservaciones.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReservaciones.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReservaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservacionesIN_CellContentClick);
            // 
            // siticoneHtmlLabel1
            // 
            this.siticoneHtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneHtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneHtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.siticoneHtmlLabel1.Location = new System.Drawing.Point(43, 13);
            this.siticoneHtmlLabel1.Name = "siticoneHtmlLabel1";
            this.siticoneHtmlLabel1.Size = new System.Drawing.Size(263, 44);
            this.siticoneHtmlLabel1.TabIndex = 8;
            this.siticoneHtmlLabel1.Text = "Cancelaciones";
            this.siticoneHtmlLabel1.Click += new System.EventHandler(this.siticoneHtmlLabel1_Click);
            // 
            // UsCtrlCancelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckIn);
            this.Controls.Add(this.txtCodigoReservacion);
            this.Controls.Add(this.dgvReservaciones);
            this.Controls.Add(this.siticoneHtmlLabel1);
            this.Name = "UsCtrlCancelaciones";
            this.Size = new System.Drawing.Size(1390, 588);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneButton CheckIn;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtCodigoReservacion;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView dgvReservaciones;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel siticoneHtmlLabel1;
    }
}
