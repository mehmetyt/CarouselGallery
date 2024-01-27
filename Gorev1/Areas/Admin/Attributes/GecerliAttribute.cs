using System.ComponentModel.DataAnnotations;

namespace Gorev1.Areas.Admin.Attributes
{
	public class GecerliAttribute : ValidationAttribute
	{
		public double MaxBoyut { get; set; } = 1;

        public GecerliAttribute(double boyut)
        {
            MaxBoyut = boyut;
        }

        public override bool IsValid(object? value)
		{
			IFormFile? file = (IFormFile?)value;
			if (file == null)
			{
				return true;
			}
			if (!file.ContentType.StartsWith("image/"))
			{
				ErrorMessage = "Geçerli bir resim dosyası girin.";
				return false;
			}
			if (file.Length > MaxBoyut * 1024 * 1024)
			{
				ErrorMessage = $"Dosya boyutu maksimum {MaxBoyut}MB olmalıdır";
				return false;
			}
			return true;

		}
	}
}
