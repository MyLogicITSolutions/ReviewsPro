USE [Testing]
GO
/****** Object:  StoredProcedure [dbo].[RegisterUsers]    Script Date: 03-03-2017 12:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[RegisterUsers]
(
	@firstName varchar(256),
	@lastName varchar(256),
	@email varchar(max),
	@mobile varchar(64),
	@Gender char(64),
	@address varchar(max),
	@dob datetime,
	@country varchar(64),
	@city varchar(64),
	@password varchar(max)
)
as
begin
	insert into users select  
	@firstName ,
	@lastName ,
	@email ,
	@mobile,
	@Gender ,
	@address,
	@dob ,
	@country ,
	@city ,
	@password 
	declare @ret int;
	set @ret = @@identity;
	select @ret;
end