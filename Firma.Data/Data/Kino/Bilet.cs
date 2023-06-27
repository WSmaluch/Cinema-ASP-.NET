using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firma.Data.Data.Kino
{
    public class Bilet
    {
        [Key]
        public int IdBiletu { get; set; }

        [Display(Name = "ID Filmu")]
        public int FilmId { get; set; }

        [ForeignKey("FilmId")]
        public Filmy Film { get; set; }

        [Display(Name = "Numer Siedzenia")]
        public int NumerSiedzenia { get; set; }

        [Display(Name = "Data Projekcji")]
        public DateTime DataProjekcji { get; set; }

        [Display(Name = "Czas Projekcji")]
        public DateTime CzasProjekcji { get; set; }

        [Display(Name = "Zarezerwowane przez")]
        public string ZarezerwowanyPrzez { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Numer Telefonu")]
        public string NrTelefonu { get; set; }

        [Display(Name = "Aktywny")]
        public bool CzyAktywny { get; set; } = true;

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
