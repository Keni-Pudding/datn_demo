using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Brand
	{
		[Key]
		public Guid BrandID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
