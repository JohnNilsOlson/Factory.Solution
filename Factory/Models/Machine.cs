using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Technicians = new HashSet<Qualification>();
    }
    public int MachineId { get; set; }
    public string MachineName { get; set; }

    public ICollection<Qualification> Technicians { get; set; }
  }
}