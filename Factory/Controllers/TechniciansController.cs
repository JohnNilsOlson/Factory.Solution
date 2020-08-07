using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        .Include(technician => technician.Machines)
        .ThenInclude(join => join.Machine)
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

    public ActionResult AddMachine(int id)
    {
      var thisTechnician = _db.Technicians.FirstOrDefault(technician => technician.TechnicianId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View(thisTechnician);
    }

    [HttpPost]
    public ActionResult AddMachine(Technician technician, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.Qualifications.Add(new Qualification() { MachineId = MachineId, TechnicianId = technician.TechnicianId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = technician.TechnicianId });
    }

    public ActionResult DeleteMachine(int id)
    {
      var joinEntry = _db.Qualifications.FirstOrDefault(entry => entry.QualificationId == id);
      ViewBag.Technician = _db.Technicians.FirstOrDefault(technician => technician.TechnicianId == joinEntry.TechnicianId);
      ViewBag.Machine = _db.Machines.FirstOrDefault(machine => machine.MachineId == joinEntry.MachineId);
      return View(joinEntry);
    }

    [HttpPost, ActionName("DeleteMachine")]
    public ActionResult DeleteMachineConfirmed(int id)
    {
      var joinEntry = _db.Qualifications.FirstOrDefault(entry => entry.QualificationId == id);
      _db.Qualifications.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.TechnicianId });
    }
  }
}