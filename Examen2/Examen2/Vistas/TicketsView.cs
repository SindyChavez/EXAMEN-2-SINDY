using Examen2.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2.Vistas
{
    public partial class TicketsView : Form
    {
        public TicketsView()
        {
            InitializeComponent();
            TicketsController controlador = new TicketsController(this);
        }
    }
}
