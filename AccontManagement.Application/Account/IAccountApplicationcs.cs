using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Contract.Acconut;

namespace AccontManagement.Application.Account
{
    public interface IAccountApplicationcs
    {
        OpreationResult Create(CreateAccount command);
        OpreationResult Edit(EditAccount command);
        EditAccount GetDetails(long ID);
        OpreationResult ChangePassword(ChangePassword command);
        List<AccountViewModel> Search(SearchModel command);
        OpreationResult Remove(long id);
        OpreationResult Login(Login command);
    }
}
