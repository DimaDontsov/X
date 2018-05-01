using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugPack : ICloneable
    {
        public string UnitsOfMeasurement { get {return BoughtDrugSuply?.UnitsOfMeasurement?.ShortName; } }
        public string DrugName { get { return BoughtDrugSuply?.Drug?.Name; } }

        public object Clone()
        {
            var that = this;
            return new DrugPack()
            {
                BoughtDrugSuplyId = that.BoughtDrugSuplyId,
                CoordX = that.CoordX,
                CoordY = that.CoordY,
                Count = that.Count,
                Id = that.Id,
                Price = that.Price,
                BoughtDrugSuply = (BoughtDrugSuply)that.BoughtDrugSuply.Clone()
            };
        }
        

        public BoughtDrugSuply ReturnToSuply()
        {
            BoughtDrugSuply bds = this.BoughtDrugSuply;
            bds.Count += this.Count;
            return bds;
        }
    }
}