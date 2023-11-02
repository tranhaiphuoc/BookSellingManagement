using System;
using BookstoreManagementDAL;
using SubSonic;

namespace BookstoreSellingManagement.BAL.Services
{
    public class PublisherService
    {
        public static TblPublisherCollection GetAll(bool getDeleted = false)
        {
            if (getDeleted)
            {
                return new Select()
                    .From(TblPublisher.Schema)
                    .OrderAsc(TblPublisher.Columns.Name)
                    .ExecuteAsCollection<TblPublisherCollection>();
            }

            return new Select()
                .From(TblPublisher.Schema)
                .Where(TblPublisher.Columns.IsDeleted).IsEqualTo(false)
                .OrderAsc(TblPublisher.Columns.Name)
                .ExecuteAsCollection<TblPublisherCollection>();
        }

        public static TblPublisher GetById(Guid id)
        {
            return new Select()
                .From(TblPublisher.Schema)
                .Where(TblPublisher.Columns.Id).IsEqualTo(id)
                .And(TblPublisher.Columns.IsDeleted).IsEqualTo(false)
                .ExecuteSingle<TblPublisher>();
        }

        public static void Insert(TblPublisher tblBook)
        {
            TblPublisher.Insert(tblBook);
        }

        public static void Update(TblPublisher tblPublisher)
        {
            TblPublisher temp = GetById(tblPublisher.Id);
            temp.Name = tblPublisher.Name;
            temp.Address = tblPublisher.Address;
            temp.IsActivated = tblPublisher.IsActivated;
            temp.UpdatedBy = tblPublisher.UpdatedBy;
            temp.UpdatedAt = DateTime.Now;

            TblPublisher.Update(temp);
        }

        public static void Delete(Guid publisherId)
        {
            TblPublisher tblPublisher = GetById(publisherId);
            tblPublisher.IsDeleted = true;
            TblPublisher.Update(tblPublisher);

            InlineQuery query = new InlineQuery();
            query.Execute($"UPDATE TblBook SET IsActivated = 0 WHERE PublisherId = '{publisherId}'");
        }
    }
}
