using Microsoft.AspNetCore.Mvc;         // MVCの機能を使用 
using Microsoft.EntityFrameworkCore;    // ToListAsyncを使用 
using MvcBasicSample.Data;              // AppDbContextを使用 

namespace MvcBasicSample.Controllers;

// データベースの商品一覧を表示するController 
public class ProductsController : Controller {
    private readonly AppDbContext _db;  // DBへ問い合わせるためのフィールド 

    // ASP.NET Coreから必要なAppDbContextを受け取る 
    public ProductsController(AppDbContext db) {
        _db = db;                       // 受け取ったAppDbContextをフィールドに保存 
    }

    // /Products/Indexで商品一覧を取得する 
    public async Task<IActionResult> Index() {
        // Idの昇順で取得し結果をList<Product>にする 
        var products = await _db.Products
            .OrderBy(product => product.Id)
            .ToListAsync();

        return View(products);          // 商品一覧をViewへ渡す 
    }
}