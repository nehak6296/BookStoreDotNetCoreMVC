USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddImage]    Script Date: 23-06-2021 09:27:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_AddImage](
	@BookId int,	
	@Image varchar(500)
)
as
begin
	begin try
	if exists (select * from Book where BookId=@BookId)
		update Book
		set Image=@Image		
		where BookId=@BookId
	end try
	begin catch
		SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
	end catch
end
