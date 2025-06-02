using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PIA_MAD.Forms.Estructuras;

namespace PIA_MAD.Forms
{
    public partial class FrmPantallaInicio: Form
    {
        public FrmPantallaInicio()
        {
            InitializeComponent();
            UsCtrlClientes usCtrlClientes = new UsCtrlClientes();
            ShowView(usCtrlClientes);
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

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
           
            UsCtrlReporteOcup usCtrlReporteOcup = new UsCtrlReporteOcup();
            ShowView(usCtrlReporteOcup);

        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {
          
            UsCtrlHistorialCliente usCtrlHistorialClient = new UsCtrlHistorialCliente();
            ShowView(usCtrlHistorialClient);
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
           
            UsCtrlReporteVentas usCtrlReporteVentas = new UsCtrlReporteVentas();
            ShowView(usCtrlReporteVentas);
        }

        private void siticoneButton10_Click(object sender, EventArgs e)
        {
            UsCttrlChecks usCtrlChecks= new UsCttrlChecks();
            ShowView(usCtrlChecks);
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void siticoneButton11_Click(object sender, EventArgs e)
        {
            UsCtrlServicios ctrlServicios = new UsCtrlServicios();
            ShowView(ctrlServicios);
        }

        private void siticoneButton12_Click(object sender, EventArgs e)
        {
           
            UsCtrlCancelaciones ctrlCancelaciones = new UsCtrlCancelaciones();
            ShowView(ctrlCancelaciones);
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
