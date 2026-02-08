using SneakerShop;
using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakerShop.Forms
{
    public partial class DashboardForm : Form
    {
        private Random random = new Random();
        private Panel mainScrollPanel;
        private MainMenu mainMenu;
        private Label[] statValueLabels = new Label[4]; // Store references to value labels
        private List<decimal> realSalesData = new List<decimal>(); // Store real sales data for chart

        public DashboardForm(MainMenu mainMenu = null)
        {
            this.mainMenu = mainMenu;

            // Remove InitializeComponent() - we're building everything manually
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.ClientSize = new Size(1200, 800);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";

            SetupDashboardUI();

            // Load data after UI is created
            LoadDashboardDataAsync();
        }

        private async void LoadDashboardDataAsync()
        {
            try
            {
                // Fetch real stats data from Supabase
                var stats = await SupabaseClient.GetDashboardStatsAsync();

                // Fetch real sales data for the chart
                await LoadChartDataAsync();

                // Update stats cards with real data
                UpdateStatsCardsWithRealData(stats);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}", "Error");
                // Keep placeholder data if loading fails
            }
        }

        private async Task LoadChartDataAsync()
        {
            try
            {
                // Get sales from the last 7 days
                var sales = await GetLast7DaysSalesAsync();

                // Group sales by day for the last 7 days
                var dailySales = GroupSalesByDay(sales);

                // Convert to list in correct order (oldest to newest)
                realSalesData = dailySales.OrderBy(kv => kv.Key)
                                          .Select(kv => kv.Value)
                                          .ToList();

                // Force chart to redraw with real data
                mainScrollPanel.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load chart data: {ex.Message}", "Error");
                // Fall back to mock data if real data fails
                realSalesData = new List<decimal> { 2230, 2885, 1758, 2414, 2447, 2730, 2100 };
            }
        }

        private async Task<List<Sale>> GetLast7DaysSalesAsync()
        {
            try
            {
                // Get sales from the last 7 days
                var sevenDaysAgo = DateTime.Now.AddDays(-7);

                // Get Supabase client - FIX THIS based on your SupabaseClient.cs
                var client = SupabaseClient.Client; // This might need adjustment

                var sales = await client
                    .From<Sale>()
                    .Where(s => s.Date >= sevenDaysAgo)
                    .Order(s => s.Date, Postgrest.Constants.Ordering.Descending)
                    .Get();

                return sales.Models;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load sales data: {ex.Message}", "Error");
                return new List<Sale>();
            }
        }

        private Dictionary<DateTime, decimal> GroupSalesByDay(List<Sale> sales)
        {
            var dailyTotals = new Dictionary<DateTime, decimal>();

            // Initialize last 7 days with zero
            for (int i = 6; i >= 0; i--)
            {
                var date = DateTime.Now.Date.AddDays(-i);
                dailyTotals[date] = 0;
            }

            // Group sales by date and sum totals
            foreach (var sale in sales)
            {
                var saleDate = sale.Date.Date;
                if (dailyTotals.ContainsKey(saleDate))
                {
                    dailyTotals[saleDate] += sale.TotalAmount;
                }
            }

            return dailyTotals;
        }

        private void UpdateStatsCardsWithRealData(SupabaseClient.DashboardStats stats)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateStatsCardsWithRealData(stats)));
                return;
            }

            // Update with real data
            if (statValueLabels[0] != null)
                statValueLabels[0].Text = SupabaseClient.FormatCurrency(stats.TotalSales);

            if (statValueLabels[1] != null)
                statValueLabels[1].Text = $"{stats.ProductCount} items";

            if (statValueLabels[2] != null)
                statValueLabels[2].Text = $"{stats.CustomerCount} registered";

            if (statValueLabels[3] != null)
                statValueLabels[3].Text = $"{stats.BrandCount} brands";
        }

        private void SetupDashboardUI()
        {
            this.Controls.Clear();

            // ========== SCROLL PANEL ==========
            mainScrollPanel = new Panel();
            mainScrollPanel.AutoScroll = true;
            mainScrollPanel.Dock = DockStyle.Fill;
            mainScrollPanel.BackColor = Color.FromArgb(248, 250, 252);
            mainScrollPanel.AutoScrollMinSize = new Size(1150, 850);
            this.Controls.Add(mainScrollPanel);

            // ========== HEADER SECTION ==========
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(1180, 100);
            headerPanel.Location = new Point(10, 10);
            headerPanel.BackColor = Color.White;
            headerPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 12;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(headerPanel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(headerPanel.Width - radius * 2, headerPanel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, headerPanel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    e.Graphics.FillPath(Brushes.White, path);
                }
            };
            mainScrollPanel.Controls.Add(headerPanel);

            // User info
            Label lblAdmin = new Label();
            lblAdmin.Text = "ADMIN USER";
            lblAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdmin.ForeColor = Color.FromArgb(100, 100, 100);
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(30, 25);
            headerPanel.Controls.Add(lblAdmin);

            Label lblRole = new Label();
            lblRole.Text = "Administrator";
            lblRole.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(30, 30, 30);
            lblRole.AutoSize = true;
            lblRole.Location = new Point(30, 50);
            headerPanel.Controls.Add(lblRole);

            // Welcome message
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to your sneaker shop management system";
            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblWelcome.ForeColor = Color.FromArgb(102, 102, 102);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(250, 40);
            headerPanel.Controls.Add(lblWelcome);

            // ========== NAVIGATION CARDS ==========
            string[] navItems = { "Brands", "Inventory", "Sales", "Customers", "Staff" };
            Color[] navColors = {
                Color.FromArgb(155, 89, 182),   // Brands - Purple
                Color.FromArgb(46, 204, 113),    // Inventory - Green
                Color.FromArgb(231, 76, 60),     // Sales - Red
                Color.FromArgb(241, 196, 15),    // Customers - Yellow
                Color.FromArgb(149, 165, 166)    // Staff - Gray
            };

            int navStartX = 10;
            int navStartY = 120;
            int navWidth = 185;
            int navHeight = 70;

            for (int i = 0; i < navItems.Length; i++)
            {
                Panel navCard = CreateNavigationCard(navItems[i], navColors[i]);
                navCard.Location = new Point(navStartX + (i * (navWidth + 10)), navStartY);
                navCard.Size = new Size(navWidth, navHeight);
                mainScrollPanel.Controls.Add(navCard);
            }

            // ========== CHART SECTION ==========
            Panel chartContainer = new Panel();
            chartContainer.Size = new Size(780, 320);
            chartContainer.Location = new Point(10, 210);
            chartContainer.BackColor = Color.White;
            chartContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(chartContainer.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(chartContainer.Width - radius * 2, chartContainer.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, chartContainer.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    e.Graphics.FillPath(Brushes.White, path);
                }
            };
            mainScrollPanel.Controls.Add(chartContainer);

            // Chart title
            Label chartTitle = new Label();
            chartTitle.Text = "📈 SALE TREND (LAST 7 DAYS)";
            chartTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            chartTitle.ForeColor = Color.FromArgb(51, 51, 51);
            chartTitle.AutoSize = true;
            chartTitle.Location = new Point(20, 20);
            chartContainer.Controls.Add(chartTitle);

            // Draw chart
            PictureBox chartPicture = new PictureBox();
            chartPicture.Size = new Size(740, 250);
            chartPicture.Location = new Point(20, 60);
            chartPicture.Paint += DrawSalesChart;
            chartContainer.Controls.Add(chartPicture);

            // ========== FIXED STATS TABLE ==========
            Panel statsPanel = new Panel();
            statsPanel.Size = new Size(330, 260); // Normal height, not 400!
            statsPanel.Location = new Point(800, 260);
            statsPanel.BackColor = Color.White;
            statsPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(statsPanel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(statsPanel.Width - radius * 2, statsPanel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, statsPanel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    e.Graphics.FillPath(Brushes.White, path);
                    e.Graphics.DrawPath(new Pen(Color.FromArgb(230, 230, 230), 1), path);
                }
            };
            mainScrollPanel.Controls.Add(statsPanel);

            // Stats title
            Label statsTitle = new Label();
            statsTitle.Text = "📊 KEY STATISTICS";
            statsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            statsTitle.ForeColor = Color.FromArgb(51, 51, 51);
            statsTitle.AutoSize = true;
            statsTitle.Location = new Point(15, 15);
            statsPanel.Controls.Add(statsTitle);

            // Stats data
            string[] statNames = { "Total Sales", "Products", "Customers", "Brands" };
            string[] statValues = { "Loading...", "Loading...", "Loading...", "Loading..." };
            Color[] statColors = {
    Color.FromArgb(52, 152, 219),
    Color.FromArgb(155, 89, 182),
    Color.FromArgb(46, 204, 113),
    Color.FromArgb(231, 76, 60)
};

            int startY = 50;
            int rowHeight = 48;

            for (int i = 0; i < statNames.Length; i++)
            {
                Panel statRow = new Panel();
                statRow.Size = new Size(300, rowHeight);
                statRow.Location = new Point(15, startY + (i * rowHeight));
                statRow.BackColor = Color.Transparent;
                statRow.Cursor = Cursors.Hand;

                int currentIndex = i;
                Color currentColor = statColors[i];

                // Left colored indicator
                statRow.Paint += (s, e) =>
                {
                    e.Graphics.FillRectangle(new SolidBrush(currentColor), 0, 8, 3, 22);
                };

                // Stat name - FIXED: AutoSize = true and proper positioning
                Label lblName = new Label();
                lblName.Text = statNames[i];
                lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(90, 90, 90);
                lblName.AutoSize = true; // CHANGED BACK TO TRUE
                lblName.Location = new Point(12, 6); // Proper spacing from left
                statRow.Controls.Add(lblName);

                // Stat value - FIXED: AutoSize = true and below the name
                Label lblValue = new Label();
                lblValue.Text = statValues[i];
                lblValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lblValue.ForeColor = Color.FromArgb(30, 30, 30);
                lblValue.AutoSize = true; // CHANGED BACK TO TRUE
                lblValue.Location = new Point(12, 22); // Below the name with proper spacing
                statRow.Controls.Add(lblValue);

                // Store reference
                statValueLabels[i] = lblValue;

                // Add click handler
                string currentTitle = statNames[i].ToUpper();
                statRow.Click += (s, e) => HandleStatCardClick(currentTitle);

                statsPanel.Controls.Add(statRow);

                // Add separator
                if (i < statNames.Length - 1)
                {
                    Panel separator = new Panel();
                    separator.Size = new Size(280, 1);
                    separator.Location = new Point(25, startY + ((i + 1) * rowHeight) - 1);
                    separator.BackColor = Color.FromArgb(245, 245, 245);
                    statsPanel.Controls.Add(separator);
                }
            }

            // ========== QUICK ACTIONS - FEWER BUTTONS ==========
            Panel actionsPanel = new Panel();
            actionsPanel.Size = new Size(380, 200); // CHANGED: Reduced height from 260 to 200
            actionsPanel.Location = new Point(10, 550);
            actionsPanel.BackColor = Color.White;
            actionsPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(actionsPanel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(actionsPanel.Width - radius * 2, actionsPanel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, actionsPanel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    e.Graphics.FillPath(Brushes.White, path);
                }
            };
            mainScrollPanel.Controls.Add(actionsPanel);

            Label actionsTitle = new Label();
            actionsTitle.Text = "⚡ QUICK ACTIONS";
            actionsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            actionsTitle.ForeColor = Color.FromArgb(51, 51, 51);
            actionsTitle.AutoSize = true;
            actionsTitle.Location = new Point(20, 20);
            actionsPanel.Controls.Add(actionsTitle);

            // FEWER ACTIONS - only 3 instead of 6
            string[] actions = {
                "➕ Add New Product",
                "💰 Process New Sale",
                "👥 Register Customer"
                // REMOVED: "📦 Check Low Stock", "📊 View Daily Report", "⚙️ System Settings"
            };

            for (int i = 0; i < actions.Length; i++)
            {
                Button actionBtn = new Button();
                actionBtn.Text = actions[i];
                actionBtn.Font = new Font("Segoe UI", 11F);
                actionBtn.FlatStyle = FlatStyle.Flat;
                actionBtn.FlatAppearance.BorderSize = 0;
                actionBtn.BackColor = Color.Transparent;
                actionBtn.ForeColor = Color.FromArgb(70, 70, 70);
                actionBtn.Size = new Size(340, 38); // Slightly taller buttons
                actionBtn.Location = new Point(20, 60 + (i * 42)); // More spacing
                actionBtn.TextAlign = ContentAlignment.MiddleLeft;
                actionBtn.Cursor = Cursors.Hand;

                actionBtn.MouseEnter += (s, e) => actionBtn.BackColor = Color.FromArgb(245, 247, 250);
                actionBtn.MouseLeave += (s, e) => actionBtn.BackColor = Color.Transparent;

                int index = i;
                actionBtn.Click += (s, e) => HandleQuickActionClick(index);

                actionsPanel.Controls.Add(actionBtn);
            }

            // ========== ACTIVITY FEED ==========
            Panel activityPanel = new Panel();
            activityPanel.Size = new Size(380, 260);
            activityPanel.Location = new Point(410, 550);
            activityPanel.BackColor = Color.White;
            activityPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(activityPanel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(activityPanel.Width - radius * 2, activityPanel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, activityPanel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    e.Graphics.FillPath(Brushes.White, path);
                }
            };
            mainScrollPanel.Controls.Add(activityPanel);

            Label activityTitle = new Label();
            activityTitle.Text = "📈 RECENT ACTIVITY";
            activityTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            activityTitle.ForeColor = Color.FromArgb(51, 51, 51);
            activityTitle.AutoSize = true;
            activityTitle.Location = new Point(20, 20);
            activityPanel.Controls.Add(activityTitle);

            string[] activities = {
                "New sale: Air Jordan 1 - $150",
                "Customer registered: John Doe",
                "Low stock alert: Nike Dunk Low",
                "Brand added: New Balance",
                "Daily target achieved: $1,000",
                "Product added: Yeezy Boost 350"
            };

            string[] times = { "10:30 AM", "09:45 AM", "Yesterday", "Yesterday", "2 days ago", "3 days ago" };

            for (int i = 0; i < activities.Length; i++)
            {
                Panel activityItem = new Panel();
                activityItem.Size = new Size(340, 35);
                activityItem.Location = new Point(20, 60 + (i * 35));
                activityItem.BackColor = Color.Transparent;

                Label lblActivity = new Label();
                lblActivity.Text = activities[i];
                lblActivity.Font = new Font("Segoe UI", 10F);
                lblActivity.ForeColor = Color.FromArgb(70, 70, 70);
                lblActivity.AutoSize = true;
                lblActivity.Location = new Point(0, 0);

                Label lblTime = new Label();
                lblTime.Text = times[i];
                lblTime.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                lblTime.ForeColor = Color.FromArgb(150, 150, 150);
                lblTime.AutoSize = true;
                lblTime.Location = new Point(0, 18);

                activityItem.Controls.Add(lblActivity);
                activityItem.Controls.Add(lblTime);
                activityPanel.Controls.Add(activityItem);
            }
        }

        private Panel CreateNavigationCard(string title, Color color)
        {
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Rounded rectangle
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 8;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(card.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(card.Width - radius * 2, card.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, card.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();

                    e.Graphics.FillPath(Brushes.White, path);
                    e.Graphics.DrawPath(new Pen(Color.FromArgb(230, 230, 230), 1), path);
                }

                // Left accent border
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 10, 4, card.Height - 20);
            };

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(60, 60, 60);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 25);
            card.Controls.Add(lblTitle);

            // Click handler
            card.Click += (s, e) =>
            {
                if (mainMenu != null)
                {
                    switch (title)
                    {
                        case "Brands":
                            mainMenu.OpenForm(new BrandForm());
                            break;
                        case "Inventory":
                            mainMenu.OpenForm(new InventoryForm());
                            break;
                        case "Sales":
                            mainMenu.OpenForm(new SaleForm());
                            break;
                        case "Customers":
                            mainMenu.OpenForm(new CustomerForm());
                            break;
                        case "Staff":
                            mainMenu.OpenForm(new StaffForm());
                            break;
                    }
                }
            };

            return card;
        }

        private void DrawSalesChart(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Chart area
            int chartX = 40;
            int chartY = 20;
            int chartWidth = 660;
            int chartHeight = 200;

            // Background
            g.FillRectangle(Brushes.White, chartX, chartY, chartWidth, chartHeight);
            g.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220)),
                chartX, chartY, chartWidth, chartHeight);

            // Grid lines
            using (Pen gridPen = new Pen(Color.FromArgb(245, 245, 245)))
            {
                // Horizontal grid lines
                for (int i = 0; i <= 5; i++)
                {
                    int y = chartY + (i * (chartHeight / 5));
                    g.DrawLine(gridPen, chartX, y, chartX + chartWidth, y);
                }
            }

            // Use REAL sales data if available, otherwise use mock data
            decimal[] salesData;
            string[] days = new string[7];

            if (realSalesData != null && realSalesData.Count == 7)
            {
                // Use real data
                salesData = realSalesData.ToArray();

                // Generate day labels for the last 7 days
                for (int i = 0; i < 7; i++)
                {
                    var date = DateTime.Now.AddDays(-6 + i);
                    days[i] = date.ToString("ddd");
                }
            }
            else
            {
                // Fallback to mock data
                salesData = new decimal[] { 2230, 2885, 1758, 2414, 2447, 2730, 2100 };
                days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            }

            decimal maxValue = salesData.Max();
            if (maxValue == 0) maxValue = 1; // Prevent division by zero

            float pointSpacing = chartWidth / 8f;

            // Calculate points
            PointF[] points = new PointF[salesData.Length];
            for (int i = 0; i < salesData.Length; i++)
            {
                float x = chartX + ((i + 1) * pointSpacing);
                float y = chartY + chartHeight - ((float)(salesData[i] / maxValue) * chartHeight);
                points[i] = new PointF(x, y);
            }

            // Draw line
            using (Pen linePen = new Pen(Color.FromArgb(52, 152, 219), 3))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddCurve(points, 0.5f);
                    g.DrawPath(linePen, path);
                }
            }

            // Draw points and labels
            for (int i = 0; i < points.Length; i++)
            {
                // Draw point
                g.FillEllipse(Brushes.White, points[i].X - 6, points[i].Y - 6, 12, 12);
                g.DrawEllipse(new Pen(Color.FromArgb(52, 152, 219), 2),
                    points[i].X - 6, points[i].Y - 6, 12, 12);

                // Draw value label
                string valueText = $"${salesData[i]:0}";
                Font valueFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                SizeF valueSize = g.MeasureString(valueText, valueFont);
                float valueX = points[i].X - (valueSize.Width / 2);
                float valueY = points[i].Y - valueSize.Height - 10;

                if (valueY > chartY + 5)
                {
                    g.FillRectangle(Brushes.White, valueX - 3, valueY - 2,
                        valueSize.Width + 6, valueSize.Height + 4);
                    g.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)),
                        valueX - 3, valueY - 2, valueSize.Width + 6, valueSize.Height + 4);
                    g.DrawString(valueText, valueFont, Brushes.DarkSlateGray, valueX, valueY);
                }

                // Draw day label
                string dayText = days[i];
                Font dayFont = new Font("Segoe UI", 10F, FontStyle.Regular);
                SizeF daySize = g.MeasureString(dayText, dayFont);
                g.DrawString(dayText, dayFont, Brushes.DimGray,
                    points[i].X - (daySize.Width / 2), chartY + chartHeight + 5);
            }

            // Y-axis label
            Font yAxisFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            StringFormat yAxisFormat = new StringFormat();
            yAxisFormat.Alignment = StringAlignment.Center;
            yAxisFormat.LineAlignment = StringAlignment.Center;

            RectangleF yAxisRect = new RectangleF(5, chartY, 30, chartHeight);
            g.DrawString("($)", yAxisFont, Brushes.DimGray, yAxisRect, yAxisFormat);
        }

        private void HandleStatCardClick(string title)
        {
            if (mainMenu != null)
            {
                if (title.Contains("BRANDS"))
                {
                    mainMenu.OpenForm(new BrandForm());
                }
                else if (title.Contains("PRODUCTS"))
                {
                    mainMenu.OpenForm(new InventoryForm());
                }
                else if (title.Contains("CUSTOMERS"))
                {
                    mainMenu.OpenForm(new CustomerForm());
                }
                else if (title.Contains("SALES"))
                {
                    mainMenu.OpenForm(new SaleForm());
                }
            }
        }

        private void HandleQuickActionClick(int actionIndex)
        {
            if (mainMenu != null)
            {
                switch (actionIndex)
                {
                    case 0: mainMenu.OpenForm(new InventoryForm()); break;
                    case 1: mainMenu.OpenForm(new SaleForm()); break;
                    case 2: mainMenu.OpenForm(new CustomerForm()); break;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}