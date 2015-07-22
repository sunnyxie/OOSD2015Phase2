# OOSD2015Phase2
**DB Initialization Commands:**  
ALTER TABLE Customers ADD CustUsername nvarchar(25)  
ALTER TABLE Customers ADD CustPassword nvarchar(25)  
UPDATE Customers SET CustUsername='m', CustPassword='m' WHERE CustomerId=135  
UPDATE Bookings SET PackageId=(ABS(CHECKSUM(NewId())) % 4) + 1  
# ---------
There is some Deleting changed between table Packages and suppliers, Products(Linking Relations). so do not use SQL-S delete command directly.
