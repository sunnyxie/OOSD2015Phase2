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
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.btnGetSupplier = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lsbProducts = new System.Windows.Forms.ListBox();
            this.lsbAllProducts = new System.Windows.Forms.ListBox();
            this.btnModifyProd = new System.Windows.Forms.Button();
            this.DropLocationLabel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            supplierIdLabel = new System.Windows.Forms.Label();
            supNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Location = new System.Drawing.Point(85, 45);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(79, 17);
            supplierIdLabel.TabIndex = 0;
            supplierIdLabel.Text = "Supplier Id:";
            // 
            // supNameLabel
            // 
            supNameLabel.AutoSize = true;
            supNameLabel.Location = new System.Drawing.Point(88, 93);
            supNameLabel.Name = "supNameLabel";
            supNameLabel.Size = new System.Drawing.Size(78, 17);
            supNameLabel.TabIndex = 3;
            supNameLabel.Text = "Sup Name:";
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupplierId", true));
            this.txtSupplierId.Location = new System.Drawing.Point(209, 45);
            this.txtSupplierId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(72, 22);
            this.txtSupplierId.TabIndex = 1;
            this.txtSupplierId.Tag = "Supplier Id";
            // 
            // txtSupName
            // 
            this.txtSupName.BackColor = System.Drawing.SystemColors.Control;
            this.txtSupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "SupName", true));
            this.txtSupName.Location = new System.Drawing.Point(211, 88);
            this.txtSupName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(217, 22);
            this.txtSupName.TabIndex = 4;
            // 
            // btnGetSupplier
            // 
            this.btnGetSupplier.Location = new System.Drawing.Point(325, 39);
            this.btnGetSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetSupplier.Name = "btnGetSupplier";
            this.btnGetSupplier.Size = new System.Drawing.Size(101, 34);
            this.btnGetSupplier.TabIndex = 2;
            this.btnGetSupplier.Text = "Get Supplier";
            this.btnGetSupplier.UseVisualStyleBackColor = true;
            this.btnGetSupplier.Click += new System.EventHandler(this.btnGetSupplier_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(93, 141);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 33);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(210, 142);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 33);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(314, 142);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 33);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(417, 145);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lsbProducts
            // 
            this.lsbProducts.FormattingEnabled = true;
            this.lsbProducts.ItemHeight = 16;
            this.lsbProducts.Location = new System.Drawing.Point(73, 271);
            this.lsbProducts.Name = "lsbProducts";
            this.lsbProducts.Size = new System.Drawing.Size(271, 164);
            this.lsbProducts.TabIndex = 9;
            this.lsbProducts.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbProducts_DragDrop);
            this.lsbProducts.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsbProducts_DragEnter);
            this.lsbProducts.DragOver += new System.Windows.Forms.DragEventHandler(this.lsbProducts_DragOver);
            this.lsbProducts.DragLeave += new System.EventHandler(this.lsbProducts_DragLeave);
            this.lsbProducts.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.lsbProducts_QueryContinueDrag);
            this.lsbProducts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsbProducts_MouseDown);
            this.lsbProducts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lsbProducts_MouseMove);
            this.lsbProducts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lsbProducts_MouseUp);
            // 
            // lsbAllProducts
            // 
            this.lsbAllProducts.FormattingEnabled = true;
            this.lsbAllProducts.ItemHeight = 16;
            this.lsbAllProducts.Location = new System.Drawing.Point(380, 225);
            this.lsbAllProducts.Name = "lsbAllProducts";
            this.lsbAllProducts.Size = new System.Drawing.Size(345, 212);
            this.lsbAllProducts.TabIndex = 10;
            this.lsbAllProducts.Visible = false;
            this.lsbAllProducts.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbAllProducts_DragDrop);
            this.lsbAllProducts.DragOver += new System.Windows.Forms.DragEventHandler(this.lsbAllProducts_DragOver);
            this.lsbAllProducts.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.lsbAllProducts_GiveFeedback);
            this.lsbAllProducts.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.lsbAllProducts_QueryContinueDrag);
            this.lsbAllProducts.DoubleClick += new System.EventHandler(this.lsbAllProducts_DoubleClick);
            this.lsbAllProducts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsbAllProducts_MouseDown);
            this.lsbAllProducts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lsbAllProducts_MouseMove);
            this.lsbAllProducts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lsbAllProducts_MouseUp);
            // 
            // btnModifyProd
            // 
            this.btnModifyProd.Enabled = false;
            this.btnModifyProd.Location = new System.Drawing.Point(138, 458);
            this.btnModifyProd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModifyProd.Name = "btnModifyProd";
            this.btnModifyProd.Size = new System.Drawing.Size(114, 33);
            this.btnModifyProd.TabIndex = 11;
            this.btnModifyProd.Text = "ModifyProducts";
            this.btnModifyProd.UseVisualStyleBackColor = true;
            this.btnModifyProd.Click += new System.EventHandler(this.btnModifyProd_Click);
            // 
            // DropLocationLabel
            // 
            this.DropLocationLabel.AutoSize = true;
            this.DropLocationLabel.Location = new System.Drawing.Point(638, 39);
            this.DropLocationLabel.Name = "DropLocationLabel";
            this.DropLocationLabel.Size = new System.Drawing.Size(0, 17);
            this.DropLocationLabel.TabIndex = 12;
            this.DropLocationLabel.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(278, 458);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(135, 225);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(239, 17);
            this.lblMsg.TabIndex = 14;
            this.lblMsg.Text = "<<Please use mouse Drag && Drop>>";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(TravelData.Supplier);
            // 
            // frmSupplierMaintenance
            // 
            this.AcceptButton = this.btnGetSupplier;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 502);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DropLocationLabel);
            this.Controls.Add(this.btnModifyProd);
            this.Controls.Add(this.lsbAllProducts);
            this.Controls.Add(this.lsbProducts);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGetSupplier);
            this.Controls.Add(supNameLabel);
            this.Controls.Add(this.txtSupName);
            this.Controls.Add(supplierIdLabel);
            this.Controls.Add(this.txtSupplierId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSupplierMaintenance";
            this.Text = "frmSupplierMaintenance";
            this.Load += new System.EventHandler(this.frmSupplierMaintenance_Load);
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
        private System.Windows.Forms.ListBox lsbProducts;
        private System.Windows.Forms.ListBox lsbAllProducts;
        private System.Windows.Forms.Button btnModifyProd;
        private System.Windows.Forms.Label DropLocationLabel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMsg;
    }
}