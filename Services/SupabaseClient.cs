using Supabase;
using System;
using System.Windows.Forms;

namespace SneakerShop
{
    public static class SupabaseClient
    {
        private static bool _isInitialized = false;
        private static readonly object _lock = new object();

        public static Client Client { get; private set; }

        public static void Initialize()
        {
            lock (_lock)
            {
                if (!_isInitialized)
                {
                    try
                    {
                        var url = "https://dgnnhpphgkewbgyeohgc.supabase.co";
                        var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImRnbm5ocHBoZ2tld2JneWVvaGdjIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjAzMTE5OTAsImV4cCI6MjA3NTg4Nzk5MH0.TKXuUeMhR3BW6yQu33aJvcYpwV1b-Hio5okHZqno3Kw";

                        // Simple initialization without complex options
                        Client = new Client(url, key);
                        Client.InitializeAsync().Wait();
                        _isInitialized = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Connection failed: {ex.Message}", "Error");
                    }
                }
            }
        }
    }
}