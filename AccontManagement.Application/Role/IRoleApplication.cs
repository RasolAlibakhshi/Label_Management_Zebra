using _0_Framework.Application;


namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OpreationResult Create(CreateRole command);
        OpreationResult Edit(EditRole command);
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
        void Remove(long id);
        void Restore(long id);
    }
}
