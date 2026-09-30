using Microsoft.AspNetCore.Mvc;
namespace MvcBasicSample.Controllers;
   //URLのHelloに対する要求を受け取るCotroller
    public class HelloController : Controller {
    // ../Hello/Indexで呼び出されるAction
        public IActionResult Index() {
        //return Content("はじめてのASP.NET Core");
        return View();
        }
    }

