using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechTaskWG.Client.Product;

namespace TechTaskWG.Client
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormProductForm formProductForm = new FormProductForm();
            formProductForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormProductForm formProductForm = new FormProductForm();
            formProductForm.Show();                        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void Delete(int Id)
        {
            
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
