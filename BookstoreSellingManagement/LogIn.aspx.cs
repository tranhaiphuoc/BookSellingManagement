using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthService.IsLoggedIn(Page))
            {
                Response.Redirect("/");
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_logIn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (AuthService.LogIn(Page, Txt_username.Text.Trim(), Txt_password.Text.Trim()))
                {
                    string redirectURL = Request.QueryString["redirect"];

                    if (redirectURL != null)
                    {
                        Response.Redirect(redirectURL);
                    }

                    Response.Redirect("/");
                }

                Page.ShowToastr("Username or passord is not correct.", "Error", ToastrType.error.ToString());
            }
        }


        // ------------- Validators ------------- //
        protected void Cv_username_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_username.ErrorMessage = "Username is required.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_password.ErrorMessage = "Password is required.";
                args.IsValid = false;
                return;
            }
        }


        // ------------- Private Processing Methods ------------- //
    }
}