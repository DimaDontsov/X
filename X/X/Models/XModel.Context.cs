﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace X.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class XModelContainer : DbContext
    {
        public XModelContainer()
            : base("name=XModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DrugSuply> DrugSuplySet { get; set; }
        public virtual DbSet<SystemUser> SystemUserSet { get; set; }
        public virtual DbSet<Drug> DrugSet { get; set; }
        public virtual DbSet<UnitsOfMeasurement> UnitsOfMeasurementSet { get; set; }
        public virtual DbSet<DrugPack> DrugPackSet { get; set; }
    }
}
