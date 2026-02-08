namespace SneakerShop.Forms
{
    partial class BrandForm
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
            this.lblBrandManagement = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblQuickActions = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlQuickActions = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCreateedAt = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.dgvBrands = new System.Windows.Forms.DataGridView();
            this.pnlQuickActions.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrandManagement
            // 
            this.lblBrandManagement.AutoSize = true;
            this.lblBrandManagement.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblBrandManagement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBrandManagement.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandManagement.Location = new System.Drawing.Point(144, 9);
            this.lblBrandManagement.Name = "lblBrandManagement";
            this.lblBrandManagement.Size = new System.Drawing.Size(280, 35);
            this.lblBrandManagement.TabIndex = 0;
            this.lblBrandManagement.Text = "Brand Management";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(30, 72);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(59, 17);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(109, 69);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(211, 25);
            this.txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Image = global::SneakerShop.Resources.search_more_30px;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(326, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 39);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.Image = global::SneakerShop.Resources.icons8_reset_32;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(444, 62);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 38);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // lblQuickActions
            // 
            this.lblQuickActions.AutoSize = true;
            this.lblQuickActions.BackColor = System.Drawing.SystemColors.Info;
            this.lblQuickActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuickActions.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickActions.Location = new System.Drawing.Point(13, 0);
            this.lblQuickActions.Name = "lblQuickActions";
            this.lblQuickActions.Size = new System.Drawing.Size(137, 21);
            this.lblQuickActions.TabIndex = 8;
            this.lblQuickActions.Text = "QUICK ACTIONS";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SneakerShop.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(28, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 43);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::SneakerShop.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(28, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 43);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add New";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::SneakerShop.Resources.icons8_edit_image_32;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(28, 168);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 43);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SneakerShop.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(28, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 43);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pnlQuickActions
            // 
            this.pnlQuickActions.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlQuickActions.Controls.Add(this.lblQuickActions);
            this.pnlQuickActions.Controls.Add(this.btnDelete);
            this.pnlQuickActions.Controls.Add(this.btnSave);
            this.pnlQuickActions.Controls.Add(this.btnAdd);
            this.pnlQuickActions.Controls.Add(this.btnEdit);
            this.pnlQuickActions.Location = new System.Drawing.Point(12, 130);
            this.pnlQuickActions.Name = "pnlQuickActions";
            this.pnlQuickActions.Size = new System.Drawing.Size(167, 295);
            this.pnlQuickActions.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(102, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "BRAND INPUT";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(19, 36);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(69, 17);
            this.lblBrand.TabIndex = 17;
            this.lblBrand.Text = "Brand ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(94, 17);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Brand Name:";
            // 
            // lblCreateedAt
            // 
            this.lblCreateedAt.AutoSize = true;
            this.lblCreateedAt.Location = new System.Drawing.Point(19, 113);
            this.lblCreateedAt.Name = "lblCreateedAt";
            this.lblCreateedAt.Size = new System.Drawing.Size(80, 17);
            this.lblCreateedAt.TabIndex = 19;
            this.lblCreateedAt.Text = "Created At:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(126, 33);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(124, 25);
            this.txtID.TabIndex = 20;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 72);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 25);
            this.txtName.TabIndex = 21;
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.Location = new System.Drawing.Point(126, 110);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(153, 25);
            this.txtCreatedAt.TabIndex = 22;
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlBrand.Controls.Add(this.label4);
            this.pnlBrand.Controls.Add(this.txtCreatedAt);
            this.pnlBrand.Controls.Add(this.lblBrand);
            this.pnlBrand.Controls.Add(this.txtName);
            this.pnlBrand.Controls.Add(this.lblName);
            this.pnlBrand.Controls.Add(this.txtID);
            this.pnlBrand.Controls.Add(this.lblCreateedAt);
            this.pnlBrand.Location = new System.Drawing.Point(12, 441);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(324, 149);
            this.pnlBrand.TabIndex = 23;
            // 
            // dgvBrands
            // 
            this.dgvBrands.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrands.Location = new System.Drawing.Point(206, 130);
            this.dgvBrands.Name = "dgvBrands";
            this.dgvBrands.RowHeadersWidth = 51;
            this.dgvBrands.RowTemplate.Height = 24;
            this.dgvBrands.Size = new System.Drawing.Size(425, 295);
            this.dgvBrands.TabIndex = 24;
            this.dgvBrands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // BrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(708, 609);
            this.Controls.Add(this.dgvBrands);
            this.Controls.Add(this.pnlBrand);
            this.Controls.Add(this.pnlQuickActions);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblBrandManagement);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BrandForm";
            this.Text = "Brand Management";
            this.Load += new System.EventHandler(this.BrandForm_Load);
            this.pnlQuickActions.ResumeLayout(false);
            this.pnlQuickActions.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrandManagement;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlQuickActions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCreateedAt;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCreatedAt;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.DataGridView dgvBrands;
    }
}