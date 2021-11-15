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
    public class TiposController
    {
        TiposView vista;
        TiposDAO tiposDAO = new TiposDAO();
        Tipos tipos = new Tipos();
        string operacion = string.Empty;

        public TiposController(TiposView view)
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
            ListarTipos();

        }

        private void ListarTipos()
        {
            vista.TiposDataGridView.DataSource = tiposDAO.GetTipos();
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
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese un tipo de soporte");
                vista.NombreTextBox.Focus();
                return;
            }

            tipos.Nombre = vista.NombreTextBox.Text;
            if (operacion == "Nuevo")
            {
                bool inserto = tiposDAO.InsertarNuevoTipo(tipos);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    
                    MessageBox.Show("Tipo ingresado exitosamente ", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTipos();
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el Tipo", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ListarTipos();
                }
            }
            else if (operacion == "Modificar")
            {
                tipos.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = tiposDAO.ModificarTipos(tipos);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    
                    MessageBox.Show("Tipo modificado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTipos();

                }
                else
                {
                    MessageBox.Show("No se pudo modificar el tipo", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ListarTipos();
                }
            }

        }

        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.TiposDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = tiposDAO.EliminarTipos(Convert.ToInt32(vista.TiposDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    
                    MessageBox.Show("Tipo eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTipos();
                }
            }
        }

        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";

            if (vista.TiposDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.TiposDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombreTextBox.Text = vista.TiposDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
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
