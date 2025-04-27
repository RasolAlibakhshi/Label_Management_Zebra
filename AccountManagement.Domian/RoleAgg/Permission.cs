namespace AccountManagement.Domain.RoleAgg;

public class Permission
{
    public long ID { private set; get; }
    public int Code { private set; get; }
    public string Name { private set; get; }


    public long RoleID{ private set; get;}
    public Role Role { private set; get; }


    public Permission()
    {
    }

    public Permission(int code)
    {
        Code = code;
    }

    public Permission(int code, string name)
    {
        Code = code;
        Name = name;
    }
}