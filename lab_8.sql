create tablespace first_blob
datafile 'D:\Study\Databases-1\first_blob.dbf'
size 50m autoextend on next 1m;

create user C##lob_user identified by Pa$$word;
grant all privileges to C##lob_user;

alter user C##lob_user container=all;
select * from v$tablespace;

alter user C##lob_user default tablespace first_blob quota unlimited on first_blob;
account unlock container=current

--create directory Bfile_dir as 'D:/Study/Databases-1/Bfile';
--create directory BigF as 'D:/Study/Databases-1/BigF';
create directory BLOBS as 'D:/Study/Databases-1/BLOBS';
grant read, write on directory BLOBS to C##lob_user;

create table BigFiles(
  id number(5) primary key,
  FOTO BLOB,
  DOC_or_PDF BFILE
);

insert into BigFiles values(2, null, BFILENAME('BLOBS', 'test.doc'));

select * from BigFiles;

declare 
  v_blob BLOB;
  v_file BFILE;
  v_file_size binary_integer;
begin 
  v_file := BFILENAME('BLOBS', 'banner1.png');
  insert into BigFiles(id, FOTO, DOC_or_PDF) values (3, EMPTY_BLOB(), null) RETURNING FOTO INTO v_blob;
  DBMS_LOB.FILEOPEN(v_file, DBMS_LOB.FILE_READONLY);
  v_file_size := DBMS_LOB.GETLENGTH(v_file);
  DBMS_LOB.LOADFROMFILE(v_blob, v_file, v_file_size);
  DBMS_LOB.FILECLOSE(v_file);
  commit;
end;