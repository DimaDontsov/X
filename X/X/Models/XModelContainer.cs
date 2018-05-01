using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace X.Models
{
    public partial class XModelContainer
    {

        public virtual DbSet<BoughtDrugSuply> BoughtDrugSuplySet { get; set; }
        public virtual DbSet<DrugDistributor> DrugDistributorSet { get; set; }
        public virtual DbSet<DrugSuplier> DrugSuplierSet { get; set; }
        public virtual DbSet<DrugSuplyOffer>DrugSuplyOffers { get; set; }

        public System.Data.Entity.DbSet<X.Models.DrugSuplyOffer> DrugSuplies { get; set; }
    }
}