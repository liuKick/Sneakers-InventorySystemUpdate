using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakerShop.Forms
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;

        // TOP SECTION
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        // LEFT SIDE - INPUT FIELDS
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label lblSneakers;
        private System.Windows.Forms.ComboBox cmbSneakers;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Button btnAddToCart;

        // RIGHT SIDE - CART SECTION
        private System.Windows.Forms.Label lblCartTitle;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnCompleteSale;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStaff = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.lblSneakers = new System.Windows.Forms.Label();
            this.cmbSneakers = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.lblPayment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🛒 POINT OF SALE";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 16);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(69, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(275, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(356, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 25);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(6, 70);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(37, 16);
            this.lblStaff.TabIndex = 6;
            this.lblStaff.Text = "Staff:";
            // 
            // cmbStaff
            // 
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(96, 67);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(150, 24);
            this.cmbStaff.TabIndex = 7;
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(406, 59);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(74, 16);
            this.lblCustomers.TabIndex = 8;
            this.lblCustomers.Text = "Customers:";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(488, 56);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(156, 24);
            this.cmbCustomers.TabIndex = 9;
            // 
            // lblSneakers
            // 
            this.lblSneakers.AutoSize = true;
            this.lblSneakers.Location = new System.Drawing.Point(6, 120);
            this.lblSneakers.Name = "lblSneakers";
            this.lblSneakers.Size = new System.Drawing.Size(66, 16);
            this.lblSneakers.TabIndex = 10;
            this.lblSneakers.Text = "Sneakers:";
            // 
            // cmbSneakers
            // 
            this.cmbSneakers.FormattingEnabled = true;
            this.cmbSneakers.Location = new System.Drawing.Point(96, 117);
            this.cmbSneakers.Name = "cmbSneakers";
            this.cmbSneakers.Size = new System.Drawing.Size(150, 24);
            this.cmbSneakers.TabIndex = 11;
            this.cmbSneakers.SelectedIndexChanged += new System.EventHandler(this.cmbSneakers_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(6, 170);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(60, 16);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(96, 167);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 22);
            this.numQuantity.TabIndex = 13;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(406, 106);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(68, 16);
            this.lblUnitPrice.TabIndex = 14;
            this.lblUnitPrice.Text = "Unit Price:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(488, 103);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(133, 22);
            this.txtUnitPrice.TabIndex = 15;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(406, 147);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(65, 16);
            this.lblSubTotal.TabIndex = 16;
            this.lblSubTotal.Text = "Sub Total:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(488, 144);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(133, 22);
            this.txtSubTotal.TabIndex = 17;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddToCart.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(253, 208);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(151, 58);
            this.btnAddToCart.TabIndex = 18;
            this.btnAddToCart.Text = "➕ Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // lblCartTitle
            // 
            this.lblCartTitle.AutoSize = true;
            this.lblCartTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartTitle.Location = new System.Drawing.Point(40, 337);
            this.lblCartTitle.Name = "lblCartTitle";
            this.lblCartTitle.Size = new System.Drawing.Size(202, 24);
            this.lblCartTitle.TabIndex = 19;
            this.lblCartTitle.Text = "🛒 SHOPPING CART";
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(26, 364);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 24;
            this.dataGridViewCart.Size = new System.Drawing.Size(681, 155);
            this.dataGridViewCart.TabIndex = 20;
            this.dataGridViewCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellContentClick);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(23, 525);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(268, 43);
            this.btnRemoveItem.TabIndex = 21;
            this.btnRemoveItem.Text = "🗑️ Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(361, 536);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 19);
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(421, 533);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(286, 27);
            this.txtTotalAmount.TabIndex = 23;
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.Color.LightGreen;
            this.btnCompleteSale.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteSale.Location = new System.Drawing.Point(205, 574);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(322, 54);
            this.btnCompleteSale.TabIndex = 24;
            this.btnCompleteSale.Text = "✅ COMPLETE SALE";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.cmbPayment);
            this.panel1.Controls.Add(this.lblPayment);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblStaff);
            this.panel1.Controls.Add(this.cmbStaff);
            this.panel1.Controls.Add(this.lblCustomers);
            this.panel1.Controls.Add(this.btnAddToCart);
            this.panel1.Controls.Add(this.cmbCustomers);
            this.panel1.Controls.Add(this.txtSubTotal);
            this.panel1.Controls.Add(this.lblSneakers);
            this.panel1.Controls.Add(this.lblSubTotal);
            this.panel1.Controls.Add(this.cmbSneakers);
            this.panel1.Controls.Add(this.txtUnitPrice);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.lblUnitPrice);
            this.panel1.Controls.Add(this.numQuantity);
            this.panel1.Location = new System.Drawing.Point(26, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 278);
            this.panel1.TabIndex = 25;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbPayment
            // 
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Location = new System.Drawing.Point(488, 180);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(154, 24);
            this.cmbPayment.TabIndex = 20;
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(406, 183);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(63, 16);
            this.lblPayment.TabIndex = 19;
            this.lblPayment.Text = "Payment:";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1258, 640);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCompleteSale);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.lblCartTitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.SaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panel1;
        private ComboBox cmbPayment;
        private Label lblPayment;
    }
}