﻿using System;
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
            UpdateDgvProducts();
        }

        public void UpdateDgvProducts()
        {
            dgvProducts.AutoGenerateColumns = false;

            try
            { 
                dgvProducts.DataSource = ProductCtrl.GetAll();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormProductForm formProductForm = new FormProductForm(this);
            formProductForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = this.GetIdInDvg();
            if (id > 0)
            {
                FormProductForm formProductForm = new FormProductForm(this, id);
                formProductForm.Show();
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = this.GetIdInDvg();
            if (id > 0)
            {
                if (MessageBox.Show("Esta operação é irreversível. Deseja continuar?", "Confirmação de exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    { 
                        string message = ProductCtrl.Delete(id);
                        UpdateDgvProducts();                        
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
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado!");
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
            }
        }

        private int GetIdInDvg()
        {
            int id = 0;

            try
            { 
                if (dgvProducts.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
                {
                    DataGridViewRow row = this.dgvProducts.Rows[dgvProducts.SelectedRows[0].Index];
                    id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                }
            }
            catch (NullReferenceException ex)
            {

            }

            return id;            
        }

    }
}
