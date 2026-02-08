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
    public partial class BrandForm : Form
    {
        private BindingList<Brand> brands;
        private bool isEditing = false;
        private Brand currentBrand = null;
        private List<Brand> allBrandsCache; // Cache for search functionality

        public BrandForm()
        {
            InitializeComponent();
            brands = new BindingList<Brand>();
            allBrandsCache = new List<Brand>();

            // 🔥 ADDED SUPABASE INITIALIZATION 🔥
            SupabaseClient.Initialize();

            // 🔥 EVENT CONNECTIONS 🔥
            btnAdd.Click += btnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;
            //btnClose.Click += btnClose_Click;

            // Enable scrolling for the form itself
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(800, 600);
        }

        private async void BrandForm_Load(object sender, EventArgs e)
        {
            await LoadBrandsAsync();
            SetupDataGridView();
            ResetForm();
        }

        private async Task LoadBrandsAsync()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Brand>().Get();
                var brandList = response.Models.ToList();

                // Store all brands in cache for searching
                allBrandsCache = brandList;

                brands = new BindingList<Brand>(brandList);

                dgvBrands.DataSource = null;
                dgvBrands.DataSource = brands;

                // Force refresh to show row numbers
                dgvBrands.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading brands: {ex.Message}", "Error");
            }
        }

        private void SetupDataGridView()
        {
            dgvBrands.AutoGenerateColumns = false;
            dgvBrands.Columns.Clear();

            // 👇 ROW NUMBER COLUMN (1, 2, 3...)
            dgvBrands.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colNumber",
                HeaderText = "No.",
                Width = 50,
                ReadOnly = true
            });

            // Brand Name column - FIXED: Use lowercase property name
            dgvBrands.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colBrandName",
                DataPropertyName = "brand_name",  // CHANGED from "BrandName" to "brand_name"
                HeaderText = "Brand Name",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Created At column - FIXED: Use lowercase property name
            dgvBrands.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCreatedAt",
                DataPropertyName = "created_at",  // CHANGED from "CreatedAt" to "created_at"
                HeaderText = "Created Date",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "yyyy-MM-dd HH:mm:ss"
                }
            });

            // UUID column (hidden - for internal use) - FIXED: Use lowercase property name
            dgvBrands.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colUuid",
                DataPropertyName = "brand_id",  // CHANGED from "BrandUuid" to "brand_id"
                HeaderText = "UUID",
                Width = 100,
                Visible = false
            });

            // Handle row numbering
            dgvBrands.RowPostPaint += (sender, e) =>
            {
                var grid = sender as DataGridView;
                if (grid != null && e.RowIndex >= 0)
                {
                    // Add row number
                    var row = grid.Rows[e.RowIndex];
                    row.Cells["colNumber"].Value = (e.RowIndex + 1).ToString();
                }
            };

            // Handle selection change to show correct number
            dgvBrands.SelectionChanged += (sender, e) =>
            {
                if (dgvBrands.CurrentRow != null)
                {
                    txtID.Text = (dgvBrands.CurrentRow.Index + 1).ToString();
                }
            };
        }

        private void ResetForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtCreatedAt.Text = "";

            isEditing = false;
            currentBrand = null;
            btnSave.Text = "Save";

            // Clear selection
            dgvBrands.ClearSelection();
        }

        private void UpdateFormWithSelectedBrand(Brand brand, int rowIndex)
        {
            if (brand != null)
            {
                // Use row number + 1 as display ID
                txtID.Text = (rowIndex + 1).ToString();
                txtName.Text = brand.brand_name;  // CHANGED from brand.BrandName
                txtCreatedAt.Text = brand.created_at.ToString("yyyy-MM-dd HH:mm:ss");  // CHANGED from brand.CreatedAt
            }
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
                if (isEditing && currentBrand != null)
                {
                    // Update existing brand
                    currentBrand.brand_name = txtName.Text.Trim();  // CHANGED from BrandName to brand_name

                    await SupabaseClient.Client.From<Brand>()
                        .Where(b => b.brand_id == currentBrand.brand_id)  // CHANGED from BrandUuid to brand_id
                        .Update(currentBrand);
                    MessageBox.Show("Brand updated successfully!", "Success");
                }
                else
                {
                    // Create new brand
                    var brand = new Brand
                    {
                        brand_name = txtName.Text.Trim()  // CHANGED from BrandName to brand_name
                        // brand_id and created_at are set in constructor
                    };

                    await SupabaseClient.Client.From<Brand>().Insert(brand);
                    MessageBox.Show("Brand added successfully!", "Success");
                }

                await LoadBrandsAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving brand: {ex.Message}", "Error");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBrands.CurrentRow == null)
            {
                MessageBox.Show("Please select a brand to edit.", "Information");
                return;
            }

            var selectedBrand = dgvBrands.CurrentRow.DataBoundItem as Brand;
            if (selectedBrand != null)
            {
                currentBrand = selectedBrand;
                isEditing = true;

                UpdateFormWithSelectedBrand(selectedBrand, dgvBrands.CurrentRow.Index);
                btnSave.Text = "Update";
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBrands.CurrentRow == null)
            {
                MessageBox.Show("Please select a brand to delete.", "Information");
                return;
            }

            var selectedBrand = dgvBrands.CurrentRow.DataBoundItem as Brand;
            if (selectedBrand != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedBrand.brand_name}?",  // CHANGED from BrandName
                    "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await SupabaseClient.Client.From<Brand>()
                            .Where(b => b.brand_id == selectedBrand.brand_id)  // CHANGED from BrandUuid to brand_id
                            .Delete();
                        MessageBox.Show("Brand deleted successfully!", "Success");
                        await LoadBrandsAsync();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting brand: {ex.Message}", "Error");
                    }
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadBrandsAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Show all brands
                dgvBrands.DataSource = new BindingList<Brand>(allBrandsCache);
                dgvBrands.Refresh();
                return;
            }

            try
            {
                var filteredBrands = allBrandsCache.Where(b =>
                    b.brand_name.ToLower().Contains(searchTerm)  // CHANGED from BrandName to brand_name
                ).ToList();

                dgvBrands.DataSource = new BindingList<Brand>(filteredBrands);
                dgvBrands.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error");
            }
        }

        // ===== VALIDATION =====

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter brand name.", "Validation Error");
                txtName.Focus();
                return false;
            }

            // Check for duplicate brand name (case insensitive)
            string newBrandName = txtName.Text.Trim();
            bool isDuplicate = allBrandsCache.Any(b =>
                b.brand_name.Equals(newBrandName, StringComparison.OrdinalIgnoreCase) &&  // CHANGED from BrandName
                b.brand_id != (currentBrand?.brand_id ?? "")  // CHANGED from BrandUuid
            );

            if (isDuplicate)
            {
                MessageBox.Show("Brand name already exists. Please choose a different name.", "Validation Error");
                txtName.Focus();
                return false;
            }

            return true;
        }

        // ===== DATA GRID VIEW EVENTS =====

        private void dgvBrands_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBrands.CurrentRow != null && dgvBrands.CurrentRow.DataBoundItem is Brand selectedBrand)
            {
                UpdateFormWithSelectedBrand(selectedBrand, dgvBrands.CurrentRow.Index);
            }
        }

        // ===== EMPTY EVENT HANDLERS FOR DESIGNER =====
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Real-time search as user types
            btnSearch_Click(sender, e);
        }
        private void lblQuickActions_Click(object sender, EventArgs e) { }
        private void Panel_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}