using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class ProductDetail
	{
		[Key]
		public Guid ProductDetailID { get; set; }
		public Guid SizeID { get; set; }
		public Guid ColorID { get; set; }

		public string Image { get; set; }
		public int Status { get; set; }
		

		public virtual Color Color { get; set; }
		public virtual Size Size { get; set; }
	}
}
