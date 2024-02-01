USE [CATALOGO_WEB_DB]
GO


create procedure [dbo].[storedAltaArticulo]
@codigo varchar(30),
@nombre varchar(50),
@descripcion varchar(70),
@marca int,
@categoria int,
@imagen varchar(100),
@precio decimal
as
INSERT into ARTICULOS VALUES (@codigo, @nombre, @descripcion, @marca, @categoria, @imagen, @precio)
GO


create procedure [dbo].[storedEliminarArticulo]
@id int
as
delete from ARTICULOS where id=@id
GO


CREATE procedure [dbo].[storedFiltrarPorId]
@id int
as
select ARTICULOS.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion Marca, CATEGORIAS.Descripcion Categoria, ARTICULOS.IdMarca IdMarca,ARTICULOS.IdCategoria IdCategoria ,ImagenUrl,Precio 
from ARTICULOS 
inner join MARCAS on IdMarca = MARCAS.Id  
inner join CATEGORIAS on IdCategoria = CATEGORIAS.id
where Articulos.id=@id
GO


create procedure [dbo].[storedFiltroUsuario]
@email varchar(30)
as
select email, pass from USERS where email=@email
GO


create procedure [dbo].[storedListar]
as
select ARTICULOS.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion Marca, CATEGORIAS.Descripcion Categoria, ARTICULOS.IdMarca IdMarca,ARTICULOS.IdCategoria IdCategoria ,ImagenUrl,Precio 
from ARTICULOS 
inner join MARCAS on IdMarca = MARCAS.Id  
inner join CATEGORIAS on IdCategoria = CATEGORIAS.id
GO

create procedure [dbo].[storedListarCategorias]
as
select Id, Descripcion from CATEGORIAS
GO


create procedure [dbo].[storedListarMarcas]
as
select Id, Descripcion from MARCAS
GO


create procedure [dbo].[storedLogin]
@email varchar(30),
@pass varchar(30)
as
select Id, nombre, apellido, urlImagenPerfil, admin from USERS where email=@email AND pass=@pass
GO



CREATE procedure [dbo].[storedModificar]
@id int,
@codigo varchar(30),
@nombre varchar(50),
@descripcion varchar(70),
@marca int,
@categoria int,
@imagen varchar(100),
@precio decimal
as
Update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, IdMarca=@marca, IdCategoria=@categoria, ImagenUrl=@imagen, Precio=@precio where Id=@id
GO


CREATE procedure [dbo].[storedRegistro]
@email varchar(30),
@pass varchar(30),
@img varchar(50)
as
insert into USERS (email,pass,urlImagenPerfil,admin) values (@email,@pass,@img,0)
GO



