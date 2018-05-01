using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class BoughtDrugSuply
    {
        public DrugPack MakePack(int count, string coordX, string coordY, int price)
        {
            DrugPack dp = new DrugPack()
            {
                BoughtDrugSuply = this,
                CoordX = coordX,
                CoordY = coordY,
                Price = price,
                Count = Math.Min(count, this.Count)
            };
            this.Count -= dp.Count;
            return dp;
        }

        public object Clone()
        {
            var that = this;
            return new BoughtDrugSuply()
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