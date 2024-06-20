using Microsoft.AspNetCore.Mvc.RazorPages;
using DBContext;
using klase1;

namespace eUcionica.Pages.Test
{
    public class RezultatModel : PageModel
    {
        private readonly ApplicationContext _context;

        public RezultatModel(ApplicationContext context)
        {
            _context = context;
        }

        public int? TacniOdgovori { get; set; }
        public int BrojPitanja { get; set; }

        public async Task OnGetAsync(int tacniOdgovori, int brojPitanja)
        {

            TacniOdgovori = tacniOdgovori;
            BrojPitanja = brojPitanja;


        }
    }
}
