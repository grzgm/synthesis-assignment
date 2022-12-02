-- ENUMERATIONS

-- Category Table
CREATE TABLE Category
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	category nvarchar(20) NOT NULL UNIQUE,
);

-- SubCategory Table
CREATE TABLE SubCategory
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	subCategory nvarchar(20) NOT NULL UNIQUE,
);

-- OrderStatus Table
CREATE TABLE OrderStatus
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	orderStatus nvarchar(20) NOT NULL UNIQUE,
);

-- CLASSES

-- Item Table
CREATE TABLE Item
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[name] nvarchar(20) NOT NULL,
	category int NOT NULL FOREIGN KEY REFERENCES [Category]([id]),
	subCategory int NOT NULL FOREIGN KEY REFERENCES [SubCategory]([id]),
	-- price double
	price int NOT NULL,
	[unitType] nvarchar(20) NOT NULL,
	[unitAmount] int NOT NULL,
);

-- Client Table
CREATE TABLE Client
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[name] nvarchar(20) NOT NULL,
	email nvarchar(50) NOT NULL UNIQUE,
	[password] nvarchar(10) NOT NULL,
	bonusCardId int UNIQUE,
	amountOfPoints int,
	CONSTRAINT UniqueNameAndPassword_Client UNIQUE ([Name], [Password])
);

-- Order Table
CREATE TABLE [Order]
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	clientId int NOT NULL FOREIGN KEY REFERENCES [Client]([id]) ON DELETE CASCADE,
	totalBonusPointsBeforeOrder int NOT NULL,
	totalBonusPointsAfterOrder int NOT NULL,
	orderBonusPoints int NOT NULL,
	orderDate Date NOT NULL,
	deliveryDate Date NOT NULL,
	orderStatus int NOT NULL FOREIGN KEY REFERENCES [OrderStatus]([id]),
);

-- PreviousOrdersList Table
CREATE TABLE PreviousOrdersList
(
	clientId int NOT NULL FOREIGN KEY REFERENCES [Client]([id]) ON DELETE CASCADE,
	orderId int NOT NULL FOREIGN KEY REFERENCES [Order]([id]) ON DELETE CASCADE,
);

-- PurchasedItemsList Table
CREATE TABLE PurchasedItemsList
(
	orderId int NOT NULL FOREIGN KEY REFERENCES [Order]([id]) ON DELETE CASCADE,
	itemId int NOT NULL FOREIGN KEY REFERENCES [Item]([id]) ON DELETE CASCADE,
);

-- Employee Table
CREATE TABLE Employee
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[name] nvarchar(20) NOT NULL,
	email nvarchar(50) NOT NULL UNIQUE,
	[password] nvarchar(10) NOT NULL,
	CONSTRAINT UniqueNameAndPassword_Employee UNIQUE ([Name], [Password])
);



-- Mock Data
INSERT INTO Category VALUES ('fruit');
INSERT INTO Category VALUES ('meat');

INSERT INTO SubCategory VALUES ('fruit1');
INSERT INTO SubCategory VALUES ('fruit2');
INSERT INTO SubCategory VALUES ('meat1');

INSERT INTO OrderStatus VALUES ('Start');
INSERT INTO OrderStatus VALUES ('Middle');
INSERT INTO OrderStatus VALUES ('Finish');

INSERT INTO Item VALUES ('apple', 1, 1, 10, 'kg', 10);
INSERT INTO Item VALUES ('banana', 1, 1, 10, 'kg', 7);
INSERT INTO Item VALUES ('pear', 1, 2, 10, 'kg', 10);
INSERT INTO Item VALUES ('pork', 2, 3, 10, 'g', 1);

INSERT INTO Client VALUES ('jan', 'j@j', '12345', 1, 100);
INSERT INTO Client VALUES ('martin', 'm@m', '12345');

INSERT INTO [Order] VALUES (1, 1, 1, 10, '2022-12-01', '2022-12-04', 1);
INSERT INTO [Order] VALUES (1, 1, 1, 10, '2022-12-02', '2022-12-04', 1);
INSERT INTO [Order] VALUES (1, 1, 1, 10, '2022-12-03', '2022-12-05', 1);
INSERT INTO [Order] VALUES (2, 1, 1, 10, '2022-12-01', '2022-12-05', 1);
INSERT INTO [Order] VALUES (2, 1, 1, 10, '2022-12-03', '2022-12-05', 1);

INSERT INTO PreviousOrdersList VALUES (1, 1);
INSERT INTO PreviousOrdersList VALUES (1, 2);
INSERT INTO PreviousOrdersList VALUES (1, 3);
INSERT INTO PreviousOrdersList VALUES (2, 4);
INSERT INTO PreviousOrdersList VALUES (2, 5);

INSERT INTO PurchasedItemsList VALUES (1, 1);
INSERT INTO PurchasedItemsList VALUES (1, 3);
INSERT INTO PurchasedItemsList VALUES (2, 3);
INSERT INTO PurchasedItemsList VALUES (2, 2);
INSERT INTO PurchasedItemsList VALUES (3, 2);
INSERT INTO PurchasedItemsList VALUES (3, 4);
INSERT INTO PurchasedItemsList VALUES (4, 4);
INSERT INTO PurchasedItemsList VALUES (5, 1);