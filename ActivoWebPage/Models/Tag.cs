using System;
namespace ActivoWebPage.Models
{
	public class Tag
	{
		public int tagID { get; set; }

		public string? name { get; set; }

		public DateTime? timestamp { get; set; }

		public Activity[]? activity { get; set; }
	}
}

