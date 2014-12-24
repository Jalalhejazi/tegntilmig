using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TegnTilMig.Models;

namespace TegnTilMig.Controllers
{
    public class HomeController : Controller
    {
        private DrawingContext context = new DrawingContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDrawing(string output)
        {
            context.Drawings.Add(
                new Drawing
                {
                    DrawingString = output,
                    CreatedAt = DateTime.Now,
                    Deleted = false
                });
            context.SaveChanges();
            return RedirectToAction("LatestDrawing");
        }

        public ActionResult DeleteDrawing(int id)
        {
            var drawing = context.Drawings.Find(id);
            if (drawing != null)
            {
                drawing.Deleted = true;
                //context.Drawings.Remove(drawing);
                context.SaveChanges();
            }
            return RedirectToAction("AllDrawings");
        }

        public ActionResult LatestDrawing()
        {
            ViewBag.Message = "Latest drawing";
            var drawing = (from d in context.Drawings
                           where d.Deleted == false
                          orderby d.CreatedAt descending
                          select d).FirstOrDefault();

            //ViewBag.Signature = "[{\"lx\":79,\"ly\":14,\"mx\":79,\"my\":13},{\"lx\":80,\"ly\":15,\"mx\":79,\"my\":14},{\"lx\":81,\"ly\":18,\"mx\":80,\"my\":15},{\"lx\":83,\"ly\":27,\"mx\":81,\"my\":18},{\"lx\":85,\"ly\":31,\"mx\":83,\"my\":27},{\"lx\":88,\"ly\":47,\"mx\":85,\"my\":31},{\"lx\":93,\"ly\":63,\"mx\":88,\"my\":47},{\"lx\":98,\"ly\":74,\"mx\":93,\"my\":63},{\"lx\":98,\"ly\":77,\"mx\":98,\"my\":74},{\"lx\":101,\"ly\":84,\"mx\":98,\"my\":77},{\"lx\":102,\"ly\":86,\"mx\":101,\"my\":84},{\"lx\":102,\"ly\":87,\"mx\":102,\"my\":86},{\"lx\":64,\"ly\":69,\"mx\":64,\"my\":68},{\"lx\":64,\"ly\":67,\"mx\":64,\"my\":69},{\"lx\":65,\"ly\":66,\"mx\":64,\"my\":67},{\"lx\":68,\"ly\":64,\"mx\":65,\"my\":66},{\"lx\":79,\"ly\":62,\"mx\":68,\"my\":64},{\"lx\":97,\"ly\":61,\"mx\":79,\"my\":62},{\"lx\":105,\"ly\":61,\"mx\":97,\"my\":61},{\"lx\":115,\"ly\":61,\"mx\":105,\"my\":61},{\"lx\":117,\"ly\":61,\"mx\":115,\"my\":61},{\"lx\":122,\"ly\":61,\"mx\":117,\"my\":61},{\"lx\":123,\"ly\":62,\"mx\":122,\"my\":61}]";
            return View(drawing);
        }

        public ActionResult AllDrawings()
        {
            ViewBag.Message = "Your contact page.";
            var drawings = (from d in context.Drawings
                            where d.Deleted == false
                           orderby d.CreatedAt descending
                           select d).ToList();
            return View(drawings);
        }
    }
}