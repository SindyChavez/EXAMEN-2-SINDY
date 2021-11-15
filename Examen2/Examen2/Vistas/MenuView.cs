using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Examen2.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        TiposView vistaTipos;
        EstadosView vistaEstados;
        TicketsView vistaTickets;
        DetallesView vistaDetalles;

        private void TiposToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaTipos == null)
            {
                vistaTipos = new TiposView();
                vistaTipos.MdiParent = this;
                vistaTipos.FormClosed += VistaTipos_FormClosed;
                vistaTipos.Show();
            }
            else
            {
                vistaTipos.Activate();
            }
        }

        private void VistaTipos_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaTipos = null;
        }


        private void EstadosToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaEstados == null)
            {
                vistaEstados = new EstadosView();
                vistaEstados.MdiParent = this;
                vistaEstados.FormClosed += vistaEstados_FormClosed;
                vistaEstados.Show();
            }
            else
            {
                vistaEstados.Activate();
            }
        }

        private void vistaEstados_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaEstados = null;
        }

        private void TicketsToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaTickets == null)
            {
                vistaTickets = new TicketsView();
                vistaTickets.MdiParent = this;
                vistaTickets.FormClosed += vistaTickets_FormClosed;
                vistaTickets.Show();
            }
            else
            {
                vistaTickets.Activate();
            }
        }

        private void vistaTickets_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaTickets = null;
        }

        private void DetalleToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaDetalles == null)
            {
                vistaDetalles = new DetallesView();
                vistaDetalles.MdiParent = this;
                vistaDetalles.FormClosed += vistaDetalles_FormClosed;
                vistaDetalles.Show();
            }
            else
            {
                vistaDetalles.Activate();
            }
        }

        private void vistaDetalles_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaDetalles = null;
        }
    }
    
}
