using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugPack
    {
        string UnitsOfMeasurement { get { return BoughtDrugSuply.UnitsOfMeasurement.ShortName; } }
        string DrugName { get { return BoughtDrugSuply.Drug.Name; } }

        public BoughtDrugSuply ReturnToSuply()
        {
            BoughtDrugSuply bds = this.BoughtDrugSuply;
            bds.Count += this.Count;
            return bds;
        }
    }
}