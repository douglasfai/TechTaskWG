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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormComponentForm formComponentForm = new FormComponentForm();                        
            formComponentForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormComponentForm formComponentForm = new FormComponentForm(1);
            formComponentForm.Show();
        }
    }
}
