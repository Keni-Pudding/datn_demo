using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Role
	{
		public Guid RoleID { get; set; }
		public string Name { get; set; }
		public int Status { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}
