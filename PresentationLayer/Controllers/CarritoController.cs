﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class CarritoController: Controller
    {
        public ActionResult Index(CarritoCompra cc)
        {
            return View(cc);
        }
    }
}