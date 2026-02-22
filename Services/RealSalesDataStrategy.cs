using System;
using System.Collections.Generic;
using System.Linq;

namespace SneakerShop
{
    public class RealSalesDataStrategy : ISalesDataStrategy
    {
        private List<decimal> _realSalesData;

        public RealSalesDataStrategy(List<decimal> realSalesData)
        {
            _realSalesData = realSalesData;
        }

        public decimal[] GetSalesData()
        {
            return _realSalesData.ToArray();
        }

        public string[] GetDayLabels()
        {
            string[] days = new string[7];
            for (int i = 0; i < 7; i++)
            {
                var date = DateTime.Now.AddDays(-6 + i);
                days[i] = date.ToString("ddd");
            }
            return days;
        }
    }
}