using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class TableController : Controller
    {
        private TableContext db = new TableContext();

        // GET: Table
        public ActionResult Index()
        {
            return View(db.Entries.ToList());
        }

        // GET: Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table/Create
        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entries.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        public ActionResult Export()
        {
            return null;
        }

        public ActionResult ChartIncome()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var results = (from c in db.Entries select c);
            results.ToList().ForEach(rs => yvalue.Add(rs.Income));
            results.ToList().ForEach(rs => xvalue.Add(rs.Date));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Income by date")
                .AddSeries("Default", chartType: "Column", xValue: xvalue, yValues: yvalue)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartIndex()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var results = (from c in db.Entries select c);
            results.ToList().ForEach(rs => yvalue.Add(rs.Index));
            results.ToList().ForEach(rs => xvalue.Add(rs.Date));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Index by date")
                .AddSeries("Default", chartType: "Column", xValue: xvalue, yValues: yvalue)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartSilver()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var results = (from c in db.Entries select c);
            results.ToList().ForEach(rs => yvalue.Add(rs.Silver));
            results.ToList().ForEach(rs => xvalue.Add(rs.Date));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Silver by date")
                .AddSeries("Default", chartType: "Column", xValue: xvalue, yValues: yvalue)
                .Write("bmp");

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
