using gighub.Models;
using gighub.ViewModels;
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
        
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel();
            viewModel.Genres = _context.Genres;
            return View(viewModel);
        }
    }
}