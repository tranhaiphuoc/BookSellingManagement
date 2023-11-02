using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Data;

namespace BookstoreSellingManagement.BAL.Services
{
    public class BookService
    {
        public static TblBookCollection GetCollection()
        {
            return new Select().Top("8")
                .From(TblBook.Schema)
                .Where(TblBook.Columns.IsActivated).IsEqualTo(true)
                .And(TblBook.Columns.IsDeleted).IsEqualTo(false)
                .And(TblBook.Columns.Quantity).IsGreaterThan(0)
                .OrderDesc(TblBook.Columns.CreatedAt)
                .ExecuteAsCollection<TblBookCollection>();
        }

        public static TblBookCollection GetAll(bool getDeleted = false)
        {
            if (getDeleted)
            {
                return new Select()
                    .From(TblBook.Schema)
                    .OrderDesc(TblBook.Columns.CreatedAt)
                    .ExecuteAsCollection<TblBookCollection>();
            }

            return new Select()
                .From(TblBook.Schema)
                .Where(TblBook.Columns.IsDeleted).IsEqualTo(false)
                .OrderDesc(TblBook.Columns.CreatedAt)
                .ExecuteAsCollection<TblBookCollection>();
        }

        public static TblBookCollection GetAllForSale(int amount = 0)
        {
            if (amount <= 0)
            {
                return new Select()
                    .From(TblBook.Schema)
                    .Where(TblBook.Columns.IsDeleted).IsEqualTo(false)
                    .And(TblBook.Columns.IsActivated).IsEqualTo(true)
                    .And(TblBook.Columns.Quantity).IsGreaterThan(0)
                    .OrderDesc(TblBook.Columns.CreatedAt)
                    .ExecuteAsCollection<TblBookCollection>();
            }

            return new Select().Top(amount.ToString())
                .From(TblBook.Schema)
                .Where(TblBook.Columns.IsDeleted).IsEqualTo(false)
                .And(TblBook.Columns.IsActivated).IsEqualTo(true)
                .And(TblBook.Columns.Quantity).IsGreaterThan(0)
                .OrderDesc(TblBook.Columns.CreatedAt)
                .ExecuteAsCollection<TblBookCollection>();
        }

        public static TblBook GetById(Guid id)
        {
            return new Select()
                .From(TblBook.Schema.TableName)
                .Where(TblBook.Columns.Id).IsEqualTo(id)
                .ExecuteSingle<TblBook>();
        }

        public static void Insert(TblBook tblBook, Guid[] authorIdList, Guid[] categoryIdList)
        {
            TblBook.Insert(tblBook);
            TblBook.SaveTblAuthorMap(tblBook.Id, authorIdList);
            TblBook.SaveTblCategoryMap(tblBook.Id, categoryIdList);
        }

        public static void Update(TblBook tblBook, Guid[] authorIdList, Guid[] categoryIdList)
        {
            TblBook temp = GetById(tblBook.Id);
            temp.Isbn = tblBook.Isbn;
            temp.Title = tblBook.Title;
            temp.PriceInput = tblBook.PriceInput;
            temp.PriceOutput = tblBook.PriceOutput;
            temp.Quantity = tblBook.Quantity;
            temp.Description = tblBook.Description;
            temp.Image = tblBook.Image;
            temp.IsActivated = tblBook.IsActivated;
            temp.UpdatedBy = tblBook.UpdatedBy;
            temp.UpdatedAt = DateTime.Now;
            temp.PublisherId = tblBook.PublisherId;

            TblBook.Update(temp);
            TblBook.SaveTblAuthorMap(tblBook.Id, authorIdList);
            TblBook.SaveTblCategoryMap(tblBook.Id, categoryIdList);
        }

        public static void UpdateQuantity(TblOrderDetail orderDetail)
        {
            TblBook dbBook = GetById(orderDetail.BookId);
            dbBook.Quantity -= orderDetail.Quantity;

            TblBook.Update(dbBook);
        }

        public static void Delete(Guid bookId)
        {
            TblBook tblBook = GetById(bookId);
            tblBook.IsDeleted = true;
            TblBook.Update(tblBook);
        }

        public static TblBookCollection GetByCategory(int amount, Guid categoryId)
        {
            IDataReader rdr;

            if (amount <= 0)
            {
                rdr = new InlineQuery()
                    .ExecuteReader($"SELECT * FROM TblBook INNER JOIN TblBookCategory ON TblBookCategory.BookId = TblBook.Id INNER JOIN TblCategory ON TblCategory.Id = TblBookCategory.CategoryId WHERE TblCategory.Id = '{categoryId}' AND TblBook.IsDeleted = 0 AND TblBook.IsActivated = 1 AND TblBook.Quantity > 0 ORDER BY TblBook.CreatedAt DESC");
            }
            else
            {
                rdr = new InlineQuery()
                    .ExecuteReader($"SELECT TOP {amount} * FROM TblBook INNER JOIN TblBookCategory ON TblBookCategory.BookId = TblBook.Id INNER JOIN TblCategory ON TblCategory.Id = TblBookCategory.CategoryId WHERE TblCategory.Id = '{categoryId}' AND TblBook.IsDeleted = 0 AND TblBook.IsActivated = 1 AND TblBook.Quantity > 0 ORDER BY TblBook.CreatedAt DESC");
            }

            TblBookCollection coll = new TblBookCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }
    }
}
