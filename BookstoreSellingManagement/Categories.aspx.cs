using BookstoreSellingManagement.BAL.Services;
using System;
using System.Web.UI.WebControls;

namespace BookstoreSellingManagement
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }


        // ------------- Commands, Events and Page Methods ------------- //
        protected void Btn_Add_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManageCategory.aspx");
        }

        protected void Btn_Edit_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect($"ManageCategory.aspx?id={e.CommandArgument}");
        }

        protected void Btn_ConfirmDelete_Command(object sender, CommandEventArgs e)
        {
            Guid categoryId = Guid.Parse(DeleteId.Value);
            CategoryService.Delete(categoryId);

            LoadCategories();
        }

        protected string CutString(string str)
        {
            int value = 30;
            if (str.Length > value)
            {
                str = str.Substring(0, value) + "...";
            }
            return str;
        }


        // ------------- Private Methods For Processing ------------- //
        private void LoadCategories()
        {
            Rpt_List.DataSource = CategoryService.GetAll();
            Rpt_List.DataBind();
        }
    }
}