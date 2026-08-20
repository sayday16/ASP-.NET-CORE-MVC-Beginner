using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.Controllers
{
    public class ProductsController : Controller
    {
        private ProductReader reader;

        // ВНИМАНИЕ.
        // Каждый запрос обрабатывает новый экземпляр контроллера.
        // Конструктор будет вызываться перед вызовом метода List и метода Details
        // После обработки запроса, экземпляр контроллера будет удален из памяти
        public ProductsController()
        {
            reader = new ProductReader();
        }

        // Products/List
        public IActionResult List()
        {
            List<Product> products = reader.ReadFromFile();
            // Возврат представления List и передача представлению модели в виде коллекции products
            // Получить доступ к коллекции в представлении можно будет через свойство представления Model
            return View(products);
        }

        // Products/Details/1
        public IActionResult Details(int id)
        {
            List<Product> products = reader.ReadFromFile();
            Product product = products.Where(x => x.Id == id).FirstOrDefault();

            if (product == null || product.Quantity == 0)
            {
                ViewBag.Message = "Немає в наявності";
            }

            if(product.Quantity > 5)
            {
                ViewBag.Message = "В наявності";
            }

            if (product.Quantity >=1 && product.Quantity <= 5)
            {
                ViewBag.Message = "Закінчується";
            }

            if (product != null)
            {
                // Возврат представления с именем Details и передача представлению экземпляра product
                // В представление доступ к экземпляру можно получить через свойство представления Model
                return View(product);
            }
            else
            {
                // Возврат ошибки 404
                return NotFound();
            }
        }
    }
}