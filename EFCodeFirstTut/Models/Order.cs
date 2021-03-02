using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstTut.Models {
	public class Order {
		public int Id { get; set; }
		[StringLength(200), Required]
		public string Description { get; set; }
		[StringLength(12), Required]
		public string Status { get; set; }
		[Column(TypeName ="decimal(9,2)")]
		public decimal total { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; } // Set customer as foreign key
	}
}

