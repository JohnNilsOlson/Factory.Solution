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

    public ActionResult Details(int id)
    {
      var thisTechnician = _db.Technicians
        .FirstOrDefault(technician => technician.TechnicianId == id);
      return View(thisTechnician);
    }

    public ActionResult Edit(int id)
    {
      var thisTechnician = _db.Technicians.FirstOrDefault(technician => technician.TechnicianId == id);
      return View(thisTechnician);
    }

    [HttpPost]
    public ActionResult Edit(Technician technician)
    {
      _db.Entry(technician).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = technician.TechnicianId});
    }

    public ActionResult Delete(int id)
    {
      var thisTechnician = _db.Technicians.FirstOrDefault(technician => technician.TechnicianId == id);
      return View(thisTechnician);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTechnician = _db.Technicians.FirstOrDefault(technician => technician.TechnicianId == id);
      _db.Technicians.Remove(thisTechnician);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}