--1
create table Report (
	id INTEGER primary key identity(1,1),
	xml_column XML
);
go

--2
create procedure generateXML
as
declare @x XML
set @x = (select CURRENT_TIMESTAMP as current_date_time, clients.surname[client_surname], drivers.surname[driver_surname], vehicles.number[vehicle_number], products.name[product], orders.order_date  
				from orders join drivers on orders.driver_id = drivers.driver_id
							join clients on orders.client_id = clients.client_id
							join vehicles on vehicles.vehicle_id = drivers.vehicle_id
							join products on products.product_id = orders.product_id FOR XML AUTO);
SELECT @x
go

execute generateXML;
go

--3
create procedure InsertInReport
as
DECLARE @s XML  
SET @s = (select CURRENT_TIMESTAMP as current_date_time, clients.surname[client_surname], drivers.surname[driver_surname], vehicles.number[vehicle_number], products.name[product], orders.order_date  
				from orders join drivers on orders.driver_id = drivers.driver_id
							join clients on orders.client_id = clients.client_id
							join vehicles on vehicles.vehicle_id = drivers.vehicle_id
							join products on products.product_id = orders.product_id for xml raw);
insert into Report values(@s);
go
 
execute InsertInReport
select * from Report;
go

--4
create primary xml index xml_index_1 on Report(xml_column)
create xml index xml_index_2 on Report(xml_column)
using xml index xml_index_1 for path
go

--5
create procedure SelectData
as
select xml_column.query('/row') as[xml_column] from Report for xml auto, type;
go

execute SelectData