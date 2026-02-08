using System;
using System.Windows.Forms;

namespace SneakerShop
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ ADD THIS LINE - Initialize Supabase BEFORE any forms
            SupabaseClient.Initialize();

            Application.Run(new Forms.LoginForm()); // Start with LoginForm
        }
    }
}