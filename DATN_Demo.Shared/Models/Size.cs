using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Size
	{
		[Key]
		public Guid SizeID { get; set; }
		public string SizeName { get; set; }
		public int Status { get; set; }
		public virtual ICollection<ProductDetail> ProductDetails { get; set; }
		
	}
}
