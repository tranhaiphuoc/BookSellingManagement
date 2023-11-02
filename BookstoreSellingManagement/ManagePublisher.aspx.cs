using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using BookstoreSellingManagement.Utilities;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class ManagePublisher : System.Web.UI.Page
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
                TblPublisher tblPublisher = new TblPublisher()
                {
                    Name = PublisherName.Text.TrimStart().TrimEnd(),
                    Address = PublisherAddress.Text,
                    IsActivated = IsActivatedTrue.Checked,
                    UpdatedAt = DateTime.Now
                };

                if (!string.IsNullOrWhiteSpace(PublisherId.Value))
                {
                    tblPublisher.Id = Guid.Parse(PublisherId.Value);
                    PublisherService.Update(tblPublisher);

                    Page.ShowToastr("Publisher has been succesfully updated!", "Update", ToastrType.success.ToString());
                }
                else
                {
                    tblPublisher.Id = new Guid();
                    tblPublisher.CreatedAt = DateTime.Now;
                    PublisherService.Insert(tblPublisher);

                    Page.ShowToastr("Publisher has been succesfully added!", "Add", ToastrType.success.ToString());
                }
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Publisher.aspx");
        }


        // ------------- Commands And Events ------------- //
        protected void Cv_publisherName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_publisherName.ErrorMessage = "Publisher's name is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 50)
            {
                Cv_publisherName.ErrorMessage = "Publisher's name must be less than 50 characters long.";
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }

        protected void Cv_publisherAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_publisherAddress.ErrorMessage = "Publisher's address is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 256)
            {
                Cv_publisherAddress.ErrorMessage = "Publisher's address must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }


        // ------------- Private Processing Methods ------------- //
        private void PopulateDataToPage(Guid id)
        {
            TblPublisher publisher = PublisherService.GetById(id);

            if (publisher == null)
            {
                //Response.Redirect("NotFound.aspx");
            }

            PublisherId.Value = publisher.Id.ToString();
            PublisherName.Text = publisher.Name;
            PublisherAddress.Text = publisher.Address;
            if (publisher.IsActivated)
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