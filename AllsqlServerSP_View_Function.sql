USE [NGANHANG]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_LayLoginName]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_LayLoginName](@username VARCHAR(50))
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @Loginname VARCHAR(50);

	IF EXISTS (SELECT name FROM sys.database_principals WHERE name = @username)
		BEGIN
			SELECT @LoginName = sp.name
			FROM    (select name, sid, type_desc from sys.server_principals WHERE  type_desc = 'SQL_LOGIN') AS sp JOIN
					(select name, sid from sys.database_principals where name = @username) AS dp ON sp.sid = dp.sid 
		END
    ELSE
		BEGIN
			SET @Loginname = NULL;
		END

    --IF EXISTS (SELECT name FROM sys.sql_logins WHERE name = @username)
    --    SELECT @Loginname = name
    --    FROM sys.sql_logins 
    --    WHERE name = @username;

    RETURN @Loginname;
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TaoMaNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_TaoMaNV]()
RETURNS nchar(10)
AS
BEGIN
    DECLARE @temp nchar(10);
    DECLARE @newID bigint;
    DECLARE @newMANV nchar(10);

    SELECT @temp = MAX(MANV) FROM dbo.NHANVIEN;

    SET @newID = CAST((SUBSTRING(@temp, 3, 8)) AS bigint) + 2;
    SET @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 8);

    RETURN @newMANV;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TaoSTK]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_TaoSTK]()
RETURNS nchar(9)
AS
BEGIN
    DECLARE @temp nchar(9);
    DECLARE @newID bigint;
    DECLARE @newSTK nchar(9);

    SELECT @temp = MAX(SOTK) FROM dbo.TAIKHOAN as TK where TK.MACN = (select top 1 MACN from dbo.CHINHANH)
    SET @newID = CAST((SUBSTRING(@temp, 3, 7)) AS bigint) + 1;
	
	if (select top 1 MACN from dbo.CHINHANH) = 'BENTHANH'
		SET @newSTK = '01' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 7);
    else if (select top 1 MACN from dbo.CHINHANH) = 'TANDINH'
		SET @newSTK = '02' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 7);

    RETURN @newSTK;
END;

