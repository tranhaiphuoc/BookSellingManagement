--CREATE DATABASE BookstoreSellingManagement
--GO
--USE BookstoreSellingManagement
--GO


------< User-Related Tables >------
CREATE TABLE TblUser(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	FirstName NVARCHAR(50) NOT NULL DEFAULT(''),
	LastName NVARCHAR(100) NOT NULL DEFAULT(''),
	Birthday DATE NOT NULL DEFAULT(GETDATE()),
	Gender BIT NOT NULL DEFAULT(0),
	[Address] NVARCHAR(256) NOT NULL DEFAULT(''),
	Phone VARCHAR(20) NOT NULL DEFAULT(''),
	Email VARCHAR(256) NOT NULL DEFAULT(''),
	Avatar NVARCHAR(256) NOT NULL DEFAULT(''),

	[Username] VARCHAR(256) NOT NULL DEFAULT(''),
	[Password] VARCHAR(256) NOT NULL DEFAULT(''),

	IsActivated	BIT	NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),

	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
);

CREATE TABLE TblRole(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	[Name] NVARCHAR(256) NOT NULL DEFAULT(''),
);

CREATE TABLE TblUserRole(
	UserId UNIQUEIDENTIFIER NOT NULL,
	RoleId UNIQUEIDENTIFIER NOT NULL,

	PRIMARY KEY (UserId, RoleId),
	FOREIGN KEY (UserId) REFERENCES TblUser(Id),
	FOREIGN KEY (RoleId) REFERENCES TblRole(Id),
);


------< Book-Related Tables >------
CREATE TABLE TblCategory(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	[Name] VARCHAR(50) NOT NULL DEFAULT(''),
	[Description] NVARCHAR(256) NOT NULL DEFAULT(''),

	IsActivated	BIT	NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),

	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
);

CREATE TABLE TblPublisher(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	[Name] NVARCHAR(50) NOT NULL DEFAULT(''),
	[Address] NVARCHAR(256) NOT NULL DEFAULT(''),

	IsActivated	BIT	NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),

	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
);

CREATE TABLE TblAuthor(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	[Name] NVARCHAR(50) NOT NULL DEFAULT(''),
	Biography NVARCHAR(256) NOT NULL DEFAULT(''),

	IsActivated	BIT	NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),

	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
);

CREATE TABLE TblBook(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	ISBN VARCHAR(15) NOT NULL DEFAULT(''),
	Title NVARCHAR(256) NOT NULL DEFAULT(''),

	PriceInput DECIMAL(18, 2) NOT NULL DEFAULT(0),
	PriceOutput DECIMAL(18, 2) NOT NULL DEFAULT(0),

	[Description] NVARCHAR(256) NOT NULL DEFAULT(''),
	[Image] NVARCHAR(256) NOT NULL DEFAULT(''),
	Quantity INT NOT NULL DEFAULT(0),

	IsActivated	BIT	NOT NULL DEFAULT(1),
	IsDeleted BIT NOT NULL DEFAULT(0),

	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),

	PublisherId UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (PublisherId) REFERENCES TblPublisher(Id),
);

CREATE TABLE TblBookAuthor(
	BookId UNIQUEIDENTIFIER NOT NULL,
	AuthorId UNIQUEIDENTIFIER NOT NULL,

	PRIMARY KEY (BookId, AuthorId),
	FOREIGN KEY (BookId) REFERENCES TblBook(Id),
	FOREIGN KEY (AuthorId) REFERENCES TblAuthor(Id),
);

CREATE TABLE TblBookCategory(
	BookId UNIQUEIDENTIFIER NOT NULL,
	CategoryId UNIQUEIDENTIFIER NOT NULL,

	PRIMARY KEY (BookId, CategoryId),
	FOREIGN KEY (BookId) REFERENCES TblBook(Id),
	FOREIGN KEY (CategoryId) REFERENCES TblCategory(Id),
);

--CREATE TABLE TblBookPricing(
--	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
--	FromHour TIME NOT NULL DEFAULT('00:00:00'),
--	ToHour TIME NOT NULL DEFAULT('00:00:00'),

--	OriginalPrice DECIMAL(18, 2) NOT NULL DEFAULT(0),
--	SalePrice DECIMAL(18, 2) NOT NULL DEFAULT(0),

--	IsActivated	BIT	NOT NULL DEFAULT(1),
--	IsDeleted BIT NOT NULL DEFAULT(0),

--	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
--	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
--	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
--	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
--);
GO

