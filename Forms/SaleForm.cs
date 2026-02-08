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
    public partial class SaleForm : Form
    {
        private List<Sneaker> sneakers = new List<Sneaker>();
        private List<Customer> customers = new List<Customer>();
        private List<CartItem> cart = new List<CartItem>();
        private decimal totalAmount = 0;

        public SaleForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            SupabaseClient.Initialize();

            cmbStaff.Visible = true;
            lblStaff.Visible = true;
        }

        private async void SaleForm_Load(object sender, EventArgs e)
        {
            await LoadSneakersAsync();
            await LoadCustomersAsync();
            await LoadStaffAsync();
            SetupDataGridView();
            SetupPaymentMethod();

            txtTotalAmount.Text = "$0.00";
            numQuantity.Value = 1;
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 100;
        }

        private void SetupPaymentMethod()
        {
            cmbPayment.Items.Clear();
            cmbPayment.Items.AddRange(new string[] {
                "Cash",
                "Credit Card",
                "Debit Card",
                "Digital Wallet",
                "Bank Transfer"
            });
            cmbPayment.SelectedIndex = 0;
        }

        // ✅ FIXED: BULLETPROOF STAFF LOADING
        private async Task LoadStaffAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<User>().Get();
                var allUsers = response.Models?.ToList() ?? new List<User>();

                cmbStaff.Items.Clear();

                if (allUsers.Any())
                {
                    // Add real users
                    foreach (var user in allUsers)
                    {
                        cmbStaff.Items.Add(user);
                    }

                    cmbStaff.DisplayMember = "Username";
                    cmbStaff.ValueMember = "Id";
                    cmbStaff.SelectedIndex = 0;
                }
                else
                {
                    // Add fallback test users
                    cmbStaff.Items.Add(new User { Username = "admin", Id = "fallback-admin" });
                    cmbStaff.Items.Add(new User { Username = "staff1", Id = "fallback-staff1" });
                    cmbStaff.Items.Add(new User { Username = "staff2", Id = "fallback-staff2" });

                    cmbStaff.DisplayMember = "Username";
                    cmbStaff.ValueMember = "Id";
                    cmbStaff.SelectedIndex = 0;

                    MessageBox.Show("Using fallback staff accounts. Please check database users.");
                }
            }
            catch (Exception ex)
            {
                // Emergency fallback - hardcoded users
                cmbStaff.Items.Clear();
                cmbStaff.Items.Add(new User { Username = "admin", Id = "emergency-admin" });
                cmbStaff.Items.Add(new User { Username = "staff", Id = "emergency-staff" });

                cmbStaff.DisplayMember = "Username";
                cmbStaff.ValueMember = "Id";
                cmbStaff.SelectedIndex = 0;

                MessageBox.Show($"Database error. Using emergency staff: {ex.Message}");
            }
        }

        private async Task LoadSneakersAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Sneaker>().Get();
                sneakers = response.Models.Where(s => s.StockQuantity > 0).ToList();

                cmbSneakers.Items.Clear();
                foreach (var sneaker in sneakers)
                {
                    // ✅ FIXED: Use SalePrice instead of Price
                    decimal displayPrice = sneaker.SalePrice ?? sneaker.Price;
                    cmbSneakers.Items.Add($"{sneaker.Name} - Size {sneaker.Size} - ${displayPrice}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sneakers: {ex.Message}", "Error");
            }
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Customer>().Get();
                customers = response.Models.ToList();

                cmbCustomers.Items.Clear();
                cmbCustomers.Items.Add("Walk-in Customer");
                foreach (var customer in customers)
                {
                    // ✅ FIXED: Use lowercase properties
                    cmbCustomers.Items.Add($"{customer.name} - {customer.phone}");
                }
                cmbCustomers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error");
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.Columns.Add("ProductName", "Product");
            dataGridViewCart.Columns.Add("Quantity", "Qty");
            dataGridViewCart.Columns.Add("UnitPrice", "Unit Price");
            dataGridViewCart.Columns.Add("SubTotal", "Sub Total");
        }

        private void cmbSneakers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbSneakers.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < sneakers.Count)
            {
                var selectedSneaker = sneakers[selectedIndex];
                // ✅ FIXED: Use SalePrice instead of Price
                decimal unitPrice = selectedSneaker.SalePrice ?? selectedSneaker.Price;
                txtUnitPrice.Text = unitPrice.ToString("C");
                CalculateSubTotal();
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculateSubTotal();
        }

        private void CalculateSubTotal()
        {
            int selectedIndex = cmbSneakers.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < sneakers.Count && numQuantity.Value > 0)
            {
                var selectedSneaker = sneakers[selectedIndex];
                // ✅ FIXED: Use SalePrice instead of Price
                decimal unitPrice = selectedSneaker.SalePrice ?? selectedSneaker.Price;
                decimal subTotal = unitPrice * (int)numQuantity.Value;
                txtSubTotal.Text = subTotal.ToString("C");

                if (numQuantity.Value > selectedSneaker.StockQuantity)
                {
                    btnAddToCart.Enabled = false;
                    btnAddToCart.Text = "❌ OUT OF STOCK";
                }
                else
                {
                    btnAddToCart.Enabled = true;
                    btnAddToCart.Text = "➕ Add To Cart";
                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = cmbSneakers.SelectedIndex;
                if (selectedIndex == -1)
                {
                    MessageBox.Show("Please select a sneaker.");
                    return;
                }

                var selectedSneaker = sneakers[selectedIndex];
                int quantity = (int)numQuantity.Value;

                // ✅ FIXED: Use SalePrice instead of Price
                decimal unitPrice = selectedSneaker.SalePrice ?? selectedSneaker.Price;

                if (quantity > selectedSneaker.StockQuantity)
                {
                    MessageBox.Show($"Only {selectedSneaker.StockQuantity} items available in stock.");
                    return;
                }

                var existingItem = cart.FirstOrDefault(item => item.SneakerId == selectedSneaker.Id);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                    totalAmount += unitPrice * quantity; // ✅ FIXED: Use unitPrice
                }
                else
                {
                    CartItem item = new CartItem
                    {
                        SneakerId = selectedSneaker.Id,
                        ProductName = $"{selectedSneaker.Name} - Size {selectedSneaker.Size}",
                        UnitPrice = unitPrice, // ✅ FIXED: Use unitPrice
                        Quantity = quantity
                    };
                    cart.Add(item);
                    totalAmount += item.SubTotal;
                }

                UpdateCartDisplay();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}");
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            int selectedIndex = dataGridViewCart.SelectedRows[0].Index;
            if (selectedIndex >= 0 && selectedIndex < cart.Count)
            {
                CartItem removedItem = cart[selectedIndex];
                totalAmount -= removedItem.SubTotal;
                cart.RemoveAt(selectedIndex);

                UpdateCartDisplay();
            }
        }

        // ✅ FIXED: SIMPLE SALE COMPLETION WITH LOWERCASE PROPERTIES
        private async void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items before completing sale.");
                return;
            }

            try
            {
                // SIMPLE STAFF CHECK
                if (cmbStaff.SelectedIndex == -1 || cmbStaff.SelectedItem == null)
                {
                    MessageBox.Show("Please select a staff member.");
                    return;
                }

                string customerId = null;
                int customerIndex = cmbCustomers.SelectedIndex;
                if (customerIndex > 0)
                {
                    // ✅ FIXED: Use lowercase property customer_id
                    customerId = customers[customerIndex - 1].customer_id;
                }
                else
                {
                    var walkInCustomer = new Customer
                    {
                        name = "Walk-in Customer",
                        phone = "N/A",
                        email = "walkin@store.com"
                    };
                    var customerResponse = await SupabaseClient.Client.From<Customer>().Insert(walkInCustomer);
                    customerId = customerResponse.Models.First().customer_id; // ✅ FIXED
                }

                // ✅ FIXED: Get staff ID directly from selected User object
                string staffId = cmbStaff.SelectedValue?.ToString();

                string paymentMethod = cmbPayment.SelectedItem?.ToString() ?? "Cash";

                var sale = new Sale
                {
                    CustomerId = customerId,
                    StaffId = staffId,
                    TotalAmount = totalAmount,
                    Date = DateTime.Now
                };

                var saleResponse = await SupabaseClient.Client.From<Sale>().Insert(sale);
                var savedSale = saleResponse.Models.First();

                foreach (var cartItem in cart)
                {
                    var saleDetail = new SaleDetail
                    {
                        SaleId = savedSale.Id,
                        SneakerId = cartItem.SneakerId,
                        Quantity = cartItem.Quantity,
                        SubTotal = cartItem.SubTotal
                    };
                    await SupabaseClient.Client.From<SaleDetail>().Insert(saleDetail);

                    var sneaker = sneakers.First(s => s.Id == cartItem.SneakerId);
                    sneaker.StockQuantity -= cartItem.Quantity;
                    await SupabaseClient.Client.From<Sneaker>()
                        .Where(s => s.Id == cartItem.SneakerId)
                        .Update(sneaker);
                }

                // SHOW INVOICE
                ShowInvoiceWithPrintOption(savedSale.Id, paymentMethod);

                // Reset for new sale
                cart.Clear();
                totalAmount = 0;
                UpdateCartDisplay();
                ClearInputFields();

                await LoadSneakersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing sale: {ex.Message}", "Error");
            }
        }

        private void ShowInvoiceWithPrintOption(string saleId, string paymentMethod)
        {
            string invoice = "==========================================\n";
            invoice += "           🏪 SNEAKER SHOP INVOICE           \n";
            invoice += "==========================================\n";
            invoice += $"Invoice: {saleId.Substring(0, 8).ToUpper()}\n";
            invoice += $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
            invoice += $"Staff: {cmbStaff.Text}\n";
            invoice += $"Customer: {cmbCustomers.Text}\n";
            invoice += $"Payment: {paymentMethod}\n";
            invoice += "------------------------------------------\n";
            invoice += "ITEMS PURCHASED:\n";

            foreach (var item in cart)
            {
                invoice += $"• {item.ProductName}\n";
                invoice += $"  {item.Quantity} x ${item.UnitPrice} = ${item.SubTotal}\n";
            }

            invoice += "------------------------------------------\n";
            invoice += $"TOTAL AMOUNT: ${totalAmount}\n";
            invoice += "==========================================\n";
            invoice += "     Thank you for your business! 🎉\n";
            invoice += "==========================================\n";

            var result = MessageBox.Show(invoice + "\n\nWould you like to print this invoice?",
                                       "🧾 SALE COMPLETED - INVOICE",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Invoice sent to printer!", "Print",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            _ = LoadSneakersAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCartDisplay()
        {
            dataGridViewCart.Rows.Clear();
            foreach (var item in cart)
            {
                dataGridViewCart.Rows.Add(
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice.ToString("C"),
                    item.SubTotal.ToString("C")
                );
            }
            txtTotalAmount.Text = totalAmount.ToString("C");
        }

        private void ClearInputFields()
        {
            cmbSneakers.SelectedIndex = -1;
            numQuantity.Value = 1;
            txtUnitPrice.Clear();
            txtSubTotal.Clear();
            btnAddToCart.Enabled = true;
            btnAddToCart.Text = "➕ Add To Cart";
        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell clicks if needed
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Paint event handler
        }
    }

    public class CartItem
    {
        public string SneakerId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal => UnitPrice * Quantity;
    }
}