namespace CMP248WorkShop2_Team6
{
    partial class frmAddModifySupplier
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
            System.Windows.Forms.Label supNameLabel;
            System.Windows.Forms.Label supplierIdLabel;
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            supNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Location = new System.Drawing.Point(49, 63);
            supNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            supNameLabel.Name = "supNameLabel";
            supNameLabel.Size = new System.Drawing.Size(60, 13);
            supNameLabel.TabIndex = 2;
            supNameLabel.Text = "Sup Name:";
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Location = new System.Drawing.Point(49, 32);
            supplierIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(60, 13);
            supplierIdLabel.TabIndex = 0;
            supplierIdLabel.Text = "Supplier Id:";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(TravelData.Supplier);
            // 
            // txtSupName
            // 
            this.txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupName", true));
            this.txtSupName.Location = new System.Drawing.Point(125, 60);
            this.txtSupName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(237, 20);
            this.txtSupName.TabIndex = 3;
            this.txtSupName.Tag = "Supplier Name";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(51, 106);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(56, 28);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 106);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupplierId", true));
            this.txtSupplierId.Location = new System.Drawing.Point(125, 29);
            this.txtSupplierId.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(144, 20);
            this.txtSupplierId.TabIndex = 1;
            this.txtSupplierId.Tag = "Supplier ID";
            // 
            // frmAddModifySupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 166);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.txtSupplierId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(supNameLabel);
            this.Controls.Add(this.txtSupName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddModifySupplier";
            this.Text = "frmAddModifySupplier";
            this.Load += new System.EventHandler(this.frmAddModifySupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.TextBox txtSupName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSupplierId;
    }
}