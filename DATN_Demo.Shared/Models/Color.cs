using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Color
	{
		[Key]
		public Guid ColorID { get; set; }
		public string Name { get; set; }
		public int Status { get; set; }


		public virtual ICollection<ProductDetail> ProductDetails { get; set; }
	}
}
