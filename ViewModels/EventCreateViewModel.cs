using System.ComponentModel.DataAnnotations;
using BiletApp.Models;

namespace BiletApp.ViewModels
{
    public class EventCreateViewModel
    {
        [Required(ErrorMessage = "Etkinlik adı zorunludur")]
        [StringLength(200, ErrorMessage = "Etkinlik adı en fazla 200 karakter olabilir")]
        [Display(Name = "Etkinlik Adı")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur")]
        [Display(Name = "Etkinlik Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Mekan zorunludur")]
        [StringLength(200, ErrorMessage = "Mekan adı en fazla 200 karakter olabilir")]
        [Display(Name = "Mekan")]
        public string Venue { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Resim URL")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        // Dropdown için kategoriler listesi
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}

