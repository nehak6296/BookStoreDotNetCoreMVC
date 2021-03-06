USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddToWishList]    Script Date: 05-06-2021 03:37:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_AddToWishList](

@UserId int,
@BookId int,
@Quantity int
)
as
begin
begin try
		
			insert into [WishList] values(@UserId,@BookId,@Quantity);	
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

