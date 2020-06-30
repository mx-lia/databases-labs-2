CREATE TABLE clients (
	client_id INT PRIMARY KEY IDENTITY (1, 1),
	surname VARCHAR(50) NOT NULL,
	name VARCHAR(50) NOT NULL,
	patronymic VARCHAR(50),
	phone VARCHAR(25) NOT NULL,
	address VARCHAR(50) NOT NULL,
	passport VARCHAR(50),
	payment_account VARCHAR(30) NOT NULL
);

CREATE TABLE vehicles (
	vehicle_id INT PRIMARY KEY IDENTITY (1, 1),
	model VARCHAR(50) NOT NULL,
	number VARCHAR(50) NOT NULL
);

CREATE TABLE drivers (
	driver_id INT PRIMARY KEY IDENTITY (1, 1),
	vehicle_id INT NOT NULL,
	surname VARCHAR(50) NOT NULL,
	name VARCHAR(50) NOT NULL,
	patronymic VARCHAR(50),
	FOREIGN KEY (vehicle_id) 
        REFERENCES vehicles (vehicle_id) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE managers (
	manager_id INT PRIMARY KEY IDENTITY (1, 1),
	surname VARCHAR(50) NOT NULL,
	name VARCHAR(50) NOT NULL,
	patronymic VARCHAR(50),
	phone VARCHAR(25) NOT NULL
);

CREATE TABLE products (
	product_id INT PRIMARY KEY IDENTITY (1, 1),
	name VARCHAR(50) NOT NULL,
	description VARCHAR(100),
	weight INT NOT NULL
);

CREATE TABLE orders (
	order_id INT PRIMARY KEY IDENTITY (1, 1),
	client_id INT NOT NULL,
	product_id INT NOT NULL,
	driver_id INT NOT NULL,
	manager_id INT UNIQUE NOT NULL,
	order_date DATE NOT NULL,
	delivery_date DATE NOT NULL,
	mark_of_delivery VARCHAR(10) NOT NULL,
	FOREIGN KEY (client_id) 
        REFERENCES clients (client_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (product_id) 
        REFERENCES products (product_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (driver_id) 
        REFERENCES drivers (driver_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (manager_id) 
        REFERENCES managers (manager_id) 
        ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE INDEX orders_client_id ON orders (client_id);
CREATE INDEX orders_order_date ON orders (order_date);

CREATE VIEW all_clients AS SELECT * FROM clients;
CREATE VIEW all_drivers AS SELECT * FROM drivers;
CREATE VIEW all_managers AS SELECT * FROM managers;
CREATE VIEW all_orders AS SELECT * FROM orders;
CREATE VIEW all_products AS SELECT * FROM products;
CREATE VIEW all_vehicles AS SELECT * FROM vehicles;

CREATE TRIGGER orders_insert
ON orders
AFTER INSERT
AS
UPDATE products SET description = (SELECT 'Product is ordered ' + CONVERT(VARCHAR(10), order_date, 102) FROM inserted) 
		WHERE product_id = (SELECT product_id FROM inserted)

CREATE PROCEDURE OrdersByClient (@client_surname VARCHAR(50)) AS 
BEGIN 
	SELECT order_id, orders.client_id, product_id, driver_id, manager_id, order_date, delivery_date, mark_of_delivery 
				FROM orders JOIN clients ON orders.client_id = clients.client_id WHERE clients.surname = @client_surname
END;

CREATE FUNCTION GetOrdersCountByMonth (@month_number INT)
    RETURNS INT
    BEGIN
		DECLARE @orders_count INT;
        SELECT @orders_count = COUNT(*) FROM orders where MONTH(order_date) = @month_number;
		RETURN @orders_count;
    END;

SELECT * FROM all_clients;
SELECT * FROM all_drivers;
SELECT * FROM all_managers;
SELECT * FROM all_orders;
SELECT * FROM all_products;
SELECT * FROM all_vehicles;

SELECT dbo.GetOrdersCountByMonth(2);
EXEC dbo.OrdersByClient 'Иванов';