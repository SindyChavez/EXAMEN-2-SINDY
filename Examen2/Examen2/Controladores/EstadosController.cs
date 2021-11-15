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
    public class EstadosController
    {
        EstadosView vista;
        EstadosDAO estadosDAO = new EstadosDAO();
        Estados estados = new Estados();
        string operacion = string.Empty;

        public EstadosController(EstadosView view)
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
            ListarEstados();

        }

        private void ListarEstados()
        {
            vista.EstadosDataGridView.DataSource = estadosDAO.GetEstados();
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

            estados.Nombre = vista.NombreTextBox.Text;
            if (operacion == "Nuevo")
            {
                bool inserto = estadosDAO.InsertarNuevoEstado(estados);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Estado ingresado exitosamente ", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarEstados();
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el Estado", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ListarEstados();
                }
            }
            else if (operacion == "Modificar")
            {
                estados.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = estadosDAO.ModificarEstados(estados);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Estado modificado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarEstados();

                }
                else
                {
                    MessageBox.Show("No se pudo modificar el Estado", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ListarEstados();
                }
            }

        }

        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.EstadosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = estadosDAO.EliminarEstados(Convert.ToInt32(vista.EstadosDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Estado eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarEstados();
                }
            }
        }

        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";

            if (vista.EstadosDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.EstadosDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombreTextBox.Text = vista.EstadosDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
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
