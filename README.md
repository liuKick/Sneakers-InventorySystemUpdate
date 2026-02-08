# Sneakers-InventorySystemUpdate
📋 Overview
A professional management system for sneaker shops that handles inventory, sales, customers, brands, and staff management. Built as a school project demonstrating 5 software design patterns with real database integration.

✨ Features
🎯 Core Modules
📊 Dashboard - Real-time statistics and sales trends

🏷️ Brand Management - CRUD operations for sneaker brands

📦 Inventory Management - Full product catalog with stock tracking

💰 Sales Processing - Complete sales transactions

👥 Customer Management - Customer database and profiles

👤 Staff Management - Employee management (admin only)

🛠️ Technical Features
🔐 Modern UI - Clean, professional interface with smooth animations

🗄️ Database Integration - Real-time Supabase PostgreSQL connection

🔍 Search & Filter - Advanced search across all modules
Frontend:    C# WinForms (.NET Framework 4.8)
Backend:     Supabase (PostgreSQL + REST API)
Database:    PostgreSQL with real-time subscriptions
Patterns:    5 Software Design Patterns
SneakerShop/
├── Forms/                 # All application forms
│   ├── DashboardForm.cs   # Main dashboard with charts
│   ├── BrandForm.cs       # Brand management
│   ├── InventoryForm.cs   # Product inventory
│   ├── SaleForm.cs        # Sales processing
│   ├── CustomerForm.cs    # Customer management
│   └── StaffForm.cs       # Staff management
├── Models/                # Data models
│   ├── Brand.cs
│   ├── Customer.cs
│   ├── Sale.cs
│   ├── Sneaker.cs
│   └── User.cs
├── Services/              # Business logic
│   ├── SupabaseClient.cs  # Database connection
│   └── DatabaseService.cs # Data operations
├── MainMenu.cs           # Navigation system
└── Program.cs            # Application entry point
🎨 Design Patterns Implemented
1. Singleton Pattern ✅
csharp
// SupabaseClient.cs - Single database instance
public static SupabaseClient Instance { get; } = new SupabaseClient();
Ensures only one database connection exists

Global access point for all data operations

2. Repository Pattern ✅
csharp
// Centralized CRUD operations for all entities
public async Task<List<T>> GetAllAsync<T>() where T : BaseModel
public async Task<T> GetByIdAsync<T>(string id) where T : BaseModel
Abstracts data access layer

Clean separation between business logic and data access

3. Factory Pattern ✅
csharp
// MainMenu.cs - Form creation factory
public void OpenForm(string formName)
{
    switch (formName)
    {
        case "Dashboard": return new DashboardForm(this);
        case "Brands": return new BrandForm();
        // ... other forms
    }
}
Centralized object creation

Easy form instantiation

4. Observer Pattern ✅
csharp
// Event-driven architecture throughout
button.Click += (s, e) => HandleClick();
dataGridView.CellClick += (s, e) => ShowDetails();
txtSearch.TextChanged += (s, e) => FilterData();
Decouples event sources from handlers

Reactive UI components

5. Strategy Pattern ✅
csharp
// Flexible data formatting and operations
public static string FormatCurrency(decimal amount)
{
    return string.Format("${0:N2}", amount);
}
// Extensible for different strategies
Interchangeable algorithms
Easy to add new behaviors
📈 Data Visualization - Interactive charts and statistics
📱 Responsive Design - Collapsible sidebar, adaptive layouts
