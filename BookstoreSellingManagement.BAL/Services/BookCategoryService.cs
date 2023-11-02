using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSellingManagement.BAL.Services
{
    public class BookCategoryService
    {
        public static List<Guid> GetCategoriesByBookId(Guid bookId)
        {
            return new Select(TblBookCategory.Columns.CategoryId)
                .From(TblBookCategory.Schema)
                .Where(TblBookCategory.Columns.BookId).IsEqualTo(bookId)
                .ExecuteTypedList<Guid>();
        }
    }
}
