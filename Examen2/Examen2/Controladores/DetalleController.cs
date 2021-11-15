using Examen2.Modelos.DAO;
using Examen2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2.Controladores
{
    public class DetalleController
    {
        TicketsDAO ticketsDAO = new  TicketsDAO ();
        DetallesView vista;
        public DetalleController(DetallesView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Load(object sender, EventArgs e)
        {
            ListarTickets();

        }

        private void ListarTickets()
        {
            vista.DetallesDataGridView.DataSource = ticketsDAO.GetTickets();
        }







    }
}
