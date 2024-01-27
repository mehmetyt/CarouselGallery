using Gorev1.Areas.Admin.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Gorev1.Areas.Admin.Models
{
	public class YeniSlaytViewModel
	{
		public int Id { get; set; }

		[Gecerli(1.2)]
		[Required(ErrorMessage = "{0} ekleyin.")]
		public IFormFile Resim { get; set; } = null!;


		[Display(Name ="Başlık")]
		[Required(ErrorMessage = "{0} ekleyin.")]

		public string Baslik { get; set; } = null!;


		[Display(Name = "Açıklama")]
		[Required(ErrorMessage = "{0} ekleyin.")]
		public string Aciklama { get; set; } = null!;

		[Display(Name = "Sıra")]
		public int? Sira { get; set; } = null!;
	}
}
