SET IDENTITY_INSERT managers ON

CREATE TABLE managers (
	hid HIERARCHYID NOT NULL,
	manager_id INT UNIQUE IDENTITY (1, 1),
	manager_level as hid.GetLevel() persisted,
	surname VARCHAR(50) NOT NULL,
	name VARCHAR(50) NOT NULL,
	patronymic VARCHAR(50),
	phone VARCHAR(25) NOT NULL,
	constraint pk_managers primary key clustered([hid] asc)
);

insert into managers(hid, manager_id, surname, name, patronymic, phone) values (hierarchyid::GetRoot(), 1, 'Абушенко', 'Анна', 'Юрьевна', '+375447894532');

declare @id hierarchyid
select @id = max(hid) from managers where hid.GetAncestor(1) = hierarchyid::GetRoot();
insert into managers(hid, manager_id, surname, name, patronymic, phone) values (hierarchyid::GetRoot().GetDescendant(@id, null), 2, 'Иванов', 'Иван', 'Алексеевич', '+375297804585');

select @id = max(hid) from managers where hid.GetAncestor(1) = hierarchyid::GetRoot();
insert into managers(hid, manager_id, surname, name, patronymic, phone) values (hierarchyid::GetRoot().GetDescendant(@id, null), 3, 'Петрова', 'Анастасия', 'Геннадьевна', '+375257852216');

select @id = max(hid) from managers where hid.GetAncestor(1) = hierarchyid::GetRoot();
insert into managers(hid, manager_id, surname, name, patronymic, phone) values (hierarchyid::GetRoot().GetDescendant(@id, null), 4, 'Медведев', 'Павел', 'Алексеевич', '+375442546987');

declare @phId hierarchyid
select  @phId = (select hid from managers where manager_id = 2);

select @id =max(hid) from managers where hid.GetAncestor(1) = @phId
insert into managers(hid, manager_id, surname, name, patronymic, phone) values (@phId.GetDescendant(@id, null), 7, 'Смирнова', 'Ирина', 'Алексеевна', '+375442354477');

select @phId = (Select hid from managers where manager_id = 4);
select @id =max(hid) from managers where hid.GetAncestor(1) = @phId
insert into managers(hid, manager_id, surname, name, patronymic, phone) values(@phId.GetDescendant(@id, null), 5, 'Кулак', 'Дмитрий', 'Сергеевич', '+375293541689');
select @id =max(hid) from managers where hid.GetAncestor(1) = @phId
insert into managers(hid, manager_id, surname, name, patronymic, phone) values(@phId.GetDescendant(@id, null), 6, 'Кутебо', 'Ирина', 'Викторовна', '+375254108756');

select @phId = (Select hid from managers where manager_id = 7);
select @id =max(hid) from managers where hid.GetAncestor(1) = @phId
insert into managers(hid, manager_id, surname, name, patronymic, phone) values(@phId.GetDescendant(@id, null), 8, 'Кривец', 'Павел', 'Анатольевич', '+375445238411');

-------------------------------------------------
select hid.ToString() as hidString, hid.GetLevel() as Level, manager_id, surname, name, patronymic, phone from managers;
go

--2

create procedure ChildNote
@Id int
as 
declare @CurrentManager hierarchyid
select  @CurrentManager = (select hid from managers where manager_id = @Id);
select hid.ToString() as hid, * from managers where
hid.GetAncestor(1) = @CurrentManager;
go

execute ChildNote 1
go
--3

CREATE PROCEDURE AddManager(@mgrid int, @manager_id int, @surname varchar(50), @name varchar(50), @patronymic varchar(50), @phone varchar(25))   
AS   
BEGIN  
   DECLARE @mOrgNode hierarchyid, @lc hierarchyid;
   SELECT @mOrgNode = hid FROM managers WHERE manager_id = @mgrid;
   SET TRANSACTION ISOLATION LEVEL SERIALIZABLE; 
   BEGIN TRANSACTION  
      SELECT @lc = max(hid) FROM managers WHERE hid.GetAncestor(1) = @mOrgNode;  
      INSERT managers(hid, manager_id, surname, name, patronymic, phone) VALUES(@mOrgNode.GetDescendant(@lc, NULL), @manager_id, @surname, @name, @patronymic, @phone);  
   COMMIT  
END;

execute AddManager 1, 9, 'Седлярова', 'Екатерина', 'Сергеевна', '+375256541585';
select hid.ToString() as hidString, hid.GetLevel() as Level, manager_id, surname, name, patronymic, phone from managers;
go
--4

CREATE PROCEDURE MoveUnderTree(@oldMgr nvarchar(50), @newMgr nvarchar(50))
as
BEGIN
	DECLARE @nold hierarchyid, @nnew hierarchyid  
	SELECT @nold = hid FROM managers WHERE surname = @oldMgr ;  
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  
	BEGIN TRANSACTION  
		SELECT @nnew = hid FROM managers WHERE surname = @newMgr ;   
		SELECT @nnew = @nnew.GetDescendant(max(hid), NULL) FROM managers WHERE hid.GetAncestor(1)=@nnew ;  
		UPDATE managers SET hid = hid.GetReparentedValue(@nold, @nnew) WHERE hid.IsDescendantOf(@nold) = 1;  
	COMMIT TRANSACTION  
END;  
GO 

execute MoveUnderTree 'Смирнова', 'Кутебо';
select hid.ToString() as hidString, hid.GetLevel() as Level, manager_id, surname, name, patronymic, phone from managers;