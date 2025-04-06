using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD.Forms
{
    public partial class FrmPantallaInicio: Form
    {
        public FrmPantallaInicio()
        {
            InitializeComponent();
            UsCtrlUsuarios userControl1 = new UsCtrlUsuarios();
            ShowView(userControl1);
        }

        private void ShowView(UserControl vista)
        {
            siticonePanel3.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            siticonePanel3.Controls.Add(vista);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void siticonePanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            UsCtrlHoteles userControl2 = new UsCtrlHoteles();
            ShowView(userControl2);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            UsCtrlUsuarios userControl1 = new UsCtrlUsuarios();
            ShowView(userControl1);
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            UsCtrlTipoHabit usCtrlTipoHabit = new UsCtrlTipoHabit();
            ShowView(usCtrlTipoHabit);
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            UsCtrlHabit usCtrlHabit = new UsCtrlHabit();
            ShowView(usCtrlHabit);
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            UsCtrlClientes usCtrlClientes = new UsCtrlClientes();
            ShowView(usCtrlClientes);
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            UsCtrlReservaciones usCtrlReservaciones = new UsCtrlReservaciones();
            ShowView(usCtrlReservaciones);
        }
    }
}
