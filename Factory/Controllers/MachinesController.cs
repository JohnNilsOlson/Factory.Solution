using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(machine => machine.Technicians)
        .ThenInclude(join => join.Technician)
        .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId});
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTechnician(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.TechnicianId = new SelectList(_db.Technicians, "TechnicianId", "TechnicianName");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddTechnician(Machine machine, int TechnicianId)
    {
      IQueryable<Qualification> qualifications = _db.Qualifications.Where(entry => entry.MachineId == machine.MachineId);
      foreach (Qualification entry in qualifications)
      {
        if (entry.TechnicianId == TechnicianId)
        {
          return RedirectToAction("Details", new { id = machine.MachineId });
        }
      }
      if (TechnicianId != 0)
      {
        _db.Qualifications.Add(new Qualification() { TechnicianId = TechnicianId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId });
    }

    public ActionResult DeleteTechnician(int id)
    {
      var joinEntry = _db.Qualifications.FirstOrDefault(entry => entry.QualificationId == id);
      ViewBag.Technician = _db.Technicians.FirstOrDefault(technician => technician.TechnicianId == joinEntry.TechnicianId);
      ViewBag.Machine = _db.Machines.FirstOrDefault(machine => machine.MachineId == joinEntry.MachineId);
      return View(joinEntry);
    }

    [HttpPost, ActionName("DeleteTechnician")]
    public ActionResult DeleteTechnicianConfirmed(int id)
    {
      var joinEntry = _db.Qualifications.FirstOrDefault(entry => entry.QualificationId == id);
      _db.Qualifications.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.MachineId });
    }
  }
}