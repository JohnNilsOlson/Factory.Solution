using System.Collections.Generic;

namespace Factory.Models
{
  public class Technician
  {
    public Technician()
    {
      this.Machines = new HashSet<Qualification>();
    }
    public int TechnicianId { get; set; }
    public string TechnicianName { get; set; }
    public ICollection<Qualification> Machines { get; set; }
  }
}