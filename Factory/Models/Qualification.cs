namespace Factory.Models
{
  public class Qualification
  {
    public int QualificationId { get; set; }
    public int MachineId { get; set; }
    public int TechnicianId { get; set; }
    public Machine Machine { get; set; }
    public Technician Technician { get; set; }
  }
}