using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class DrugDistributor
    {
        public IEnumerable<DrugPack> DrugPacks { get
            {
                if (BoughtDrugSuplies != null)
                {
                    foreach (var s in this.BoughtDrugSuplies)
                    {
                        if (s.DrugPacks != null)
                        {
                            foreach (var p in s.DrugPacks)
                            {
                                yield return p;
                            }
                        }
                        else
                        {
                            yield break;
                        }
                    }
                }
                else
                {
                    yield break;
                }
            }
                
        }

        public BoughtDrugSuply Buy( DrugSuplyOffer suply)
        {
            if (suply.Price > this.Balance)
            {
                throw new Exception("Нужно боольше золота. Да милорд. Как скажешь, хозяин. Вжих-вжих. Попытка купить распространитель поставку, на которую у него не хватает денег");
            }
            this.Balance -= suply.Price;
            suply.DrugSuplier.Balance += suply.Price;
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