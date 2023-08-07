using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToplantiProjem.Models
{
    public class Duyuru
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ToplantiAdi { get; set; }

        public DateTime Baslangic { get; set; }
        public DateTime Bitis  { get; set; }

        public string Aciklama { get; set; }

        [ValidateNever]
        public int ToplantiTuruId { get; set; }
        [ForeignKey("ToplantiTuruId")]
        [ValidateNever]
        public Toplanti Toplanti { get; set; }
       
        [ValidateNever]
        public string Dokuman { get; set; }
    }
}
