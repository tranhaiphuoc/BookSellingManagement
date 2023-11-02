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
	/// Strongly-typed collection for the TblAuthor class.
	/// </summary>
    [Serializable]
	public partial class TblAuthorCollection : ActiveList<TblAuthor, TblAuthorCollection>
	{	   
		public TblAuthorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblAuthorCollection</returns>
		public TblAuthorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblAuthor o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the TblAuthor table.
	/// </summary>
	[Serializable]
	public partial class TblAuthor : ActiveRecord<TblAuthor>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblAuthor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblAuthor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblAuthor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblAuthor(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("TblAuthor", TableType.Table, DataService.GetInstance("DefaultConnection"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Guid;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				
						colvarId.DefaultSetting = @"(newid())";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				
						colvarName.DefaultSetting = @"('')";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarBiography = new TableSchema.TableColumn(schema);
				colvarBiography.ColumnName = "Biography";
				colvarBiography.DataType = DbType.String;
				colvarBiography.MaxLength = 256;
				colvarBiography.AutoIncrement = false;
				colvarBiography.IsNullable = false;
				colvarBiography.IsPrimaryKey = false;
				colvarBiography.IsForeignKey = false;
				colvarBiography.IsReadOnly = false;
				
						colvarBiography.DefaultSetting = @"('')";
				colvarBiography.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBiography);
				
				TableSchema.TableColumn colvarIsActivated = new TableSchema.TableColumn(schema);
				colvarIsActivated.ColumnName = "IsActivated";
				colvarIsActivated.DataType = DbType.Boolean;
				colvarIsActivated.MaxLength = 0;
				colvarIsActivated.AutoIncrement = false;
				colvarIsActivated.IsNullable = false;
				colvarIsActivated.IsPrimaryKey = false;
				colvarIsActivated.IsForeignKey = false;
				colvarIsActivated.IsReadOnly = false;
				
						colvarIsActivated.DefaultSetting = @"((1))";
				colvarIsActivated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActivated);
				
				TableSchema.TableColumn colvarIsDeleted = new TableSchema.TableColumn(schema);
				colvarIsDeleted.ColumnName = "IsDeleted";
				colvarIsDeleted.DataType = DbType.Boolean;
				colvarIsDeleted.MaxLength = 0;
				colvarIsDeleted.AutoIncrement = false;
				colvarIsDeleted.IsNullable = false;
				colvarIsDeleted.IsPrimaryKey = false;
				colvarIsDeleted.IsForeignKey = false;
				colvarIsDeleted.IsReadOnly = false;
				
						colvarIsDeleted.DefaultSetting = @"((0))";
				colvarIsDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDeleted);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 256;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedAt = new TableSchema.TableColumn(schema);
				colvarCreatedAt.ColumnName = "CreatedAt";
				colvarCreatedAt.DataType = DbType.DateTime;
				colvarCreatedAt.MaxLength = 0;
				colvarCreatedAt.AutoIncrement = false;
				colvarCreatedAt.IsNullable = false;
				colvarCreatedAt.IsPrimaryKey = false;
				colvarCreatedAt.IsForeignKey = false;
				colvarCreatedAt.IsReadOnly = false;
				
						colvarCreatedAt.DefaultSetting = @"(getdate())";
				colvarCreatedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedAt);
				
				TableSchema.TableColumn colvarUpdatedBy = new TableSchema.TableColumn(schema);
				colvarUpdatedBy.ColumnName = "UpdatedBy";
				colvarUpdatedBy.DataType = DbType.AnsiString;
				colvarUpdatedBy.MaxLength = 256;
				colvarUpdatedBy.AutoIncrement = false;
				colvarUpdatedBy.IsNullable = false;
				colvarUpdatedBy.IsPrimaryKey = false;
				colvarUpdatedBy.IsForeignKey = false;
				colvarUpdatedBy.IsReadOnly = false;
				
						colvarUpdatedBy.DefaultSetting = @"('')";
				colvarUpdatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedBy);
				
				TableSchema.TableColumn colvarUpdatedAt = new TableSchema.TableColumn(schema);
				colvarUpdatedAt.ColumnName = "UpdatedAt";
				colvarUpdatedAt.DataType = DbType.DateTime;
				colvarUpdatedAt.MaxLength = 0;
				colvarUpdatedAt.AutoIncrement = false;
				colvarUpdatedAt.IsNullable = false;
				colvarUpdatedAt.IsPrimaryKey = false;
				colvarUpdatedAt.IsForeignKey = false;
				colvarUpdatedAt.IsReadOnly = false;
				
						colvarUpdatedAt.DefaultSetting = @"(getdate())";
				colvarUpdatedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedAt);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DefaultConnection"].AddSchema("TblAuthor",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public Guid Id 
		{
			get { return GetColumnValue<Guid>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Biography")]
		[Bindable(true)]
		public string Biography 
		{
			get { return GetColumnValue<string>(Columns.Biography); }
			set { SetColumnValue(Columns.Biography, value); }
		}
		  
		[XmlAttribute("IsActivated")]
		[Bindable(true)]
		public bool IsActivated 
		{
			get { return GetColumnValue<bool>(Columns.IsActivated); }
			set { SetColumnValue(Columns.IsActivated, value); }
		}
		  
		[XmlAttribute("IsDeleted")]
		[Bindable(true)]
		public bool IsDeleted 
		{
			get { return GetColumnValue<bool>(Columns.IsDeleted); }
			set { SetColumnValue(Columns.IsDeleted, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedAt")]
		[Bindable(true)]
		public DateTime CreatedAt 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedAt); }
			set { SetColumnValue(Columns.CreatedAt, value); }
		}
		  
		[XmlAttribute("UpdatedBy")]
		[Bindable(true)]
		public string UpdatedBy 
		{
			get { return GetColumnValue<string>(Columns.UpdatedBy); }
			set { SetColumnValue(Columns.UpdatedBy, value); }
		}
		  
		[XmlAttribute("UpdatedAt")]
		[Bindable(true)]
		public DateTime UpdatedAt 
		{
			get { return GetColumnValue<DateTime>(Columns.UpdatedAt); }
			set { SetColumnValue(Columns.UpdatedAt, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public BookstoreManagementDAL.TblBookAuthorCollection TblBookAuthorRecords()
		{
			return new BookstoreManagementDAL.TblBookAuthorCollection().Where(TblBookAuthor.Columns.AuthorId, Id).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public BookstoreManagementDAL.TblBookCollection GetTblBookCollection() { return TblAuthor.GetTblBookCollection(this.Id); }
		public static BookstoreManagementDAL.TblBookCollection GetTblBookCollection(Guid varId)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[TblBook] INNER JOIN [TblBookAuthor] ON [TblBook].[Id] = [TblBookAuthor].[BookId] WHERE [TblBookAuthor].[AuthorId] = @AuthorId", TblAuthor.Schema.Provider.Name);
			cmd.AddParameter("@AuthorId", varId, DbType.Guid);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			TblBookCollection coll = new TblBookCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveTblBookMap(Guid varId, TblBookCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [TblBookAuthor] WHERE [TblBookAuthor].[AuthorId] = @AuthorId", TblAuthor.Schema.Provider.Name);
			cmdDel.AddParameter("@AuthorId", varId, DbType.Guid);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (TblBook item in items)
			{
				TblBookAuthor varTblBookAuthor = new TblBookAuthor();
				varTblBookAuthor.SetColumnValue("AuthorId", varId);
				varTblBookAuthor.SetColumnValue("BookId", item.GetPrimaryKeyValue());
				varTblBookAuthor.Save();
			}
		}
		public static void SaveTblBookMap(Guid varId, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [TblBookAuthor] WHERE [TblBookAuthor].[AuthorId] = @AuthorId", TblAuthor.Schema.Provider.Name);
			cmdDel.AddParameter("@AuthorId", varId, DbType.Guid);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					TblBookAuthor varTblBookAuthor = new TblBookAuthor();
					varTblBookAuthor.SetColumnValue("AuthorId", varId);
					varTblBookAuthor.SetColumnValue("BookId", l.Value);
					varTblBookAuthor.Save();
				}
			}
		}
		public static void SaveTblBookMap(Guid varId , Guid[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [TblBookAuthor] WHERE [TblBookAuthor].[AuthorId] = @AuthorId", TblAuthor.Schema.Provider.Name);
			cmdDel.AddParameter("@AuthorId", varId, DbType.Guid);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Guid item in itemList) 
			{
				TblBookAuthor varTblBookAuthor = new TblBookAuthor();
				varTblBookAuthor.SetColumnValue("AuthorId", varId);
				varTblBookAuthor.SetColumnValue("BookId", item);
				varTblBookAuthor.Save();
			}
		}
		
		public static void DeleteTblBookMap(Guid varId) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [TblBookAuthor] WHERE [TblBookAuthor].[AuthorId] = @AuthorId", TblAuthor.Schema.Provider.Name);
			cmdDel.AddParameter("@AuthorId", varId, DbType.Guid);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,string varName,string varBiography,bool varIsActivated,bool varIsDeleted,string varCreatedBy,DateTime varCreatedAt,string varUpdatedBy,DateTime varUpdatedAt)
		{
			TblAuthor item = new TblAuthor();
			
			item.Id = varId;
			
			item.Name = varName;
			
			item.Biography = varBiography;
			
			item.IsActivated = varIsActivated;
			
			item.IsDeleted = varIsDeleted;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedAt = varCreatedAt;
			
			item.UpdatedBy = varUpdatedBy;
			
			item.UpdatedAt = varUpdatedAt;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

        public static void Insert(TblAuthor item)
        {
            //TblAuthor item = new TblAuthor();

            //item.Id = varId;

            //item.Name = varName;

            //item.Biography = varBiography;


            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }


        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(Guid varId,string varName,string varBiography,bool varIsActivated,bool varIsDeleted,string varCreatedBy,DateTime varCreatedAt,string varUpdatedBy,DateTime varUpdatedAt)
		{
			TblAuthor item = new TblAuthor();
			
				item.Id = varId;
			
				item.Name = varName;
			
				item.Biography = varBiography;
			
				item.IsActivated = varIsActivated;
			
				item.IsDeleted = varIsDeleted;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedAt = varCreatedAt;
			
				item.UpdatedBy = varUpdatedBy;
			
				item.UpdatedAt = varUpdatedAt;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

        public static void Update(TblAuthor item)
        {
            //TblAuthor item = new TblAuthor();

            //	item.Id = varId;

            //	item.Name = varName;

            //	item.Biography = varBiography;

            item.IsNew = false;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        #endregion



        #region Typed Columns


        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BiographyColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActivatedColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDeletedColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Name = @"Name";
			 public static string Biography = @"Biography";
			 public static string IsActivated = @"IsActivated";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedAt = @"CreatedAt";
			 public static string UpdatedBy = @"UpdatedBy";
			 public static string UpdatedAt = @"UpdatedAt";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
