--2
ALTER TABLE orders ADD location_id INT FOREIGN KEY REFERENCES BLR(ID);

--3
--SELECT * FROM BLR WHERE ID in (SELECT ID FROM BLR INTERSECT SELECT location_id FROM orders);
--go

select geom.STSrid from BLR;
select * from sys.spatial_reference_systems;

DECLARE @shape geometry
set @shape = geometry::STGeomFromText('geometrycollection empty', 4326);
select @shape = @shape.STUnion(geom) FROM BLR WHERE ID in (SELECT ID FROM BLR INTERSECT SELECT location_id FROM orders);
select @shape;
go
--4

CREATE PROCEDURE GetDistance  
    @FirstOrder int,   
    @SecondOrder int   
AS   
	DECLARE @geom1 geometry;  
	DECLARE @geom2 geometry;  
	DECLARE @result float; 
	SELECT @geom1 = geom FROM BLR inner join orders on BLR.ID=orders.order_id WHERE orders.order_id = @FirstOrder;  
	SELECT @geom2 = geom FROM BLR inner join orders on BLR.ID=orders.order_id WHERE orders.order_id = @SecondOrder;  
	SELECT @result = @geom1.STDistance (@geom2);  
	SELECT @result;
GO  

exec GetDistance 1,2;

--5

go
DECLARE @old_geom geometry;
SELECT @old_geom = (SELECT geom FROM BLR WHERE ID = (select location_id from orders where order_id = 2));
UPDATE BLR SET geom = @old_geom.STUnion(geometry::STGeomFromText('POINT(31 55)', 4326)) WHERE ID = (select location_id from orders where order_id = 2);

SELECT geom.STNumPoints() FROM BLR where ID=(select location_id from orders where order_id = 2);

go

CREATE PROCEDURE AddPoint  
    @values varchar(255),
	@orderId int
AS   
DECLARE @old_geom geometry;
SELECT @old_geom = (SELECT geom FROM BLR WHERE ID = (select location_id from orders where order_id = @orderId));
UPDATE BLR SET geom = @old_geom.STUnion(geometry::STGeomFromText('POINT(' + @values + ')', 4326)) WHERE ID = (select location_id from orders where order_id = @orderId);
SELECT geom.STNumPoints() FROM BLR where ID=(select location_id from orders where order_id = @orderId);
GO 

--7
CREATE SPATIAL INDEX SIndx_BRL_geom_col ON BLR(geom);  