namespace Gorev1.Data
{
    public class Slayt
    {
        public int Id { get; set; }
        public string Resim { get; set; } = null!;

        public string Baslik { get; set; } = null!;
        public string Aciklama { get; set; } = null!;
        public int Sira { get; set; }
    }
}
