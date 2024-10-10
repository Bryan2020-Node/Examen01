create database Examen1
go
use Examen1
go


create table ApiResult
(
id int,
fecha date,
nombre nvarchar(100),
sales decimal(18,2),
expenses decimal(18,2),
utility decimal(18,2)
)
go


alter proc SP_CatpuraDatosAPI
@id int,
@fecha date,
@nombre nvarchar(100),
@sales decimal(18,2),
@expenses decimal(18,2),
@utiliy decimal(18,2)
as
if not exists (select id from ApiResult api where api.id = @id) 
begin
	insert into ApiResult values(@id, @fecha, @nombre, @sales, @expenses, @utiliy)
end
else
begin
	update ApiResult set fecha = @fecha, nombre = @nombre, sales = @sales, expenses = @expenses, utility = @utiliy where id = @id
end
go


create proc SP_ListaRegistros
@sucursales nvarchar(100)
as
select * from ApiResult
where id in (select value from string_split(@sucursales, ','))
go


exec SP_ListaRegistros '619, 643'