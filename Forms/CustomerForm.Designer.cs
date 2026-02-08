namespace SneakerShop.Forms
{
    partial class CustomerForm
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblQuickActions = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewPurchaseHistory = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPurchaseHistoryTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPurchaseSummary = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(142, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(322, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CUSTOMER MANAGEMENT";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(26, 69);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 19);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // lblQuickActions
            // 
            this.lblQuickActions.AutoSize = true;
            this.lblQuickActions.BackColor = System.Drawing.SystemColors.Info;
            this.lblQuickActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuickActions.Location = new System.Drawing.Point(28, 9);
            this.lblQuickActions.Name = "lblQuickActions";
            this.lblQuickActions.Size = new System.Drawing.Size(137, 21);
            this.lblQuickActions.TabIndex = 2;
            this.lblQuickActions.Text = "QUICK ACTIONS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(12, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "CUSTOM DETAILS";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(109, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(328, 27);
            this.txtSearch.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btnViewPurchaseHistory);
            this.panel1.Controls.Add(this.lblQuickActions);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(12, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 365);
            this.panel1.TabIndex = 11;
            // 
            // btnViewPurchaseHistory
            // 
            this.btnViewPurchaseHistory.Image = global::SneakerShop.Resources.preview_pane_30px;
            this.btnViewPurchaseHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPurchaseHistory.Location = new System.Drawing.Point(13, 308);
            this.btnViewPurchaseHistory.Name = "btnViewPurchaseHistory";
            this.btnViewPurchaseHistory.Size = new System.Drawing.Size(168, 43);
            this.btnViewPurchaseHistory.TabIndex = 11;
            this.btnViewPurchaseHistory.Text = "View History";
            this.btnViewPurchaseHistory.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SneakerShop.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(13, 242);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 43);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::SneakerShop.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(13, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 43);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add New";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::SneakerShop.Resources.icons8_edit_image_32;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(13, 174);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 43);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SneakerShop.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(13, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 43);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.lblEmail);
            this.panel2.Controls.Add(this.lblID);
            this.panel2.Controls.Add(this.lblPhone);
            this.panel2.Controls.Add(this.LblName);
            this.panel2.Location = new System.Drawing.Point(12, 528);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 160);
            this.panel2.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(82, 108);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(166, 27);
            this.txtEmail.TabIndex = 19;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(82, 75);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(119, 27);
            this.txtPhone.TabIndex = 18;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(82, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 27);
            this.txtName.TabIndex = 17;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(82, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 27);
            this.txtID.TabIndex = 16;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 111);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblID.Location = new System.Drawing.Point(14, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(31, 19);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(14, 82);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(61, 19);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Phone:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(14, 45);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(56, 19);
            this.LblName.TabIndex = 13;
            this.LblName.Text = "Name:";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colPhone,
            this.colEmail});
            this.dgvCustomers.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCustomers.Location = new System.Drawing.Point(287, 136);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(598, 296);
            this.dgvCustomers.TabIndex = 13;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 80;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Phone";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.Width = 150;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Customer List";
            // 
            // lblPurchaseHistoryTitle
            // 
            this.lblPurchaseHistoryTitle.AutoSize = true;
            this.lblPurchaseHistoryTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblPurchaseHistoryTitle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseHistoryTitle.Location = new System.Drawing.Point(283, 444);
            this.lblPurchaseHistoryTitle.Name = "lblPurchaseHistoryTitle";
            this.lblPurchaseHistoryTitle.Size = new System.Drawing.Size(332, 24);
            this.lblPurchaseHistoryTitle.TabIndex = 16;
            this.lblPurchaseHistoryTitle.Text = "PURCHASE HISTORY - Select a customer";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.Image = global::SneakerShop.Resources.icons8_reset_32;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(564, 59);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 38);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Image = global::SneakerShop.Resources.search_more_30px;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(443, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 39);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colProductName,
            this.colQuantity,
            this.colPrice,
            this.colSubTotal});
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(287, 481);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.RowHeadersWidth = 51;
            this.dgvPurchaseHistory.RowTemplate.Height = 24;
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(598, 182);
            this.dgvPurchaseHistory.TabIndex = 12;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Sale Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.Width = 120;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "ProductName";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 125;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 80;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 125;
            // 
            // colSubTotal
            // 
            this.colSubTotal.HeaderText = "Sub Total";
            this.colSubTotal.MinimumWidth = 6;
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.Width = 125;
            // 
            // lblPurchaseSummary
            // 
            this.lblPurchaseSummary.AutoSize = true;
            this.lblPurchaseSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblPurchaseSummary.Location = new System.Drawing.Point(287, 666);
            this.lblPurchaseSummary.Name = "lblPurchaseSummary";
            this.lblPurchaseSummary.Size = new System.Drawing.Size(288, 19);
            this.lblPurchaseSummary.TabIndex = 17;
            this.lblPurchaseSummary.Text = "Total Purchases: 0 | Total Spent: $0.00";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(919, 785);
            this.Controls.Add(this.lblPurchaseSummary);
            this.Controls.Add(this.dgvPurchaseHistory);
            this.Controls.Add(this.lblPurchaseHistoryTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPurchaseHistoryTitle;
        private System.Windows.Forms.Button btnViewPurchaseHistory;
        private System.Windows.Forms.DataGridView dgvPurchaseHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.Label lblPurchaseSummary;
    }
}