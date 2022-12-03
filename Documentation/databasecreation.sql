-- ENUMERATIONS

-- Category Table
CREATE TABLE Category
(
	id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[name] nvarchar(20) NOT NULL UNIQUE,
	parentCategory int,
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
	subCategory int NOT NULL FOREIGN KEY REFERENCES [Category]([id]),
	price decimal(19,4) NOT NULL,
	[unitType] nvarchar(20) NOT NULL,
	available bit NOT NULL,
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
INSERT INTO Category VALUES ('fruit', NULL);
INSERT INTO Category VALUES ('meat', NULL);
INSERT INTO Category VALUES ('fruit1', 1);
INSERT INTO Category VALUES ('fruit2', 1);
INSERT INTO Category VALUES ('meat1', 2);

INSERT INTO OrderStatus VALUES ('Start');
INSERT INTO OrderStatus VALUES ('Middle');
INSERT INTO OrderStatus VALUES ('Finish');

INSERT INTO Item VALUES ('apple', 1, 1, 10, 'kg', 1);
INSERT INTO Item VALUES ('banana', 1, 1, 10, 'kg', 0);
INSERT INTO Item VALUES ('pear', 1, 2, 10, 'kg', 1);
INSERT INTO Item VALUES ('pork', 2, 3, 10, 'g', 1);

INSERT INTO Client VALUES ('jan', 'j@j', '12345', 1, 100);
INSERT INTO Client VALUES ('martin', 'm@m', '12345', NULL, NULL);

INSERT INTO [Order] VALUES (1, 1, 1, 10, '2022-12-01', '2022-12-04', 1);
INSERT INTO [Order] VALUES (1, 1, 1, 10, '2022-12-02', '2022-12-04', 1);
INSERT INTO [Order] VALUES (1, 1, 1, 10, '2022-12-03', '2022-12-05', 1);
INSERT INTO [Order] VALUES (2, 1, 1, 10, '2022-12-01', '2022-12-05', 1);
INSERT INTO [Order] VALUES (2, 1, 1, 10, '2022-12-03', '2022-12-05', 1);

INSERT INTO PurchasedItemsList VALUES (1, 1);
INSERT INTO PurchasedItemsList VALUES (1, 3);
INSERT INTO PurchasedItemsList VALUES (2, 3);
INSERT INTO PurchasedItemsList VALUES (2, 2);
INSERT INTO PurchasedItemsList VALUES (3, 2);
INSERT INTO PurchasedItemsList VALUES (3, 4);
INSERT INTO PurchasedItemsList VALUES (4, 4);
INSERT INTO PurchasedItemsList VALUES (5, 1);