------< Order-Related Tables >------
CREATE TABLE TblOrder(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	DueDate DATETIME NOT NULL DEFAULT(GETDATE()),
	[Status] NVARCHAR(20) NOT NULL DEFAULT(''),

	Subtotal DECIMAL(18, 2) NOT NULL DEFAULT(0),
	TotalDiscount DECIMAL(18, 2) NOT NULL DEFAULT(0),
	Total DECIMAL(18, 2) NOT NULL DEFAULT(0),

	IsDeleted BIT NOT NULL DEFAULT(0),

	CreatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
	UpdatedBy VARCHAR(256) NOT NULL DEFAULT(''),
	UpdatedAt DATETIME NOT NULL DEFAULT(GETDATE()),

	UserId UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (UserId) REFERENCES TblUser(Id),
);

CREATE TABLE TblOrderDetail(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()),
	UnitPrice DECIMAL(18, 2) NOT NULL DEFAULT(0),
	Discount DECIMAL(18, 2) NOT NULL DEFAULT(0),
	Quantity INT NOT NULL DEFAULT(0),
	Total DECIMAL NOT NULL,

	OrderId UNIQUEIDENTIFIER NOT NULL,
	BookId UNIQUEIDENTIFIER NOT NULL,

	FOREIGN KEY (OrderId) REFERENCES TblOrder(Id),
	FOREIGN KEY (BookId) REFERENCES TblBook(Id),
);


INSERT INTO TblCategory([Name], [Description])
VALUES
	('Art & Photography', 'This genre includes books on artists of all kinds, as well as on each type of art and its history.')
	,('Science Fiction', 'This genre explores futuristic or technological themes and ideas to address scientific “what if” questions.')
	,('Cooking', 'In this genre, you’ll find books on every kind of cooking someone in the world took the time to write about, as well as cooking for different diets and nutritional needs')
	,('Law & Criminology', 'Books on the legal system, on laws, criminal justice, and related topics belong in this genre')
	,('Education & Teaching', 'Any book that proposes to teach the reader how to do something or how to do it better belongs to this genre')

INSERT INTO TblPublisher([Id], [Name], [Address])
VALUES
	('90b5604e-c8c8-4b20-8395-0dbf98cfef97', N'Nhà xuất bản Trẻ', N'161B Lý Chính Thắng, phường Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh')
	,('e4442e27-3d3c-4749-9828-38c52b3a55b1', N'Nhà xuất bản Kim Đồng', N'55 Quang Trung, Hà Nội')
	,('e818ed20-6e72-4199-baf4-8a0bc55214ff', N'Nhà xuất bản Tổng hợp thành phố Hồ Chí Minh', N'62 Nguyễn Thị Minh Khai, Phường Đa Kao, Quận 1, TP. HCM')
	,('dcdaead8-bdad-4a3b-a193-af812c9d31f7', N'Nhà xuất bản Hội Nhà văn', N'65 Nguyễn Du, Quận Hai Bà Trưng, Hà Nội')
	,('648938ae-31d5-4b4a-a8b6-d4e72645969b', N'Nhà xuất bản Phụ nữ Việt Nam', N'39 Hàng Chuối, Quận Hai Bà Trưng, Hà Nội')
	,('c77aa98c-b912-4ff7-9157-ed59c0cbaa69', N'Nhà xuất bản Lao Động', N'175 Giảng Võ, Đống Đa, Hà Nội')
	,('8242ac02-98aa-4812-8387-f9b294bf7918', N'Nhà xuất bản Chính trị quốc gia Sự thật', N'6/86 Duy tân, Cầu Giấy, Hà Nội')

INSERT INTO TblAuthor([Name], [Biography])
VALUES
	('Author 1', 'TEXT TEXT TEXT TEXT TEXT TEXT')
	,('Author 2', 'TEXT TEXT TEXT TEXT TEXT TEXT')
	,('Author 3', 'TEXT TEXT TEXT TEXT TEXT TEXT')
	,('Author 4', 'TEXT TEXT TEXT TEXT TEXT TEXT')
	,('Author 5', 'TEXT TEXT TEXT TEXT TEXT TEXT')

