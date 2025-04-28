
using AccountManagement.Domian;
using AccountManagement.Domian.AccountAgg;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        

        protected Role()
        {
        }

        public Role(string name)
        {
            Name = name;
            Accounts = new List<Account>();
            
        }

    }
}