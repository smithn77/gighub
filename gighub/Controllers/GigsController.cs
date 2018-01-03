using gighub.Models;
using gighub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace gighub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel();
            viewModel.Genres = _context.Genres.ToList();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
                
            var artist = _context.Users.Where( u => u.Email == User.Identity.Name).First();

            var newGig = new Gig
            {
                Artist = artist,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
                DateTime = viewModel.GetDateTime()
            };

            _context.Gigs.Add(newGig);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}