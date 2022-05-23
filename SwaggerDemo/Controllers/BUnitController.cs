using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerDemo.Controllers
{
   [ApiController]
   [Route("bunit/")]
    public class BUnitController : ControllerBase
    {

        MyDbContext dbContext = new MyDbContext();


        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        // GET: BUnitController
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public ActionResult Save(BUnit unit)
        {
            dbContext.BUnit.Add(unit);
            dbContext.SaveChanges();
            var id = Guid.NewGuid();
            var data = new { batchId = id };

            var bId = new BatchIds { Id = unit.Id, BatchId = id };
            dbContext.BatchId.Add(bId);
            dbContext.SaveChanges();

            return Ok(data);
        }

        //// GET: BUnitController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: BUnitController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BUnitController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BUnitController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BUnitController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BUnitController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BUnitController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
