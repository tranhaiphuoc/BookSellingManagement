using BookstoreManagementDAL;
using SubSonic;
using System;
using System.Data;

namespace BookstoreSellingManagement.BAL.Services
{
    public class OrderService
    {
        public static TblOrderCollection GetAll(bool getDeleted = false)
        {
            if (getDeleted)
            {
                return new Select()
                    .From(TblOrder.Schema)
                    .OrderDesc(TblOrder.Columns.CreatedAt)
                    .ExecuteAsCollection<TblOrderCollection>();
            }

            return new Select()
                .From(TblOrder.Schema)
                .Where(TblOrder.Columns.IsDeleted).IsEqualTo(false)
                .OrderDesc(TblOrder.Columns.CreatedAt)
                .ExecuteAsCollection<TblOrderCollection>();
        }

        public static TblOrderCollection GetAllByUserId(Guid userId)
        {
            return new Select()
                .From(TblOrder.Schema)
                .Where(TblOrder.Columns.UserId).IsEqualTo(userId)
                .And(TblOrder.Columns.IsDeleted).IsEqualTo(false)
                .OrderAsc(TblOrder.Columns.CreatedAt)
                .ExecuteAsCollection<TblOrderCollection>();
        }

        public static IDataReader GetDetails(Guid? userId, Guid orderId)
        {
            if (userId == null)
            {
                return new InlineQuery().ExecuteReader(
                    $"SELECT TblBook.Title, TblBook.Image, TblOrderDetail.UnitPrice, TblOrderDetail.Discount, TblOrderDetail.Quantity, TblOrderDetail.Total " +
                    $"FROM TblOrderDetail " +
                    $"INNER JOIN TblOrder ON TblOrderDetail.OrderId = TblOrder.Id " +
                    $"INNER JOIN TblBook ON TblOrderDetail.BookId = TblBook.Id " +
                    $"WHERE TblOrder.Id = '{orderId}' AND TblOrder.IsDeleted = 0");
            }

            return new InlineQuery().ExecuteReader(
                $"SELECT TblBook.Title, TblBook.Image, TblOrderDetail.UnitPrice, TblOrderDetail.Discount, TblOrderDetail.Quantity, TblOrderDetail.Total " +
                $"FROM TblOrderDetail " +
                $"INNER JOIN TblOrder ON TblOrderDetail.OrderId = TblOrder.Id " +
                $"INNER JOIN TblBook ON TblOrderDetail.BookId = TblBook.Id " +
                $"WHERE TblOrder.UserId = '{userId}' AND TblOrder.Id = '{orderId}' AND TblOrder.IsDeleted = 0");
        }

        public static TblOrder GetById(Guid id)
        {
            return new Select()
                .From(TblOrder.Schema.TableName)
                .Where(TblOrder.Columns.Id).IsEqualTo(id)
                .ExecuteSingle<TblOrder>();
        }

        public static decimal GetOrderDetailsTotal(Guid orderId)
        {
            return new Select(Aggregate.Sum("Total"))
                .From(TblOrderDetail.Schema)
                .Where(TblOrderDetail.Columns.OrderId).IsEqualTo(orderId)
                .ExecuteScalar<decimal>();
        }

        public static void Insert(TblOrder tblOrder, TblOrderDetailCollection tblOrderDetails)
        {
            TblOrder.Insert(tblOrder);
            foreach (var item in tblOrderDetails)
            {
                TblOrderDetail.Insert(item);
            }
        }

        public static void Update(TblOrder tblOrder)
        {
            TblOrder.Update(tblOrder);
        }

        public static void Delete(Guid orderId)
        {
            TblOrder tblOrder = GetById(orderId);
            tblOrder.IsDeleted = true;
            TblOrder.Update(tblOrder);
        }
    }
}
