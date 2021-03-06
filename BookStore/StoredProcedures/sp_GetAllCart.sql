USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCart]    Script Date: 11-06-2021 02:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[sp_GetAllCart]  (
	@UserId int
)
as  
begin  
   begin try
		if exists (select UserId from Cart where UserId=@UserId)
		begin
		select Book.BookId , Book.BookName ,Book.Author ,Book.Price ,Book.Image ,
		Cart.CartBookQuantity ,
		Cart.CartId  from Book inner join  Cart on Book.BookId=Cart.BookId
		where UserId=@UserId	
		end
	end try
	begin catch
			 SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
	end catch 
End