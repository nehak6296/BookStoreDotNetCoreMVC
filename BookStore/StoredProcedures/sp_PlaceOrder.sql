USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_PlaceOrder]    Script Date: 11-06-2021 05:38:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_PlaceOrder](
	@UserId int,
	@CartId int	 
)as
begin
	begin try
		if exists(select UserId from [User] where UserId=@UserId)
		begin
			if exists (select CartId from [Cart] where CartId=@CartId)
			begin 
				if not exists (select * from Orders where UserId=@UserId and CartId=@CartId)
				begin
				insert into [Orders] values (@UserId,@CartId)	
				end
				select OrderId from [Orders] where UserId=@UserId and CartId=@CartId			
			end
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
end