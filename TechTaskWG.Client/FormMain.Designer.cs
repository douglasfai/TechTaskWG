namespace TechTaskWG.Client
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHistoric = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRegister,
            this.tsmiHistoric,
            this.tsmiClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiRegister
            // 
            this.tsmiRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProduct,
            this.tmsiComponent});
            this.tsmiRegister.Name = "tsmiRegister";
            this.tsmiRegister.Size = new System.Drawing.Size(66, 20);
            this.tsmiRegister.Text = "&Cadastro";
            // 
            // tsmiProduct
            // 
            this.tsmiProduct.Name = "tsmiProduct";
            this.tsmiProduct.Size = new System.Drawing.Size(180, 22);
            this.tsmiProduct.Text = "&Produto";
            this.tsmiProduct.Click += new System.EventHandler(this.tsmiProduct_Click);
            // 
            // tmsiComponent
            // 
            this.tmsiComponent.Name = "tmsiComponent";
            this.tmsiComponent.Size = new System.Drawing.Size(180, 22);
            this.tmsiComponent.Text = "C&omponente";
            this.tmsiComponent.Click += new System.EventHandler(this.tmsiComponent_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.ShortcutKeyDisplayString = "Ctrl+End";
            this.tsmiClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End)));
            this.tsmiClose.Size = new System.Drawing.Size(38, 20);
            this.tsmiClose.Text = "&Sair";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiHistoric
            // 
            this.tsmiHistoric.Name = "tsmiHistoric";
            this.tsmiHistoric.Size = new System.Drawing.Size(67, 20);
            this.tsmiHistoric.Text = "&Histórico";
            this.tsmiHistoric.Click += new System.EventHandler(this.tsmiHistoric_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TechTaskWG Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegister;
        private System.Windows.Forms.ToolStripMenuItem tsmiProduct;
        private System.Windows.Forms.ToolStripMenuItem tmsiComponent;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiHistoric;
    }
}

