using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSellingManagement.BAL.Services
{
    public class CategoryService
    {
        public static TblCategoryCollection GetAll(bool getDeleted = false)
        {
            if (getDeleted)
            {
                return new Select()
                    .From(TblCategory.Schema)
                    .OrderAsc(TblCategory.Columns.Name)
                    .ExecuteAsCollection<TblCategoryCollection>();
            }

            return new Select()
                .From(TblCategory.Schema)
                .Where(TblCategory.Columns.IsDeleted).IsEqualTo(false)
                .OrderAsc(TblCategory.Columns.Name)
                .ExecuteAsCollection<TblCategoryCollection>();
        }

        public static TblCategory GetById(Guid id)
        {
            return new Select()
                .From(TblCategory.Schema)
                .Where(TblCategory.Columns.Id).IsEqualTo(id)
                .And(TblCategory.Columns.IsDeleted).IsEqualTo(false)
                .ExecuteSingle<TblCategory>();
        }

        public static void Insert(TblCategory tblCategory)
        {
            TblCategory.Insert(tblCategory);
        }

        public static void Update(TblCategory tblCategory)
        {
            TblCategory temp = GetById(tblCategory.Id);
            temp.Name = tblCategory.Name;
            temp.Description = tblCategory.Description;
            temp.IsActivated = tblCategory.IsActivated;
            temp.UpdatedBy = tblCategory.UpdatedBy;
            temp.UpdatedAt = DateTime.Now;

            TblCategory.Update(temp);
        }

        public static void Delete(Guid categoryId)
        {
            TblCategory tblCategory = GetById(categoryId);
            tblCategory.IsDeleted = true;

            TblCategory.Update(tblCategory);

            InlineQuery query = new InlineQuery();
            query.Execute($"UPDATE TblBook SET TblBook.IsActivated = 0 FROM TblBook INNER JOIN TblBookCategory ON TblBook.Id = TblBookCategory.BookId WHERE TblBookCategory.CategoryId = '{categoryId}'");
        }

        public static TblCategoryCollection GetRandom(int amount)
        {
            return new InlineQuery()
                .ExecuteAsCollection<TblCategoryCollection>($"SELECT TOP {amount} * FROM TblCategory TABLESAMPLE(20 PERCENT)");
        }
    }
}
