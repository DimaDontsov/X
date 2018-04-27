using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugDistributor
    {
        BoughtDrugSuply Buy( DrugSuply suply)
        {
            BoughtDrugSuply bds = new BoughtDrugSuply()
            {
                Count = suply.Count,
                DeliveryTime = suply.DeliveryTime,
                Drug = suply.Drug,
                DrugDistributor = this,
                DrugSuplier = suply.DrugSuplier,
                Price = suply.Price,
                UnitsOfMeasurement = suply.UnitsOfMeasurement
            };
            return bds;
        }
    }
}