using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SneakerShop.Forms
{
    public partial class StaffForm : Form
    {
        private BindingList<User> staffList;
        private DatabaseService dbService;
        private User currentStaff;
        private bool isEditing = false;

        public StaffForm()
        {
            InitializeComponent();
            dbService = new DatabaseService();
            staffList = new BindingList<User>();

            // Setup password field
            txtGeneratePass.PasswordChar = '•';
            txtGeneratePass.Text = "staff123";

            SetupDataGridView();
            SetupCheckboxLogic();
        }

        private void SetupCheckboxLogic()
        {
            // Ensure only one role is selected
            chckStaff.CheckedChanged += (s, e) => {
                if (chckStaff.Checked) chckAdmin.Checked = false;
            };

            chckAdmin.CheckedChanged += (s, e) => {
                if (chckAdmin.Checked) chckStaff.Checked = false;
            };

            // Status checkbox logic
            chckActive.CheckedChanged += (s, e) => {
                if (chckActive.Checked) chckInactive.Checked = false;
            };

            chckInactive.CheckedChanged += (s, e) => {
                if (chckInactive.Checked) chckActive.Checked = false;
            };

            // Make status checkboxes visible
            chckActive.Visible = true;
            chckInactive.Visible = true;
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadStaffAsync();
        }

        private async void LoadStaffAsync()
        {
            try
            {
                var users = await dbService.GetAllUsers();
                staffList.Clear();

                foreach (var user in users)
                {
                    staffList.Add(user);
                }

                // Force refresh the DataGridView
                dgvStaff.DataSource = null;
                dgvStaff.DataSource = staffList;
                dgvStaff.Refresh();

                ResetForm();

                // Show debug info (optional - you can remove this)
                if (staffList.Count > 0)
                {
                    MessageBox.Show($"Successfully loaded {staffList.Count} staff members!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns.Clear();

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Username",
                HeaderText = "Username",
                Width = 150
            });

            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Role",
                HeaderText = "Role",
                Width = 100
            });

            // Add Status column
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 80
            });
        }

        private void ResetForm()
        {
            txtUsername.Text = "";
            txtGeneratePass.Text = "staff123";
            chckStaff.Checked = true;
            chckAdmin.Checked = false;

            // Add status default
            chckActive.Checked = true;
            chckInactive.Checked = false;

            currentStaff = null;
            isEditing = false;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetForm();
            isEditing = false;
            txtUsername.Focus();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                if (isEditing && currentStaff != null)
                {
                    // Update existing staff
                    currentStaff.Username = txtUsername.Text.Trim();
                    currentStaff.Role = chckAdmin.Checked ? "admin" : "staff";

                    // Add status saving
                    currentStaff.Status = chckActive.Checked ? "Active" : "Inactive";

                    var success = await dbService.UpdateUser(currentStaff);
                    if (success)
                    {
                        MessageBox.Show("Staff updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaffAsync();
                    }
                }
                else
                {
                    // Add new staff - ✅ FIXED: Use proper BCrypt hashing
                    var usernameExists = await dbService.UsernameExists(txtUsername.Text.Trim());
                    if (usernameExists)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newStaff = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        Password = DatabaseService.HashPassword(txtGeneratePass.Text), // ✅ FIXED: Use BCrypt hashing
                        Role = chckAdmin.Checked ? "admin" : "staff",
                        Status = chckActive.Checked ? "Active" : "Inactive"
                    };

                    var success = await dbService.AddUser(newStaff);
                    if (success)
                    {
                        MessageBox.Show("Staff added successfully!\nTemporary password: staff123",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaffAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving staff: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow != null && dgvStaff.CurrentRow.DataBoundItem is User selectedStaff)
            {
                currentStaff = selectedStaff;
                isEditing = true;

                txtUsername.Text = selectedStaff.Username;
                txtGeneratePass.Text = "••••••••••";
                chckAdmin.Checked = selectedStaff.Role == "admin";
                chckStaff.Checked = selectedStaff.Role == "staff";

                // Add status loading
                chckActive.Checked = selectedStaff.Status == "Active";
                chckInactive.Checked = selectedStaff.Status == "Inactive";
            }
            else
            {
                MessageBox.Show("Please select a staff member to edit", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow != null && dgvStaff.CurrentRow.DataBoundItem is User selectedStaff)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedStaff.Username}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var success = await dbService.DeleteUser(selectedStaff.Id);
                    if (success)
                    {
                        MessageBox.Show("Staff deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaffAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change Password feature will be added later", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGeneratePass.Text) && txtGeneratePass.Text != "••••••••••")
            {
                Clipboard.SetText(txtGeneratePass.Text);
                MessageBox.Show("Password copied to clipboard!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText) || searchText == "search staff......")
            {
                dgvStaff.DataSource = staffList;
            }
            else
            {
                var filteredList = new BindingList<User>(staffList.Where(s =>
                    s.Username.ToLower().Contains(searchText) ||
                    s.Role.ToLower().Contains(searchText) ||
                    s.Status.ToLower().Contains(searchText)
                ).ToList());
                dgvStaff.DataSource = filteredList;
            }
        }

        // === EVENT HANDLERS ===
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void chckStaff_CheckedChanged(object sender, EventArgs e) { }
        private void chckAdmin_CheckedChanged(object sender, EventArgs e) { }
        private void chckActive_CheckedChanged(object sender, EventArgs e) { }
        private void chckInactive_CheckedChanged(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtGeneratePass_TextChanged(object sender, EventArgs e) { }
        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblQuickActions_Click(object sender, EventArgs e) { }
    }
}