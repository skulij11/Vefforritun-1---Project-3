using Project3.DAL;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            ViewBag.Categories = GetAvailableCategories();
            return View(db.Products.ToList());
        }

        public ActionResult Filter(int? id)
        {
            ViewBag.Categories = GetAvailableCategories();
            if (id.HasValue)
            {
                if(id == 0)
                {
                    return RedirectToAction("Index");
                }

                IEnumerable<Product> products = db.Products.Where(x => x.Category == id.Value).ToList();
                return View("Index", products);

            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Product product = db.Products.Where(x => x.ID == id.Value).SingleOrDefault();
                if (product != null)
                {
                    ViewBag.Categories = GetAvailableCategories();
                    return View(product);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Product model = db.Products.Where(x => x.ID == product.ID).SingleOrDefault();

            if (product != null)
            {
                model.Name = product.Name;
                model.Description = product.Description;
                model.Category = product.Category;
                model.Stock = product.Stock;
                model.Price = product.Price;

                db.SaveChanges();
            }
            ViewBag.Categories = GetAvailableCategories();
            return RedirectToAction("Index");
        }
       

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = GetAvailableCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product newproduct)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(newproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetAvailableCategories();
            return View(newproduct);
        }

        public List<SelectListItem> GetAvailableCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>();

            var data = new[] {
                new SelectListItem { Value = "", Text = "All Categories" },
                new SelectListItem { Value = "1", Text = "Books & Audible" },
                new SelectListItem { Value = "2", Text = "Movies, Music & Games" },
                new SelectListItem { Value = "3", Text = "Electronics & Computers" },
                new SelectListItem { Value = "4", Text = "Home, Garden & Tools" },
                new SelectListItem { Value = "5", Text = "Beauty, Health & Grocery" },
                new SelectListItem { Value = "6", Text = "Toys, Kids & Baby" },
                new SelectListItem { Value = "7", Text = "Clothing, Shoes & Jewelry" },
                new SelectListItem { Value = "8", Text = "Sport & Outdoors" },
                new SelectListItem { Value = "9", Text = "Automotive & Industrial" },
                
            };
            categories = data.ToList();
            
            return categories;
        }
    }
}
