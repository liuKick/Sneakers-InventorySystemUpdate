using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakerShop.Forms
{
    public partial class CustomerForm : Form
    {
        private BindingList<Customer> customers;
        private bool isEditing = false;
        private Customer currentCustomer = null;

        public CustomerForm()
        {
            InitializeComponent();
            SupabaseClient.Initialize();
            customers = new BindingList<Customer>();

            // FIXED EVENT HANDLERS
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Add purchase history button event
            this.btnViewPurchaseHistory.Click += new System.EventHandler(this.btnViewPurchaseHistory_Click);
        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
            SetupDataGridView();
            SetupPurchaseHistoryGridView();
            ResetForm();
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Customer>().Get();
                var customerList = response.Models.ToList();
                customers = new BindingList<Customer>(customerList);
                dgvCustomers.DataSource = customers;

                // Debug output to verify loading
                Console.WriteLine($"DEBUG: Loaded {customers.Count} customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"  - {customer.name}: UUID={customer.customer_id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error");
            }
        }

        private void SetupDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            // Add sequential number column as the first column
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colNumber",
                HeaderText = "No.",
                Width = 50,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Customer ID column (hidden - shows UUID if needed for debugging)
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCustomerId",
                DataPropertyName = "customer_id",
                HeaderText = "Customer ID",
                Width = 120,
                Visible = false
            });

            // Name column
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                DataPropertyName = "name",
                HeaderText = "Name",
                Width = 150
            });

            // Phone column
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPhone",
                DataPropertyName = "phone",
                HeaderText = "Phone",
                Width = 120
            });

            // Email column
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEmail",
                DataPropertyName = "email",
                HeaderText = "Email",
                Width = 200
            });

            // Created At column
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCreatedAt",
                DataPropertyName = "created_at",
                HeaderText = "Created Date",
                Width = 120
            });

            // Add row numbering event
            dgvCustomers.RowPostPaint += (sender, e) =>
            {
                var grid = sender as DataGridView;
                if (grid != null && e.RowIndex >= 0 && e.RowIndex < grid.Rows.Count)
                {
                    var row = grid.Rows[e.RowIndex];
                    row.Cells["colNumber"].Value = (e.RowIndex + 1).ToString();
                }
            };

            // Remove auto-generated UUID column if it appears
            dgvCustomers.DataBindingComplete += (sender, e) =>
            {
                if (dgvCustomers.Columns.Contains("Id"))
                {
                    dgvCustomers.Columns["Id"].Visible = false;
                }
                if (dgvCustomers.Columns.Contains("CustomerId"))
                {
                    dgvCustomers.Columns["CustomerId"].Visible = false;
                }
            };
        }

        private void SetupPurchaseHistoryGridView()
        {
            dgvPurchaseHistory.AutoGenerateColumns = false;
            dgvPurchaseHistory.Columns.Clear();

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SaleDate",
                HeaderText = "Sale Date",
                Width = 120
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductName",
                HeaderText = "Product",
                Width = 150
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "Qty",
                Width = 60
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Unit Price",
                Width = 80
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SubTotal",
                HeaderText = "Subtotal",
                Width = 80
            });

            dgvPurchaseHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Total Sale",
                Width = 90
            });
        }

        private void ResetForm()
        {
            txtID.Text = Guid.NewGuid().ToString();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            isEditing = false;
            currentCustomer = null;
            btnSave.Text = "Save";

            // Clear purchase history
            dgvPurchaseHistory.DataSource = null;
            lblPurchaseHistoryTitle.Text = "PURCHASE HISTORY - Select a customer";
            UpdatePurchaseSummary(0, 0);
        }

        // ✅ ADDED: COMPLETE REFRESH METHOD
        private async Task RefreshFormAsync()  // CHANGED to async Task
        {
            try
            {
                // 1. Clear all data and reset form
                ResetForm();

                // 2. Clear selection in DataGridView
                dgvCustomers.ClearSelection();
                dgvPurchaseHistory.DataSource = null;

                // 3. Reset search
                txtSearch.Clear();

                // 4. Reload customers from database - FIXED: Added await
                await LoadCustomersAsync();

                // 5. Reset purchase history display
                lblPurchaseHistoryTitle.Text = "PURCHASE HISTORY - Select a customer";
                UpdatePurchaseSummary(0, 0);

                // 6. Force UI refresh
                this.Refresh();

                MessageBox.Show("Form refreshed successfully!", "Refresh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing form: {ex.Message}", "Error");
            }
        }

        private void UpdatePurchaseSummary(int totalPurchases, decimal totalSpent)
        {
            lblPurchaseSummary.Text = $"Total Purchases: {totalPurchases} | Total Spent: ${totalSpent:F2}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                if (isEditing && currentCustomer != null)
                {
                    // Update using lowercase property names
                    currentCustomer.name = txtName.Text;
                    currentCustomer.phone = txtPhone.Text;
                    currentCustomer.email = txtEmail.Text;

                    await SupabaseClient.Client.From<Customer>()
                        .Where(c => c.customer_id == currentCustomer.customer_id)
                        .Update(currentCustomer);

                    MessageBox.Show("Customer updated successfully!", "Success");
                }
                else
                {
                    var customer = new Customer
                    {
                        customer_id = txtID.Text,
                        name = txtName.Text,
                        phone = txtPhone.Text,
                        email = txtEmail.Text
                    };

                    await SupabaseClient.Client.From<Customer>().Insert(customer);
                    MessageBox.Show("Customer added successfully!", "Success");
                }

                await LoadCustomersAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
            {
                currentCustomer = selectedCustomer;
                isEditing = true;
                txtID.Text = selectedCustomer.customer_id;
                txtName.Text = selectedCustomer.name;
                txtPhone.Text = selectedCustomer.phone;
                txtEmail.Text = selectedCustomer.email;
                btnSave.Text = "Update";

                // Load purchase history for this customer
                _ = LoadCustomerPurchaseHistory(selectedCustomer.customer_id);  // Using discard operator
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
            {
                if (MessageBox.Show($"Delete {selectedCustomer.name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await SupabaseClient.Client.From<Customer>()
                        .Where(c => c.customer_id == selectedCustomer.customer_id)
                        .Delete();

                    await LoadCustomersAsync();
                    ResetForm();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                dgvCustomers.DataSource = customers;
                return;
            }

            var filtered = customers.Where(c =>
                (c.name?.ToLower() ?? "").Contains(searchTerm) ||
                (c.phone?.Contains(searchTerm) ?? false) ||
                (c.email?.ToLower() ?? "").Contains(searchTerm)
            ).ToList();

            dgvCustomers.DataSource = new BindingList<Customer>(filtered);
        }

        // ✅ FIXED: REFRESH BUTTON - Added async/await properly
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshFormAsync();  // FIXED: Added await
        }

        private async void btnViewPurchaseHistory_Click(object sender, EventArgs e)
        {
            if (currentCustomer != null)
            {
                await LoadCustomerPurchaseHistory(currentCustomer.customer_id);  // FIXED: Added await
            }
            else if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
            {
                currentCustomer = selectedCustomer;
                await LoadCustomerPurchaseHistory(selectedCustomer.customer_id);  // FIXED: Added await
            }
            else
            {
                MessageBox.Show("Please select a customer to view purchase history.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task LoadCustomerPurchaseHistory(string customerId)
        {
            try
            {
                // Clear previous data first
                dgvPurchaseHistory.DataSource = null;

                // Get all sales for this customer
                var salesResponse = await SupabaseClient.Client.From<Sale>()
                    .Where(s => s.CustomerId == customerId)
                    .Get();

                var sales = salesResponse.Models.ToList();

                var purchaseHistory = new List<PurchaseHistoryItem>();
                decimal totalSpent = 0;

                foreach (var sale in sales)
                {
                    // Get sale details for each sale
                    var detailsResponse = await SupabaseClient.Client.From<SaleDetail>()
                        .Where(sd => sd.SaleId == sale.Id)
                        .Get();

                    var saleDetails = detailsResponse.Models.ToList();

                    foreach (var detail in saleDetails)
                    {
                        // Get sneaker info
                        var sneakerResponse = await SupabaseClient.Client.From<Sneaker>()
                            .Where(sn => sn.Id == detail.SneakerId)
                            .Get();

                        var sneaker = sneakerResponse.Models.FirstOrDefault();

                        // FIX: Use the values directly (no null checking needed for decimal)
                        decimal unitPrice = detail.UnitPrice ?? 0;
                        decimal subTotal = detail.SubTotal ?? 0;
                        decimal totalAmount = sale.TotalAmount;

                        // If unit price is 0 but we have quantity and subtotal, calculate it
                        if (unitPrice == 0 && detail.Quantity > 0 && subTotal > 0)
                        {
                            unitPrice = subTotal / detail.Quantity;
                        }

                        var historyItem = new PurchaseHistoryItem
                        {
                            SaleDate = sale.Date,
                            ProductName = sneaker?.Name ?? "Unknown Product",
                            Quantity = detail.Quantity,
                            UnitPrice = unitPrice,
                            SubTotal = subTotal,
                            TotalAmount = totalAmount
                        };

                        purchaseHistory.Add(historyItem);
                        totalSpent += subTotal;
                    }
                }

                // Display purchase history
                dgvPurchaseHistory.DataSource = purchaseHistory;
                lblPurchaseHistoryTitle.Text = $"PURCHASE HISTORY - {currentCustomer?.name} ({purchaseHistory.Count} purchases)";
                UpdatePurchaseSummary(purchaseHistory.Count, totalSpent);

                if (purchaseHistory.Count == 0)
                {
                    MessageBox.Show("No purchase history found for this customer.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading purchase history: {ex.Message}", "Error");
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter name.", "Error");
                return false;
            }
            return true;
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (!isEditing && dgvCustomers.CurrentRow?.DataBoundItem is Customer customer)
            {
                txtID.Text = customer.customer_id;
                txtName.Text = customer.name;
                txtPhone.Text = customer.phone;
                txtEmail.Text = customer.email;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
    }

    // Purchase History Item class for display
    public class PurchaseHistoryItem
    {
        public DateTime SaleDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalAmount { get; set; }
    }
}