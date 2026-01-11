using System.ComponentModel.DataAnnotations;
using BiletApp.Models;

namespace BiletApp.ViewModels
{
    public class OrderCreateViewModel
    {
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

        [Required(ErrorMessage = "Bilet seçimi zorunludur")]
        [Display(Name = "Bilet")]
        public int TicketId { get; set; }

        // Dropdown için biletler listesi (Event bilgisi ile birlikte)
        public List<TicketInfo> Tickets { get; set; } = new List<TicketInfo>();

        // Hesaplanan toplam tutar
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }
    }

    public class TicketInfo
    {
        public int Id { get; set; }
        public string DisplayText { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}

