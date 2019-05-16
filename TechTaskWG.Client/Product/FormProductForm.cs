using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechTaskWG.Client.Product
{
    public partial class FormProductForm : Form
    {
        private FormProduct formProduct;

        public FormProductForm(FormProduct formProduct, int Id = 0)
        {
            InitializeComponent();

            this.formProduct = formProduct;

            this.tbId.Enabled = false;

            if (Id > 0)
            {
                DTO.Product product = ProductCtrl.GetById(Id);

                this.tbId.Text = Id.ToString();
                tbName.Text = product.Name;
                tbDescription.Text = product.Description;
                tbAmount.Text = product.Amount.ToString();
                tbPrice.Text = product.Price.ToString();                
                this.tbId.ReadOnly = true;
            }

            this.tbName.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DTO.Product product = new DTO.Product();
            if (tbId.Text != "")
            {
                product.Id = Convert.ToInt32(tbId.Text);
            }            
            product.Name = tbName.Text;
            product.Description = tbDescription.Text;
            product.Amount = Convert.ToInt32(tbAmount.Text);
            product.Price = Convert.ToInt32(tbPrice.Text);
            string message = ProductCtrl.Save(product);
            this.formProduct.UpdateDgvProducts();
            MessageBox.Show(message);
            this.Close();
        }
    }
}
