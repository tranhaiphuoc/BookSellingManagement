using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using System;
using System.Web;
using System.Web.UI;

namespace BookstoreSellingManagement
{
    public partial class Admin : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = AuthService.GetUserCookie(Page);

            if (cookie == null)
            {
                Response.Redirect("NotFound");
            }

            if (AuthService.IsAuthorized(cookie, UserRole.Admin, UserRole.Manager) == false)
            {
                Response.Redirect("NotFound");
            }

            TblUser user = UserService.GetById(Guid.Parse(cookie[AuthService.Key_Id]));

            if (user != null)
            {
                Img_userImage.Src = "img/avatar/" + user.Avatar;
                Lb_userName.InnerText = user.LastName;
            }
        }

        protected void Btn_adminLogOut_Click(object sender, EventArgs e)
        {
            AuthService.LogOut(Page);
            Response.Redirect("/");
        }
    }
}