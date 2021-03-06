USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCustomerDetails]    Script Date: 22-06-2021 12:14:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_UpdateCustomerDetails](	
	@Name varchar(50),
	@PhoneNumber int ,
	@Address varchar(255),
	@Locality varchar(50),
	@Landmark varchar(50),
	@Pincode int,
	@City varchar(50),
	@Type varchar(50)
)
as
begin	
	begin try
		if exists(select Name,PhoneNumber from [Customer] where Name=@Name and PhoneNumber=@PhoneNumber)
		Update [Customer] 
		set 
			Address=@Address,
			Locality=@Locality,
			Landmark=@Landmark,
			Pincode=@Pincode,
			City=@City,
			Type=@Type 
		where Name=@Name and PhoneNumber=@PhoneNumber
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