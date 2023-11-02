using BookstoreManagementDAL;
using System;
using System.Web;
using System.Web.UI;

namespace BookstoreSellingManagement.BAL.Services
{
    public enum UserRole
    {
        Admin,
        Manager,
        User
    }

    public class AuthService
    {
        public static readonly string CookieName = "User_Cookie";
        public static readonly string Key_Id = "Id";
        public static readonly string Key_Name = "Name";


        public static bool IsLoggedIn(Page page)
        {
            HttpCookie requestedCookie = GetUserCookie(page);

            if (requestedCookie != null)
            {
                TblUser user = UserService.GetById(Guid.Parse(requestedCookie[Key_Id]));

                return user != null;
            }

            return false;
        }

        public static bool IsAuthorized(Page page, params UserRole[] rolesToCheck)
        {
            HttpCookie requestedCookie = GetUserCookie(page);

            if (requestedCookie != null)
            {
                TblRoleCollection userRoleList = TblUser.GetTblRoleCollection(Guid.Parse(requestedCookie[Key_Id]));

                foreach (var userRole in userRoleList)
                {
                    foreach (var role in rolesToCheck)
                    {
                        if (userRole.Name == role.ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool IsAuthorized(HttpCookie userCookie, params UserRole[] rolesToCheck)
        {
            Guid userId;

            if (Guid.TryParse(userCookie[Key_Id], out userId) == false) return false;

            TblRoleCollection userRoleList = TblUser.GetTblRoleCollection(userId);

            if (userRoleList != null)
            {
                foreach (var userRole in userRoleList)
                {
                    foreach (var role in rolesToCheck)
                    {
                        if (userRole.Name == role.ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static HttpCookie GetUserCookie(Page page)
        {
            HttpCookie cookie = (HttpCookie)page.Session[CookieName];

            if (cookie == null)
            {
                cookie = page.Request.Cookies[CookieName];
                page.Session[CookieName] = cookie;
            }

            return cookie;
        }

        public static bool LogIn(Page page, string username, string password)
        {
            bool isActivated;
            TblUser user = UserService.GetByLogIn(username, password, out isActivated);

            if (user != null && isActivated)
            {
                HttpCookie userCookie = new HttpCookie(CookieName);
                userCookie[Key_Id] = user.Id.ToString();
                userCookie[Key_Name] = user.LastName;

                page.Response.Cookies.Add(userCookie);
                page.Session[CookieName] = userCookie;
                return true;
            }

            return false;
        }

        public static void LogOut(Page page)
        {
            page.Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
