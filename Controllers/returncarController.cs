using carrental1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carrental1.Controllers
{
    public class returncarController : Controller
    {
        supercarEntities1 db = new supercarEntities1();
        //
        // GET: /ReturnCar/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(returncar recar)
        {
            if (ModelState.IsValid)
            {
                db.returncars.Add(recar);
                var car = db.carregs.SingleOrDefault(e => e.carno == recar.carno);
                if (car == null)
                
                    return HttpNotFound("CarNo not Found");
                    car.available = "yes";
                    db.Entry(car).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }

            return View(recar);
        }

        [HttpPost]
        public ActionResult Getid(string carno)
        {
            var car = (from s in db.rentals
                       where s.carid == carno
                       select new
                       {
                           StartDate = s.sdate,
                           EndDate = s.edate,
                           Custid = s.custid,
                           CarNo = s.carid,
                           Fee = s.fee,
                           ElapsedDays = SqlFunctions.DateDiff("day", s.edate, DateTime.Now)



                       }).ToArray();

            return Json(car, JsonRequestBehavior.AllowGet);
        }

    }
}