using System.ComponentModel.DataAnnotations;

namespace YineBirCore.Models
{
    public class Urunler
    {  
        [Key]
        public int UrunID { get; set; }

        [Required(ErrorMessage ="Gerekli Alan")]
        [Display(Name ="Ürün Adı")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Gerekli Alan")]
        [Display(Name = "Ürün Miktarı(kg)")]
        public int? Miktari { get; set; }

        [Required(ErrorMessage = "Gerekli Alan")]
        [Display(Name = "Birimi")]
        public string Birimi { get; set; }


        [Required(ErrorMessage = "Gerekli Alan")]
        [Display(Name = "Birim Fiyatı(TL)")]
        public decimal? BirimFiyati { get; set; }

    }
}
