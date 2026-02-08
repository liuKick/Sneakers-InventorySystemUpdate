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
    public partial class InventoryForm : Form
    {
        private BindingList<Sneaker> sneakers;
        private List<Brand> brands;
        private bool isEditing = false;
        private Sneaker currentSneaker = null;

        public InventoryForm()
        {
            InitializeComponent();
            sneakers = new BindingList<Sneaker>();
            brands = new List<Brand>();

            // Enable scrolling for the form itself
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(800, 600);

            // Handle DataGridView errors
            dgvInventory.DataError += dgvInventory_DataError;
        }

        private async void InventoryForm_Load(object sender, EventArgs e)
        {
            await LoadBrandsAsync();
            await LoadSneakersAsync();
            SetupDataGridView();
            ResetForm();

            // Connect the formatting event
            dgvInventory.CellFormatting += dgvInventory_CellFormatting;
        }

        // Handle DataGridView errors silently
        private void dgvInventory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            Console.WriteLine($"DataGridView Error: {e.Exception.Message}");
        }

        private async Task LoadBrandsAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Brand>().Get();
                brands = response.Models.ToList();

                // DEBUG: Show what brands we loaded
                Console.WriteLine($"DEBUG: Loaded {brands.Count} brands:");
                foreach (var brand in brands)
                {
                    Console.WriteLine($"  - {brand.brand_name}: UUID={brand.brand_id}");
                }

                // Populate brand dropdown - Use lowercase property names
                cmbBrand.DataSource = brands;
                cmbBrand.DisplayMember = "brand_name";
                cmbBrand.ValueMember = "brand_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading brands: {ex.Message}", "Error");
            }
        }

        private async Task LoadSneakersAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Sneaker>().Get();
                var sneakerList = response.Models.ToList();

                // DEBUG: Show what sneakers we loaded
                Console.WriteLine($"DEBUG: Loaded {sneakerList.Count} sneakers:");
                foreach (var sneaker in sneakerList)
                {
                    Console.WriteLine($"  - {sneaker.Name}: BrandId={sneaker.BrandId}");
                }

                // SIMPLE FIX: Just sort by DisplayId
                sneakerList = sneakerList.OrderBy(s => s.DisplayId).ToList();

                sneakers = new BindingList<Sneaker>(sneakerList);

                dgvInventory.DataSource = null;
                dgvInventory.DataSource = sneakers;

                UpdateStockSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error");
            }
        }

        // ✅ SIMPLE & RELIABLE: Reorder all DisplayIds after deletion
        private async Task ReorderDisplayIdsAfterDeletion()
        {
            try
            {
                // Get all remaining sneakers ordered by current DisplayId
                var response = await SupabaseClient.Client.From<Sneaker>().Get();
                var allSneakers = response.Models.OrderBy(s => s.DisplayId).ToList();

                // SIMPLE: Just reassign 1, 2, 3, 4... to all items
                int newDisplayId = 1;
                foreach (var sneaker in allSneakers)
                {
                    sneaker.DisplayId = newDisplayId++;
                }

                // Save the new order to database
                foreach (var sneaker in allSneakers)
                {
                    await SupabaseClient.Client.From<Sneaker>()
                        .Where(s => s.Id == sneaker.Id)
                        .Set(s => s.DisplayId, sneaker.DisplayId)
                        .Update();
                }

                Console.WriteLine($"✅ Reordered {allSneakers.Count} products to: {string.Join(", ", allSneakers.Select(s => s.DisplayId))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Could not reorder DisplayIds: {ex.Message}");
            }
        }

        // NEW METHOD: Get next available DisplayId (no duplicates)
        private int GetNextDisplayId()
        {
            if (sneakers.Count == 0) return 1;

            // Find the highest current DisplayId and add 1
            int maxId = sneakers.Max(s => s.DisplayId);
            return maxId + 1;
        }

        private void SetupDataGridView()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.Columns.Clear();

            // Product ID
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDisplayId",
                DataPropertyName = "DisplayId",
                HeaderText = "Product ID",
                Width = 80,
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                DataPropertyName = "Name",
                HeaderText = "Product Name",
                Width = 200
            });

            // Brand Name
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colBrand",
                HeaderText = "Brand",
                Width = 120
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colSize",
                DataPropertyName = "Size",
                HeaderText = "Size",
                Width = 80
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colColor",
                DataPropertyName = "Color",
                HeaderText = "Color",
                Width = 100
            });

            // Cost Price
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colPrice",
                DataPropertyName = "Price",
                HeaderText = "Cost Price",
                Width = 100
            });

            // Selling Price
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colSalePrice",
                DataPropertyName = "SalePrice",
                HeaderText = "Selling Price",
                Width = 100
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStock",
                DataPropertyName = "StockQuantity",
                HeaderText = "Stock",
                Width = 80
            });

            // Status column
            var statusColumn = new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Status",
                Width = 100
            };
            dgvInventory.Columns.Add(statusColumn);
        }

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInventory.Rows.Count)
            {
                var sneaker = dgvInventory.Rows[e.RowIndex].DataBoundItem as Sneaker;
                if (sneaker != null)
                {
                    // Handle Brand column - FIXED: Use lowercase property names
                    if (dgvInventory.Columns[e.ColumnIndex].Name == "colBrand")
                    {
                        var brand = brands.FirstOrDefault(b => b.brand_id == sneaker.BrandId);
                        if (brand != null)
                        {
                            e.Value = brand.brand_name;
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            e.Value = "Unknown Brand";
                            e.FormattingApplied = true;
                            // DEBUG: Show what we couldn't find
                            Console.WriteLine($"DEBUG: Could not find brand for sneaker '{sneaker.Name}' with BrandId: {sneaker.BrandId}");
                        }
                    }

                    // Handle Cost Price column
                    else if (dgvInventory.Columns[e.ColumnIndex].Name == "colPrice")
                    {
                        try
                        {
                            e.Value = sneaker.Price.ToString("C2");
                            e.FormattingApplied = true;
                        }
                        catch
                        {
                            e.Value = "Invalid Price";
                            e.FormattingApplied = true;
                        }
                    }

                    // Handle Sale Price column
                    else if (dgvInventory.Columns[e.ColumnIndex].Name == "colSalePrice")
                    {
                        try
                        {
                            if (sneaker.SalePrice.HasValue && sneaker.SalePrice.Value > 0)
                            {
                                e.Value = sneaker.SalePrice.Value.ToString("C2");
                                // Highlight profit/loss
                                if (sneaker.SalePrice.Value > sneaker.Price)
                                {
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                }
                                else if (sneaker.SalePrice.Value < sneaker.Price)
                                {
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                            }
                            else
                            {
                                e.Value = sneaker.Price.ToString("C2");
                                e.CellStyle.ForeColor = Color.Gray;
                            }
                            e.FormattingApplied = true;
                        }
                        catch
                        {
                            e.Value = "Invalid Price";
                            e.FormattingApplied = true;
                        }
                    }

                    // Handle Status column
                    else if (dgvInventory.Columns[e.ColumnIndex].Name == "colStatus")
                    {
                        if (sneaker.StockQuantity == 0)
                        {
                            e.Value = "OUT OF STOCK";
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                        }
                        else if (sneaker.StockQuantity < 10)
                        {
                            e.Value = "LOW STOCK";
                            e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                            e.CellStyle.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            e.Value = "IN STOCK";
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                        }
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void ResetForm()
        {
            // Use the new method to get next ID (no duplicates)
            int nextId = GetNextDisplayId();

            // Reset all form controls
            txtProductsID.Text = nextId.ToString();
            txtProductName.Text = "";
            txtSize.Text = "";
            txtColor.Text = "";
            txtPrice.Text = "";
            txtSalePrice.Text = "";
            numericUpDown1.Value = 0;
            cmbBrand.SelectedIndex = -1;

            isEditing = false;
            currentSneaker = null;
            btnSave.Text = "Save";

            UpdateStockStatus();
        }

        private void UpdateStockStatus()
        {
            int stock = (int)numericUpDown1.Value;

            if (stock == 0)
            {
                txtStatus.Text = "OUT OF STOCK";
                txtStatus.BackColor = Color.LightCoral;
                txtStatus.ForeColor = Color.DarkRed;
            }
            else if (stock < 10)
            {
                txtStatus.Text = "LOW STOCK";
                txtStatus.BackColor = Color.LightGoldenrodYellow;
                txtStatus.ForeColor = Color.OrangeRed;
            }
            else
            {
                txtStatus.Text = "IN STOCK";
                txtStatus.BackColor = Color.LightGreen;
                txtStatus.ForeColor = Color.DarkGreen;
            }

            txtStatus.TextAlign = HorizontalAlignment.Center;
            txtStatus.Font = new Font(txtStatus.Font, FontStyle.Bold);
        }

        private void UpdateStockSummary()
        {
            int totalItems = sneakers.Count;
            int lowStockItems = sneakers.Count(s => s.StockQuantity > 0 && s.StockQuantity < 10);
            int outOfStockItems = sneakers.Count(s => s.StockQuantity == 0);
        }

        // ===== BUTTON EVENT HANDLERS =====

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                int stockQuantity = (int)numericUpDown1.Value;
                int displayId = int.Parse(txtProductsID.Text);

                // Get brand ID - This should be the UUID
                string brandId = "";
                if (cmbBrand.SelectedValue != null)
                {
                    brandId = cmbBrand.SelectedValue.ToString();
                    Console.WriteLine($"DEBUG: Selected brand UUID: {brandId}");
                }

                // Handle sale price
                decimal? salePrice = null;
                if (!string.IsNullOrWhiteSpace(txtSalePrice.Text) && decimal.TryParse(txtSalePrice.Text, out decimal parsedSalePrice))
                {
                    salePrice = parsedSalePrice;
                }

                if (isEditing && currentSneaker != null)
                {
                    // Update the existing object directly
                    currentSneaker.Name = txtProductName.Text;
                    currentSneaker.BrandId = brandId;
                    currentSneaker.Size = txtSize.Text;
                    currentSneaker.Color = txtColor.Text;
                    currentSneaker.Price = decimal.Parse(txtPrice.Text);
                    currentSneaker.SalePrice = salePrice;
                    currentSneaker.StockQuantity = stockQuantity;

                    await SupabaseClient.Client.From<Sneaker>()
                        .Where(s => s.Id == currentSneaker.Id)
                        .Update(currentSneaker);

                    MessageBox.Show("Product updated successfully!", "Success");
                }
                else
                {
                    // Create new sneaker
                    var sneaker = new Sneaker
                    {
                        DisplayId = displayId,
                        Name = txtProductName.Text,
                        BrandId = brandId,
                        Size = txtSize.Text,
                        Color = txtColor.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        SalePrice = salePrice,
                        StockQuantity = stockQuantity
                    };

                    await SupabaseClient.Client.From<Sneaker>().Insert(sneaker);
                    MessageBox.Show("Product added successfully!", "Success");
                }

                await LoadSneakersAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to edit.", "Information");
                return;
            }

            var selectedSneaker = dgvInventory.CurrentRow.DataBoundItem as Sneaker;
            if (selectedSneaker != null)
            {
                currentSneaker = selectedSneaker;
                isEditing = true;

                txtProductsID.Text = selectedSneaker.DisplayId.ToString();
                txtProductName.Text = selectedSneaker.Name;
                txtSize.Text = selectedSneaker.Size;
                txtColor.Text = selectedSneaker.Color;
                txtPrice.Text = selectedSneaker.Price.ToString("F2");
                txtSalePrice.Text = selectedSneaker.SalePrice?.ToString("F2") ?? "";
                numericUpDown1.Value = selectedSneaker.StockQuantity;

                // Set brand - FIXED: Use lowercase property names
                var brand = brands.FirstOrDefault(b => b.brand_id == selectedSneaker.BrandId);
                if (brand != null)
                {
                    // Find the index of this brand in the combo box
                    for (int i = 0; i < cmbBrand.Items.Count; i++)
                    {
                        var brandItem = cmbBrand.Items[i] as Brand;
                        if (brandItem != null && brandItem.brand_id == brand.brand_id)
                        {
                            cmbBrand.SelectedIndex = i;
                            break;
                        }
                    }
                }

                btnSave.Text = "Update";
                UpdateStockStatus();
            }
        }

        // ✅ FIXED: Delete button now properly reorders DisplayIds
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.", "Information");
                return;
            }

            var selectedSneaker = dgvInventory.CurrentRow.DataBoundItem as Sneaker;
            if (selectedSneaker != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedSneaker.Name}?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await SupabaseClient.Client.From<Sneaker>().Where(s => s.Id == selectedSneaker.Id).Delete();
                        MessageBox.Show("Product deleted successfully!", "Success");

                        // ✅ REORDER ALL DISPLAY IDs AFTER DELETION
                        await ReorderDisplayIdsAfterDeletion();

                        await LoadSneakersAsync();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Error");
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                saveFileDialog.Title = "Export Inventory";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("ProductID,ProductName,Brand,Size,Color,CostPrice,SellingPrice,Stock,Status");
                        foreach (Sneaker sneaker in sneakers)
                        {
                            // Get brand name for export
                            string brandName = "Unknown";
                            var brand = brands.FirstOrDefault(b => b.brand_id == sneaker.BrandId);
                            if (brand != null) brandName = brand.brand_name;

                            string status = sneaker.StockQuantity == 0 ? "Out of Stock" :
                                          sneaker.StockQuantity < 10 ? "Low Stock" : "In Stock";
                            string sellingPrice = sneaker.SalePrice.HasValue ? sneaker.SalePrice.Value.ToString("F2") : sneaker.Price.ToString("F2");

                            writer.WriteLine($"\"{sneaker.DisplayId}\",\"{sneaker.Name}\",\"{brandName}\",\"{sneaker.Size}\",\"{sneaker.Color}\"," +
                                            $"{sneaker.Price},{sellingPrice}," +
                                            $"{sneaker.StockQuantity},\"{status}\"");
                        }
                    }
                    MessageBox.Show("Inventory exported successfully!", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting inventory: {ex.Message}", "Error");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtsearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                _ = LoadSneakersAsync();
                return;
            }

            try
            {
                var filteredSneakers = sneakers.Where(s =>
                    s.Name.ToLower().Contains(searchTerm) ||
                    (brands.FirstOrDefault(b => b.brand_id == s.BrandId)?.brand_name.ToLower().Contains(searchTerm) == true) ||
                    s.Color.ToLower().Contains(searchTerm) ||
                    s.Size.ToLower().Contains(searchTerm)
                ).ToList();

                dgvInventory.DataSource = new BindingList<Sneaker>(filteredSneakers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error");
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtsearch.Clear();
            await LoadSneakersAsync();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter product name.", "Validation Error");
                txtProductName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                MessageBox.Show("Please enter size.", "Validation Error");
                txtSize.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Please enter color.", "Validation Error");
                txtColor.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid cost price greater than 0.", "Validation Error");
                txtPrice.Focus();
                return false;
            }

            // Sale Price validation
            if (!string.IsNullOrWhiteSpace(txtSalePrice.Text))
            {
                if (!decimal.TryParse(txtSalePrice.Text, out decimal salePrice) || salePrice < 0)
                {
                    MessageBox.Show("Please enter a valid selling price (0 or greater) or leave empty.", "Validation Error");
                    txtSalePrice.Focus();
                    return false;
                }
            }

            if (cmbBrand.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a brand.", "Validation Error");
                cmbBrand.Focus();
                return false;
            }

            return true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockStatus();
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInventory.Rows.Count)
            {
                btnEdit_Click(sender, e);
            }
        }

        // ===== EMPTY EVENT HANDLERS =====
        private void txtsearch_TextChanged(object sender, EventArgs e) { }
        private void lblQuickActions_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void Panel_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void lblInventoryList_Click(object sender, EventArgs e) { }
        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}