namespace SneakerShop.Forms
{
    partial class StaffForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQuickActions = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtGeneratePass = new System.Windows.Forms.TextBox();
            this.chckInactive = new System.Windows.Forms.CheckBox();
            this.chckActive = new System.Windows.Forms.CheckBox();
            this.chckAdmin = new System.Windows.Forms.CheckBox();
            this.chckStaff = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lblQuickActions);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(12, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 358);
            this.panel1.TabIndex = 12;
            // 
            // lblQuickActions
            // 
            this.lblQuickActions.AutoSize = true;
            this.lblQuickActions.BackColor = System.Drawing.SystemColors.Info;
            this.lblQuickActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuickActions.Location = new System.Drawing.Point(15, 11);
            this.lblQuickActions.Name = "lblQuickActions";
            this.lblQuickActions.Size = new System.Drawing.Size(137, 21);
            this.lblQuickActions.TabIndex = 2;
            this.lblQuickActions.Text = "QUICK ACTIONS";
            this.lblQuickActions.Click += new System.EventHandler(this.lblQuickActions_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Image = global::SneakerShop.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(15, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 51);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.Image = global::SneakerShop.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(15, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 51);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add New";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LightYellow;
            this.btnEdit.Image = global::SneakerShop.Resources.icons8_edit_image_32;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(15, 207);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 51);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightBlue;
            this.btnSave.Image = global::SneakerShop.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(15, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 51);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearch.Location = new System.Drawing.Point(313, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(368, 27);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.Text = "Search Staff......";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(240, 64);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 19);
            this.lblSearch.TabIndex = 13;
            this.lblSearch.Text = "Search:";
            // 
            // dgvStaff
            // 
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(223, 114);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.Size = new System.Drawing.Size(524, 358);
            this.dgvStaff.TabIndex = 15;
            this.dgvStaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 35);
            this.label1.TabIndex = 16;
            this.label1.Text = "Staff Management";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.lblPass);
            this.panel2.Controls.Add(this.lblGenerate);
            this.panel2.Controls.Add(this.btnCopy);
            this.panel2.Controls.Add(this.txtGeneratePass);
            this.panel2.Controls.Add(this.chckInactive);
            this.panel2.Controls.Add(this.chckActive);
            this.panel2.Controls.Add(this.chckAdmin);
            this.panel2.Controls.Add(this.chckStaff);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.lblRole);
            this.panel2.Controls.Add(this.LblPassword);
            this.panel2.Location = new System.Drawing.Point(223, 510);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 210);
            this.panel2.TabIndex = 18;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(299, 76);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(77, 19);
            this.lblPass.TabIndex = 26;
            this.lblPass.Text = "[staff123]";
            // 
            // lblGenerate
            // 
            this.lblGenerate.AutoSize = true;
            this.lblGenerate.Location = new System.Drawing.Point(14, 76);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(255, 19);
            this.lblGenerate.TabIndex = 25;
            this.lblGenerate.Text = "☑ Generate temporary password:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(405, 72);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(78, 27);
            this.btnCopy.TabIndex = 24;
            this.btnCopy.Text = "📋 Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtGeneratePass
            // 
            this.txtGeneratePass.Location = new System.Drawing.Point(121, 42);
            this.txtGeneratePass.Name = "txtGeneratePass";
            this.txtGeneratePass.PasswordChar = '.';
            this.txtGeneratePass.ReadOnly = true;
            this.txtGeneratePass.Size = new System.Drawing.Size(159, 27);
            this.txtGeneratePass.TabIndex = 20;
            this.txtGeneratePass.TextChanged += new System.EventHandler(this.txtGeneratePass_TextChanged);
            // 
            // chckInactive
            // 
            this.chckInactive.AutoSize = true;
            this.chckInactive.Location = new System.Drawing.Point(217, 157);
            this.chckInactive.Name = "chckInactive";
            this.chckInactive.Size = new System.Drawing.Size(87, 23);
            this.chckInactive.TabIndex = 23;
            this.chckInactive.Text = "Inactive";
            this.chckInactive.UseVisualStyleBackColor = true;
            this.chckInactive.CheckedChanged += new System.EventHandler(this.chckInactive_CheckedChanged);
            // 
            // chckActive
            // 
            this.chckActive.AutoSize = true;
            this.chckActive.Location = new System.Drawing.Point(114, 157);
            this.chckActive.Name = "chckActive";
            this.chckActive.Size = new System.Drawing.Size(75, 23);
            this.chckActive.TabIndex = 22;
            this.chckActive.Text = "Active";
            this.chckActive.UseVisualStyleBackColor = true;
            this.chckActive.CheckedChanged += new System.EventHandler(this.chckActive_CheckedChanged);
            // 
            // chckAdmin
            // 
            this.chckAdmin.AutoSize = true;
            this.chckAdmin.Location = new System.Drawing.Point(217, 122);
            this.chckAdmin.Name = "chckAdmin";
            this.chckAdmin.Size = new System.Drawing.Size(77, 23);
            this.chckAdmin.TabIndex = 21;
            this.chckAdmin.Text = "Admin";
            this.chckAdmin.UseVisualStyleBackColor = true;
            this.chckAdmin.CheckedChanged += new System.EventHandler(this.chckAdmin_CheckedChanged);
            // 
            // chckStaff
            // 
            this.chckStaff.AutoSize = true;
            this.chckStaff.Location = new System.Drawing.Point(114, 122);
            this.chckStaff.Name = "chckStaff";
            this.chckStaff.Size = new System.Drawing.Size(65, 23);
            this.chckStaff.TabIndex = 20;
            this.chckStaff.Text = "Staff";
            this.chckStaff.UseVisualStyleBackColor = true;
            this.chckStaff.CheckedChanged += new System.EventHandler(this.chckStaff_CheckedChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(121, 9);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(108, 27);
            this.txtUsername.TabIndex = 16;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(14, 158);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 19);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUsername.Location = new System.Drawing.Point(14, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(88, 19);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(17, 123);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(46, 19);
            this.lblRole.TabIndex = 14;
            this.lblRole.Text = "Role:";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(14, 45);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(85, 19);
            this.LblPassword.TabIndex = 13;
            this.LblPassword.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(223, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "STAFF DETAILS";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Image = global::SneakerShop.Resources.search_more_30px;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(705, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 39);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 732);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StaffForm";
            this.Text = " 🏢 STAFF MANAGEMENT SYSTEM  ";
            this.Load += new System.EventHandler(this.StaffForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chckAdmin;
        private System.Windows.Forms.CheckBox chckStaff;
        private System.Windows.Forms.CheckBox chckInactive;
        private System.Windows.Forms.CheckBox chckActive;
        private System.Windows.Forms.TextBox txtGeneratePass;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblGenerate;
        private System.Windows.Forms.Label lblPass;
    }
}