using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSellingManagement.BAL.Services
{
    public class AuthorService
    {
        public static TblAuthorCollection GetAll(bool getDeleted = false)
        {
            if (getDeleted)
            {
                return new Select()
                .From(TblAuthor.Schema)
                .OrderDesc(TblAuthor.Columns.CreatedAt)
                .ExecuteAsCollection<TblAuthorCollection>();
            }

            return new Select()
                .From(TblAuthor.Schema)
                .Where(TblAuthor.Columns.IsDeleted).IsEqualTo(false)
                .OrderDesc(TblAuthor.Columns.CreatedAt)
                .ExecuteAsCollection<TblAuthorCollection>();
        }

        public static TblAuthor GetById(Guid id)
        {
            return new Select()
                .From(TblAuthor.Schema.TableName)
                .Where(TblAuthor.Columns.Id).IsEqualTo(id)
                .ExecuteSingle<TblAuthor>();
        }

        public static void Insert(TblAuthor tblBook)
        {
            TblAuthor.Insert(tblBook);
        }

        public static void Update(TblAuthor tblAuthor)
        {
            TblAuthor temp = GetById(tblAuthor.Id);
            temp.Name = tblAuthor.Name;
            temp.Biography = tblAuthor.Biography;
            temp.IsActivated = tblAuthor.IsActivated;
            temp.UpdatedBy = tblAuthor.UpdatedBy;
            temp.UpdatedAt = DateTime.Now;

            TblAuthor.Update(temp);
        }

        public static void Delete(Guid authorId)
        {
            TblAuthor tblAuthor = GetById(authorId);
            tblAuthor.IsDeleted = true;
            TblAuthor.Update(tblAuthor);

            InlineQuery query = new InlineQuery();
            query.Execute($"UPDATE TblBook SET TblBook.IsActivated = 0 FROM TblBook INNER JOIN TblBookAuthor ON TblBook.Id = TblBookAuthor.BookId WHERE TblBookAuthor.AuthorId = '{authorId}'");
        }
    }
}
