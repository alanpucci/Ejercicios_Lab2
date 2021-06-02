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
    public partial class FrmList : Form
    {
        public FrmList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReloadList()
        {
            this.dgvList.DataSource = null;
            BindingSource bSource = new BindingSource();
            bSource.DataSource = ConnectionHandler.GetPersons();
            this.dgvList.DataSource = bSource;
        }

        private void FrmList_Load(object sender, EventArgs e)
        {
            this.ReloadList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Person person = (Person)this.dgvList.CurrentRow.DataBoundItem;
            FrmAdd addFrm = new FrmAdd(person);
            addFrm.ShowDialog();
            this.ReloadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = (Person)this.dgvList.CurrentRow.DataBoundItem;
                ConnectionHandler.Delete(person.GetId);
                MessageBox.Show("Persona eliminada exitosamente","Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ReloadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar a la persona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
