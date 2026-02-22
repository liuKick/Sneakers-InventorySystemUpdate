using System;

namespace SneakerShop
{
    public class MockSalesDataStrategy : ISalesDataStrategy
    {
        public decimal[] GetSalesData()
        {
            return new decimal[] { 2230, 2885, 1758, 2414, 2447, 2730, 2100 };
        }

        public string[] GetDayLabels()
        {
            return new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        }
    }
}