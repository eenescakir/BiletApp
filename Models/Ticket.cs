using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiletApp.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bilet türü zorunludur")]
        [StringLength(100, ErrorMessage = "Bilet türü en fazla 100 karakter olabilir")]
        [Display(Name = "Bilet Türü")]
        public string TicketType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, 10000, ErrorMessage = "Fiyat 0.01 ile 10000 arasında olmalıdır")]
        [Display(Name = "Fiyat")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0 veya pozitif olmalıdır")]
        [Display(Name = "Stok Miktarı")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Etkinlik seçimi zorunludur")]
        [Display(Name = "Etkinlik")]
        public int EventId { get; set; }

        // Navigation Property - 1-M ilişki
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; } = null!;

        // Navigation Property - 1-M ilişki
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

