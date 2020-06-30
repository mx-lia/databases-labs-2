PRAGMA foreign_keys=ON;
BEGIN TRANSACTION;
CREATE TABLE clients (
client_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
surname TEXT NOT NULL,
name TEXT NOT NULL,
phone TEXT NOT NULL
);
CREATE TABLE products (
product_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
name TEXT NOT NULL,
description TEXT,
weight INTEGER NOT NULL
);
CREATE TABLE orders (
order_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
client_id INTEGER NOT NULL,
product_id INTEGER NOT NULL,
order_date TEXT NOT NULL,
FOREIGN KEY (client_id) 
        REFERENCES clients (client_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY (product_id) 
        REFERENCES products (product_id) 
        ON DELETE CASCADE ON UPDATE CASCADE
);
DELETE FROM sqlite_sequence;
CREATE VIEW today_orders AS SELECT * FROM orders WHERE order_date = date('now');
CREATE TRIGGER orders_insert AFTER INSERT
ON orders
BEGIN
UPDATE products SET description = 'Product is ordered'
WHERE product_id = NEW.product_id;
END;
COMMIT;
