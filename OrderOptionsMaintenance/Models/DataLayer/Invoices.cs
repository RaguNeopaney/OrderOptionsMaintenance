using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderOptionsMaintenance.Models.DataLayer
{
    public partial class Invoices
    {
        public Invoices()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItems>();
        }

        [Key]
        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "money")]
        public decimal ProductTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesTax { get; set; }
        [Column(TypeName = "money")]
        public decimal Shipping { get; set; }
        [Column(TypeName = "money")]
        public decimal InvoiceTotal { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Invoices))]
        public virtual Customers Customer { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceLineItems> InvoiceLineItems { get; set; }
    }
}
