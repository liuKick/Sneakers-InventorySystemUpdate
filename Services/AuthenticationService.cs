using Supabase;
using System.Threading.Tasks;

public static class AuthenticationService
{
    public static async Task<bool> Login(string username, string password)
    {
        try
        {
            // SIMPLE HARDCODED CHECK - NO DATABASE NEEDED
            if (username == "admin" && password == "admin123")
            {
                return true;
            }
            if (username == "staff" && password == "staff123")
            {
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }
}