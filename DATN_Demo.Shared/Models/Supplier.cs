using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Supplier
	{
		[Key]
		public Guid SupplierID { get; set; }
		public string Name { get; set;}
		public string Email { get; set;}
		public string PhoneNumber { get; set;}
		public string Address { get; set;}
		
		public virtual ICollection<Product> Products { get; set; }
	}
}
