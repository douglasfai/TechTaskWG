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
        public FormProductForm()
        {
            InitializeComponent();
            this.tbId.Select();
        }

        public FormProductForm(Int32 Id)
        {
            InitializeComponent();                     
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
