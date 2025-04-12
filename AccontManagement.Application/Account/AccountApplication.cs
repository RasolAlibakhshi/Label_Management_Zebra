using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Contract.Acconut;
using Infrastructure.DTO;

namespace AccontManagement.Application.Account
{
    public class AccountApplication:IAccountApplicationcs
    {
        private readonly IRepository<AccountManagement.Domian.AccountAgg.Account> _repository;
        private readonly IFileUploder _fileUploder;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IRepository<AccountManagement.Domian.AccountAgg.Account> repository, IFileUploder fileUploder, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _fileUploder = fileUploder;
            _passwordHasher = passwordHasher;
        }
        public OpreationResult Create(CreateAccount command)
        {
            var opreation =new OpreationResult();
            if (command==null)
            {
                return opreation.Failed(ApplicationMessages.InputNull);
            }

            if (_repository.Exist(x=>x.UserName.ToLower().Contains(command.UserName.ToLower())))
            {
                return opreation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            _repository.Create(new AccountManagement.Domian.AccountAgg.Account(command.FullName,command.UserName.ToLower(),_passwordHasher.Hash(command.Password),command.RoleID,_fileUploder.Upload(command.ProfilePhoto,"AccountPhotos")));
            _repository.SaveChanges();
            return opreation.Success();
        }

        public OpreationResult Edit(EditAccount command)
        {
            var opration = new OpreationResult();
            var data = _repository.GetBy(x => x.ID == command.ID);
            if (data==null)
            {
                return opration.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_repository.Exist(x => x.UserName == command.UserName && x.ID != command.ID))
            {
                return opration.Failed("نام کاربری تکراری می باشد.");
            }
            data.Edit(command.FullName,command.UserName.ToLower(),1,_fileUploder.Upload(command.ProfilePhoto, "AccountPhotos"));
            _repository.SaveChanges();
            return opration.Success();
        }

        public EditAccount GetDetails(long ID)
        {
            return _repository.GetDetails(ID);
        }

        public OpreationResult ChangePassword(ChangePassword command)
        {
            var Opreation = new OpreationResult();
            var account = _repository.GetBy(x => x.ID == command.ID);
            if (account == null)
            {
                return Opreation.Failed(ApplicationMessages.RecordNotFound);
            }
            if (command.Password!=command.RePassword)
            {
                return Opreation.Failed(ApplicationMessages.PasswordsNotMatch);
            }
            if (_repository.Exist(x=>x.ID==command.ID && x.Password==command.Password))
            {
                return Opreation.Failed(ApplicationMessages.PasswordDublication);
            }
            account.ChangePassword(_passwordHasher.Hash(command.Password));
            _repository.SaveChanges();
            return Opreation.Success();
        }

        public List<AccountViewModel> Search(SearchModel command)
        {
            return _repository.Search(command);
        }
    }
}
