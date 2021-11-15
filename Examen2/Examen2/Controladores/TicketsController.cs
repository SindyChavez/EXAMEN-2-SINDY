using Examen2.Modelos.DAO;
using Examen2.Modelos.Entidades;
using Examen2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2.Controladores
{
    public class TicketsController
    {
        TicketsView vista;
        TicketsDAO ticketsDAO = new TicketsDAO();
        TiposDAO tiposDAO = new TiposDAO();
        EstadosDAO estadosDAO = new EstadosDAO();
        Tickets tickets = new Tickets();
        string operacion = string.Empty;

        public TicketsController(TicketsView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }

        private void Load(object sender, EventArgs e)
        {
            ListarTickets();
            ListarTipos();
            ListarEstados();
        }

        private void ListarTickets()
        {
            vista.TicketsDataGridView.DataSource = ticketsDAO.GetTickets();
        }

        private void ListarTipos()
        {
            vista.TiposComboBox.DataSource = tiposDAO.GetTipos();
            vista.TiposComboBox.DisplayMember = "TIPOS";
            vista.TiposComboBox.ValueMember = "NOMBRE";
        }
        private void ListarEstados()
        {
            vista.EstadosComboBox.DataSource = estadosDAO.GetEstados();
            vista.EstadosComboBox.DisplayMember = "ESTADOS";
            vista.EstadosComboBox.ValueMember = "NOMBRE";
        }

        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object serder, EventArgs e)
        {
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese un estado");
                vista.NombreTextBox.Focus();
                return;
            }

            tickets.NombreCliente = vista.NombreTextBox.Text;
            tickets.Fecha = vista.FechaDateTimePicker.Value;
            tickets.NombreTipos = vista.TiposComboBox.Text;
            tickets.NombreEstados = vista.EstadosComboBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = ticketsDAO.InsertarNuevoTickets(tickets);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Tickets ingresado exitosamente ", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTickets();
                    ListarTipos();
                    ListarEstados();
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el Tickets", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ListarTickets();
                    ListarTipos();
                    ListarEstados();
                }
            }
            else if (operacion == "Modificar")
            {
                tickets.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = ticketsDAO.ModificarTickets(tickets);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Tickets modificado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTickets();
                    ListarTipos();
                    ListarEstados();

                }
                else
                {
                    MessageBox.Show("No se pudo modificar el Tickets", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ListarTickets();
                    ListarTipos();
                    ListarEstados();
                }
            }

        }

        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.TicketsDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = ticketsDAO.EliminarTickets(Convert.ToInt32(vista.TicketsDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Tickets eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTickets();
                    ListarTipos();
                    ListarEstados();
                }
            }
        }

        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";

            if (vista.TicketsDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombreTextBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["NOMBRECLIENTE"].Value.ToString();
                vista.TiposComboBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["NOMBRETIPOS"].Value.ToString();
                vista.EstadosComboBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["NOMBREESTADOS"].Value.ToString();
                HabilitarControles();
            }
        }

        private void Cancelar(object serder, EventArgs e)
        {
            LimpiarControles();
            DesabilitarControles();
        }
        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;
            vista.FechaDateTimePicker.Enabled = true;
            vista.TiposComboBox.Enabled = true;
            vista.EstadosComboBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
            vista.EliminarButton.Enabled = false;
        }
        private void DesabilitarControles()
        {
            vista.IdTextBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.FechaDateTimePicker.Enabled = false;
            vista.TiposComboBox.Enabled = false;
            vista.EstadosComboBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
            vista.EliminarButton.Enabled = true;
        }
        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.NombreTextBox.Clear();
        }






    }
}
