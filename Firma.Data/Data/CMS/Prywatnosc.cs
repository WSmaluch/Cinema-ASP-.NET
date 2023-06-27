using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Prywatnosc
    {
        [Key]
        public int IdPrywatnosci { get; set; }

        [Display(Name = "Naglowek")]
        public string? Naglowek { get; set; }

        [Display(Name = "Tresc1")]
        public string? Tresc1 { get; set; }

        [Display(Name = "Tresc2")]
        public string? Tresc2 { get; set; }

        [Display(Name = "Tresc3")]
        public string? Tresc3 { get; set; }

        [Display(Name = "Tresc4")]
        public string? Tresc4 { get; set; }

        [Display(Name = "Lista")]
        public string? Lista { get; set; }

        [Display(Name = "Tresc5")]
        public string? Tresc5 { get; set; }

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
