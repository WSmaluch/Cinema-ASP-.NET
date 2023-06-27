using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firma.Data.Data.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }
        [Required(ErrorMessage = "Tytul jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytul moze zawierac max 10 znakow")]
        [Display(Name = "Tytul odnośnika do strony")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytul jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytul moze zawierac max 10 znakow")]
        [Display(Name = "Tytul strony")]
        public string Tytul { get; set; }

        [Display(Name = "Tytul strony")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }

        [Display(Name = "Pozycja wyswietlania")]
        [Required(ErrorMessage = "Pozycja jest wymagana")]
        public int Pozycja { get; set; }

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
