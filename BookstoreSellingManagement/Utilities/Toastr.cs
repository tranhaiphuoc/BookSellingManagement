using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreSellingManagement.Utilities
{
    [Serializable]
    public class Toastr
    {
        public static readonly string SessionName = "toastrMessage";


        public string Message { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }


        public static Toastr Create(string message, string title, Enum type)
        {
            return new Toastr()
            {
                Message = message,
                Title = title,
                Type = type.ToString()
            };
        }
    }
}