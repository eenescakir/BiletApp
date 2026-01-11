using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiletApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Müşteri adı zorunludur")]
        [StringLength(100, ErrorMessage = "Müşteri adı en fazla 100 karakter olabilir")]
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(200, ErrorMessage = "E-posta en fazla 200 karakter olabilir")]
        [Display(Name = "E-posta")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur")]
        [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir")]
        [Display(Name = "Telefon")]
        public string CustomerPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bilet miktarı zorunludur")]
        [Range(1, 100, ErrorMessage = "Bilet miktarı 1 ile 100 arasında olmalıdır")]
        [Display(Name = "Bilet Miktarı")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Toplam tutar zorunludur")]
        [Display(Name = "Toplam Tutar")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Bilet seçimi zorunludur")]
        [Display(Name = "Bilet")]
        public int TicketId { get; set; }

        // Navigation Property - 1-M ilişki
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; } = null!;
    }
}

