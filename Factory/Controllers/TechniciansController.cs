using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FactoryControllers
{
  public class TechniciansController : Controller
  {
    private readonly FactoryContext _db;

    public TechniciansController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Technician> model = _db.Technicians.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Technician technician)
    {
      _db.Technicians.Add(technician);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}