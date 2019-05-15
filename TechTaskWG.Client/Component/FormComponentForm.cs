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
        public FormComponentForm()
        {
            InitializeComponent();
            this.tbId.Select();
        }

        public FormComponentForm(Int32 Id)
        {
            InitializeComponent();
            this.tbId.Text = Id.ToString();
            this.tbId.ReadOnly = true;
            this.tbName.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