GO
/****** Object:  View [dbo].[v_DanhSachKhachHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_DanhSachKhachHang]
AS
SELECT TOP (100) PERCENT CMND, HO, TEN, PHAI, DIACHI, NGAYCAP, SoDT, MACN
FROM     dbo.KHACHHANG WITH (INDEX = IX_KHACHHANG_TEN)
GO
/****** Object:  View [dbo].[v_DanhSachKhachHang_NganHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_DanhSachKhachHang_NganHang]
AS
SELECT TOP (100) PERCENT CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
FROM     (SELECT CMND, HO, TEN, PHAI, DIACHI, NGAYCAP, SoDT, MACN
                  FROM      dbo.v_DanhSachKhachHang
                  UNION ALL
                  SELECT CMND, HO, TEN, PHAI, DIACHI, NGAYCAP, SoDT, MACN
                  FROM     LINK1.NGANHANG.dbo.v_DanhSachKhachHang AS v_DanhSachKhachHang_1) AS KH
GO
/****** Object:  View [dbo].[v_AllLoginName]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_AllLoginName]
as
	SELECT 
        sp.name AS LoginName, 
        dp.name AS UserName
    FROM 
        sys.server_principals sp
    LEFT JOIN 
        sys.database_principals dp
    ON 
        sp.sid = dp.sid
    WHERE 
        sp.type_desc = 'SQL_LOGIN' -- Filter only SQL logins
GO
/****** Object:  View [dbo].[v_DanhSachNhanVien]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_DanhSachNhanVien]
as
	select MANV, CMND, HO, TEN, PHAI, DIACHI, SoDT, TrangThaiXoa
	from dbo.NHANVIEN --with (index = IX_NHANVIEN_TEN)
GO
/****** Object:  View [dbo].[V_DS_PHANMANH]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_DS_PHANMANH]
AS
SELECT PUBS.description AS TENCN, SUBS.subscriber_server AS TENSERVER
FROM     LINK0.NGANHANG.dbo.sysmergepublications AS PUBS INNER JOIN
                  LINK0.NGANHANG.dbo.sysmergesubscriptions AS SUBS ON PUBS.pubid = SUBS.pubid AND PUBS.publisher <> SUBS.subscriber_server
WHERE  (PUBS.description <> N'Site tra cứu thông tin khách hàng')
GO
/****** Object:  View [dbo].[V_EX_LoginName]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_EX_LoginName]
AS
SELECT NV.MANV, NV.CMND, trim(NV.HO) + ' ' + trim(NV.TEN) AS HOTEN, NV.SoDT
FROM     dbo.NHANVIEN AS NV LEFT OUTER JOIN
                      (SELECT uid, name
                       FROM      sys.sysusers) AS S ON NV.MANV = S.name
WHERE  (NV.TrangThaiXoa = 0) AND (S.uid IS NULL)
GO
/****** Object:  View [dbo].[V_EX_LoginNameKH]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_EX_LoginNameKH]
AS
SELECT TOP (100) PERCENT KH.CMND
FROM     dbo.KHACHHANG AS KH LEFT OUTER JOIN
                      (SELECT uid, name
                       FROM      sys.sysusers) AS S ON KH.CMND = S.name
WHERE  (S.uid IS NULL)
ORDER BY KH.CMND
GO
/****** Object:  View [dbo].[V_LoginName]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_LoginName]
AS
SELECT name AS LoginName
FROM     sys.server_principals
WHERE  (type_desc = 'SQL_LOGIN')
GO
/****** Object:  View [dbo].[v_taiKhoanKhachHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_taiKhoanKhachHang]
AS
SELECT TOP (100) PERCENT TK.SOTK, TK.CMND, KH.HOTEN, TK.SODU, TK.MACN
FROM     (SELECT SOTK, CMND, MACN, SODU
                  FROM      dbo.TAIKHOAN) AS TK INNER JOIN
                      (SELECT CMND, trim(HO) + ' ' + trim(TEN) AS HOTEN
                       FROM      LINK2.NGANHANG.dbo.KHACHHANG AS KHACHHANG_1) AS KH ON TK.CMND = KH.CMND
ORDER BY TK.SOTK
GO
/****** Object:  View [dbo].[V_Username]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[V_Username]
AS
    SELECT name as Username
    FROM sys.database_principals
    WHERE type_desc = 'SQL_USER'
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangePassword]
    @LoginName NVARCHAR(256),
    @NewPassword NVARCHAR(256)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = N'ALTER LOGIN [' + @LoginName + N'] WITH PASSWORD = N''' + @NewPassword + N'''';

    EXEC sp_executesql @SQL;
END
GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLogin]
    @LoginName NVARCHAR(256),
    @Password NVARCHAR(256)
AS
BEGIN
    DECLARE @cmd NVARCHAR(4000)
    DECLARE @result INT

    SET @cmd = 'sqlcmd -S ' + @@SERVERNAME + ' -U ' + @LoginName + ' -P ' + @Password + ' -Q "SELECT 1"'
    
    EXEC @result = xp_cmdshell @cmd

    IF @result = 0
    BEGIN
        return 1
    END
    ELSE
    BEGIN
        return 0
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ChuyenChiNhanh]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ChuyenChiNhanh]
@MANV nchar(10)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN DISTRIBUTED TRANSACTION;
BEGIN TRY
	if not exists (select MANV from dbo.NHANVIEN where MANV = @MANV)
	BEGIN
		rollback
		return 1 -- Không tồn tại MANV
	END
	else if (select TrangThaiXoa from dbo.NHANVIEN where MANV = @MANV) = 1
	BEGIN
		rollback
		return 2 -- Nhân viên không còn làm ở chi nhánh nữa
	END
	declare @CMND nchar(10)
	select @CMND = CMND from dbo.NHANVIEN where MANV = @MANV

	if exists (select CMND from LINK1.NGANHANG.dbo.NHANVIEN where CMND = @CMND)
	BEGIN
		update LINK1.NGANHANG.dbo.NHANVIEN
		set TrangThaiXoa = 0
		where CMND = @CMND
	END
	else
	BEGIN
		DECLARE @temp nchar(10);
		DECLARE @newID bigint;
		DECLARE @newMANV nchar(10);

		SELECT @temp = MAX(MANV) FROM LINK1.NGANHANG.dbo.NHANVIEN;

		SET @newID = CAST((SUBSTRING(@temp, 3, 8)) AS bigint) + 2;
		SET @newMANV = 'NV' + RIGHT('0000000000' + CAST(@newID AS NVARCHAR(10)), 8)

		insert into LINK1.NGANHANG.dbo.NHANVIEN (MANV, CMND, HO, TEN, PHAI,SoDT, DIACHI, MACN, TrangThaiXoa)
		select	@newMANV as MANV, 
				CMND,
				HO, 
				TEN, 
				PHAI, 
				SoDT, 
				DIACHI, 
				(select top 1 MACN from LINK1.NGANHANG.dbo.CHINHANH) as MACN, 
				0 
		from dbo.NHANVIEN 
		where MANV = @MANV
	END

	update dbo.NHANVIEN
	set TrangThaiXoa = 1
	where MANV = @MANV

	COMMIT TRANSACTION;
	return 0 -- Thành công
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
		RAISERROR (@ErrorMessage,16,1)
	END
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_ChuyenTien]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_ChuyenTien] (@STKGUI nChar(9), @STKNHAN nChar(9), @TIEN MONEY, @NGAYGD datetime, @MANV NCHAR(10))
AS
SET XACT_ABORT ON
BEGIN
	--KIEM TRA STK_GUI VA STK_NHAN CO TON TAI TRONG DB HAY KHONG, SAU DO THI KIEM TRA SO DU NGUOI GUI.
	IF ( EXISTS( SELECT SOTK FROM dbo.TAIKHOAN WHERE SOTK=@STKNHAN ) AND EXISTS( SELECT SOTK FROM dbo.TAIKHOAN WHERE SOTK=@STKGUI) )
		BEGIN
			DECLARE @SODU_CHUYEN MONEY
			SELECT @SODU_CHUYEN = SODU FROM dbo.TAIKHOAN WHERE @STKGUI = SOTK
  
			IF @SODU_CHUYEN < @TIEN
				RAISERROR('SO DU KHONG DU !!!', 16, 1)
			ELSE
				BEGIN
					BEGIN TRANSACTION
					BEGIN TRY
						UPDATE dbo.TAIKHOAN
						SET SODU -= @TIEN
						WHERE @STKGUI = SOTK

						UPDATE dbo.TAIKHOAN
						SET SODU += @TIEN
						WHERE @STKNHAN = SOTK

						INSERT INTO GD_CHUYENTIEN(SOTK_CHUYEN,NGAYGD,SOTIEN,SOTK_NHAN,MANV) 
							VALUES (@STKGUI,@NGAYGD,@TIEN,@STKNHAN,@MANV)

						COMMIT
					END TRY
					
					BEGIN CATCH		-- một số trường hợp bất ngờ có thể xảy ra gây ra lỗi
						ROLLBACK	-- ví dụ như mất điện khi đang cộng trừ tiền trong tài khoản.
						DECLARE @ERRORMESSAGE VARCHAR(2000)
						SELECT @ERRORMESSAGE = 'Lỗi: ' + ERROR_MESSAGE()
						RAISERROR(@ERRORMESSAGE, 16, 1)
					END CATCH
				END
		END
	ELSE
		RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachKhachHang_ChiNhanh]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DanhSachKhachHang_ChiNhanh]
as
begin
	select CMND, HO, TEN, PHAI, DIACHI, NGAYCAP, SoDT, MACN
	from dbo.v_DanhSachKhachHang
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachKhachHang_NganHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DanhSachKhachHang_NganHang]
as
begin
	select CMND, NGAYCAP, HO, TEN, DIACHI, PHAI, SoDT, MACN
	from (	select * from dbo.v_DanhSachKhachHang
			union all
			select * from LINK1.NGANHANG.dbo.v_DanhSachKhachHang) as KH
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachTaiKhoan_KhachHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DanhSachTaiKhoan_KhachHang]
@CMND nchar(10)
as
begin
	select SOTK, NGAYMOTK, SODU, MACN
	from dbo.TAIKHOAN
	where CMND = @CMND
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachTaiKhoan_NganHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DanhSachTaiKhoan_NganHang] @dateFrom AS DATE, @dateTo AS DATE, @Loai char(1), @MACN NCHAR(10)
AS
BEGIN
      IF (@Loai = 'T')--TẤT CẢ CHI NHÁNH
      BEGIN
            SELECT TK.SOTK,KH.HO +' ' + KH.TEN AS HOTEN,TK.CMND,TK.MACN,TK.NGAYMOTK
            FROM (select HO, TEN, CMND from LINK2.NGANHANG.dbo.KhachHang) as KH,
                  (     SELECT SOTK,CMND,MACN,NGAYMOTK 
                        FROM TaiKhoan with (index = IX_TAIKHOAN_NGAYMOTK)
                        WHERE NGAYMOTK BETWEEN @dateFrom AND @dateTo) AS TK 
            WHERE KH.CMND = TK.CMND 
             ORDER BY TK.MACN, TK.SOTK
      END
      ELSE IF (@Loai = 'C')--CHI NHÁNH HIỆN TẠI
      BEGIN
            SELECT TK.SOTK,KH.HO +' ' + KH.TEN AS HOTEN,TK.CMND,TK.MACN,TK.NGAYMOTK
            FROM (select HO, TEN, CMND from LINK2.NGANHANG.dbo.KhachHang) AS KH,
                  (     SELECT SOTK,CMND,MACN,NGAYMOTK 
                        FROM TaiKhoan with (index = IX_TAIKHOAN_NGAYMOTK)
                        WHERE NGAYMOTK BETWEEN @dateFrom AND @dateTo AND MACN = @MACN) AS TK 
            WHERE KH.CMND = TK.CMND
             ORDER BY TK.MACN, TK.SOTK
      END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Existed_CMND_KH]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Existed_CMND_KH]
@CMND nchar(10)
as
BEGIN
	IF exists (select CMND from LINK2.NGANHANG.dbo.KHACHHANG where CMND = @CMND)
		return 1;
	else
		return 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Existed_CMND_NV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Existed_CMND_NV]
@CMND nchar(10)
as
BEGIN
	IF exists (select CMND from LINK0.NGANHANG.dbo.NHANVIEN where CMND = @CMND)
		return 1;
	ELSE
		return 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Existed_Loginname]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE proc [dbo].[sp_Existed_Loginname]
@Username nchar(10)
as 
begin
	IF EXISTS (SELECT sp.name
			FROM    (select name, sid, type_desc from sys.server_principals WHERE  type_desc = 'SQL_LOGIN') AS sp JOIN
					(select name, sid from sys.database_principals where name = @Username) AS dp ON sp.sid = dp.sid)
		return 1
	else 
		return 0
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Existed_STK]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Existed_STK]
@SOTK nchar(9)
as
BEGIN
	IF exists (select SOTK from dbo.TAIKHOAN where SOTK = @SOTK)
		return 1;
	ELSE
		return 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Existed_Username]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE proc [dbo].[sp_Existed_Username]
@Username nchar(10)
as 
begin
	IF EXISTS (SELECT name FROM sys.sql_logins WHERE name = @username)
	return 1
	else 
	return 0
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GuiRut]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GuiRut] (@SOTK	NCHAR(9), @TIEN MONEY, @LOAIGD NCHAR(2), @NGAYGD datetime, @MANV NCHAR(10))
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION		-- Nếu chỉ SP chỉ có một lệnh UPDATE thì ta không cần sử dụng giao tác vì nó là giao tác tự động.
	BEGIN TRY			-- Nhưng SP này ta có 2 lệnh là UPDATE và INSERT.
		IF EXISTS(SELECT SOTK FROM dbo.TaiKhoan WHERE SOTK = @SOTK)	-- Kiểm tra stk có tồn tại hay không, sau đó xét xem nó là 'RT' hay 'GT'
			BEGIN
				DECLARE @SODUDAU MONEY;
			  SELECT @SODUDAU = SODU FROM dbo.TaiKhoan WHERE SOTK = @SOTK;

				IF @LOAIGD = 'GT'
					BEGIN
						UPDATE dbo.TaiKhoan
						SET SODU = @SODUDAU + @TIEN
						WHERE SOTK = @SOTK

						INSERT INTO GD_GOIRUT(SOTK,LOAIGD,NGAYGD,SOTIEN,MANV) 
							VALUES(@SOTK,@LOAIGD,@NGAYGD,@TIEN,@MANV)
					END

	
				ELSE IF @LOAIGD = 'RT'
					BEGIN
						IF @SODUDAU < @TIEN
							RAISERROR('SO DU KHONG DU !!!', 16, 1)
						ELSE
							BEGIN
								UPDATE dbo.TaiKhoan
								SET SODU = @SODUDAU - @TIEN
								WHERE SOTK = @SOTK

								INSERT INTO GD_GOIRUT(SOTK,LOAIGD,NGAYGD,SOTIEN,MANV) 
									VALUES(@SOTK,@LOAIGD,@NGAYGD,@TIEN,@MANV)
							END
					END
			END
		ELSE
			RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
		COMMIT TRANSACTION;
	END TRY
	
	BEGIN CATCH
		IF (@@TRANCOUNT > 0)
		BEGIN
			ROLLBACK TRANSACTION;
			DECLARE @ErrorMessage NVARCHAR(2000)
			SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
			RAISERROR (@ErrorMessage,16,1)
		END
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_HuyXoaNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_HuyXoaNV]
@MANV nchar(10)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
BEGIN TRY
    IF NOT EXISTS (SELECT MANV FROM dbo.NHANVIEN WHERE MANV = @MANV)
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN 1; -- Không tồn tại mã nhân viên 
        END
    ELSE IF (SELECT TrangThaiXoa FROM dbo.NHANVIEN WHERE MANV = @MANV) = 0
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN 2; -- Nhân viên đã bị chưa bị xóa
        END
    ELSE IF (SELECT TrangThaiXoa FROM LINK1.NGANHANG.dbo.NHANVIEN WHERE CMND = (SELECT CMND FROM dbo.NHANVIEN WHERE MANV = @MANV)) = 0
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN 3; -- Nhân viên đang làm việc ở chi nhánh khác, yêu cầu chuyển chi nhánh.
        END
    ELSE
        BEGIN
            UPDATE NHANVIEN
            SET TrangThaiXoa = 0
            WHERE MANV = @MANV;
        END

    COMMIT TRANSACTION;
    RETURN 0; -- Hủy xóa thành công
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
		RAISERROR (@ErrorMessage,16,1)
	END
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_jobs_DanhSachKhachHang_NganHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_jobs_DanhSachKhachHang_NganHang]
AS
BEGIN
	-- Create global scope temp table to store data
    CREATE TABLE ##Data (
        CMND NCHAR(10),
        HO NVARCHAR(50),
        TEN NVARCHAR(10),
        PHAI NVARCHAR(3),
        DIACHI NVARCHAR(100),
        NGAYCAP DATE,
        SODT NVARCHAR(15),
        MACN NCHAR(10)
    )

	-- Create and run job on local site to insert data to temp table
    DECLARE @JCommand NVARCHAR(1000)
    SET @JCommand = 'INSERT INTO ##Data EXEC sp_DanhSachKhachHang_ChiNhanh'

    IF EXISTS (SELECT job_id from msdb.dbo.sysjobs_view WHERE name = 'job1')
		BEGIN
			EXEC msdb.dbo.sp_delete_job @job_name = 'job1'
		END

    EXEC msdb.dbo.sp_add_job @job_name = 'job1', @start_step_id = 1
    EXEC msdb.dbo.sp_add_jobserver @job_name = 'job1', @server_name = @@SERVERNAME
    EXEC msdb.dbo.sp_add_jobstep @job_name = 'job1', @step_id = 1, @step_name = 'localData', 
		@command = @JCommand, @server = @@SERVERNAME, @database_name = 'NGANHANG'

    EXEC msdb.dbo.sp_start_job @job_name = 'job1'

	INSERT INTO ##Data EXEC LINK1.NGANHANG.DBO.sp_DanhSachKhachHang_ChiNhanh

	DECLARE @LimitTime INT = 20
    DECLARE @CheckedTime INT = 0
	DECLARE @JobStatus INT

	WHILE @CheckedTime < @LimitTime
    BEGIN
        SELECT @JobStatus = run_status FROM msdb.dbo.sysjobhistory
		WHERE job_id = (SELECT job_id FROM msdb.dbo.sysjobs WHERE name = 'job1')

        -- Retrieve data from the temp table after the job has executed (status = 1)
        IF @JobStatus = 1
        BEGIN
			EXEC msdb.dbo.sp_delete_job @job_name = 'job1'
			SELECT * FROM ##Data ORDER BY MACN, TEN, HO
			DROP TABLE ##Data
            RETURN
        END

		WAITFOR DELAY '00:00:01'
        SET @CheckedTime = @CheckedTime + 1
    END

	EXEC msdb.dbo.sp_delete_job @job_name = 'job1'
	RAISERROR (N'Không thể tổng hợp dữ liệu', 16, 1)
	DROP TABLE ##Data
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_jobs_dskh]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_jobs_dskh]
as
begin
	select * from dbo.v_DanhSachKhachHang
	union all
	select * from link1.nganhang.dbo.v_danhsachkhachhang
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinKhachHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayThongTinKhachHang]
@SOTK nchar(9)
as
begin
	declare @CMND nchar(10)
	select @CMND = CMND from dbo.TAIKHOAN where SOTK = @SOTK

	select CMND, trim(HO) + ' ' + trim(TEN) as HOTEN
	from LINK2.NGANHANG.dbo.KHACHHANG
	where CMND = @CMND
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinLogin]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayThongTinLogin]
@TENLOGIN NVARCHAR (50)
AS
DECLARE @USERNAME NVARCHAR(50), @UID INT
SELECT @UID = UID, @USERNAME = NAME 
FROM sys.sysusers 
WHERE sid = SUSER_SID(@TENLOGIN)
 
IF exists (select MANV from dbo.NHANVIEN where MANV = @USERNAME)
	BEGIN
		SELECT USERNAME = @USERNAME, 
			HOTEN = (SELECT trim(HO) + ' ' + trim(TEN) FROM NHANVIEN WHERE MANV = @USERNAME),
			TENNHOM = NAME
		FROM sys.sysusers 
		WHERE UID = (SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID= @UID)
	END
ELSE
	SELECT USERNAME = @USERNAME, 
		HOTEN = (SELECT trim(HO) + ' ' + trim(TEN) FROM dbo.KHACHHANG WHERE CMND = @USERNAME),
		TENNHOM = NAME
		FROM sys.sysusers
		WHERE UID = (SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID= @UID)
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinNhanVien]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayThongTinNhanVien] 
@MANV nchar(10)
as
begin
	select MANV, trim(HO) + ' ' + trim(TEN) as HOTEN, SODT 
	from dbo.NHANVIEN 
	where @MANV = MANV
end
GO
/****** Object:  StoredProcedure [dbo].[SP_SaoKeTaiKhoanNganHang]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SaoKeTaiKhoanNganHang] @SOTK_SAOKE NCHAR(9), @dateFrom AS DATE, @dateTo AS DATE
AS
BEGIN
    CREATE TABLE #GD_Temp(SODUDAU money,NGAYGD DATETIME,LOAIGD nchar(10),SOTIEN money,SODUSAU money)

    DECLARE @CrsrVar CURSOR, @SOTK nchar(9), @SOTIEN money, @SODUDAU money, 
    @SODUSAU money, @SOTK_NHAN nchar(9), @SOTK_CHUYEN nchar(9),@SODUSAU_TK_NHAN money, @LOAIGD nchar(10),@NGAYGD DATETIME
    
	SET @CrsrVar=CURSOR KEYSET FOR 

    SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	from dbo.GD_GOIRUT AS GR
    WHERE GR.SOTK = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @dateTo

    UNION ALL

	SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM LINK1.NGANHANG.dbo.GD_GOIRUT AS GR
    WHERE GR.SOTK = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @dateTo   

    UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM dbo.GD_CHUYENTIEN AS CT
    WHERE CT.SOTK_CHUYEN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @dateTo

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM GD_CHUYENTIEN AS CT_Nhan
    WHERE SOTK_NHAN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @dateTo  

	UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM LINK1.NGANHANG.dbo.GD_CHUYENTIEN AS CT
    WHERE CT.SOTK_CHUYEN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @dateTo

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM LINK1.NGANHANG.dbo.GD_CHUYENTIEN AS CT_Nhan
    WHERE SOTK_NHAN = @SOTK_SAOKE
    AND NGAYGD between @dateFrom and @dateTo
    ORDER BY NGAYGD DESC
	
	EXEC @SODUSAU = dbo.sp_SoDuSau @SOTK_SAOKE, @dateTo

    OPEN @CrsrVar
    FETCH NEXT FROM @CrsrVar INTO @SOTIEN,@LOAIGD,@NGAYGD
    WHILE(@@FETCH_STATUS = 0)
    BEGIN       
        IF @LOAIGD = N'GT' or @LOAIGD = N'NT'
            BEGIN       
                SET @SODUDAU = @SODUSAU - @SOTIEN
                INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
            END
        ELSE IF @LOAIGD = N'RT' or @LOAIGD = N'CT'
            BEGIN
                SET @SODUDAU = @SODUSAU + @SOTIEN
                INSERT INTO #GD_Temp Values(@SODUDAU,@NGAYGD,@LOAIGD,@SOTIEN,@SODUSAU) 
            END
        SET @SODUSAU = @SODUDAU
        FETCH NEXT FROM @CrsrVar INTO @SOTIEN,@LOAIGD,@NGAYGD
    END
    SELECT * FROM #GD_Temp
    ORDER BY NGAYGD 
    CLOSE @CrsrVar 
    DEALLOCATE @CrsrVar
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SoDuSau]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SoDuSau] 
@STK nchar(9),
@dateTo datetime
as
begin
	declare @SODU money 
	declare @SODUSAU money
	select @SODU = SODU from dbo.TAIKHOAN where SOTK = @STK

	--if not exists
	--(
	--	select 1 from GD_CHUYENTIEN where NGAYGD > @dateTo and ( SOTK_CHUYEN = @STK or SOTK_NHAN = @STK )
	--	union all
	--	select 1 from LINK1.NGANHANG.dbo.GD_CHUYENTIEN where NGAYGD > @dateTo and ( SOTK_CHUYEN = @STK or SOTK_NHAN = @STK)
	--	union all
	--	select 1 from GD_GOIRUT where NGAYGD > @dateTo and ( SOTK = @STK)
	--	union all
	--	select 1 from LINK1.NGANHANG.dbo.GD_GOIRUT where NGAYGD > @dateTo and ( SOTK = @STK)
	--) return @SODU

	select @SODUSAU = @SODU + ISNULL( SUM(case when LOAIGD = 'GT' or LOAIGD = 'NT' 
									then -SOTIEN else SOTIEN end), 0)
	from (
		SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM dbo.GD_GOIRUT  AS GR
    WHERE GR.SOTK = @STK
    AND NGAYGD > @dateTo     

    UNION ALL

	SELECT GR.SOTIEN,GR.LOAIGD,GR.NGAYGD 
	FROM  LINK1.NGANHANG.dbo.GD_GOIRUT AS GR
    WHERE GR.SOTK = @STK
    AND NGAYGD > @dateTo     

    UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM dbo.GD_CHUYENTIEN AS CT
    WHERE CT.SOTK_CHUYEN = @STK
    AND NGAYGD > @dateTo  

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM GD_CHUYENTIEN  AS CT_Nhan
    WHERE SOTK_NHAN = @STK
    AND NGAYGD > @dateTo    

	UNION ALL

    SELECT CT.SOTIEN, 'CT' ,CT.NGAYGD 
	FROM LINK1.NGANHANG.dbo.GD_CHUYENTIEN  AS CT
    WHERE CT.SOTK_CHUYEN = @STK
    AND NGAYGD > @dateTo  

    UNION ALL 

    SELECT CT_Nhan.SOTIEN, 'NT' ,CT_Nhan.NGAYGD 
	FROM LINK1.NGANHANG.dbo.GD_CHUYENTIEN AS CT_Nhan
    WHERE SOTK_NHAN = @STK
    AND NGAYGD > @dateTo
	) as GD

	return @SODUSAU
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaThongTinKH]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuaThongTinKH]
    @HO nvarchar(50),
    @TEN nvarchar(10),
    @DIACHI nvarchar(100),
    @newCMND nchar(10),
	@oldCMND nchar(10),
    @NGAYCAP date,
    @SoDT nvarchar(15),
    @PHAI nvarchar(3)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN DISTRIBUTED TRANSACTION
BEGIN TRY

    -- Kiểm tra sự tồn tại của khách hàng
    declare @existedCMND int
	if (@newCMND != @oldCMND)
		begin
		exec @existedCMND = sp_Existed_CMND_KH @newCMND
			if(@existedCMND = 0)
				BEGIN
					ROLLBACK TRANSACTION; -- Rollback nếu khách hàng không tồn tại
					RETURN 1;
				END
			else
				BEGIN
		
					-- Cập nhật thông tin khách hàng
					UPDATE LINK2.NGANHANG.dbo.KHACHHANG
					SET HO = @HO,
						TEN = @TEN,
						DIACHI = @DIACHI,
						NGAYCAP = @NGAYCAP,
						SoDT = @SoDT,
						PHAI = @PHAI,
						CMND = @newCMND
					WHERE CMND = @oldCMND;
					COMMIT TRANSACTION; -- Commit nếu không có lỗi
					RETURN 0
				end
		end
	else 
		begin
				-- Cập nhật thông tin khách hàng
				UPDATE LINK2.NGANHANG.dbo.KHACHHANG
				SET HO = @HO,
					TEN = @TEN,
					DIACHI = @DIACHI,
					NGAYCAP = @NGAYCAP,
					SoDT = @SoDT,
					PHAI = @PHAI
				WHERE CMND = @oldCMND;
				COMMIT TRANSACTION; -- Commit nếu không có lỗi
				RETURN 0
			END
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
        BEGIN
            ROLLBACK TRANSACTION;
            DECLARE @ErrorMessage NVARCHAR(2000)
            SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
            RAISERROR (@ErrorMessage,16,1)
        END
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[sp_SuaThongTinNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuaThongTinNV] @MaNV nchar(10), 
@CMND nchar(10), 
@Ho nvarchar (50), 
@Ten nvarchar(10), 
@Phai nvarchar(3), 
@SODT nvarchar(15), 
@Diachi nvarchar(100)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN DISTRIBUTED TRANSACTION
BEGIN TRY

	if not exists (select MANV from dbo.NHANVIEN where MANV = @MaNV)
	BEGIN
		rollback
		return 1 -- Không tồn tại MANV
	END

	declare @current_CMND nchar(10)
	select @current_CMND = CMND from dbo.NHANVIEN where MANV = @MANV
	
	if @CMND in (	select CMND 
					from LINK0.NGANHANG.dbo.NHANVIEN
					where CMND != @current_CMND )
	BEGIN
		rollback
		return 2 -- trùng CMND với NV khác
	END

	update dbo.NHANVIEN
	set CMND = @CMND,
		HO = @HO,
		TEN = @Ten,
		PHAI = @Phai,
		SoDT = @SODT,
		DIACHI = @Diachi
	where MANV = @MaNV

	-- Trường hợp chi nhánh khác cũng có thông tin nhân viên này (cùng CMND -> 1 người) nhưng khác MANV
	declare @link1MANV nchar(10) 
	if exists (select MANV from LINK1.NGANHANG.dbo.NHANVIEN where CMND = @current_CMND)
	BEGIN
		select @link1MANV = MANV from LINK1.NGANHANG.dbo.NHANVIEN where CMND = @current_CMND
		update LINK1.NGANHANG.dbo.NHANVIEN
		set CMND = @CMND,
			HO = @HO,
			TEN = @Ten,
			PHAI = @Phai,
			SoDT = @SODT,
			DIACHI = @Diachi
		where MANV = @link1MANV
	END

	COMMIT TRANSACTION
	return 0 -- thành công
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
		RAISERROR (@ErrorMessage,16,1)
	END
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoLogin]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_TaoLogin]
@LGNAME VARCHAR(50),
@PASS VARCHAR(50),
@USERNAME VARCHAR(50),
@ROLE VARCHAR(50)
AS
	DECLARE @RET INT
	EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'NGANHANG'
	
	IF (@RET =1)  -- LOGIN NAME BI TRUNG
		RETURN 1
	EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
	
	IF (@RET =1)  -- USER  NAME BI TRUNG
	BEGIN
		EXEC SP_DROPLOGIN @LGNAME
		RETURN 2
	END
	
	EXEC sp_addrolemember @ROLE, @USERNAME
	IF @ROLE = 'NganHang' OR @ROLE = 'ChiNhanh'
	BEGIN 
		EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
		EXEC sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
	END
	RETURN 0  -- THANH CONG
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoMaNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TaoMaNV]
as 
begin
	declare @manv nchar(10)
	set @manv = dbo.fn_TaoMaNV()

	select @manv as MANV
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoSTK]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TaoSTK]
as
BEGIN
	declare @STK nchar(9)
	set @STK = dbo.fn_TaoSTK()
	select @STK as STK
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoTK_KH]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- t đang lầm giữa tạo tk login cho khách hàng với tạo tk, hình như cái này t viết là tạo 1 Tk trong db
CREATE PROCEDURE [dbo].[sp_TaoTK_KH] 
@SOTK nchar(9), 
@CMND nchar(10), 
@SODU money, 
@MACN nchar(10), 
@NGAYMOTK datetime
AS
BEGIN
	SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRANSACTION
		-- Kiem tra su ton tai cua khach hang bang CMND
		declare @existedCMND int
		exec @existedCMND = sp_Existed_CMND_KH @CMND
		if(@existedCMND = 0)
			BEGIN
				ROLLBACK; -- Rollback nếu khách hàng không tồn tại
				RETURN 1
			END
		-- CMND ko tồn tại
		ELSE
			BEGIN
				INSERT INTO TaiKhoan (SOTK , CMND , SODU , MACN , NGAYMOTK)
				VALUES (@SOTK , @CMND , @SODU , @MACN ,@NGAYMOTK)
				COMMIT TRANSACTION
				RETURN 0
			END 
	END TRY

	BEGIN CATCH
		IF (@@TRANCOUNT > 0)
			BEGIN
				ROLLBACK TRANSACTION;
				DECLARE @ErrorMessage NVARCHAR(2000)
				SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
				RAISERROR (@ErrorMessage,16,1)
			END
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKH]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemKH] 
@CMND nchar(10),
@HO nvarchar(50), 
@TEN nvarchar(10),
@DIACHI nvarchar(100),
@PHAI nvarchar(3), 
@NGAYCAP datetime,
@SODT nvarchar(15)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION
BEGIN TRY
	declare @existedCMND int
	declare @MACN nchar(10)
	exec @existedCMND = sp_Existed_CMND_KH @CMND
	if(@existedCMND = 1)
		BEGIN
			rollback
			RETURN 1 -- Thêm không thành công
		END
	if(@existedCMND = 0)
		BEGIN
			select @MACN = MACN from dbo.CHINHANH

			INSERT INTO KhachHang (CMND , HO , TEN , DIACHI , PHAI,NGAYCAP,SODT,MACN)
			VALUES (@CMND , @HO , @TEN , @DIACHI , @PHAI,@NGAYCAP,@SODT,@MACN)
			COMMIT TRANSACTION;
			RETURN 0 -- Thành công
		END 
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
		BEGIN
			ROLLBACK TRANSACTION;
			DECLARE @ErrorMessage NVARCHAR(2000)
			SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
			RAISERROR (@ErrorMessage,16,1)
		END
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ThemNV]
@CMND nchar(10),
@HO nvarchar(50),
@TEN nvarchar(10),
@PHAI nvarchar(3),
@SODT nvarchar(15),
@DIACHI nvarchar(100)
as
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
BEGIN TRY
	declare @existedCMND int
	exec @existedCMND = sp_Existed_CMND_NV @CMND
	if(@existedCMND = 1)
	BEGIN
		rollback
		RETURN 1 -- Thêm không thành công
	END

	declare @MACN nchar(10)
	set @MACN = (select top 1 MACN from dbo.CHINHANH)

	declare @newMANV nchar(10);
	set @newMANV = dbo.fn_TaoMaNV()

	insert into dbo.NHANVIEN(MANV, CMND, HO, TEN, PHAI, SODT, DIACHI, MACN) 
	values (@newMANV, @CMND, @HO, @TEN, @PHAI, @SODT, @DIACHI, @MACN)

	COMMIT TRANSACTION
	RETURN 0 --Thêm thành công
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
	BEGIN
		ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
		RAISERROR (@ErrorMessage,16,1)
	END
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_TimNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_TimNV]
@MANV nchar(10)
AS
DECLARE @MACN VARCHAR(10), @HO nvarchar(50), @TEN nvarchar(10)
IF exists (select MANV from dbo.NHANVIEN where MANV = @MANV)
    BEGIN
        select TENCN = (select TENCN from dbo.CHINHANH), HO, TEN
        from dbo.NHANVIEN 
        where MANV = @MANV
    END
ELSE IF exists (select MANV from LINK0.NGANHANG.dbo.NHANVIEN where MANV = @MANV)
    BEGIN
        select @MACN = MACN, @HO = HO, @TEN = TEN
        from LINK0.NGANHANG.dbo.NHANVIEN
        where MANV = @MANV

        select TENCN, HO = @HO, TEN = @TEN
        from LINK0.NGANHANG.dbo.CHINHANH 
        where MACN = @MACN
    END
ELSE
    raiserror('Ma nhav vien ban tim khong co', 16, 1)
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaLogin]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_XoaLogin]
    @USRNAME VARCHAR(50)
AS
    declare @LGNAME varchar(50) = NULL
	set @LGNAME = dbo.fn_LayLoginName(@USRNAME)

	if @LGNAME is not NULL
		begin
			EXEC SP_DROPUSER @USRNAME
			EXEC SP_DROPLOGIN @LGNAME
			return 0
		end
	else
		begin
			return 1
			raiserror('Khong co loginname cho user nay', 16, 1)
		end
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaNV]    Script Date: 7/12/2024 11:17:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XoaNV]
    @MANV nchar(10)
AS
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
BEGIN TRY

    IF NOT EXISTS (SELECT MANV FROM dbo.NHANVIEN WHERE MANV = @MANV)
    BEGIN
        RETURN 1; -- Không tồn tại nhân viên
    END
    ELSE IF (SELECT TrangThaiXoa FROM dbo.NHANVIEN WHERE MANV = @MANV) = 1
        BEGIN
            RETURN 2; -- Nhân viên đã bị xóa trước đó
        END
    ELSE
        BEGIN
            UPDATE NHANVIEN
            SET TrangThaiXoa = 1
            WHERE MANV = @MANV;
        END

    COMMIT TRANSACTION;
    RETURN 0; -- Xóa thành công
END TRY

BEGIN CATCH
	IF (@@TRANCOUNT > 0)
        BEGIN
            ROLLBACK TRANSACTION;
            DECLARE @ErrorMessage NVARCHAR(2000)
            SELECT @ErrorMessage = 'LOI: ' + ERROR_MESSAGE()
            RAISERROR (@ErrorMessage,16,1)
        END
END CATCH
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -120
         Left = 0
      End
      Begin Tables = 
         Begin Table = "KHACHHANG"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DanhSachKhachHang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DanhSachKhachHang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "KH"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DanhSachKhachHang_NganHang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_DanhSachKhachHang_NganHang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PUBS"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 380
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SUBS"
            Begin Extent = 
               Top = 7
               Left = 428
               Bottom = 170
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_DS_PHANMANH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_DS_PHANMANH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "NV"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "S"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_EX_LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_EX_LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "KH"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "S"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_EX_LoginNameKH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_EX_LoginNameKH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "server_principals (sys)"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 301
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TK"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "KH"
            Begin Extent = 
               Top = 126
               Left = 48
               Bottom = 245
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_taiKhoanKhachHang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_taiKhoanKhachHang'
GO
