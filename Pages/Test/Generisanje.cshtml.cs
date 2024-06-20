using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBContext;
using klase1;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Test
{
    public class GenerisanjeModel : PageModel
    {
        private readonly ApplicationContext _context;

        public GenerisanjeModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<int> PitanjaIDs { get; set; }

        public List<klase1.Pitanja> Pitanja { get; set; }

        public int? TacniOdgovori { get; set; }
        public int BrojPitanja { get; set; }


        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                var predmet = await _context.Predmeti.Include(p => p.Pitanje).FirstOrDefaultAsync(p => p.ID == id);
                if (predmet != null && predmet.Pitanje.Any())
                {
                    Pitanja = predmet.Pitanje.OrderBy(_ => Guid.NewGuid()).Take(5).ToList();
                }
            }
        }

        public IActionResult OnPost(Dictionary<int, string> Odgovori)
        {
            if (Odgovori != null && Odgovori.Any())
            {
                var pitanjaIDs = Odgovori.Keys.ToList();

                if (pitanjaIDs != null)
                {
                    int tacniOdgovori = 0;

                    foreach (var pitanjeID in pitanjaIDs)
                    {
                        Odgovori.TryGetValue(pitanjeID, out var odgovorKorisnika);
                        if (Provera(pitanjeID, odgovorKorisnika))
                        {
                            tacniOdgovori++;
                        }
                    }

                    TacniOdgovori = tacniOdgovori;
                    BrojPitanja = pitanjaIDs.Count;
                }

                return RedirectToPage("./Rezultat", new { tacniOdgovori = TacniOdgovori, brojPitanja = BrojPitanja });

            }
            else
            {
                return RedirectToPage("./Home");
            }
        }
        private bool Provera(int pitanjeID, string odgovorKorisnika)
        {
            var tacanOdgovor = _context.Pitanja
                .Where(z => z.ID == pitanjeID)
                .Select(z => z.Odgovor)
                .FirstOrDefault();

            if (tacanOdgovor == null)
                return false;

            return odgovorKorisnika?.Trim().ToLower() == tacanOdgovor.Trim().ToLower();
        }
    }
}
