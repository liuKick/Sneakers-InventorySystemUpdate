using SneakerShop.Models;
using Supabase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using System.Linq;

namespace SneakerShop
{
    public class DatabaseService
    {
        private void ClearSchemaCache()
        {
            try
            {
                // Force re-initialization to clear cache
                SupabaseClient.Initialize();
            }
            catch { /* Ignore errors */ }
        }

        public async Task<bool> AddBrand(Brand brand)
        {
            try
            {
                await SupabaseClient.Client.From<Brand>().Insert(brand);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding brand: {ex.Message}", "Error");
                return false;
            }
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            try
            {
                var response = await SupabaseClient.Client.From<Brand>().Get();
                return response.Models;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting brands: {ex.Message}", "Error");
                return new List<Brand>();
            }
        }

        // USER METHODS FOR STAFFFORM
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var response = await SupabaseClient.Client.From<User>().Get();
                return response.Models;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting users: {ex.Message}", "Error");
                return new List<User>();
            }
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                ClearSchemaCache(); // ADDED: Clear schema cache
                await SupabaseClient.Client.From<User>().Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error");
                return false;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                ClearSchemaCache(); // ADDED: Clear schema cache
                await SupabaseClient.Client.From<User>().Where(u => u.Id == user.Id).Update(user);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error");
                return false;
            }
        }

        public async Task<bool> DeleteUser(string userId)
        {
            try
            {
                ClearSchemaCache(); // ADDED: Clear schema cache
                await SupabaseClient.Client.From<User>().Where(u => u.Id == userId).Delete();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error");
                return false;
            }
        }

        // Check if username already exists - TEMPORARY FIX
        public async Task<bool> UsernameExists(string username)
        {
            // TEMPORARY FIX: Get all users and check manually to avoid column casing issues
            try
            {
                var allUsers = await GetAllUsers();
                return allUsers.Any(u => u.Username?.ToLower() == username?.ToLower());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking username: {ex.Message}", "Error");
                return false;
            }
        }

        // BCrypt Password Hashing Method
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}