CREATE TABLE [dbo].[Messages](
	[message_db_key] [int] IDENTITY(1,1) NOT NULL,
	[message] [varchar](max) NULL,
	[sender_id] [int] NULL,
	[receiver_id] [int] NULL,
	[TimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[message_db_key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Messages]  WITH CHECK ADD FOREIGN KEY([receiver_id])
REFERENCES [dbo].[UsersProfileDetails] ([user_id])
GO

ALTER TABLE [dbo].[Messages]  WITH CHECK ADD FOREIGN KEY([sender_id])
REFERENCES [dbo].[UsersProfileDetails] ([user_id])
GO


------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[UsersProfileDetails](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](256) NOT NULL,
	[LastName] [varchar](256) NOT NULL,
	[email] [varchar](max) NULL,
	[mobile] [bigint] NOT NULL,
	[Gender] [char](64) NOT NULL,
	[Address] [varchar](max) NULL,
	[dob] [datetime] NULL,
	[country] [varchar](64) NULL,
	[city] [varchar](64) NULL,
	[password] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
---------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[GetUserID] 
(
	@MobileNum varchar(256)
)
AS  
BEGIN  
   SELECT user_id  from [dbo].[UsersProfileDetails] where mobile= @MobileNum 
   END
-----------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[InsertMessage] 
(
	@sender_id int, 
	@receiver_id int,
	@message varchar(max)
	

)
AS  
BEGIN  
   insert into Messages values(@message,@sender_id,@receiver_id,GETDATE())
END
GO
---------------------------------------------------------------------------------------
USE [chatting]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[InsertMessage]
		@sender_id = 1,
		@receiver_id = 2,
		@message = N'hello'

SELECT	'Return Value' = @return_value

GO
----------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[MyMessages] 
(
	@sender_id int, 
	@receiver_id int
	

)
AS  
BEGIN  
   SELECT message from Messages where sender_id=@sender_id and receiver_id=@receiver_id
END
------------------------------------------------------------------------------------------
CREATE procedure [dbo].[RegisterUsers]
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
insert into UsersProfileDetails select  
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

end
---------------------------------------------------------------------
USE [chatting]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[RegisterUsers]
		@firstName = N'soumik',
		@lastName = N'paul',
		@email = N'sou@gnk.com',
		@mobile = N' 8978805050',
		@Gender = N'M',
		@address = N'vnvefov',
		@dob = N'2017-04-05 17:26:08.023',
		@country = N'India',
		@city = N'Hyderabad',
		@password = N'soumik@9007'

SELECT	'Return Value' = @return_value

GO

