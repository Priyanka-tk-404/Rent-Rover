using carrental1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carrental1.Controllers
{
    public class login1Controller : Controller
    {
        supercarEntities1 db = new supercarEntities1();
        //
        // GET: /login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(login1 l)
        {
            if (ModelState.IsValid)
            {
                if (db.login1.Any(x => x.Email == l.Email))
                {
                    ViewBag.Message = "Email Already Registered!!";
                }
                else
                {
                    db.login1.Add(l);
                    db.SaveChanges();
                    Response.Write("<script>alert('Registration Successful')</script>");
                }
            }
            return View();
        }
    }
}