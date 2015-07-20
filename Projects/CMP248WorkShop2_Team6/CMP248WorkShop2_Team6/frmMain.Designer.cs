namespace CMP248WorkShop2_Team6
{
    partial class frmMain
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
            this.btnPackageProdSuppTable = new System.Windows.Forms.Button();
            this.btnPackageMaintenance = new System.Windows.Forms.Button();
            this.btnSupplierMaintenance = new System.Windows.Forms.Button();
            this.btnProdMaintenance = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPSMaintenance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPackageProdSuppTable
            // 
            this.btnPackageProdSuppTable.Location = new System.Drawing.Point(217, 84);
            this.btnPackageProdSuppTable.Name = "btnPackageProdSuppTable";
            this.btnPackageProdSuppTable.Size = new System.Drawing.Size(246, 62);
            this.btnPackageProdSuppTable.TabIndex = 0;
            this.btnPackageProdSuppTable.Text = "Package Product Supplier Table";
            this.btnPackageProdSuppTable.UseVisualStyleBackColor = true;
            this.btnPackageProdSuppTable.Click += new System.EventHandler(this.btnPackageProdSuppTable_Click);
            // 
            // btnPackageMaintenance
            // 
            this.btnPackageMaintenance.Location = new System.Drawing.Point(217, 181);
            this.btnPackageMaintenance.Name = "btnPackageMaintenance";
            this.btnPackageMaintenance.Size = new System.Drawing.Size(246, 60);
            this.btnPackageMaintenance.TabIndex = 1;
            this.btnPackageMaintenance.Text = "Package Maintenance";
            this.btnPackageMaintenance.UseVisualStyleBackColor = true;
            this.btnPackageMaintenance.Click += new System.EventHandler(this.btnPackageMaintenance_Click);
            // 
            // btnSupplierMaintenance
            // 
            this.btnSupplierMaintenance.Location = new System.Drawing.Point(217, 367);
            this.btnSupplierMaintenance.Name = "btnSupplierMaintenance";
            this.btnSupplierMaintenance.Size = new System.Drawing.Size(246, 59);
            this.btnSupplierMaintenance.TabIndex = 2;
            this.btnSupplierMaintenance.Text = "Supplier Maintenance";
            this.btnSupplierMaintenance.UseVisualStyleBackColor = true;
            this.btnSupplierMaintenance.Click += new System.EventHandler(this.btnSupplierMaintenance_Click);
            // 
            // btnProdMaintenance
            // 
            this.btnProdMaintenance.Location = new System.Drawing.Point(217, 273);
            this.btnProdMaintenance.Name = "btnProdMaintenance";
            this.btnProdMaintenance.Size = new System.Drawing.Size(246, 58);
            this.btnProdMaintenance.TabIndex = 3;
            this.btnProdMaintenance.Text = "Product Maintenance";
            this.btnProdMaintenance.UseVisualStyleBackColor = true;
            this.btnProdMaintenance.Click += new System.EventHandler(this.btnProdMaintenance_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(217, 546);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(246, 62);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPSMaintenance
            // 
            this.btnPSMaintenance.Location = new System.Drawing.Point(217, 459);
            this.btnPSMaintenance.Name = "btnPSMaintenance";
            this.btnPSMaintenance.Size = new System.Drawing.Size(246, 56);
            this.btnPSMaintenance.TabIndex = 5;
            this.btnPSMaintenance.Text = "Product Supplier Maintenance";
            this.btnPSMaintenance.UseVisualStyleBackColor = true;
            this.btnPSMaintenance.Click += new System.EventHandler(this.btnPSMaintenance_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 638);
            this.Controls.Add(this.btnPSMaintenance);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProdMaintenance);
            this.Controls.Add(this.btnSupplierMaintenance);
            this.Controls.Add(this.btnPackageMaintenance);
            this.Controls.Add(this.btnPackageProdSuppTable);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPackageProdSuppTable;
        private System.Windows.Forms.Button btnPackageMaintenance;
        private System.Windows.Forms.Button btnSupplierMaintenance;
        private System.Windows.Forms.Button btnProdMaintenance;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPSMaintenance;
    }
}