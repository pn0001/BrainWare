//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositories.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderproduct
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public int quantity { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}