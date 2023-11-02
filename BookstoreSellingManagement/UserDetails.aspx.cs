using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie requestedCookie = AuthService.GetUserCookie(Page);

                if (requestedCookie == null)
                {
                    Response.Redirect("LogIn.aspx");
                }

                Guid id;

                if (Guid.TryParse(requestedCookie[AuthService.Key_Id], out id))
                {
                    PopulateDataToPage(id);
                }
                else
                {
                    Response.Redirect("NotFound.aspx");
                }
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_action_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandArgument)
            {
                case "Save":
                    if (Page.IsValid)
                    {
                        TblUser user = UserService.GetById(Guid.Parse(Hf_userId.Value));
                        user.FirstName = change_firstname.Text;
                        user.LastName = change_lastname.Text;
                        user.Birthday = change_birthday.Text;
                        user.Gender = change_gender.Value == "Male";
                        user.Address = change_address.Text;
                        user.Phone = change_phone.Text;
                        user.Email = change_email.Text;

                        UserService.Update(user);
                        Response.Redirect($"UserDetails.aspx");
                    }
                    break;

                case "Edit":
                    firstname_container.Visible = true;
                    lastname_container.Visible = true;
                    birthday_container.Visible = true;
                    gender_container.Visible = true;
                    address_container.Visible = true;
                    phone_container.Visible = true;
                    email_container.Visible = true;

                    user_firstname.Visible = false;
                    user_lastname.Visible = false;
                    user_birthday.Visible = false;
                    user_gender.Visible = false;
                    user_address.Visible = false;
                    user_phone.Visible = false;
                    user_email.Visible = false;

                    Btn_action.Text = "Save";
                    Btn_action.CommandArgument = "Save";
                    Btn_cancel.Visible = true;
                    break;

                case "Cancel":
                    Response.Redirect($"UserDetails.aspx");
                    break;
            }
        }


        // ------------- Validators ------------- //
        protected void Cv_firstname_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_firstname.ErrorMessage = "First name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 50)
            {
                Cv_firstname.ErrorMessage = "First name must be less than 50 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_lastname_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_lastname.ErrorMessage = "Last name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 100)
            {
                Cv_lastname.ErrorMessage = "Last name must be less than 100 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_birthday_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_birthday.ErrorMessage = "Birthday is required.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_address_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_address.ErrorMessage = "Address is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 256)
            {
                Cv_address.ErrorMessage = "Address must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_phone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_phone.ErrorMessage = "Phone number is required.";
                args.IsValid = false;
                return;
            }

            Regex arabicNumber = new Regex(@"^[0-9]+$");

            if (!arabicNumber.IsMatch(args.Value))
            {
                Cv_phone.ErrorMessage = "Invalid format.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 20)
            {
                Cv_phone.ErrorMessage = "User's phone number must be less than 20 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_email.ErrorMessage = "Email is required.";
                args.IsValid = false;
                return;
            }

            Regex email = new Regex(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;,.]{0,1}\s*)+$");

            if (!email.IsMatch(args.Value))
            {
                Cv_email.ErrorMessage = "Invalid email format.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 256)
            {
                Cv_email.ErrorMessage = "User's phone number must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }


        // ------------- Private Processing Methods ------------- //
        private void PopulateDataToPage(Guid id)
        {
            TblUser user = UserService.GetById(id);

            if (user == null)
            {
                Response.Redirect("NotFound.aspx");
            }

            Hf_userId.Value = user.Id.ToString();
            user_avatar.Src = "img/avatar/" + user.Avatar;

            change_firstname.Text = user_firstname.InnerText = user.FirstName;
            change_lastname.Text = user_lastname.InnerText = user.LastName;
            change_birthday.Text = user_birthday.InnerText = DateTime.Parse(user.Birthday.Split(' ')[0]).ToString("yyyy-MM-dd");
            change_gender.Value = user_gender.InnerText = user.Gender ? "Male" : "Female";
            change_address.Text = user_address.InnerText = user.Address;
            change_phone.Text = user_phone.InnerText = user.Phone;
            change_email.Text = user_email.InnerText = user.Email;
        }
    }
}