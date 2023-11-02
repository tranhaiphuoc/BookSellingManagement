using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // ------------- Commands And Events ------------- //
        protected void Btn_Submit_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                TblUser newUser = GetUserInputInForm();

                if (FileUpload.PostedFile != null && FileUpload.PostedFile.FileName != "")
                {
                    newUser.Avatar = FileUpload.FileName;
                    UploadFile();
                }

                TblRole role = RoleService.GetByName(UserRole.User.ToString());

                UserService.Insert(newUser, new Guid[] { role.Id });

                Response.Redirect("/");
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/");
        }


        // ------------- Validatiors ------------- //
        protected void Cv_userAvatar_ServerValidate(object source, ServerValidateEventArgs args)
        {
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

            string tempUsername = args.Value.Trim();

            if (tempUsername.Length < 8)
            {
                Cv_username.ErrorMessage = "Username must be at least 8 characters long.";
                args.IsValid = false;
                return;
            }

            if (tempUsername.Length > 256)
            {
                Cv_username.ErrorMessage = "Username must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }

            TblUser findExistedUser = UserService.GetByUsername(tempUsername);

            if (findExistedUser != null)
            {
                Cv_username.ErrorMessage = "This username has been taken.";
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


        // ------------- Private Processing Methods ------------- //
        private TblUser GetUserInputInForm()
        {
            return new TblUser()
            {
                Avatar = "placeholder.png",
                FirstName = Txt_FirstName.Text.Trim(),
                LastName = Txt_LastName.Text.Trim(),
                Gender = Male.Checked,
                Birthday = Txt_Birthday.Value,
                Address = Txt_Address.Text.Trim(),
                Phone = Txt_Phone.Text.Trim(),
                Email = Txt_Email.Text.Trim(),
                Username = Txt_Username.Text.Trim(),
                Password = Txt_Password.Text.Trim(),
                IsActivated = true,
                CreatedBy = "user",
                CreatedAt = DateTime.Now,
                UpdatedBy = "user",
                UpdatedAt = DateTime.Now
            };
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
    }
}