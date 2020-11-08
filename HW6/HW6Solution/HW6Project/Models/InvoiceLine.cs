﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW6Project.Models
{
    [Table("InvoiceLine")]
    public partial class InvoiceLine
    {
        [Key]
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceLines")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(TrackId))]
        [InverseProperty("InvoiceLines")]
        public virtual Track Track { get; set; }
    }
}
