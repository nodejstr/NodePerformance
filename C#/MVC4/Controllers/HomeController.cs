using System.Threading.Tasks;
using System.Web.Mvc;
using MVC4.Models;

namespace MVC4.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            var model = new Person();
            return View(await model.GetPersonsAsync());
        }
    }
}
