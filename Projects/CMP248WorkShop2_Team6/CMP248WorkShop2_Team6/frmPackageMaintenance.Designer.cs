namespace CMP248WorkShop2_Team6
{
    partial class frmPackageMaintenance
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
            System.Windows.Forms.Label packageIdLabel;
            System.Windows.Forms.Label pkgAgencyCommissionLabel;
            System.Windows.Forms.Label pkgBasePriceLabel;
            System.Windows.Forms.Label pkgDescLabel;
            System.Windows.Forms.Label pkgEndDateLabel;
            System.Windows.Forms.Label pkgNameLabel;
            System.Windows.Forms.Label pkgStartDateLabel;
            this.packagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPackageId = new System.Windows.Forms.TextBox();
            this.txtPkgAgencyCommission = new System.Windows.Forms.TextBox();
            this.txtPkgBasePrice = new System.Windows.Forms.TextBox();
            this.txtPkgDesc = new System.Windows.Forms.TextBox();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.btnGetPackage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPkgEndDate = new System.Windows.Forms.TextBox();
            this.txtPkgStartDate = new System.Windows.Forms.TextBox();
            packageIdLabel = new System.Windows.Forms.Label();
            pkgAgencyCommissionLabel = new System.Windows.Forms.Label();
            pkgBasePriceLabel = new System.Windows.Forms.Label();
            pkgDescLabel = new System.Windows.Forms.Label();
            pkgEndDateLabel = new System.Windows.Forms.Label();
            pkgNameLabel = new System.Windows.Forms.Label();
            pkgStartDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.packagesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Location = new System.Drawing.Point(104, 76);
            packageIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new System.Drawing.Size(65, 13);
            packageIdLabel.TabIndex = 0;
            packageIdLabel.Text = "Package Id:";
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Location = new System.Drawing.Point(105, 262);
            pkgAgencyCommissionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new System.Drawing.Size(126, 13);
            pkgAgencyCommissionLabel.TabIndex = 13;
            pkgAgencyCommissionLabel.Text = "Pkg Agency Commission:";
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Location = new System.Drawing.Point(105, 232);
            pkgBasePriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new System.Drawing.Size(83, 13);
            pkgBasePriceLabel.TabIndex = 11;
            pkgBasePriceLabel.Text = "Pkg Base Price:";
            // 
            // pkgDescLabel
            // 
            pkgDescLabel.AutoSize = true;
            pkgDescLabel.Location = new System.Drawing.Point(105, 135);
            pkgDescLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgDescLabel.Name = "pkgDescLabel";
            pkgDescLabel.Size = new System.Drawing.Size(57, 13);
            pkgDescLabel.TabIndex = 5;
            pkgDescLabel.Text = "Pkg Desc:";
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Location = new System.Drawing.Point(105, 202);
            pkgEndDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new System.Drawing.Size(77, 13);
            pkgEndDateLabel.TabIndex = 9;
            pkgEndDateLabel.Text = "Pkg End Date:";
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Location = new System.Drawing.Point(104, 105);
            pkgNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new System.Drawing.Size(60, 13);
            pkgNameLabel.TabIndex = 3;
            pkgNameLabel.Text = "Pkg Name:";
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Location = new System.Drawing.Point(105, 168);
            pkgStartDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new System.Drawing.Size(80, 13);
            pkgStartDateLabel.TabIndex = 7;
            pkgStartDateLabel.Text = "Pkg Start Date:";
            // 
            // packagesBindingSource
            // 
            this.packagesBindingSource.DataSource = typeof(TravelData.Packages);
            // 
            // txtPackageId
            // 
            this.txtPackageId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PackageId", true));
            this.txtPackageId.Location = new System.Drawing.Point(233, 73);
            this.txtPackageId.Margin = new System.Windows.Forms.Padding(2);
            this.txtPackageId.Name = "txtPackageId";
            this.txtPackageId.Size = new System.Drawing.Size(151, 20);
            this.txtPackageId.TabIndex = 1;
            this.txtPackageId.Tag = "PackageId";
            // 
            // txtPkgAgencyCommission
            // 
            this.txtPkgAgencyCommission.BackColor = System.Drawing.SystemColors.Control;
            this.txtPkgAgencyCommission.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgAgencyCommission", true));
            this.txtPkgAgencyCommission.Location = new System.Drawing.Point(234, 259);
            this.txtPkgAgencyCommission.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgAgencyCommission.Name = "txtPkgAgencyCommission";
            this.txtPkgAgencyCommission.Size = new System.Drawing.Size(151, 20);
            this.txtPkgAgencyCommission.TabIndex = 14;
            // 
            // txtPkgBasePrice
            // 
            this.txtPkgBasePrice.BackColor = System.Drawing.SystemColors.Control;
            this.txtPkgBasePrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgBasePrice", true));
            this.txtPkgBasePrice.Location = new System.Drawing.Point(234, 229);
            this.txtPkgBasePrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgBasePrice.Name = "txtPkgBasePrice";
            this.txtPkgBasePrice.Size = new System.Drawing.Size(151, 20);
            this.txtPkgBasePrice.TabIndex = 12;
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.BackColor = System.Drawing.SystemColors.Control;
            this.txtPkgDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgDesc", true));
            this.txtPkgDesc.Location = new System.Drawing.Point(234, 132);
            this.txtPkgDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(267, 20);
            this.txtPkgDesc.TabIndex = 6;
            // 
            // txtPkgName
            // 
            this.txtPkgName.BackColor = System.Drawing.SystemColors.Control;
            this.txtPkgName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgName", true));
            this.txtPkgName.Location = new System.Drawing.Point(233, 102);
            this.txtPkgName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(151, 20);
            this.txtPkgName.TabIndex = 4;
            // 
            // btnGetPackage
            // 
            this.btnGetPackage.Location = new System.Drawing.Point(423, 72);
            this.btnGetPackage.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetPackage.Name = "btnGetPackage";
            this.btnGetPackage.Size = new System.Drawing.Size(100, 26);
            this.btnGetPackage.TabIndex = 2;
            this.btnGetPackage.Text = "Get Package";
            this.btnGetPackage.UseVisualStyleBackColor = true;
            this.btnGetPackage.Click += new System.EventHandler(this.btnGetPackage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(106, 309);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 28);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(225, 308);
            this.btnModify.Margin = new System.Windows.Forms.Padding(2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(56, 29);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(340, 309);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 28);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(454, 308);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 29);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPkgEndDate
            // 
            this.txtPkgEndDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtPkgEndDate.Location = new System.Drawing.Point(234, 199);
            this.txtPkgEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgEndDate.Name = "txtPkgEndDate";
            this.txtPkgEndDate.Size = new System.Drawing.Size(151, 20);
            this.txtPkgEndDate.TabIndex = 10;
            this.txtPkgEndDate.Tag = "Pkg End Date";
            // 
            // txtPkgStartDate
            // 
            this.txtPkgStartDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtPkgStartDate.Location = new System.Drawing.Point(234, 166);
            this.txtPkgStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgStartDate.Name = "txtPkgStartDate";
            this.txtPkgStartDate.Size = new System.Drawing.Size(151, 20);
            this.txtPkgStartDate.TabIndex = 8;
            // 
            // frmPackageMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 407);
            this.Controls.Add(this.txtPkgStartDate);
            this.Controls.Add(this.txtPkgEndDate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGetPackage);
            this.Controls.Add(packageIdLabel);
            this.Controls.Add(this.txtPackageId);
            this.Controls.Add(pkgAgencyCommissionLabel);
            this.Controls.Add(this.txtPkgAgencyCommission);
            this.Controls.Add(pkgBasePriceLabel);
            this.Controls.Add(this.txtPkgBasePrice);
            this.Controls.Add(pkgDescLabel);
            this.Controls.Add(this.txtPkgDesc);
            this.Controls.Add(pkgEndDateLabel);
            this.Controls.Add(pkgNameLabel);
            this.Controls.Add(this.txtPkgName);
            this.Controls.Add(pkgStartDateLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPackageMaintenance";
            this.Text = "frmPackageMaintenance";
            ((System.ComponentModel.ISupportInitialize)(this.packagesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource packagesBindingSource;
        private System.Windows.Forms.TextBox txtPackageId;
        private System.Windows.Forms.TextBox txtPkgAgencyCommission;
        private System.Windows.Forms.TextBox txtPkgBasePrice;
        private System.Windows.Forms.TextBox txtPkgDesc;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.Button btnGetPackage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPkgEndDate;
        private System.Windows.Forms.TextBox txtPkgStartDate;
    }
}