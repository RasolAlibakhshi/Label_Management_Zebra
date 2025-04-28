using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domian.AccountAgg
{
    public class Account:EntityBase
    {
        public string FullName { get;private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public long RoleID { get; private set; }
        public Role Role { get; private set; }

        public string ProfilePhoto { get; private set; }

        public Account()
        {}

        public Account(string fullName, string userName, string password, long roleId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            RoleID = roleId;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
            {
                ProfilePhoto = profilePhoto;
            }
            
            IsDeleted=false;
            CreaationDateTime=DateTime.Now;
        }

        public Account(string fullName, string userName, string password, long roleId)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            RoleID = roleId;
            ProfilePhoto = "";
            IsDeleted=false;
            CreaationDateTime=DateTime.Now;
        }

        public void Edit(string fullName, string userName, long roleId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;

            RoleID = roleId;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
            {
                ProfilePhoto = profilePhoto;
            }
        }

        public void ChangePassword(string password)
        {
            Password=password;
        }

    }
}
