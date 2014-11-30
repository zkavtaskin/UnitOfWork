
--Create ECommerce database and then run below script

use ECommerce

CREATE TABLE Customer
(
	Id uniqueidentifier NOT NULL,
	FirstName nvarchar(256),
	LastName nvarchar(256)
)
GO
