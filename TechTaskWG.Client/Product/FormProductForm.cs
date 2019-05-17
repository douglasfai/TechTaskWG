using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechTaskWG.Client.Component;

namespace TechTaskWG.Client.Product
{
    public partial class FormProductForm : Form
    {
        private FormProduct formProduct;
        private List<DTO.Component> componentsList;
        private List<int> productComponents;

        public FormProductForm(FormProduct formProduct, int Id = 0)
        {
            InitializeComponent();

            this.formProduct = formProduct;

            this.tbId.Enabled = false;

            productComponents = null;

            if (Id > 0)
            {
                DTO.Product product = ProductCtrl.GetById(Id);

                this.tbId.Text = Id.ToString();
                tbName.Text = product.Name;
                tbDescription.Text = product.Description;
                tbAmount.Text = product.Amount.ToString();
                tbPrice.Text = product.Price.ToString();                
                this.tbId.ReadOnly = true;

                productComponents = (from component in product.Components select component.Id).ToList();
            }

            componentsList = ComponentCtrl.GetAll();
            foreach (var component in componentsList)
            {
                clbComponents.Items.Add(component.Name, productComponents != null && productComponents.Contains(component.Id));
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
            product.Price = Convert.ToDouble(tbPrice.Text);
            
            if (clbComponents.Items.Count > 0)
            {
                List<DTO.Component> productComponents = new List<DTO.Component>();

                int quantityOfComponentsChecked = clbComponents.Items.Count;

                for (int i = 0; i < quantityOfComponentsChecked; i++)
                {
                    if (clbComponents.GetItemChecked(i))
                    {
                        productComponents.Add(new DTO.Component() { Id = componentsList[i].Id });
                    }
                }
                product.Components = productComponents;
            }
            

            string message = ProductCtrl.Save(product);
            this.formProduct.UpdateDgvProducts();
            MessageBox.Show(message);
            this.Close();
        }
    }
}
