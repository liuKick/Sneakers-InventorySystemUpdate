using System;

namespace SneakerShop
{
    public interface ISalesDataStrategy
    {
        decimal[] GetSalesData();
        string[] GetDayLabels();
    }
}