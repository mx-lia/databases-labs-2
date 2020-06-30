--2

select * from orders where orders.order_date between '2020-04-01' and '2020-05-01';

select distinct products.name, SUM(orders.count) OVER(PARTITION BY products.name) AS Total FROM products 
inner join orders on products.product_id = orders.product_id  
where orders.order_date between '2020-04-01' and '2020-05-01';

SELECT distinct products.name, 
CAST(100. * SUM(orders.count) OVER(PARTITION BY products.name) / SUM(orders.count) OVER() AS DECIMAL(5,2)) AS "Percent"  
FROM products inner join orders on products.product_id = orders.product_id  
where orders.order_date between '2020-04-01' and '2020-05-01';

SELECT distinct products.name, 
CAST(100. * SUM(orders.count) OVER(PARTITION BY products.name) / MAX(orders.count) OVER() AS DECIMAL(5,2)) AS "Percent"  
FROM products inner join orders on products.product_id = orders.product_id  
where orders.order_date between '2020-04-01' and '2020-05-01';

--3

select * from orders;

DECLARE
  @pagenum  AS INT = 3,
  @pagesize AS INT = 20;
WITH Aggregates AS
(
  SELECT ROW_NUMBER() OVER(ORDER BY name, product_id) AS rownum, products.* FROM products
)
SELECT * FROM Aggregates
WHERE rownum BETWEEN (@pagenum - 1) * @pagesize + 1 AND @pagenum * @pagesize
ORDER BY rownum;

--4

WITH Aggregates AS
(
  SELECT products.*, ROW_NUMBER() OVER(PARTITION BY name ORDER BY (SELECT NULL)) AS n FROM products
)
DELETE FROM Aggregates WHERE n > 1;

--5

WITH Aggregates AS
(
  SELECT client_id, location_id, order_date, VARNAME_2, ROW_NUMBER() OVER(PARTITION BY client_id
      ORDER BY order_date DESC, client_id DESC) AS rownum
  FROM orders inner join BLR on orders.location_id = BLR.ID
)
SELECT * FROM Aggregates
WHERE rownum <= 6
ORDER BY client_id, rownum;

--6
WITH Aggregates AS
(
	SELECT model, VARNAME_2, COUNT(VARNAME_2) AS cnt, RANK() OVER(partition by model, VARNAME_2 ORDER BY Count(VARNAME_2) DESC) AS rnk
			FROM orders inner join drivers ON orders.driver_id = drivers.driver_id
				inner join vehicles ON drivers.vehicle_id = vehicles.vehicle_id
					inner join BLR ON orders.location_id = BLR.ID GROUP BY model, VARNAME_2
)
SELECT TOP 1 WITH ties model, VARNAME_2, cnt
	FROM Aggregates
		ORDER BY ROW_NUMBER() OVER (PARTITION BY model ORDER BY cnt DESC);