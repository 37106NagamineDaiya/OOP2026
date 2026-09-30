using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;

namespace MvcBasicSample.Controllers;
   //URLのHelloに対する要求を受け取るCotroller
    public class HelloController : Controller {
    // ../Hello/Indexで呼び出されるAction
        public IActionResult Index() {
        //商品一件のオブジェクトを作る
        var product = new List<Product> {
            new Product {
                Name = "ハンバーガー",
                Price = 500
            },
            new Product {
                Name = "紅茶",
                Price = 450
            }

        };



        return View(product);
        }
    }

