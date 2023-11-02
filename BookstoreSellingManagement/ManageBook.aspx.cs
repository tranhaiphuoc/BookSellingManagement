using BookstoreManagementDAL;
using BookstoreSellingManagement.BAL.Services;
using BookstoreSellingManagement.Enums;
using BookstoreSellingManagement.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class ManageBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAuthors();
                LoadCategories();
                LoadPublisher();

                if (Request.QueryString["id"] != null)
                {
                    Guid id;
                    bool isValidId = Guid.TryParse(Request.QueryString["id"], out id);

                    if (isValidId)
                    {
                        PopulateDataToPage(id);
                    }
                    else
                    {
                        Response.Redirect("NotFound.aspx");
                    }
                }
            }
        }


        // ------------- Commands And Events ------------- //
        protected void Btn_Submit_Command(object sender, CommandEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BookId.Value))
            {
                if (Page.IsValid)
                {
                    TblBook book = GetBookDataInForm();
                    book.Id = Guid.Parse(BookId.Value);
                    book.Image = BookImgURI.Value;

                    if (IsImageValid())
                    {
                        book.Image = FileUpload.FileName;
                        UploadFile();
                    }

                    BookService.Update(book, GetBookAuthorIdList(), GetBookCategoryIdList());

                    Page.ShowToastr("Book has been succesfully updated!", "Update", ToastrType.success.ToString());
                }
            }
            else
            {
                if (Page.IsValid)
                {
                    TblBook book = GetBookDataInForm();
                    book.Id = new Guid();
                    book.Image = FileUpload.FileName;
                    book.CreatedAt = DateTime.Now;

                    BookService.Insert(book, GetBookAuthorIdList(), GetBookCategoryIdList());
                    UploadFile();

                    Page.ShowToastr("Book has been succesfully added!", "Add", ToastrType.success.ToString());
                }
            }
        }

        protected void Btn_ReturnBack_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Books.aspx");
        }


        // ------------- Validators ------------- //
        protected void Cv_bookImage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(BookId.Value))
            {
                if (FileUpload.PostedFile == null || FileUpload.PostedFile.FileName == "")
                {
                    Cv_bookImage.ErrorMessage = "Book's image is required.";
                    args.IsValid = false;
                    return;
                }

                if (FileUpload.PostedFile.FileName.Length > 256)
                {
                    Cv_bookImage.ErrorMessage = "The image's name must be less than 256 characters long.";
                    args.IsValid = false;
                    return;
                }

                // 60000 B means 60KB, You can change the value based on your requirement  
                if (FileUpload.PostedFile.ContentLength > 60000)
                {
                    Cv_bookImage.ErrorMessage = "The image's size must be less than 60KB.";
                    args.IsValid = false;
                    return;
                }
            }
        }

        protected void Cv_bookDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_bookDescription.ErrorMessage = "Book's description is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 256)
            {
                Cv_bookDescription.ErrorMessage = "Book's description must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookISBN_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_bookISBN.ErrorMessage = "Book's ISBN is required.";
                args.IsValid = false;
                return;
            }

            Regex arabicNumber = new Regex(@"^[0-9]+$");

            if (!arabicNumber.IsMatch(args.Value))
            {
                Cv_bookISBN.ErrorMessage = "Invalid format.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length != 10 && args.Value.Length != 13)
            {
                Cv_bookISBN.ErrorMessage = "ISBN is only 10 or 13 digits long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value))
            {
                Cv_bookTitle.ErrorMessage = "Book's title is required.";
                args.IsValid = false;
                return;
            }

            if (args.Value.Length > 256)
            {
                Cv_bookTitle.ErrorMessage = "Book's title must be less than 256 characters long.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookPriceInput_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_bookPriceInput.ErrorMessage = "Book's price input is required.";
                args.IsValid = false;
                return;
            }

            decimal priceIn;
            bool isPriceValid = decimal.TryParse(args.Value, out priceIn);

            if (!isPriceValid)
            {
                Cv_bookPriceInput.ErrorMessage = "Invalid format.";
                args.IsValid = false;
                return;
            }

            if (priceIn < 0)
            {
                Cv_bookPriceInput.ErrorMessage = "Book's price input must be greater than 0.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookPriceOutput_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_bookPriceOutput.ErrorMessage = "Book's price output is required.";
                args.IsValid = false;
                return;
            }

            decimal priceOut;
            bool isPriceValid = decimal.TryParse(args.Value, out priceOut);

            if (!isPriceValid)
            {
                Cv_bookPriceOutput.ErrorMessage = "Invalid format.";
                args.IsValid = false;
                return;
            }

            if (priceOut < 0)
            {
                Cv_bookPriceOutput.ErrorMessage = "Book's price output must not be a negative number.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookQuantity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                Cv_bookQuantity.ErrorMessage = "Book's quantity is required.";
                args.IsValid = false;
                return;
            }

            int quantity;
            bool isQuantityValid = int.TryParse(args.Value, out quantity);

            if (!isQuantityValid)
            {
                Cv_bookQuantity.ErrorMessage = "Invalid format.";
                args.IsValid = false;
                return;
            }

            if (quantity < 0)
            {
                Cv_bookQuantity.ErrorMessage = "Book's quantity must not be a negative number.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookPublisher_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Ddl_Publisher.SelectedIndex == -1)
            {
                Cv_bookPublisher.ErrorMessage = "Book's publisher is required.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookAuthor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Ddl_Author.SelectedIndex == -1)
            {
                Cv_bookAuthor.ErrorMessage = "Book's author is required.";
                args.IsValid = false;
                return;
            }
        }

        protected void Cv_bookCategory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Ddl_Category.SelectedIndex == -1)
            {
                Cv_bookCategory.ErrorMessage = "Book's category is required.";
                args.IsValid = false;
                return;
            }
        }


        // ------------- Private Processing Methods ------------- //
        private void LoadAuthors()
        {
            foreach (var item in AuthorService.GetAll())
            {
                Ddl_Author.Items.Add(new ListItem(item.Name, item.Id.ToString()));
            }
        }

        private void LoadCategories()
        {
            Ddl_Category.DataSource = CategoryService.GetAll();
            Ddl_Category.DataTextField = "Name";
            Ddl_Category.DataValueField = "Id";
            Ddl_Category.DataBind();
        }

        private void LoadPublisher()
        {
            Ddl_Publisher.DataSource = PublisherService.GetAll();
            Ddl_Publisher.DataTextField = "Name";
            Ddl_Publisher.DataValueField = "Id";
            Ddl_Publisher.DataBind();

            //Ddl_Publisher.Items.Insert(0, new ListItem("", ""));
        }

        private void PopulateDataToPage(Guid id)
        {
            TblBook book = BookService.GetById(id);

            if (book == null)
            {
                Response.Redirect("NotFound.aspx");
            }

            BookId.Value = book.Id.ToString();
            BookImgURI.Value = book.Image;
            BookImg.Src = "img/book/" + book.Image;

            ISBN.Text = book.Isbn;
            BookTitle.Text = book.Title;
            PriceInput.Text = book.PriceInput.ToString();
            PriceOutput.Text = book.PriceOutput.ToString();
            Quantity.Text = book.Quantity.ToString();
            Description.Text = book.Description;
            if (book.IsActivated)
            {
                IsActivatedTrue.Checked = true;
            }
            else
            {
                IsActivatedFalse.Checked = true;
            }

            Ddl_Publisher.Items.FindByValue(book.PublisherId.ToString()).Selected = true;

            var coll = BookAuthorService.GetAuthorsByBookId(book.Id);
            foreach (var item in coll)
            {
                Ddl_Author.Items.FindByValue(item.ToString()).Selected = true;
            }

            coll = BookCategoryService.GetCategoriesByBookId(book.Id);
            foreach (var item in coll)
            {
                Ddl_Category.Items.FindByValue(item.ToString()).Selected = true;
            }
        }

        private void UploadFile()
        {
            //folder path to save uploaded file
            string folderPath = Server.MapPath("img/book/");

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
                Cv_bookImage.ErrorMessage = "Book's image is required.";
                return false;
            }

            // 60000 B means 60KB, You can change the value based on your requirement  
            if (FileUpload.PostedFile.ContentLength > 60000)
            {
                Cv_bookImage.ErrorMessage = "The image's size must be less than 60KB.";
                return false;
            }

            return true;
        }

        private TblBook GetBookDataInForm()
        {
            return new TblBook()
            {
                Isbn = ISBN.Text,
                Title = BookTitle.Text,
                PriceInput = decimal.Parse(PriceInput.Text),
                PriceOutput = decimal.Parse(PriceOutput.Text),
                Description = Description.Text,
                Quantity = int.Parse(Quantity.Text),
                IsActivated = IsActivatedTrue.Checked,
                UpdatedAt = DateTime.Now,
                PublisherId = Guid.Parse(Ddl_Publisher.Value)
            };
        }

        private Guid[] GetBookAuthorIdList()
        {
            var bookAuthorIdList = Ddl_Author.Items.Cast<ListItem>()
                                 .Where(item => item.Selected)
                                 .Select(item => item.Value)
                                 .ToList();

            Guid[] authorIdList = new Guid[bookAuthorIdList.Count];

            for (int i = 0; i < bookAuthorIdList.Count; i++)
            {
                authorIdList[i] = Guid.Parse(bookAuthorIdList[i]);
            }

            return authorIdList;
        }

        private Guid[] GetBookCategoryIdList()
        {
            var bookCategoryIdList = Ddl_Category.Items.Cast<ListItem>()
                                 .Where(item => item.Selected)
                                 .Select(item => item.Value)
                                 .ToList();

            Guid[] categoryIdList = new Guid[bookCategoryIdList.Count];

            for (int i = 0; i < bookCategoryIdList.Count; i++)
            {
                categoryIdList[i] = Guid.Parse(bookCategoryIdList[i]);
            }

            return categoryIdList;
        }
    }
}