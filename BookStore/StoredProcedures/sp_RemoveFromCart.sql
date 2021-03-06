USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_RemoveFromCart]    Script Date: 19-06-2021 06:41:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[sp_RemoveFromCart](
	@CartId int	
)
as
begin	
	begin try
		if exists(select CartId from [Cart] where CartId=@CartId)
		delete from [Cart] where CartId=@CartId
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
