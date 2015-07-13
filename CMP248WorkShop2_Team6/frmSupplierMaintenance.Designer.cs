namespace CMP248WorkShop2_Team6
{
    partial class frmSupplierMaintenance
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label supplierIdLabel;
            System.Windows.Forms.Label supNameLabel;
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.btnGetSupplier = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            supplierIdLabel = new System.Windows.Forms.Label();
            supNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Location = new System.Drawing.Point(62, 90);
            supplierIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(60, 13);
            supplierIdLabel.TabIndex = 0;
            supplierIdLabel.Text = "Supplier Id:";
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Location = new System.Drawing.Point(63, 154);
            supNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            supNameLabel.Name = "supNameLabel";
            supNameLabel.Size = new System.Drawing.Size(60, 13);
            supNameLabel.TabIndex = 3;
            supNameLabel.Text = "Sup Name:";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(TravelData.Supplier);
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupplierId", true));
            this.txtSupplierId.Location = new System.Drawing.Point(155, 90);
            this.txtSupplierId.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(55, 20);
            this.txtSupplierId.TabIndex = 1;
            this.txtSupplierId.Tag = "Supplier Id";
            // 
            // txtSupName
            // 
            this.txtSupName.BackColor = System.Drawing.SystemColors.Control;
            this.txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupName", true));
            this.txtSupName.Location = new System.Drawing.Point(155, 150);
            this.txtSupName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(164, 20);
            this.txtSupName.TabIndex = 4;
            // 
            // btnGetSupplier
            // 
            this.btnGetSupplier.Location = new System.Drawing.Point(242, 85);
            this.btnGetSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetSupplier.Name = "btnGetSupplier";
            this.btnGetSupplier.Size = new System.Drawing.Size(76, 28);
            this.btnGetSupplier.TabIndex = 2;
            this.btnGetSupplier.Text = "Get Supplier";
            this.btnGetSupplier.UseVisualStyleBackColor = true;
            this.btnGetSupplier.Click += new System.EventHandler(this.btnGetSupplier_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(44, 241);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 27);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(133, 242);
            this.btnModify.Margin = new System.Windows.Forms.Padding(2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(56, 27);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(219, 241);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 27);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(297, 242);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 24);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSupplierMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 334);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGetSupplier);
            this.Controls.Add(supNameLabel);
            this.Controls.Add(this.txtSupName);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.txtSupplierId);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSupplierMaintenance";
            this.Text = "frmSupplierMaintenance";
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.TextBox txtSupplierId;
        private System.Windows.Forms.TextBox txtSupName;
        private System.Windows.Forms.Button btnGetSupplier;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
    }
}