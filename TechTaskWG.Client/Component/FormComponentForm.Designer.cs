namespace TechTaskWG.Client.Component
{
    partial class FormComponentForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.pnlComponent = new System.Windows.Forms.Panel();
            this.pnlComponent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(55, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cadastro de componente";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(11, 17);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(40, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Código";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(74, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nome";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 71);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(55, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Descrição";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(11, 173);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(62, 13);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Quantidade";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(149, 173);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Preço";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(215, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(296, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(14, 33);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(40, 20);
            this.tbId.TabIndex = 8;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(77, 33);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(265, 20);
            this.tbName.TabIndex = 9;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(14, 87);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(325, 67);
            this.tbDescription.TabIndex = 10;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(14, 189);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 20);
            this.tbAmount.TabIndex = 11;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(152, 189);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(100, 20);
            this.tbPrice.TabIndex = 12;
            // 
            // pnlComponent
            // 
            this.pnlComponent.Controls.Add(this.tbPrice);
            this.pnlComponent.Controls.Add(this.tbId);
            this.pnlComponent.Controls.Add(this.tbName);
            this.pnlComponent.Controls.Add(this.lblId);
            this.pnlComponent.Controls.Add(this.lblName);
            this.pnlComponent.Controls.Add(this.lblDescription);
            this.pnlComponent.Controls.Add(this.lblAmount);
            this.pnlComponent.Controls.Add(this.lblPrice);
            this.pnlComponent.Controls.Add(this.tbDescription);
            this.pnlComponent.Controls.Add(this.tbAmount);
            this.pnlComponent.Location = new System.Drawing.Point(10, 40);
            this.pnlComponent.Name = "pnlComponent";
            this.pnlComponent.Size = new System.Drawing.Size(360, 230);
            this.pnlComponent.TabIndex = 13;
            // 
            // FormComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.pnlComponent);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormComponentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TechTaskWG Client";
            this.pnlComponent.ResumeLayout(false);
            this.pnlComponent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Panel pnlComponent;
    }
}