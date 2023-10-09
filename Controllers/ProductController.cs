using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDWithModalPopup.Data;
using CRUDWithModalPopup.Models.DBEntities;

namespace CRUDWithModalPopup.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyAppDbContext _context;

        public ProductController(MyAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: Product
        public JsonResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Json(products);
        }

        public JsonResult Insert(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return Json("Product details saved");

            }
            return Json("Model Validation failed");

        }




        [HttpGet]
        public JsonResult Edit(int id)
        {
            var product = _context.Products.Find(id); return Json(product);
        }

        [HttpPost]
        public JsonResult Update(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(model);
                _context.SaveChanges();
                return Json("Product details updated.");
            }
            return Json("Model validation failed.");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Json("Product details deleted!");
            }
            return Json($"Product details not found with id : {id}");

        }
    }
}
