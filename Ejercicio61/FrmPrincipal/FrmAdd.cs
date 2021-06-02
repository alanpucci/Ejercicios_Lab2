using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPrincipal
{
    public partial class FrmAdd : Form
    {
        Person person;
        public FrmAdd()
        {
            InitializeComponent();
        }

        public FrmAdd(Person person):this()
        {
            this.person = person;
            this.btnAdd.Text = "Modificar";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(person is null)
                {
                    Person newPerson = new Person(this.txtName.Text,this.txtLastName.Text);
                    ConnectionHandler.InsertPerson(newPerson);
                    MessageBox.Show("Persona creada con exito", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    Person newPerson = new Person(this.person.GetId,this.txtName.Text, this.txtLastName.Text);
                    ConnectionHandler.EditPerson(newPerson);
                    MessageBox.Show("Persona modificada con exito", "Modificacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            if(!(person is null))
            {
                this.txtName.Text = person.GetNombre;
                this.txtLastName.Text = person.GetApellido;
            }
        }
    }
}
