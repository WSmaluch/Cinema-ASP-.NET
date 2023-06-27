using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firma.Data.Data.Kino
{
    public class Filmy
    {
        [Key]
        public int IdFilmu { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [StringLength(100, ErrorMessage = "Tytuł nie może być dłuższy niż 100 znaków")]
        [Display(Name = "Tytuł filmu")]
        public string Tytuł { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [StringLength(5000, ErrorMessage = "Opis nie może być dłuższy niż 5000 znaków")]
        [Display(Name = "Opis filmu")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Data premiery jest wymagana")]
        [DataType(DataType.Date)]
        [Display(Name = "Data premiery")]
        public DateTime DataPremiery { get; set; }

        [Required(ErrorMessage = "Reżyser jest wymagany")]
        [StringLength(100, ErrorMessage = "Reżyser nie może być dłuższy niż 100 znaków")]
        [Display(Name = "Reżyser")]
        public string Rezyser { get; set; }

        [Required(ErrorMessage = "Długość filmu jest wymagana")]
        [Range(1, int.MaxValue, ErrorMessage = "Długość filmu musi być większa od 0")]
        [Display(Name = "Długość filmu (w minutach)")]
        public int Dlugosc { get; set; }

        
        [StringLength(100, ErrorMessage = "Gatunek nie może być dłuższy niż 100 znaków")]
        [Display(Name = "Gatunek")]
        public string Gatunek { get; set; }


        [Display(Name = "Link do zwiastunu")]
        public string LinkDoZwiastunu { get; set; }

        [Display(Name = "Od kiedy grany")]
        [DataType(DataType.Date)]
        public DateTime? OdKiedyGrany { get; set; }

        [Display(Name = "Do kiedy grany")]
        [DataType(DataType.Date)]
        public DateTime? DoKiedyGrany { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Zdjecie { get; set; }

		[Required(ErrorMessage = "Godziny grania są wymagane")]
		[Display(Name = "Godziny grania")]
		public string GodzinyGrania { get; set; }

        [Display(Name = "Miejsca")]
        public List<Miejsce> Miejsca { get; set; }


        [Display(Name = "Aktywny")]
        public bool CzyAktywny { get; set; } = true;

        [Display(Name = "Dodane przez")]
        public string? KtoDodal { get; set; }

        [Display(Name = "Data dodania")]
        
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
