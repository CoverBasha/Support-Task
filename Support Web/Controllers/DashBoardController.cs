using Microsoft.AspNetCore.Mvc;
using Support_Web.Data;
using Support_Web.Models;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.



namespace Support_Web.Controllers
{
    public class DashBoardController : Controller
    {
        ApplicationDbContext _context;

        public DashBoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        #region Add Product

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("ViewProducts");
        }

        #endregion

        #region View Products

        public IActionResult ViewProducts()
        {
            return View(_context.Products.ToList());
        }

        #endregion

        #region Edit Product
        public IActionResult EditProduct(int id)
        {
			Product x = _context.Products.SingleOrDefault(x => x.Id == id);
			return View(x);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            Product x = _context.Products.SingleOrDefault(x => x.Id == product.Id);

            x.Name = product.Name;
            x.Description = product.Description;
            x.Price = product.Price;
            x.EnableSize = product.EnableSize;
            x.Quantity = product.Quantity;
            x.Company = product.Company;

            _context.SaveChanges();

            return RedirectToAction("ViewProducts");
        }
        #endregion

        #region Delete Product
        public IActionResult DeleteProduct(int id)
        {
            Product x = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(x);
            _context.SaveChanges();

            return RedirectToAction("ViewProducts");
        }
        #endregion




        #region Add Blog

        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region View Blogs

        public IActionResult Viewblogs()
        {
            return View(_context.Blogs.ToList());
        }

        #endregion

        #region Edit Blog

        public IActionResult EditBlog(int id)
        {
            Blog x = _context.Blogs.SingleOrDefault(x => x.Id == id);
            return View(x);
        }

        [HttpPost]
        public IActionResult EditBlog(Product product)
        {
            Blog x = _context.Blogs.SingleOrDefault(x => x.Id == product.Id);

            x.Name = product.Name;
            _context.SaveChanges();

            return RedirectToAction("ViewBlogs");
        }
        #endregion

        #region Delete Blog

        public IActionResult DeleteBlog(int id)
        {
            Blog x = _context.Blogs.SingleOrDefault(x => x.Id == id);
            _context.Blogs.Remove(x);
            _context.SaveChanges();

            return RedirectToAction("ViewBlogs");
        }

        #endregion
    }
}
