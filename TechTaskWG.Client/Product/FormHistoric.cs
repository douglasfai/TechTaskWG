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
    public partial class FormHistoric : Form
    {
        public FormHistoric()
        {
            InitializeComponent();

            dgvHistoric.AutoGenerateColumns = false;

            try
            {
                dgvHistoric.DataSource = ProductCtrl.GetAll();
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
    }
}