INSERT INTO TblBook([ISBN], [Title], [PriceInput], [PriceOutput], [Description], [Image], [Quantity], [PublisherId])
VALUES
	('9780440412670', 'Where the Red Fern Grows', 1000, 2000, 'Where the Red Fern Grows, is an exciting tale of love and adventure you''ll never forget.', '441267-where_the_Red_Fern_Grows.jpg', 0, 'e818ed20-6e72-4199-baf4-8a0bc55214ff')
	,('9780765374653', 'A Dog''s Way Home', 1000, 2000, 'A classic story of unwavering loyalty and incredible devotion, A Dog''s Way Home is a beautifully told, charming tale that explores the unbreakable bond between us and our pets.', '31702812-a-dog-s-way-home.jpg', 0, '8242ac02-98aa-4812-8387-f9b294bf7918')
	,('9781444737097', 'A Street Cat Named Bob: How One Man and His Cat Found Hope on the Streets', 1000, 2000, 'A Street Cat Named Bob is a moving and uplifting story that will touch the heart of anyone who reads it.', '12394068-a-street-cat-named-bob.jpg', 0, '90b5604e-c8c8-4b20-8395-0dbf98cfef97')
	,('9781626720947', 'This One Summer', 1000, 2000, 'In This One Summer two stellar creators redefine the teen graphic novel—a story of renewal and revelation.', '18465566-this-one-summer.jpg', 0, 'e4442e27-3d3c-4749-9828-38c52b3a55b1')
	,('9781338656152', 'Do You Know Me', 1000, 2000, 'Told through a mix of prose and diary entries, this authentic and relatable novel is about finding your people, and learning what it takes to be a true friend.', '52664801-do-you-know-me.jpg', 0, 'e818ed20-6e72-4199-baf4-8a0bc55214ff')
	,('9781510105157', 'The Star Outside My Window', 1000, 2000, 'Told through the innocent voice of a child, this is a story that celebrates the power of hope and resilience, from the author of The Boy at the Back of the Class.', '43866010-the-star-outside-my-window.jpg', 0, 'dcdaead8-bdad-4a3b-a193-af812c9d31f7')
	,('9781419707858', 'In the Footsteps of Crazy Horse', 1000, 2000, 'Through his grandfather’s tales about the famous warrior, Jimmy learns more about his Lakota heritage and, ultimately, himself.', '24795887-in-the-footsteps-of-crazy-horse.jpg', 0, '648938ae-31d5-4b4a-a8b6-d4e72645969b')
	,('9780062643865', 'Granted', 1000, 2000, 'A novel about a fairy-in-training and her first wish-granting assignment.', '35181559-granted.jpg', 0, 'c77aa98c-b912-4ff7-9157-ed59c0cbaa69')
	,('9780385744669', 'The Girl at Midnight', 1000, 2000, 'Beneath the streets of New York City live the Avicen, an ancient race of people with feathers for hair and magic running through their veins.', '26891475-the-girl-at-midnight.jpg', 0, '8242ac02-98aa-4812-8387-f9b294bf7918')

INSERT INTO TblRole([Name])
VALUES
	('Admin')
	,('Manager')
	,('User')

---- Guid is auto-generateed, change if needed
--INSERT INTO TblBookAuthor([BookId], [AuthorId])
--VALUES
--	('8e7127f8-c78c-4046-92c1-0b2bce80943f', '1182957f-6a1f-4a14-898a-1409b068b15e')
--	,('478eab96-0f42-4d75-9dc6-38e286c324c7', '4e5bf5a1-a8e3-4bea-84de-50a8ee4b19e4')
--	,('48d12986-dab4-4a7d-9051-7a507402962a', 'f4ad3d0f-cf25-4e72-9a63-b1b27df05167')
--	,('25737723-32e5-4d92-8215-8110c8cb29a7', '398866e8-2bab-4585-855f-f3504d45b2a5')
--	,('2fb3fd7b-51b4-44f9-ae2e-8911784c1791', '1672e4d7-7974-404c-87e1-ff7c26f2eba4')


--DROP TABLE TblUserRole
--DROP TABLE TblBookAuthor;
--DROP TABLE TblBookCategory;
--DROP TABLE TblOrderDetail;

--DROP TABLE TblOrder;
--DROP TABLE TblBook;
--DROP TABLE TblPublisher;
--DROP TABLE TblCategory;
--DROP TABLE TblRole;
--DROP TABLE TblUser;
--DROP TABLE TblAuthor;