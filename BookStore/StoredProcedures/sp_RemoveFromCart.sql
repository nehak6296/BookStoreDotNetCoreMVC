
alter procedure [sp_RemoveFromCart](
	@CartId int	
)
as
begin	
	begin try
		if exists(select CartId from [Cart] where CartId=@CartId)
		delete from Cart where CartId=@CartId
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