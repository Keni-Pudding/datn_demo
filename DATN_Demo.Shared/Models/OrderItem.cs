using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class OrderItem
	{
		[Key]
		public Guid ItemId { get; set; }
		public Guid OrderID { get; set; }

		
		public Guid ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

	}
}
