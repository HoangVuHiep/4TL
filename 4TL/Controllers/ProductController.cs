using _4TL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4TL.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Details(int id)
        {

            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        public ActionResult Create()
        {

                var listCate = dbContext.Categories.ToList();
                ViewBag.Loai = listCate;
                
            
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Product product, HttpPostedFileBase FeatureImage)
        {
            if (!ModelState.IsValid)
            {

                var listCate = dbContext.Categories.ToList();
                ViewBag.Loai = listCate;
                return View("Create",product);
            }
                    string path = Path.Combine(Server.MapPath("~/Content/NoiThat/images" ), Path.GetFileName(FeatureImage.FileName));
                    FeatureImage.SaveAs(path);
            product.FeatureImage = "/Content/NoiThat/images/"+ Path.GetFileName(FeatureImage.FileName);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}