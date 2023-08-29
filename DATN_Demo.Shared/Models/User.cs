using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class User
	{
		[Key]
		public Guid UserID { get; set; }
		public string Name { get; set; } =string.Empty;
		public string UserName { get; set; } = string.Empty;
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public int Status { get; set; }

		public Guid RoleID { get; set; }

		public virtual Role Roles { get; set; }
		public virtual Cart Cart { get; set; }
		public virtual ICollection<Orders> Order { get; set; }
		
	}
}
