using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firma.Data.Data.CMS
{
    public class Posty
    {
        [Key]
        public int IdPostu { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Required(ErrorMessage = "Pole treść jest wymagane")]
        public string Tresc { get; set; }

        [Display(Name = "Data publikacji")]
        [Required(ErrorMessage = "Pole data publikacji jest wymagane")]
        public DateTime DataPublikacji { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Pole autor jest wymagane")]
        public string Autor { get; set; }

        [Display(Name = "Link do obrazka")]
        public string ObrazekUrl { get; set; }

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
