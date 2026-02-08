namespace SneakerShop.Forms
{
    partial class InventoryForm
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
            this.lblInventoryManagement = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblQuickActions = new System.Windows.Forms.Label();
            this.pnlQuickActions = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblInventoryDetails = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInventoryList = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblStockQuantity = new System.Windows.Forms.Label();
            this.txtProductsID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlQuickActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInventoryManagement
            // 
            this.lblInventoryManagement.AutoSize = true;
            this.lblInventoryManagement.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblInventoryManagement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInventoryManagement.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryManagement.Location = new System.Drawing.Point(18, 6);
            this.lblInventoryManagement.Name = "lblInventoryManagement";
            this.lblInventoryManagement.Size = new System.Drawing.Size(391, 35);
            this.lblInventoryManagement.TabIndex = 0;
            this.lblInventoryManagement.Text = "INVENTORY MANAGEMENT";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(14, 57);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(59, 17);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(79, 55);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(216, 25);
            this.txtsearch.TabIndex = 2;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblQuickActions
            // 
            this.lblQuickActions.AutoSize = true;
            this.lblQuickActions.BackColor = System.Drawing.SystemColors.Info;
            this.lblQuickActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuickActions.Location = new System.Drawing.Point(13, 0);
            this.lblQuickActions.Name = "lblQuickActions";
            this.lblQuickActions.Size = new System.Drawing.Size(123, 19);
            this.lblQuickActions.TabIndex = 5;
            this.lblQuickActions.Text = "QUICK ACTIONS";
            this.lblQuickActions.Click += new System.EventHandler(this.lblQuickActions_Click);
            // 
            // pnlQuickActions
            // 
            this.pnlQuickActions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlQuickActions.Controls.Add(this.lblQuickActions);
            this.pnlQuickActions.Controls.Add(this.btnExport);
            this.pnlQuickActions.Controls.Add(this.btnAdd);
            this.pnlQuickActions.Controls.Add(this.btnDelete);
            this.pnlQuickActions.Controls.Add(this.btnSave);
            this.pnlQuickActions.Controls.Add(this.btnEdit);
            this.pnlQuickActions.Location = new System.Drawing.Point(11, 113);
            this.pnlQuickActions.Name = "pnlQuickActions";
            this.pnlQuickActions.Size = new System.Drawing.Size(154, 327);
            this.pnlQuickActions.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::SneakerShop.Resources.Export;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(10, 199);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 38);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::SneakerShop.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(10, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 38);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add New";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SneakerShop.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(10, 265);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 38);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SneakerShop.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(10, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 38);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::SneakerShop.Resources.icons8_edit_image_32;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(10, 140);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 38);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblInventoryDetails
            // 
            this.lblInventoryDetails.AutoSize = true;
            this.lblInventoryDetails.BackColor = System.Drawing.SystemColors.Info;
            this.lblInventoryDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInventoryDetails.Location = new System.Drawing.Point(130, 443);
            this.lblInventoryDetails.Name = "lblInventoryDetails";
            this.lblInventoryDetails.Size = new System.Drawing.Size(156, 19);
            this.lblInventoryDetails.TabIndex = 14;
            this.lblInventoryDetails.Text = "INVENTORY DETAILS";
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colBrand,
            this.colSize,
            this.colColor,
            this.colPrice,
            this.colSalePrice,
            this.colStock});
            this.dgvInventory.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInventory.Location = new System.Drawing.Point(182, 132);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(773, 309);
            this.dgvInventory.TabIndex = 15;
            this.dgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellClick);
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ProductID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 125;
            // 
            // colName
            // 
            this.colName.HeaderText = "ProductName";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Brand";
            this.colBrand.MinimumWidth = 6;
            this.colBrand.Name = "colBrand";
            this.colBrand.Width = 80;
            // 
            // colSize
            // 
            this.colSize.HeaderText = "Size";
            this.colSize.MinimumWidth = 6;
            this.colSize.Name = "colSize";
            this.colSize.Width = 50;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Color";
            this.colColor.MinimumWidth = 6;
            this.colColor.Name = "colColor";
            this.colColor.Width = 70;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 125;
            // 
            // colSalePrice
            // 
            this.colSalePrice.HeaderText = "Sale Price";
            this.colSalePrice.MinimumWidth = 6;
            this.colSalePrice.Name = "colSalePrice";
            this.colSalePrice.ReadOnly = true;
            this.colSalePrice.Width = 125;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Stock";
            this.colStock.MinimumWidth = 6;
            this.colStock.Name = "colStock";
            this.colStock.Width = 125;
            // 
            // lblInventoryList
            // 
            this.lblInventoryList.AutoSize = true;
            this.lblInventoryList.BackColor = System.Drawing.SystemColors.Info;
            this.lblInventoryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInventoryList.Location = new System.Drawing.Point(412, 110);
            this.lblInventoryList.Name = "lblInventoryList";
            this.lblInventoryList.Size = new System.Drawing.Size(127, 19);
            this.lblInventoryList.TabIndex = 16;
            this.lblInventoryList.Text = "INVENTORY LIST";
            this.lblInventoryList.Click += new System.EventHandler(this.lblInventoryList_Click);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(9, 16);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(81, 17);
            this.lblProductID.TabIndex = 17;
            this.lblProductID.Text = "Product ID:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(273, 18);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(51, 17);
            this.lblProductName.TabIndex = 18;
            this.lblProductName.Text = "Name:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(546, 20);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(51, 17);
            this.lblBrand.TabIndex = 19;
            this.lblBrand.Text = "Brand:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(34, 65);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(47, 17);
            this.lblColor.TabIndex = 20;
            this.lblColor.Text = "Color:";
            // 
            // lblStockQuantity
            // 
            this.lblStockQuantity.AutoSize = true;
            this.lblStockQuantity.Location = new System.Drawing.Point(10, 99);
            this.lblStockQuantity.Name = "lblStockQuantity";
            this.lblStockQuantity.Size = new System.Drawing.Size(107, 17);
            this.lblStockQuantity.TabIndex = 21;
            this.lblStockQuantity.Text = "Stock Quantity:";
            // 
            // txtProductsID
            // 
            this.txtProductsID.Location = new System.Drawing.Point(124, 15);
            this.txtProductsID.Name = "txtProductsID";
            this.txtProductsID.ReadOnly = true;
            this.txtProductsID.Size = new System.Drawing.Size(106, 25);
            this.txtProductsID.TabIndex = 22;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(347, 15);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(116, 25);
            this.txtProductName.TabIndex = 23;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(643, 18);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(116, 25);
            this.cmbBrand.TabIndex = 24;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(283, 60);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(41, 17);
            this.lblSize.TabIndex = 25;
            this.lblSize.Text = "Size:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(347, 57);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(71, 25);
            this.txtSize.TabIndex = 26;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(124, 57);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(106, 25);
            this.txtColor.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.txtSalePrice);
            this.panel1.Controls.Add(this.lblSalePrice);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblProductID);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Controls.Add(this.lblColor);
            this.panel1.Controls.Add(this.txtColor);
            this.panel1.Controls.Add(this.lblStockQuantity);
            this.panel1.Controls.Add(this.txtSize);
            this.panel1.Controls.Add(this.txtProductsID);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.cmbBrand);
            this.panel1.Location = new System.Drawing.Point(11, 464);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 146);
            this.panel1.TabIndex = 29;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(643, 99);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(90, 25);
            this.txtSalePrice.TabIndex = 36;
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Location = new System.Drawing.Point(546, 102);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(79, 17);
            this.lblSalePrice.TabIndex = 35;
            this.lblSalePrice.Text = "Sale Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(643, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(90, 25);
            this.txtPrice.TabIndex = 34;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(347, 96);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(169, 25);
            this.txtStatus.TabIndex = 32;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(546, 60);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(91, 17);
            this.lblPrice.TabIndex = 33;
            this.lblPrice.Text = "Import Price:";
            this.lblPrice.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(270, 99);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.TabIndex = 31;
            this.lblStatus.Text = "Status:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(124, 97);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(106, 25);
            this.numericUpDown1.TabIndex = 30;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Image = global::SneakerShop.Resources.icons8_reset_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(434, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Refresh";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSearch.Image = global::SneakerShop.Resources.search_more_30px;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(332, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(982, 616);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInventoryList);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.lblInventoryDetails);
            this.Controls.Add(this.pnlQuickActions);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblInventoryManagement);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InventoryForm";
            this.Text = "Inventory Management";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            this.pnlQuickActions.ResumeLayout(false);
            this.pnlQuickActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInventoryManagement;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlQuickActions;
        private System.Windows.Forms.Label lblInventoryDetails;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Label lblInventoryList;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblStockQuantity;
        private System.Windows.Forms.TextBox txtProductsID;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
    }
}