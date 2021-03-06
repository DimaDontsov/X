﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugSuply : ICloneable
    {
        public string DrugName { get { return Drug.Name; } }
        public string UnitsOfMeasurementName {  get { return UnitsOfMeasurement.ShortName;  } }
        public string DrugSuplierName {  get { return DrugSuplier.Name; } }

        public object Clone()
        {
            return new DrugSuply()
            {
                Count = this.Count,
                DeliveryTime = this.DeliveryTime,
                Drug = this.Drug,
                DrugSuplier = this.DrugSuplier,
                Price = this.Price,
                UnitsOfMeasurement = this.UnitsOfMeasurement,
            };
        }
    }
}