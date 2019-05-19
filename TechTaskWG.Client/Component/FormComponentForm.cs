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

            try
            {
                if (Id > 0)
                {
                    DTO.Component component = ComponentCtrl.GetById(Id);

                    this.tbId.Text = Id.ToString();
                    tbName.Text = component.Name;
                    tbDescription.Text = component.Description;
                    tbAmount.Text = component.Amount.ToString();
                    tbPrice.Text = component.Price.ToString("0.00");
                    this.tbId.ReadOnly = true;
                }

                this.tbName.Select();
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("Aplicação servidora não responde: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema na solicitação: " + ex.Message);
            }
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
                component.Amount = amount;
                component.Price = price;

                try
                { 
                    string message = ComponentCtrl.Save(component);
                    this.formComponent.UpdateDgvComponents();
                    MessageBox.Show(message);
                    this.Close();
                }
                catch (AggregateException ex)
                {
                    MessageBox.Show("Operação não realizada porque a aplicação servidora não responde: " + ex.Message);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operação não realizada. Problema na solicitação: " + ex.Message);                    
                }                
            }
            else
            {
                MessageBox.Show(validationMessage);
            }
        }
    }
}
