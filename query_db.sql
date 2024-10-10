create database Examen1
go
use Examen1
go


create table ApiResult
(
id int,
nombre nvarchar(100),
sales int,
expenses decimal(18,2)
)
go


create proc SP_CatpuraDatosAPI
@id int,
@nombre nvarchar(100),
@sales int,
@expenses decimal(18,2)
as
if not exists (select id from ApiResult api where api.id = @id) 
begin
	insert into ApiResult values(@id, @nombre, @sales, @expenses)
end
else
begin
	update ApiResult set nombre = @nombre, sales = @sales, expenses = @expenses where id = @id
end
go


select * from ApiResult