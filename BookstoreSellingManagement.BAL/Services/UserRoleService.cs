using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Collections.Generic;

namespace BookstoreSellingManagement.BAL.Services
{
    public class UserRoleService
    {
        public static List<Guid> GetRolesByUserId(Guid userId)
        {
            return new Select(TblUserRole.Columns.RoleId)
                .From(TblUserRole.Schema)
                .Where(TblUserRole.Columns.UserId).IsEqualTo(userId)
                .ExecuteTypedList<Guid>();
        }
    }
}
