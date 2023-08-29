using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class ProductCategory
	{
		[Key]
		public Guid CateID { get; set; }
		public string Name { get; set; }
		public string SeoTitle { get; set; }
		public int Status { get; set; }
		public int Soft { get; set; }
		public Guid ParentID { get; set; } = Guid.Empty;
		public string MetaKeywords  { get; set; }
		public string MetaDescriptionins { get; set; }
		public Guid CreateBy { get; set; }

		public DateTime CreateDate { get; set; }
		public Guid UpdateBy { get; set; }
		public DateTime UpdateDate { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	
	}
}
