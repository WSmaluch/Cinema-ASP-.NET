using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firma.Data.Data.CMS
{
    public class StronaGlowna
    {
        [Key]
        public int IdStronyGlownej { get; set; }

        [Display(Name = "BanneryZdjecia")]
        public string? Bannery { get; set; }

        [Display(Name = "Teksty do banerow")]
        [Required(ErrorMessage = "Teksty do banerow jest wymagane")]
        public string TekstyBanner { get; set; }

        [Display(Name = "ReklamyZdjecia")]
        public string? ReklamyZdjecia { get; set; }

        [Display(Name = "Teksty do reklamy")]
        [Required(ErrorMessage = "Teksty do reklamy jest wymagane")]
        public string TekstyReklama { get; set; }

        [Display(Name = "Partnerzy zdjecia")]
        [Required(ErrorMessage = "Partnerzy zdjecia jest wymagane")]
        public string? PartnerzyZdjecia { get; set; }

        [Display(Name = "Aktywny")]
        public bool CzyAktywny { get; set; } = true;

        [Display(Name = "Dodane przez")]
        public string? KtoDodal { get; set; }

        [Display(Name = "Data dodania")]
        [Required(ErrorMessage = "Pole data dodania jest wymagane")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime KiedyDodal { get; set; } = DateTime.Now;

        [Display(Name = "Zmodyfikowane przez")]
        public string? KtoZmodyfikowal { get; set; }

        [Display(Name = "Data modyfikacji")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? KiedyZmodyfikowal { get; set; }

        [Display(Name = "Usunięte przez")]
        public string? KtoWykasowal { get; set; }

        [Display(Name = "Data usunięcia")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? KiedyWykasowal { get; set; }

    }
}
