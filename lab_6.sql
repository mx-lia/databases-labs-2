CREATE USER university IDENTIFIED BY Pa$$w0rd;
GRANT all privileges to university;
GRANT UNLIMITED TABLESPACE TO university;

select * from "UNIVERSITY"."faculty";