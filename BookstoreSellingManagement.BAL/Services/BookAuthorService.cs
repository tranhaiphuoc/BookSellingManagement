using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Collections.Generic;

namespace BookstoreSellingManagement.BAL.Services
{
    public class BookAuthorService
    {
        public static List<Guid> GetAuthorsByBookId(Guid bookId)
        {
            return new Select(TblBookAuthor.Columns.AuthorId)
                .From(TblBookAuthor.Schema)
                .Where(TblBookAuthor.Columns.BookId).IsEqualTo(bookId)
                .ExecuteTypedList<Guid>();
        }
    }
}
