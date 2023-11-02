using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class ManageAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string queryId = Request.QueryString["id"];

                if (queryId != null)
                {
                    Guid id;

                    if (Guid.TryParse(queryId, out id))
                    {
                        PopulateDataToPage(id);
                    }
                }
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_Submit_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                TblAuthor tblAuthor = new TblAuthor()
                {
                    Name = AuthorName.Text.TrimStart().TrimEnd(),
                    Biography = AuthorBiography.Text.TrimStart().TrimEnd(),
                    IsActivated = IsActivatedTrue.Checked,
                    UpdatedAt = DateTime.Now
                };

                if (!string.IsNullOrWhiteSpace(AuthorId.Value))
                {
                    tblAuthor.Id = Guid.Parse(AuthorId.Value);
                    AuthorService.Update(tblAuthor);
                    
                    Page.ShowToastr("Author has been succesfully updated!", "Update", ToastrType.success.ToString());
                }
                else
                {
                    tblAuthor.Id = new Guid();
                    tblAuthor.CreatedAt = DateTime.Now;
                    AuthorService.Insert(tblAuthor);

                    Page.ShowToastr("Author has been succesfully added!", "Add", ToastrType.success.ToString());
                }
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Authors.aspx");
        }


        // ------------- Validators ------------- //
        protected void Cv_authorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_authorName.ErrorMessage = "Author's name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 50)
            {
                Cv_authorName.ErrorMessage = "Author's name must be less than 50 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_authorBiography_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_authorBiography.ErrorMessage = "Author's biography is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 256)
            {
                Cv_authorBiography.ErrorMessage = "Author's biography must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }


        // ------------- Private Processing Methods ------------- //
        private void PopulateDataToPage(Guid id)
        {
            TblAuthor author = AuthorService.GetById(id);

            if (author == null)
            {
                Response.Redirect("NotFound.aspx");
            }

            AuthorId.Value = author.Id.ToString();
            AuthorName.Text = author.Name;
            AuthorBiography.Text = author.Biography;
            if (author.IsActivated)
            {
                IsActivatedTrue.Checked = true;
            }
            else
            {
                IsActivatedFalse.Checked = true;
            }
        }
    }
}