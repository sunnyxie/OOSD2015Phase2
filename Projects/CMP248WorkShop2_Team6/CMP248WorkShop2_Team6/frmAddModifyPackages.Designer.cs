namespace CMP248WorkShop2_Team6
{
    partial class frmAddModifyPackages
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
            System.Windows.Forms.Label pkgAgencyCommissionLabel;
            System.Windows.Forms.Label pkgBasePriceLabel;
            System.Windows.Forms.Label pkgDescLabel;
            System.Windows.Forms.Label pkgEndDateLabel;
            System.Windows.Forms.Label pkgNameLabel;
            System.Windows.Forms.Label pkgStartDateLabel;
            this.packagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPkgAgencyCommission = new System.Windows.Forms.TextBox();
            this.txtPkgBasePrice = new System.Windows.Forms.TextBox();
            this.txtPkgDesc = new System.Windows.Forms.TextBox();
            this.dtpPkgEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.dtpPkgStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            pkgAgencyCommissionLabel = new System.Windows.Forms.Label();
            pkgBasePriceLabel = new System.Windows.Forms.Label();
            pkgDescLabel = new System.Windows.Forms.Label();
            pkgEndDateLabel = new System.Windows.Forms.Label();
            pkgNameLabel = new System.Windows.Forms.Label();
            pkgStartDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.packagesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Location = new System.Drawing.Point(84, 236);
            pkgAgencyCommissionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new System.Drawing.Size(126, 13);
            pkgAgencyCommissionLabel.TabIndex = 10;
            pkgAgencyCommissionLabel.Text = "Pkg Agency Commission:";
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Location = new System.Drawing.Point(84, 201);
            pkgBasePriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new System.Drawing.Size(83, 13);
            pkgBasePriceLabel.TabIndex = 8;
            pkgBasePriceLabel.Tag = "PkhBasePrice";
            pkgBasePriceLabel.Text = "Pkg Base Price:";
            // 
            // pkgDescLabel
            // 
            pkgDescLabel.AutoSize = true;
            pkgDescLabel.Location = new System.Drawing.Point(84, 93);
            pkgDescLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgDescLabel.Name = "pkgDescLabel";
            pkgDescLabel.Size = new System.Drawing.Size(57, 13);
            pkgDescLabel.TabIndex = 2;
            pkgDescLabel.Tag = "Pkg Desc";
            pkgDescLabel.Text = "Pkg Desc:";
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Location = new System.Drawing.Point(84, 162);
            pkgEndDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new System.Drawing.Size(74, 13);
            pkgEndDateLabel.TabIndex = 6;
            pkgEndDateLabel.Tag = "PkgEndDate";
            pkgEndDateLabel.Text = "Pkg End Date";
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Location = new System.Drawing.Point(84, 64);
            pkgNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new System.Drawing.Size(60, 13);
            pkgNameLabel.TabIndex = 0;
            pkgNameLabel.Tag = "Pkg Name";
            pkgNameLabel.Text = "Pkg Name:";
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Location = new System.Drawing.Point(84, 129);
            pkgStartDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new System.Drawing.Size(80, 13);
            pkgStartDateLabel.TabIndex = 4;
            pkgStartDateLabel.Tag = "Pkg Start Date";
            pkgStartDateLabel.Text = "Pkg Start Date:";
            // 
            // packagesBindingSource
            // 
            this.packagesBindingSource.DataSource = typeof(TravelData.Packages);
            // 
            // txtPkgAgencyCommission
            // 
            this.txtPkgAgencyCommission.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgAgencyCommission", true));
            this.txtPkgAgencyCommission.Location = new System.Drawing.Point(213, 233);
            this.txtPkgAgencyCommission.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgAgencyCommission.Name = "txtPkgAgencyCommission";
            this.txtPkgAgencyCommission.Size = new System.Drawing.Size(151, 20);
            this.txtPkgAgencyCommission.TabIndex = 11;
            this.txtPkgAgencyCommission.Tag = "PkgAgencyCommission";
            // 
            // txtPkgBasePrice
            // 
            this.txtPkgBasePrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgBasePrice", true));
            this.txtPkgBasePrice.Location = new System.Drawing.Point(213, 198);
            this.txtPkgBasePrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgBasePrice.Name = "txtPkgBasePrice";
            this.txtPkgBasePrice.Size = new System.Drawing.Size(151, 20);
            this.txtPkgBasePrice.TabIndex = 9;
            this.txtPkgBasePrice.Tag = "PkgBasePrice";
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgDesc", true));
            this.txtPkgDesc.Location = new System.Drawing.Point(213, 91);
            this.txtPkgDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(151, 20);
            this.txtPkgDesc.TabIndex = 3;
            this.txtPkgDesc.Tag = "PkgDesc";
            // 
            // dtpPkgEndDate
            // 
            this.dtpPkgEndDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packagesBindingSource, "PkgEndDate", true));
            this.dtpPkgEndDate.Location = new System.Drawing.Point(213, 159);
            this.dtpPkgEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPkgEndDate.Name = "dtpPkgEndDate";
            this.dtpPkgEndDate.Size = new System.Drawing.Size(151, 20);
            this.dtpPkgEndDate.TabIndex = 7;
            // 
            // txtPkgName
            // 
            this.txtPkgName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packagesBindingSource, "PkgName", true));
            this.txtPkgName.Location = new System.Drawing.Point(213, 62);
            this.txtPkgName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(151, 20);
            this.txtPkgName.TabIndex = 1;
            this.txtPkgName.Tag = "Pkg Name";
            // 
            // dtpPkgStartDate
            // 
            this.dtpPkgStartDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packagesBindingSource, "PkgStartDate", true));
            this.dtpPkgStartDate.Location = new System.Drawing.Point(213, 126);
            this.dtpPkgStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPkgStartDate.Name = "dtpPkgStartDate";
            this.dtpPkgStartDate.Size = new System.Drawing.Size(151, 20);
            this.dtpPkgStartDate.TabIndex = 5;
            this.dtpPkgStartDate.Tag = "Pkg Start Date";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(115, 275);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(56, 29);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 275);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddModifyPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 334);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(pkgAgencyCommissionLabel);
            this.Controls.Add(this.txtPkgAgencyCommission);
            this.Controls.Add(pkgBasePriceLabel);
            this.Controls.Add(this.txtPkgBasePrice);
            this.Controls.Add(pkgDescLabel);
            this.Controls.Add(this.txtPkgDesc);
            this.Controls.Add(pkgEndDateLabel);
            this.Controls.Add(this.dtpPkgEndDate);
            this.Controls.Add(pkgNameLabel);
            this.Controls.Add(this.txtPkgName);
            this.Controls.Add(pkgStartDateLabel);
            this.Controls.Add(this.dtpPkgStartDate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddModifyPackages";
            this.Text = "frmAddModifyPackages";
            this.Load += new System.EventHandler(this.frmAddModifyPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packagesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource packagesBindingSource;
        private System.Windows.Forms.TextBox txtPkgAgencyCommission;
        private System.Windows.Forms.TextBox txtPkgBasePrice;
        private System.Windows.Forms.TextBox txtPkgDesc;
        private System.Windows.Forms.DateTimePicker dtpPkgEndDate;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.DateTimePicker dtpPkgStartDate;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}