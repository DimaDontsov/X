//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DrugSuply
    {
        public int Id { get; set; }
        public int DrugSuplierId { get; set; }
        public long Price { get; set; }
        public System.DateTime DeliveryTime { get; set; }
        public int DrugId { get; set; }
        public int Count { get; set; }
        public int UnitsOfMeasurementId { get; set; }
    
        public virtual DrugSuplier DrugSuplier { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual UnitsOfMeasurement UnitsOfMeasurement { get; set; }
    }
}
