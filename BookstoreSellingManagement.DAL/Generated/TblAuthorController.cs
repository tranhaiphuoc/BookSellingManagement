using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace BookstoreManagementDAL
{
    /// <summary>
    /// Controller class for TblAuthor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TblAuthorController
    {
        // Preload our schema..
        TblAuthor thisSchemaLoad = new TblAuthor();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TblAuthorCollection FetchAll()
        {
            TblAuthorCollection coll = new TblAuthorCollection();
            Query qry = new Query(TblAuthor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblAuthorCollection FetchByID(object Id)
        {
            TblAuthorCollection coll = new TblAuthorCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblAuthorCollection FetchByQuery(Query qry)
        {
            TblAuthorCollection coll = new TblAuthorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (TblAuthor.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (TblAuthor.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,string Name,string Biography,bool IsActivated,bool IsDeleted,string CreatedBy,DateTime CreatedAt,string UpdatedBy,DateTime UpdatedAt)
	    {
		    TblAuthor item = new TblAuthor();
		    
            item.Id = Id;
            
            item.Name = Name;
            
            item.Biography = Biography;
            
            item.IsActivated = IsActivated;
            
            item.IsDeleted = IsDeleted;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedAt = CreatedAt;
            
            item.UpdatedBy = UpdatedBy;
            
            item.UpdatedAt = UpdatedAt;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,string Name,string Biography,bool IsActivated,bool IsDeleted,string CreatedBy,DateTime CreatedAt,string UpdatedBy,DateTime UpdatedAt)
	    {
		    TblAuthor item = new TblAuthor();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Name = Name;
				
			item.Biography = Biography;
				
			item.IsActivated = IsActivated;
				
			item.IsDeleted = IsDeleted;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedAt = CreatedAt;
				
			item.UpdatedBy = UpdatedBy;
				
			item.UpdatedAt = UpdatedAt;
				
	        item.Save(UserName);
	    }
    }
}
