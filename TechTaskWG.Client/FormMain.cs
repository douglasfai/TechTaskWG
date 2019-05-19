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
    public partial class FormMain : Form
    {
        private bool formClosingConfirm;

        public FormMain()
        {
            InitializeComponent();
            formClosingConfirm = true;
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair da aplicação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                formClosingConfirm = false;
                Application.Exit();                
            }            
        }

        private void tsmiProduct_Click(object sender, EventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            formProduct.Show();
        }

        private void tmsiComponent_Click(object sender, EventArgs e)
        {
            FormComponent formComponent = new FormComponent();
            formComponent.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formClosingConfirm)
            {
                if (MessageBox.Show("Tem certeza que deseja sair da aplicação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }            
        }

        private void tsmiHistoric_Click(object sender, EventArgs e)
        {
            FormHistoric formHistoric = new FormHistoric();
            formHistoric.Show();
        }
    }
}
