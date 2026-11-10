using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Models;
using SelfOrderSystem.Services;
using SelfOrderSystem.ViewModels;
using System.Numerics;

namespace SelfOrderSystem.Controllers;

public class OrdersController : Controller {
    private readonly AppDbContext _db; // 商品と注文のDB 操作
    private readonly CartService _cart; // Session 内のカート操作
    private readonly IOrderService _orderService; //注文の検証と保存を担当するService

    public OrdersController(AppDbContext db, CartService cart,IOrderService orderService) {
        _db = db;
        _cart = cart;
        _orderService = orderService;

    }

    [HttpGet]
    public IActionResult Checkout() {
        var items = _cart.GetItems(); // Session からカートを読む
        if (items.Count == 0) {
            return RedirectToAction("Index", "Menu");
        }
        return View(new CheckoutViewModel { Items = items });
    }

    [HttpPost]                                 // POSTで注文を受け取る 
    [ValidateAntiForgeryToken]                 // 不正なフォーム送信を検証 
    public async Task<IActionResult> Place(CheckoutViewModel model) {
        var cartItems = _cart.GetItems();      // Session内のカートを取得 
        if (!ModelState.IsValid)               // テーブル番号などが不正 
        {
            model.Items = cartItems;          // 画面再表示のため戻す 
            return View("Checkout", model);
        }

        var result = await _orderService.PlaceAsync(
            cartItems, model.TableNumber);     // 注文処理をServiceへ依頼 

        if (!result.IsSuccess)                 // 保存できない場合 
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error); // エラーを画面へ 
            model.Items = cartItems;
            return View("Checkout", model);
        }

        _cart.Clear();                         // 保存成功後だけカートを消す 
        return RedirectToAction(nameof(Complete),
            new { id = result.PublicId });     // 完了画面へ移動 
    }

    [HttpGet]
    public async Task<IActionResult> Complete(Guid id) {
        var order = await LoadPublicOrderAsync(id);
        return order == null ? NotFound() : View(order);
    }
    [HttpGet]
    public async Task<IActionResult> Status(Guid id) {
        var order = await LoadPublicOrderAsync(id);
        return order == null ? NotFound() : View(order);
    }
    private Task<Order?> LoadPublicOrderAsync(Guid publicId) {
        return _db.Orders.AsNoTracking()
        .Include(o => o.Items)
        .ThenInclude(i => i.Product)
        .SingleOrDefaultAsync(o => o.PublicId == publicId);
    }

}
