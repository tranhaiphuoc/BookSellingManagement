using BookstoreManagementDAL;
using SubSonic;
using System;

namespace BookstoreSellingManagement.BAL.Services
{
    public class UserService
    {
        public static TblUserCollection GetAll(bool getDeleted = false)
        {
            if (getDeleted)
            {
                return new Select()
                    .From(TblUser.Schema)
                    .OrderDesc(TblUser.Columns.CreatedAt)
                    .ExecuteAsCollection<TblUserCollection>();
            }

            return new Select()
                .From(TblUser.Schema)
                .Where(TblUser.Columns.IsDeleted).IsEqualTo(false)
                .OrderDesc(TblUser.Columns.CreatedAt)
                .ExecuteAsCollection<TblUserCollection>();
        }

        public static TblUser GetById(Guid id)
        {
            return new Select()
                .From(TblUser.Schema)
                .Where(TblUser.Columns.Id).IsEqualTo(id)
                .ExecuteSingle<TblUser>();
        }

        public static void Insert(TblUser tbl, System.Web.UI.WebControls.ListItemCollection roleList)
        {
            TblUser.Insert(tbl);
            TblUser.SaveTblRoleMap(tbl.Id, roleList);
        }

        public static void Insert(TblUser tbl, Guid[] roleIdList)
        {
            TblUser.Insert(tbl);
            TblUser.SaveTblRoleMap(tbl.Id, roleIdList);
        }

        public static void Update(TblUser tbl, System.Web.UI.WebControls.ListItemCollection roleList)
        {
            TblUser temp = GetById(tbl.Id);
            temp.FirstName = tbl.FirstName;
            temp.LastName = tbl.LastName;
            temp.Birthday = tbl.Birthday;
            temp.Gender = tbl.Gender;
            temp.Address = tbl.Address;
            temp.Phone = tbl.Phone;
            temp.Email = tbl.Email;
            temp.Avatar = tbl.Avatar;
            // Username won't be alter by any means
            if (!string.IsNullOrEmpty(tbl.Password)) temp.Password = tbl.Password;
            temp.IsActivated = tbl.IsActivated;
            temp.UpdatedBy = tbl.UpdatedBy;
            temp.UpdatedAt = DateTime.Now;

            TblUser.Update(temp);
            TblUser.SaveTblRoleMap(tbl.Id, roleList);
        }

        public static void Update(TblUser user)
        {
            TblUser.Update(user);
        }

        public static void Delete(Guid userId)
        {
            TblUser tblUser = GetById(userId);
            tblUser.IsDeleted = true;
            TblUser.Update(tblUser);
        }

        public static TblUser GetByLogIn(string username, string password, out bool isActivated)
        {
            TblUser user = new Select().From(TblUser.Schema)
                .Where(TblUser.Columns.Username).IsEqualTo(username)
                .And(TblUser.Columns.Password).IsEqualTo(password)
                .And(TblUser.Columns.IsDeleted).IsEqualTo(false)
                .ExecuteSingle<TblUser>();

            if (user != null)
                isActivated = user.IsActivated;
            else
                isActivated = false;

            return user;
        }

        public static TblUser GetByUsername(string username)
        {
            return new Select()
                .From(TblUser.Schema)
                .Where(TblUser.Columns.Username).IsEqualTo(username)
                .ExecuteSingle<TblUser>();
        }
    }
}
