using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSellingManagement.BAL.Services
{
    public class RoleService
    {
        public static TblRoleCollection GetAll()
        {
            return new Select()
                .From(TblRole.Schema)
                .OrderAsc(TblRole.Columns.Name)
                .ExecuteAsCollection<TblRoleCollection>();
        }

        public static TblRoleCollection GetAll(bool excludedAdmin)
        {
            return new Select()
                .From(TblRole.Schema)
                .Where(TblRole.Columns.Name).IsNotEqualTo(UserRole.Admin.ToString())
                .OrderAsc(TblRole.Columns.Name)
                .ExecuteAsCollection<TblRoleCollection>();
        }

        public static TblRole GetById(Guid id)
        {
            return new Select()
                .From(TblRole.Schema)
                .Where(TblRole.Columns.Id).IsEqualTo(id)
                .ExecuteSingle<TblRole>();
        }

        public static TblRole GetByName(string name)
        {
            return new Select()
                .From(TblRole.Schema)
                .Where(TblRole.Columns.Name).IsEqualTo(name)
                .ExecuteSingle<TblRole>();
        }

        public static TblRoleCollection GetByUserId(Guid id)
        {
            IDataReader rdr = new InlineQuery()
                .ExecuteReader($"SELECT * FROM TblRole INNER JOIN TblUserRole ON TblUserRole.RoleId = TblRole.Id INNER JOIN TblUser ON TblUser.Id = TblUserRole.UserId WHERE TblUser.Id = '{id}' AND TblUser.IsDeleted = 0 AND TblUser.IsActivated = 1");

            TblRoleCollection coll = new TblRoleCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }
    }
}
