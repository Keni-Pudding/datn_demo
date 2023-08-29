using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Orders
	{
		[Key]

		public Guid UserID { get; set; }
		public DateTime OrderDate { get; set; }
		public int Status { get; set; }
		public DateTime DeliveryDate { get; set; }
		
		public virtual User User { get; set; }		

	}
}
