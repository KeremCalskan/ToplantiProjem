using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToplantiProjem.Models
{
    public class Toplanti
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Toplantı Türü boş bırakılamaz!")]
        [MaxLength(25)]
        [DisplayName("Toplantı Türü Adı")]
        public string Ad { get; set; }
    }
}
