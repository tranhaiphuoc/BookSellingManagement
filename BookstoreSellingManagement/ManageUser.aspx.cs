using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class ManageUser : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRoles();
                
                if (Request.QueryString["id"] != null)
                {
                    Guid id;
                    bool isValidId = Guid.TryParse(Request.QueryString["id"], out id);

                    if (isValidId)
                    {
                        LoadDataToPage(id);
                    }
                }
                else
                {
                    //Response.Redirect("NotFound.aspx");
                }
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_Submit_Command(object sender, CommandEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserId.Value))
            {
                if (Page.IsValid)
                {
                    TblUser user = GetUserDataInForm();
                    user.Id = Guid.Parse(UserId.Value);
                    user.Avatar = UserAvatarURI.Value;

                    if (IsImageValid())
                    {
                        user.Avatar = FileUpload.FileName;
                        UploadFile();
                    }

                    if (IsEditedPasswordValid())
                    {
                        user.Password = Password.Text;
                    }

                    UserService.Update(user, Ddl_Roles.Items);

                    Page.ShowToastr("User has been succesfully updated!", "Update", ToastrType.success.ToString());
                }
            }
            else
            {
                if (Page.IsValid)
                {
                    TblUser user = GetUserDataInForm();
                    user.Id = new Guid();
                    user.Avatar = "placeholder.png";
                    user.Username = Username.Text;
                    user.Password = Password.Text;
                    user.CreatedAt = DateTime.Now;

                    if (IsImageValid())
                    {
                        user.Avatar = FileUpload.FileName;
                        UploadFile();
                    }

                    UserService.Insert(user, Ddl_Roles.Items);

                    Page.ShowToastr("User has been succesfully added!", "Add", ToastrType.success.ToString());
                }
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Users.aspx");
        }


        // ------------- Validators ------------- //
        protected void Cv_userAvatar_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(UserId.Value))
            {
                if (FileUpload.PostedFile == null || FileUpload.PostedFile.FileName == "")
                {
                    Cv_userAvatar.ErrorMessage = "User's avatar is required.";
                    args.IsValid = false;
                    return;
                }

                if (FileUpload.PostedFile.FileName.Length > 256)
                {
                    Cv_userAvatar.ErrorMessage = "The image's name must be less than 256 characters long.";
                    args.IsValid = false;
                    return;
                }

                // 60000 B means 60KB, You can change the value based on your requirement  
                if (FileUpload.PostedFile.ContentLength > 60000)
                {
                    Cv_userAvatar.ErrorMessage = "The image's size must be less than 60KB.";
                    args.IsValid = false;
                    return;
                }
            }
        }

        protected void Cv_userFirstName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_userFirstName.ErrorMessage = "User's first name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 50)
            {
                Cv_userFirstName.ErrorMessage = "User's first name must be less than 50 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_userLastName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_userLastName.ErrorMessage = "User's last name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 100)
            {
                Cv_userLastName.ErrorMessage = "User's last name must be less than 100 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_userBirthday_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_userBirthday.ErrorMessage = "User's birthday is required.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_userAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_userAddress.ErrorMessage = "User's address is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 256)
            {
                Cv_userAddress.ErrorMessage = "User's address must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_userPhone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_userPhone.ErrorMessage = "User's phone number is required.";
                args.IsValid = false;
                return;
            }

            Regex arabicNumber = new Regex(@"^[0-9]+$");

            if (!arabicNumber.IsMatch(args.Value))
            {
                Cv_userPhone.ErrorMessage = "Invalid format.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 20)
            {
                Cv_userPhone.ErrorMessage = "User's phone number must be less than 20 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_userEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_userEmail.ErrorMessage = "User's phone number is required.";
                args.IsValid = false;
                return;
            }

            Regex email = new Regex(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;,.]{0,1}\s*)+$");

            if (!email.IsMatch(args.Value))
            {
                Cv_userEmail.ErrorMessage = "Invalid email format.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 256)
            {
                Cv_userEmail.ErrorMessage = "User's phone number must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_username_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_username.ErrorMessage = "Username is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Trim().Length > 256)
            {
                Cv_username.ErrorMessage = "Username must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(UserId.Value))
            {
                if (string.IsNullOrWhiteSpace(args.Value))
                {
                    Cv_password.ErrorMessage = "Password is required.";
                    args.IsValid = false;
                    return;
                }

                if (args.Value.Trim().Length < 8)
                {
                    Cv_password.ErrorMessage = "Password must be at least 8 characters long.";
                    args.IsValid = false;
                    return;
                }

                if (args.Value.Trim().Length > 256)
                {
                    Cv_password.ErrorMessage = "Password must be less than 256 characters long.";
                    args.IsValid = false;
                    return;
                }
            }
        }

        protected void Cv_role_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_role.ErrorMessage = "User's role is required.";
                args.IsValid = false;
                return;
            }
        }


        // ------------- Private Methods For Processing ------------- //
        private void LoadRoles()
        {
            HttpCookie requestedCookie = Request.Cookies[AuthService.CookieName];

            if (requestedCookie != null)
            {
                Guid id;
                bool isValid = Guid.TryParse(requestedCookie[AuthService.Key_Id], out id);

                if (isValid)
                {
                    TblRoleCollection userRoles = RoleService.GetByUserId(id);

                    foreach (var item in userRoles)
                    {
                        if (item.Name == UserRole.Admin.ToString())
                        {
                            foreach (var role in RoleService.GetAll())
                            {
                                Ddl_Roles.Items.Add(new ListItem(role.Name, role.Id.ToString()));
                            }
                            return;
                        }
                    }

                    foreach (var role in RoleService.GetAll(true))
                    {
                        Ddl_Roles.Items.Add(new ListItem(role.Name, role.Id.ToString()));
                    }
                }
            }
        }

        private void LoadDataToPage(Guid id)
        {
            TblUser tbl = UserService.GetById(id);

            if (tbl == null)
            {
                //Response.Redirect("NotFound.aspx");
            }

            UserId.Value = tbl.Id.ToString();
            UserAvatarURI.Value = tbl.Avatar;
            UserAvatar.Src = "img/user/" + tbl.Avatar;

            UserFirstName.Text = tbl.FirstName;
            UserLastName.Text = tbl.LastName;
            UserBirthday.Value = DateTime.Parse(tbl.Birthday).ToString("yyyy-MM-dd");
            UserAddress.Text = tbl.Address;
            UserPhone.Text = tbl.Phone;
            UserEmail.Text = tbl.Email;

            // Username won't be alter by any means
            usernameComp.Visible = false;

            if (tbl.Gender) Male.Checked = true;
            else Female.Checked = true;

            if (tbl.IsActivated) IsActivatedTrue.Checked = true;
            else IsActivatedFalse.Checked = true;

            foreach (var item in UserRoleService.GetRolesByUserId(tbl.Id))
            {
                Ddl_Roles.Items.FindByValue(item.ToString()).Selected = true;
            }
        }

        private void UploadFile()
        {
            //folder path to save uploaded file
            string folderPath = Server.MapPath("img/avatar/");

            //Check whether Directory (Folder) exists, although we have created, if it si not created this code will check
            if (!Directory.Exists(folderPath))
            {
                //If folder does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Concat a path to save file
            string imagePath = folderPath + FileUpload.FileName;

            //save file in the specified folder and path
            FileUpload.SaveAs(imagePath);
        }

        private bool IsImageValid()
        {
            if (FileUpload.PostedFile == null || FileUpload.PostedFile.FileName == "")
            {
                return false;
            }

            // 60000 B means 60KB, You can change the value based on your requirement  
            if (FileUpload.PostedFile.ContentLength > 60000)
            {
                return false;
            }

            return true;
        }

        private bool IsEditedPasswordValid()
        {
            if (!string.IsNullOrEmpty(Password.Text))
            {
                return false;
            }

            if (Password.Text.Trim().Length < 8)
            {
                return false;
            }

            return true;
        }

        private TblUser GetUserDataInForm()
        {
            return new TblUser()
            {
                FirstName = UserFirstName.Text.Trim(),
                LastName = UserLastName.Text.Trim(),
                Birthday = UserBirthday.Value,
                Gender = Male.Checked,
                Address = UserAddress.Text.Trim(),
                Phone = UserPhone.Text.Trim(),
                Email = UserEmail.Text.Trim(),
                IsActivated = IsActivatedTrue.Checked,
                UpdatedAt = DateTime.Now
            };
        }
    }
}