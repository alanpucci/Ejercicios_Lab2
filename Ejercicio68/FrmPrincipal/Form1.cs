using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPrincipal
{
    public partial class Form1 : Form
    {
        Persona persona;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void NotificarCambio(string cambio)
        {
            MessageBox.Show(cambio);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(this.persona is null)
            {
                this.persona = new Persona(this.txtName.Text, this.txtLastName.Text);
                this.persona.EventoString += NotificarCambio;
                this.btnCreate.Text = "Actualizar";
                this.NotificarCambio(this.persona.Mostrar());
            }
            else
            {
                if(this.persona.Nombre != this.txtName.Text)
                {
                   this.persona.Nombre = this.txtName.Text;
                }
                if(this.persona.Apellido != this.txtLastName.Text)
                {
                    this.persona.Apellido = this.txtLastName.Text;
                }
            }
        }
    }
}
