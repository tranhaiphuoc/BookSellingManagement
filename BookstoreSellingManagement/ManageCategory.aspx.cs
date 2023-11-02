using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using BookstoreSellingManagement.Utilities;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Guid id;
                    bool isValidId = Guid.TryParse(Request.QueryString["id"], out id);

                    if (isValidId)
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
                TblCategory tblCategory = new TblCategory()
                {
                    Name = CategoryName.Text.TrimStart().TrimEnd(),
                    Description = CategoryDescription.Text.TrimStart().TrimEnd(),
                    IsActivated = IsActivatedTrue.Checked,
                    UpdatedAt = DateTime.Now
                };

                if (!string.IsNullOrWhiteSpace(CategoryId.Value))
                {
                    tblCategory.Id = Guid.Parse(CategoryId.Value);
                    CategoryService.Update(tblCategory);

                    Page.ShowToastr("Category has been succesfully updated!", "Update", ToastrType.success.ToString());
                }
                else
                {
                    tblCategory.Id = new Guid();
                    tblCategory.CreatedAt = DateTime.Now;
                    CategoryService.Insert(tblCategory);

                    Page.ShowToastr("Category has been succesfully added!", "Add", ToastrType.success.ToString());
                }
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }


        // ------------- Validators ------------- //
        protected void Cv_categoryName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_categoryName.ErrorMessage = "Category's name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 50)
            {
                Cv_categoryName.ErrorMessage = "Category's name must be less than 50 characters long.";
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }

        protected void Cv_categoryDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_categoryDescription.ErrorMessage = "Category's description is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 256)
            {
                Cv_categoryName.ErrorMessage = "Category's description must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }


        // ------------- Private Processing Methods ------------- //
        private void PopulateDataToPage(Guid id)
        {
            TblCategory tblCategory = CategoryService.GetById(id);

            if (tblCategory == null)
            {
                Response.Redirect("NotFound.aspx");
            }

            CategoryId.Value = tblCategory.Id.ToString();
            CategoryName.Text = tblCategory.Name;
            CategoryDescription.Text = tblCategory.Description;
            if (tblCategory.IsActivated)
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