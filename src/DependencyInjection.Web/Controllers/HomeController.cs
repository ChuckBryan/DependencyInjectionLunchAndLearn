namespace DependencyInjection.Web.Controllers
{
    using Entities;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public HomeController() :
            this(new EFCharacterRepository(new ApplicationDbContext()))
        {
            
        }

        private HomeController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public IActionResult Index()
        {
            var characters = _characterRepository.GetAll();

            return View(characters);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Character character)
        {
            _characterRepository.Add(character);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}