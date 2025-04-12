namespace Application.Contracts.Machine;

public class MachineViewModel
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string CreationDateTime { get; set; }
    public string HallName { set; get; }
    public long HallID { set; get; }
    public bool IsDeleted { set; get; }
}