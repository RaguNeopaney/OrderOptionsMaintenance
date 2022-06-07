using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOptionsMaintenance.Models.DataLayer
{
    public partial class Products
    {
        public Products()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItems>();
        }

        [Key]
        [StringLength(10)]
        public string ProductCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public int OnHandQuantity { get; set; }

        [InverseProperty("ProductCodeNavigation")]
        public virtual ICollection<InvoiceLineItems> InvoiceLineItems { get; set; }
    }
}
