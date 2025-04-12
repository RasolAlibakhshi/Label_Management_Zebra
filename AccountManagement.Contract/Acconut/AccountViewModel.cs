namespace AccountManagement.Contract.Acconut;

public class AccountViewModel
{
    public long ID { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public long RoleID { get; set; }
    public string RoleName { get; set; }
    public string ProfilePhoto { get; set; }
}