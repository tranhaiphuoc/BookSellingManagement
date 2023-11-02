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
	/// Strongly-typed collection for the TblOrder class.
	/// </summary>
    [Serializable]
	public partial class TblOrderCollection : ActiveList<TblOrder, TblOrderCollection>
	{	   
		public TblOrderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblOrderCollection</returns>
		public TblOrderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblOrder o = this[i];
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
	/// This is an ActiveRecord class which wraps the TblOrder table.
	/// </summary>
	[Serializable]
	public partial class TblOrder : ActiveRecord<TblOrder>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblOrder()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblOrder(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblOrder(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblOrder(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TblOrder", TableType.Table, DataService.GetInstance("DefaultConnection"));
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
				
				TableSchema.TableColumn colvarDueDate = new TableSchema.TableColumn(schema);
				colvarDueDate.ColumnName = "DueDate";
				colvarDueDate.DataType = DbType.DateTime;
				colvarDueDate.MaxLength = 0;
				colvarDueDate.AutoIncrement = false;
				colvarDueDate.IsNullable = false;
				colvarDueDate.IsPrimaryKey = false;
				colvarDueDate.IsForeignKey = false;
				colvarDueDate.IsReadOnly = false;
				
						colvarDueDate.DefaultSetting = @"(getdate())";
				colvarDueDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDueDate);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.String;
				colvarStatus.MaxLength = 20;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"('')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				TableSchema.TableColumn colvarSubtotal = new TableSchema.TableColumn(schema);
				colvarSubtotal.ColumnName = "Subtotal";
				colvarSubtotal.DataType = DbType.Decimal;
				colvarSubtotal.MaxLength = 0;
				colvarSubtotal.AutoIncrement = false;
				colvarSubtotal.IsNullable = false;
				colvarSubtotal.IsPrimaryKey = false;
				colvarSubtotal.IsForeignKey = false;
				colvarSubtotal.IsReadOnly = false;
				
						colvarSubtotal.DefaultSetting = @"((0))";
				colvarSubtotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubtotal);
				
				TableSchema.TableColumn colvarTotalDiscount = new TableSchema.TableColumn(schema);
				colvarTotalDiscount.ColumnName = "TotalDiscount";
				colvarTotalDiscount.DataType = DbType.Decimal;
				colvarTotalDiscount.MaxLength = 0;
				colvarTotalDiscount.AutoIncrement = false;
				colvarTotalDiscount.IsNullable = false;
				colvarTotalDiscount.IsPrimaryKey = false;
				colvarTotalDiscount.IsForeignKey = false;
				colvarTotalDiscount.IsReadOnly = false;
				
						colvarTotalDiscount.DefaultSetting = @"((0))";
				colvarTotalDiscount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalDiscount);
				
				TableSchema.TableColumn colvarTotal = new TableSchema.TableColumn(schema);
				colvarTotal.ColumnName = "Total";
				colvarTotal.DataType = DbType.Decimal;
				colvarTotal.MaxLength = 0;
				colvarTotal.AutoIncrement = false;
				colvarTotal.IsNullable = false;
				colvarTotal.IsPrimaryKey = false;
				colvarTotal.IsForeignKey = false;
				colvarTotal.IsReadOnly = false;
				
						colvarTotal.DefaultSetting = @"((0))";
				colvarTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotal);
				
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
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = true;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				
					colvarUserId.ForeignKeyTableName = "TblUser";
				schema.Columns.Add(colvarUserId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DefaultConnection"].AddSchema("TblOrder",schema);
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
		  
		[XmlAttribute("DueDate")]
		[Bindable(true)]
		public DateTime DueDate 
		{
			get { return GetColumnValue<DateTime>(Columns.DueDate); }
			set { SetColumnValue(Columns.DueDate, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("Subtotal")]
		[Bindable(true)]
		public decimal Subtotal 
		{
			get { return GetColumnValue<decimal>(Columns.Subtotal); }
			set { SetColumnValue(Columns.Subtotal, value); }
		}
		  
		[XmlAttribute("TotalDiscount")]
		[Bindable(true)]
		public decimal TotalDiscount 
		{
			get { return GetColumnValue<decimal>(Columns.TotalDiscount); }
			set { SetColumnValue(Columns.TotalDiscount, value); }
		}
		  
		[XmlAttribute("Total")]
		[Bindable(true)]
		public decimal Total 
		{
			get { return GetColumnValue<decimal>(Columns.Total); }
			set { SetColumnValue(Columns.Total, value); }
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
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid UserId 
		{
			get { return GetColumnValue<Guid>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public BookstoreManagementDAL.TblOrderDetailCollection TblOrderDetailRecords()
		{
			return new BookstoreManagementDAL.TblOrderDetailCollection().Where(TblOrderDetail.Columns.OrderId, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a TblUser ActiveRecord object related to this TblOrder
		/// 
		/// </summary>
		public BookstoreManagementDAL.TblUser TblUser
		{
			get { return BookstoreManagementDAL.TblUser.FetchByID(this.UserId); }
			set { SetColumnValue("UserId", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(TblOrder item)
		{		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(TblOrder item)
		{			
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
        
        
        
        public static TableSchema.TableColumn DueDateColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SubtotalColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalDiscountColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDeletedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string DueDate = @"DueDate";
			 public static string Status = @"Status";
			 public static string Subtotal = @"Subtotal";
			 public static string TotalDiscount = @"TotalDiscount";
			 public static string Total = @"Total";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedAt = @"CreatedAt";
			 public static string UpdatedBy = @"UpdatedBy";
			 public static string UpdatedAt = @"UpdatedAt";
			 public static string UserId = @"UserId";
						
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