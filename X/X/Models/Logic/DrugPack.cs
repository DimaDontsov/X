using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugPack
    {
        public string UnitsOfMeasurement { get {return BoughtDrugSuply?.UnitsOfMeasurement?.ShortName; } }
        public string DrugName { get { return BoughtDrugSuply?.Drug?.Name; } }

        public BoughtDrugSuply ReturnToSuply()
        {
            BoughtDrugSuply bds = this.BoughtDrugSuply;
            bds.Count += this.Count;
            return bds;
        }
    }
}