using Microsoft.AspNetCore.Mvc;
using Support_Web.Models;

namespace Support_Web.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Product> _products = new List<Product>();
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult AddProduct()
		{
			return View();
		}

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if(_products.Count == 0)
			{
                product.Id = 1;
			}
			else
			{
                product.Id = _products.Max(x => x.Id) + 1;
			}

            _products.Add(product);

            return RedirectToAction("Index");
        }

        #region GetAll

        public IActionResult GetAllData()
		{
            return View(_products);
		}

        #endregion

        #region Delete
        public IActionResult Delete(int id)
		{
            Product x = _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(x);

            return RedirectToAction("GetAllData");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
		{
            Product x = _products.SingleOrDefault(x => x.Id == id);

            //x.Name = product.Name;
            //x.Description = product.Description;
            //x.Price = product.Price;
            //x.Quantity = product.Quantity;
            //x.Company = product.Company;

            return View(x);
		}

        [HttpPost]
        public IActionResult Edit(Product product)
		{
            Product x = _products.SingleOrDefault(x => x.Id == product.Id);

            x.Name = product.Name;
            x.Description = product.Description;
            x.Price = product.Price;
            x.EnableSize = product.EnableSize;
            x.Quantity = product.Quantity;
            x.Company = product.Company;

            return RedirectToAction("GetAllData");
		}
        #endregion
    }
}
