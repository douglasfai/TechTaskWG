using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechTaskWG.Client.Component
{
    public partial class FormComponentForm : Form
    {
        private FormComponent formComponent;

        public FormComponentForm(FormComponent formComponent, int Id = 0)
        {
            InitializeComponent();

            this.formComponent = formComponent;

            this.tbId.Enabled = false;

            if (Id > 0)
            {
                DTO.Component component = ComponentCtrl.GetById(Id);

                this.tbId.Text = Id.ToString();
                tbName.Text = component.Name;
                tbDescription.Text = component.Description;
                tbAmount.Text = component.Amount.ToString();
                tbPrice.Text = component.Price.ToString();
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
            DTO.Component component = new DTO.Component();
            if (tbId.Text != "")
            {
                component.Id = Convert.ToInt32(tbId.Text);
            }

            string validationMessage = "";
            if (tbName.Text.Trim() == "")
                validationMessage += "Nome do componente é obrigatório. ";

            int amount;
            if (!int.TryParse(tbAmount.Text, out amount))
                validationMessage += "Quantidade deve ser inteiro. ";

            double price;
            if (!double.TryParse(tbPrice.Text, out price))
                validationMessage += "Preço inválido!";

            if (validationMessage == "")
            {
                component.Name = tbName.Text;
                component.Description = tbDescription.Text;
                component.Amount = Convert.ToInt32(tbAmount.Text);
                component.Price = Convert.ToDouble(tbPrice.Text);
                string message = ComponentCtrl.Save(component);
                this.formComponent.UpdateDgvComponents();
                MessageBox.Show(message);
                this.Close();
            }
            else
            {
                MessageBox.Show(validationMessage);
            }
        }
    }
}
