using CarFuel.Models;
using CarFuel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFuel.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IService<Car> _carService;

        public CarsController(IService<Car> carService) {
            _carService = carService;
        }

        // GET: Cars
        [Authorize]
        public ActionResult Index()
        {
            CreateTestCar();

            var cars = _carService.All();
            return View(cars);
        }

        private void CreateTestCar() {
            Car c = new Car();
            c.Make = "Honda";
            c.Model = "Jazz";           


            FillUp f1 = c.AddFillUp(odometer: 1000, liters: 40.0);
            FillUp f2 = c.AddFillUp(odometer: 1600, liters: 50.0);
            FillUp f3 = c.AddFillUp(odometer: 2200, liters: 60.0);

            _carService.Add(c);
            _carService.SaveChanges();
        }
    }
}