using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugSuply : ICloneable
    {
        public string DrugName { get { return Drug?.Name; } }
        public string UnitsOfMeasurementName {  get { return UnitsOfMeasurement?.ShortName;  } }
        public string DrugSuplierName {  get { return DrugSuplier?.Name; } }

        public object Clone()
        {
            var that = this;
            return new DrugSuply()
            {
                Count = that.Count,
                DeliveryTime = that.DeliveryTime,
                Drug = that.Drug,
                DrugSuplierId = that.DrugSuplierId,
                Price = that.Price,
                UnitsOfMeasurement = that.UnitsOfMeasurement,
            };
        }
    }
}