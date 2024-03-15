using System;
namespace ActivoWebPage.Models
{
	public class Category
	{
		public int categoryID { get; set; }

		public string? name { get; set; }

		public DateTime? timestamp { get; set; }

		public Activities[]? activity {get; set;}
	}
}
