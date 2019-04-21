using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using System.Web.Mvc;
using PresentationLayer.Models;
using System.Net;

namespace PresentationLayer.Controllers
{
    public class ProductController: Controller
    {
        private ProductsManagement pm = new ProductsManagement();
        public ActionResult Index()
        {
            return View(pm.getProductList());
        }

        public ActionResult Add(CarritoCompra cc, int id)
        {
            ProductBusiness pb = pm.findProductBusiness(id);
            cc.Add(pb);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBusiness pb = pm.findProductBusiness(id);
            if (pb == null)
            {
                return HttpNotFound();
            }
            return View(pb);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Price")] ProductBusiness productBusiness)
        {
            if (ModelState.IsValid)
            {
                pm.addProductBusiness(productBusiness);
                return RedirectToAction("Index");
            }

            return View(productBusiness);
        }

    }
}