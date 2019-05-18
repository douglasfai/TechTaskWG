using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechTaskWG.Client.Component;

namespace TechTaskWG.Client
{
    public partial class FormComponent : Form
    {
        public FormComponent()
        {
            InitializeComponent();
            dgvComponents.DataSource = ComponentCtrl.GetAll();
        }

        public void UpdateDgvComponents()
        {
            dgvComponents.AutoGenerateColumns = false;
            dgvComponents.DataSource = ComponentCtrl.GetAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormComponentForm formComponentForm = new FormComponentForm(this);                        
            formComponentForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = this.GetIdInDvg();
            if (id > 0)
            {
                FormComponentForm formComponentForm = new FormComponentForm(this, id);
                formComponentForm.Show();
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = this.GetIdInDvg();
            if (id > 0)
            {
                if (MessageBox.Show("Esta operação é irreversível. Deseja continuar?", "Confirmação de exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string message = ComponentCtrl.Delete(id);
                    UpdateDgvComponents();
                    MessageBox.Show(message);
                }
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado!");
            }
        }

        private void dgvComponents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dgvComponents.Rows[e.RowIndex];
            }
        }

        private int GetIdInDvg()
        {
            int id = 0;
            if (dgvComponents.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = this.dgvComponents.Rows[dgvComponents.SelectedRows[0].Index];
                id = Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
            return id;
        }
    }
}
