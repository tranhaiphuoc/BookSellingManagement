using BookstoreManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BookstoreSellingManagement.BAL.Services
{
    public class CartService
    {
        public static void AddToCart(Page page, Guid bookId)
        {
            if (page.Session["Cart"] == null)
            {
                TblBook book = BookService.GetById(bookId);
                book.Quantity = 1;

                List<TblBook> list = new List<TblBook> { book };
                page.Session["Cart"] = list;
            }
            else
            {
                List<TblBook> list = (List<TblBook>)page.Session["Cart"];

                Guid guid = bookId;

                TblBook book = list.FirstOrDefault(x => x.Id == guid);

                if (book == null)
                {
                    book = BookService.GetById(guid);
                    book.Quantity = 1;

                    list.Add(book);
                }
                else
                {
                    TblBook dbBook = BookService.GetById(guid);

                    if (book.Quantity < dbBook.Quantity)
                    {
                        book.Quantity++;
                    }
                }
            }
        }
    }
}
