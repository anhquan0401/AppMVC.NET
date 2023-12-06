using System.Xml.Serialization;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers {
    public class FirstController : Controller {
        private readonly ILogger<FirstController> _logger;

        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productSevice){
            _logger = logger;
            _productService = productSevice;
        }
        public string Index() {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogInformation("Index action");

            return "day la file first";
        }

        public void Nothing(){
            _logger.LogInformation("Nongthing action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => Math.Sqrt(2);


        public IActionResult Readme() {
            var content = @"
                    xin chao cac ban
            ";
            return Content(content, "text/html");
        }

        public IActionResult Img(){
            string filepath = Path.Combine("Files", "IMG_1756.jpg");
            var bytes = System.IO.File.ReadAllBytes(filepath);
            return File(bytes, "image/jpg");
        }

        public IActionResult Iphone(){
            return Json(
                new {
                    productName = "Ip15",
                    price = 100000
                }
            );
        }

        public IActionResult Privacy(){
           var url = Url.Action("Privacy", "Home");
           _logger.LogInformation("chuyen huong den " + url);
           return LocalRedirect(url);
        }

        public IActionResult Google(){
           var url = "https://www.nuget.org";
           _logger.LogInformation("chuyen huong den " + url);
           return Redirect(url);
        }

        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username)) 
                username = "Khach";
            // View(template, model)
            // return View("/MyView/xinChao.cshtml", username);

            // xinChao2.cshtml -> /View/First/xinChao2.cshtml
            // return View("xinChao2", username);
            
            // xinChao2.cshtml -> /View/First/HelloView.cshtml
            // return View((object)username);

            return View("xinChao3", username);
        }

        [TempData]
        public string StatusMessage {set; get;}

        public IActionResult ViewProduct(int? id) {
            var product = _productService.Where(p => p.id == id).FirstOrDefault();
            if (product == null) {
                
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "San pham ban yeu cau khong co";
                // Redirect: chuyển hướng về trang Home
                return Redirect(Url.Action("Index", "Home"));
            }
            // return Content($"San pham ID = {id}");

            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml
            // model
            // return View(product);

            // ViewData
            // this.ViewData["product"] = product;
            // ViewData["title"] = product.Name;
            // return View("ViewProduct2");

            // ViewBag: kieu dynamic
            ViewBag.product = product;
            return View("ViewProduct3");



        }

        //  Kiểu trả về                 | Phương thức
        // ------------------------------------------------
        // ContentResult               | Content()
        // EmptyResult                 | new EmptyResult()
        // FileResult                  | File()
        // ForbidResult                | Forbid()
        // JsonResult                  | Json()
        // LocalRedirectResult         | LocalRedirect()
        // RedirectResult              | Redirect()
        // RedirectToActionResult      | RedirectToAction()
        // RedirectToPageResult        | RedirectToRoute()
        // RedirectToRouteResult       | RedirectToPage()
        // PartialViewResult           | PartialView()
        // ViewComponentResult         | ViewComponent()
        // StatusCodeResult            | StatusCode()
        // ViewResult                  | View()
    }
}