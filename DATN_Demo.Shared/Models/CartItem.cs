using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class CartItem
	{
		[Key]
		public Guid CartID { get; set; }
		public Guid ProductDetail { get; set; }
		public int Status { get; set; }
	}
}
