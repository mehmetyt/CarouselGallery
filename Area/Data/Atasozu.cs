using System.ComponentModel.DataAnnotations;

namespace Area.Data
{
    public class Atasozu
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Icerik { get; set; } = null!;
    }
}
