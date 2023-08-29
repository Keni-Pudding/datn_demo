using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN_Demo.Shared.Models
{
	public class Product
	{
		[Key]
		public Guid ProductID { get; set; }
		public string Name { get; set; }
		public string SeoTitle { get; set; }
		public int Status { get; set; }
		
		public decimal Price { get; set; }
		public decimal PromotionPrice { get; set; }
		public bool VAT { get; set; }
		public int Quantity { get; set; }
		public int Warranty { get; set; }	
		public string Desciption { get; set; }

		public string MetaKeywords { get; set; }
		public string MetaDescriptionins { get; set; }
		public Guid CreateBy { get; set; }

		public DateTime CreateDate { get; set; }
		public Guid UpdateBy { get; set; }
		public DateTime UpdateDate { get; set; }

		public Guid BrandID { get; set; }
		public Guid SupplierID { get; set; }
		public Guid ProductDetailID { get; set; }

		public Guid ProductCategoryID { get; set; }
		public virtual Brand Brand { get; set; }
		public virtual Supplier Supplier { get; set; }

		public virtual ProductDetail ProductDetail { get; set; }
		public virtual ProductCategory ProductCategory { get; set; }

	}
}
