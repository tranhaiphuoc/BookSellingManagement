using System.Web.UI;

namespace BookstoreSellingManagement.Extensions
{
    public static class ExtensionMethod
    {
        public static void ShowToastr(this Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  string.Format($"toastr.{type}('{message}', '{title}');"), true);
        }
    }
}