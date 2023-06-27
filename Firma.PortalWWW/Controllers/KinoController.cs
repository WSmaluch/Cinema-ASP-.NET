using Firma.Data.Data;
using Firma.Data.Data.Kino;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class KinoController : Controller
    {
        private readonly FirmaContext _context;

        public KinoController(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? date)
        {

            DateTime selectedDate = date.HasValue ? date.Value.Date : DateTime.Today;

            var filmy = await _context.Filmy
                .Where(f => (f.OdKiedyGrany.HasValue && f.OdKiedyGrany.Value.Date <= selectedDate) && (f.DoKiedyGrany.HasValue && f.DoKiedyGrany.Value.Date >= selectedDate))
                .ToArrayAsync();



            ViewBag.SelectedDate = selectedDate.ToShortDateString();

            return View(filmy);
        }




        public async Task<IActionResult> Szczegoly(int? id)
        {
            var oferty = _context.Oferty.ToList(); 
            var losoweOferty = oferty.OrderBy(o => Guid.NewGuid()).Take(3).Distinct().ToList(); 
            ViewBag.ModelOferty = losoweOferty; 


            var dzis = DateTime.Today;

            ViewBag.ModelFilm = (
                from film in _context.Filmy
                where film.OdKiedyGrany <= dzis && film.DoKiedyGrany >= dzis
                select film
            ).ToList();


            ViewBag.Filmy = await _context.Filmy.ToListAsync();
            return View(await _context.Filmy.FirstOrDefaultAsync(f => f.IdFilmu == id));

        }


        public async Task<IActionResult> WybierzMiejscaAsync(int id, string godzinaGrania, string dataProjekcji)
        {
            ViewBag.GodzinaGrania = godzinaGrania;
            ViewBag.DataProjekcji = dataProjekcji;

            var film = await _context.Filmy.Include(f => f.Miejsca)
                .FirstOrDefaultAsync(f => f.IdFilmu == id);

            if (film == null)
            {
                return NotFound();
            }

            var reservedSeatsList = GetReservedSeats(film.IdFilmu, DateTime.Parse(dataProjekcji), DateTime.Parse(godzinaGrania));

            ViewBag.ReservedSeatsList = reservedSeatsList; // lista zarezerwowanych miejsc do widoku

            return View(film);
        }

        private List<int> GetReservedSeats(int filmId, DateTime dataProjekcji, DateTime czasProjekcji)
        {
            List<int> reservedSeatsList = _context.Bilet
                .Where(b => b.FilmId == filmId &&
                            b.DataProjekcji.Date == dataProjekcji.Date &&
                            b.DataProjekcji.TimeOfDay == czasProjekcji.TimeOfDay)
                .Select(b => b.NumerSiedzenia)
                .ToList();

            return reservedSeatsList;
        }


        [HttpPost]
        public async Task<IActionResult> Rezerwuj(int filmId, string selectedSeats, string imie, string nazwisko,string email, string nrTel, string selectedDate, string selectedTime)
        {
            DateTime dataProjekcji = Convert.ToDateTime(selectedDate).Add(TimeSpan.Parse(selectedTime));

            List<Bilet> bilety = new List<Bilet>();

            if (!string.IsNullOrEmpty(selectedSeats))
            {
                int[] selectedSeatsArray = selectedSeats.Split(',').Select(int.Parse).ToArray();

                foreach (var seatNumber in selectedSeatsArray)
                {
                    Bilet bilet = new Bilet
                    {
                        FilmId = filmId,
                        NumerSiedzenia = seatNumber,
                        DataProjekcji = dataProjekcji,
                        ZarezerwowanyPrzez = imie + ' ' + nazwisko,
                        Email = email,
                        NrTelefonu = nrTel,
                        CzyAktywny = true
                    };
                    bilety.Add(bilet);
                    _context.Bilet.Add(bilet);
                }

                _context.SaveChanges();
            }

            ViewBag.Bilety = bilety;
            ViewBag.TytulFilmu = _context.Filmy.Find(filmId).Tytuł;
            ViewBag.DataProjekcji = dataProjekcji.ToString("dd-MM-yyyy HH:mm");
            ViewBag.ZarezerwowanyPrzez = imie + ' ' + nazwisko;
            ViewBag.Email = email;


            return View("PotwierdzenieRezerwacji");
        }






        private int rzadMiejsce(int numerSiedzenia)
        {
            if (numerSiedzenia>=1 && numerSiedzenia <=14)
                return 1;
            else if(numerSiedzenia >= 15 && numerSiedzenia <= 31)
            {
                return 2;
            }
            else if (numerSiedzenia >= 32 && numerSiedzenia <= 48)
            {
                return 3;
            }
            else if (numerSiedzenia >= 49 && numerSiedzenia <= 65)
            {
                return 4;
            }
            else if (numerSiedzenia >= 66 && numerSiedzenia <= 82)
            {
                return 5;
            }
            else if (numerSiedzenia >= 83 && numerSiedzenia <= 99)
            {
                return 6;
            }
            else if (numerSiedzenia >= 100 && numerSiedzenia <= 116)
            {
                return 7;
            }
            else if (numerSiedzenia >= 117 && numerSiedzenia <= 136)
            {
                return 8;
            }
            else if (numerSiedzenia >= 137 && numerSiedzenia <= 158)
            {
                return 9;
            }
            else
            {
                return 0;
            }
        }

        public IActionResult GenerateTicket(int filmId, int seatNumber, string name, string selectedDate, string selectedTime)
        {
            string movieTitle = _context.Filmy.FirstOrDefault(f => f.IdFilmu == filmId).Tytuł;
            string cinema = "Belle";
            string date = selectedDate;
            string time = selectedTime;
            string seat = seatNumber.ToString();
            string NumerBiletu = _context.Bilet.Max(b => b.IdBiletu).ToString();
            int nrRzedu = rzadMiejsce(seatNumber);

            string ticketHtml = @"
        <html>
        <head>
            <script src=""https://cdn.rawgit.com/davidshimjs/qrcodejs/gh-pages/qrcode.min.js""></script>
            <script src=""https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js""></script>
            <style>
                .cardWrap {
              width: 27em;
              margin: 3em auto;
              color: #fff;
              font-family: sans-serif;
            }

            .card {
              background: linear-gradient(to bottom, #3FCACA 0%, #3FCACA 26%, #ecedef 26%, #ecedef 100%);
              height: 11em;
              float: left;
              position: relative;
              padding: 1em;
              margin-top: 100px;
            }

            .cardLeft {
              border-top-left-radius: 8px;
              border-bottom-left-radius: 8px;
              width: 16em;
            color:black;
            }

            .cardRight {
              width: 6.5em;
              border-left: 0.18em dashed #fff;
              border-top-right-radius: 8px;
              border-bottom-right-radius: 8px;
            }
            .cardRight:before, .cardRight:after {
              content: "";
              position: absolute;
              display: block;
              width: 0.9em;
              height: 0.9em;
              background: #fff;
              border-radius: 50%;
              left: -0.5em;
            }
            .cardRight:before {
              top: -0.4em;
            }
            .cardRight:after {
              bottom: -0.4em;
            }

            h1 {
              font-size: 1.1em;
              margin-top: 0;
            }
            h1 span {
              font-weight: normal;
            }

            .title, .name, .seat, .time {
              text-transform: uppercase;
              font-weight: normal;
            }
            .title h2, .name h2, .seat h2, .time h2 {
              font-size: 0.9em;
              color: #525252;
              margin: 0;
            }
            .title span, .name span, .seat span, .time span {
              font-size: 0.7em;
              color: #a2aeae;
            }

            .title {
              margin: 2em 0 0 0;
            }

            .name, .seat {
              margin: 0.7em 0 0 0;
            }

            .time {
              margin: 0.7em 0 0 1em;
            }

            .seat, .time {
              float: left;
            }

            .eye {
              position: relative;
              width: 2em;
              height: 1.5em;
              background: #fff;
              margin: 0 auto;
              border-radius: 1em/0.6em;
              z-index: 1;
            }
            .eye:before, .eye:after {
              content: "";
              display: block;
              position: absolute;
              border-radius: 50%;
            }
            .eye:before {
              width: 1em;
              height: 1em;
              background: #e84c3d;
              z-index: 2;
              left: 8px;
              top: 4px;
            }
            .eye:after {
              width: 0.5em;
              height: 0.5em;
              background: #fff;
              z-index: 3;
              left: 12px;
              top: 8px;
            }

            .number {
              text-align: center;
              text-transform: uppercase;
                margin-top:-15px;
            margin-bottom:5px;
            }
            .number h3 {
              color: #e84c3d;
              margin: 0.9em 0 0 0;
              font-size: 2.5em;
            }
            .number span {
              display: block;
              color: #a2aeae;
            }

            .qr-code-container 
            {
                                text-align: center;
                                margin-top: 20px;
            }
            .qr-code {
                    max-width: 100px;

            }

            .barcode {
              height: 2em;
              width: 0;
              margin: 1.2em 0 0 0.8em;
            }
            </style>
        </head>
        <body>
        <div class='cardWrap'>
            <div class='card cardLeft'>
              <img src='https://i.imgur.com/2z23F02.png'  height='30px' alt='" + cinema + @" Logo' class='logo'>
                <div class='title'>
                    <h2>" + movieTitle + @"</h2>
                    <span>film</span>
                </div>
                <div class='name'>
                    <h2>" + name + @"</h2>
                    <span>zarezerwowane przez</span>
                </div>
                <div class='seat'>
                    <h2>" + seat + @"</h2>
                    <span>miejsce</span>
                </div>
                <div class='seat' style='padding-left:15px'>
                    <h2>" + nrRzedu + @"</h2>
                    <span>rzad</span>
                </div>
                <div class='time'>
                    <h2>" + time + @"</h2>
                    <span>godzina</span>
                </div>
                <div class='time' style='padding-left:5px'>
                    <h2>" + date + @"</h2>
                    <span>data</span>
                </div>
            </div>
            <div class='card cardRight'>
                <div class='eye'></div>
                <div class='number'>
                    <h3>" + NumerBiletu + @"</h3>
                    <span>bilet</span>
                </div>
                <div id='qrcode' style='margin-left:20px'></div>
            </div>
        </div>
             <script>
                var qrcodeElement = document.getElementById('qrcode');
                var qrCodeText = '" + NumerBiletu + @"';

                var qrcode = new QRCode(qrcodeElement, {
                    text: qrCodeText,
                    width: 65,
                    height: 65,
                    correctLevel: QRCode.CorrectLevel.H
                });
            </script>
    </body>
    </html>";

            var renderer = new IronPdf.HtmlToPdf();
            renderer.PrintOptions.PaperSize = PdfPrintOptions.PdfPaperSize.C6Envelope;  
            renderer.PrintOptions.MarginTop = 10;  
            renderer.PrintOptions.MarginBottom = 10;
            renderer.PrintOptions.MarginLeft = 10;
            renderer.PrintOptions.MarginRight = 10;

            var pdf = renderer.RenderHtmlAsPdf(ticketHtml);

            var fileContents = pdf.BinaryData;
            return File(fileContents, "application/pdf", "bilet.pdf");
        }



    }
}