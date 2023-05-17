using System;
using System.Collections.Generic;
using System.Text;

namespace SEPAL.Analytics.DAL.DataModels
{
    internal class TrendAnalyticsDTO
    {
        public DateTime Date { get; set; }
        public double OilProduction { get; set; }
        public double GasProduction { get; set; }
        public double WaterProduction { get; set; }
    }
}
