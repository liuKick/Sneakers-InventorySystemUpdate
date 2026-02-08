using SneakerShop.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SneakerShop
{
    public partial class MainMenu : Form
    {
        private Label label1;
        private Button btnManageBrand;
        private Button btnManageCustomers;
        private Button btnMakeSale;
        private Button btnExit;
        private Button btnInventory;
        private Panel panelContainer;
        private Button btnStaff; // ADDED

        public MainMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageBrand = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnMakeSale = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnStaff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "SNEAKER SHOP MANAGEMENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManageBrand
            // 
            this.btnManageBrand.BackColor = System.Drawing.Color.LightBlue;
            this.btnManageBrand.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageBrand.Location = new System.Drawing.Point(25, 99);
            this.btnManageBrand.Name = "btnManageBrand";
            this.btnManageBrand.Size = new System.Drawing.Size(200, 60);
            this.btnManageBrand.TabIndex = 1;
            this.btnManageBrand.Text = "🏷️ Brands";
            this.btnManageBrand.UseVisualStyleBackColor = false;
            this.btnManageBrand.Click += new System.EventHandler(this.btnManageBrand_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.BackColor = System.Drawing.Color.LightBlue;
            this.btnManageCustomers.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageCustomers.Location = new System.Drawing.Point(25, 177);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(200, 60);
            this.btnManageCustomers.TabIndex = 3;
            this.btnManageCustomers.Text = "👥Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = false;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnMakeSale
            // 
            this.btnMakeSale.BackColor = System.Drawing.Color.LightBlue;
            this.btnMakeSale.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeSale.Location = new System.Drawing.Point(25, 255);
            this.btnMakeSale.Name = "btnMakeSale";
            this.btnMakeSale.Size = new System.Drawing.Size(200, 60);
            this.btnMakeSale.TabIndex = 4;
            this.btnMakeSale.Text = "💰 SALE";
            this.btnMakeSale.UseVisualStyleBackColor = false;
            this.btnMakeSale.Click += new System.EventHandler(this.btnMakeSale_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightCoral;
            this.btnExit.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(25, 489);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 60);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "🚪 Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.LightBlue;
            this.btnInventory.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(25, 333);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(200, 60);
            this.btnInventory.TabIndex = 5;
            this.btnInventory.Text = "📦 Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Location = new System.Drawing.Point(250, 79);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1017, 710);
            this.panelContainer.TabIndex = 8;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStaff.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.Location = new System.Drawing.Point(25, 410);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(200, 60);
            this.btnStaff.TabIndex = 9;
            this.btnStaff.Text = "👥 Staff";
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Visible = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // MainMenu
            // 
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1322, 801);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnMakeSale);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageBrand);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Modern No. 20", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sneaker Shop Management System";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OpenFormInPanel(Form formToOpen)
        {
            // Close current form in panel
            foreach (Control control in panelContainer.Controls)
            {
                if (control is Form)
                {
                    ((Form)control).Close();
                }
            }
            panelContainer.Controls.Clear();

            // Set up the form to open inside panel
            formToOpen.TopLevel = false;
            formToOpen.FormBorderStyle = FormBorderStyle.None;
            formToOpen.Dock = DockStyle.Fill;
            formToOpen.Visible = true;

            // Add to panel
            panelContainer.Controls.Add(formToOpen);
        }

        private void btnManageBrand_Click(object sender, EventArgs e)
        {
            BrandForm brandForm = new BrandForm();
            OpenFormInPanel(brandForm);
        }

        private void btnManageSneakers_Click(object sender, EventArgs e)
        {

        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            OpenFormInPanel(customerForm);
        }

        private void btnMakeSale_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm();
            OpenFormInPanel(saleForm);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            OpenFormInPanel(inventoryForm);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffForm staffForm = new StaffForm();
            OpenFormInPanel(staffForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Center the label
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            // Check admin access (for testing, set to true to see the button)
            CheckAdminAccess();
        }

        // ADD THIS METHOD
        public void CheckAdminAccess()
        {
            // For testing - set to true to see the Staff button
            // Replace with your actual admin check from login system
            bool isAdmin = true; // Change to false to hide the button

            btnStaff.Visible = isAdmin;
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}