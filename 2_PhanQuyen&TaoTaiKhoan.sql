sp_configure 'show advanced options', 1;  
RECONFIGURE;
GO 
sp_configure 'Ad Hoc Distributed Queries', 1;  
RECONFIGURE;
---------- rename admin nếu đã có sẵn trên server
use master
go
CREATE LOGIN [admin] 
	WITH PASSWORD = 'admin'	
GO  
USE ConvenienceStore 
CREATE USER [admin]
   FOR LOGIN [admin]
EXEC master..sp_addsrvrolemember @loginame = N'admin', @rolename = N'sysadmin'
GO
------********************************************************------------------------------------------------
use master
CREATE SERVER ROLE QuanLy
GRANT ALTER ANY LOGIN TO QuanLy;
GRANT Administer Bulk Operations TO QuanLy;

use ConvenienceStore   
create role QuanLy 
grant ALTER to QuanLy
grant control, select to QuanLy
deny select on NhanVien (Quyen_ID) to QuanLy
deny delete,insert,update on SanPhamNCC to QuanLy
deny control on Quyen to QuanLy

create role BanHang
grant control to BanHang
deny control on NhanVien  to BanHang
deny control on SanPhamNCC to BanHang
deny control on ChiTietHoaDonNhap to BanHang
deny control on HoaDonNhap to BanHang
deny control on Quyen to BanHang

create role KiemKe
grant control to KiemKe
deny select on NhanVien (Quyen_ID) to KiemKe
deny delete,insert,update on NhanVien  to KiemKe
deny delete,insert,update on SanPhamNCC to KiemKe
deny delete,insert,update on SanPham to KiemKe
deny delete,insert,update on HoaDonBan to KiemKe
deny delete,insert,update on ChiTietHoaDonBan to KiemKe
deny delete,insert,update on HoaDonNhap to KiemKe
deny delete,insert,update on ChiTietHoaDonNhap to KiemKe
deny control on Quyen to KiemKe


create role NhapHang
grant control to NhapHang
deny control on NhanVien to NhapHang
deny delete,insert,update on SanPhamNCC to NhapHang
deny control on ChiTietHoaDonBan to NhapHang
deny control on HoaDonBan to NhapHang
deny control on KhachHang to NhapHang
deny control on Quyen to NhapHang

USE MASTER
CREATE LOGIN nv1 WITH PASSWORD = 'nv1'
CREATE LOGIN nv2 WITH PASSWORD = 'nv2'
CREATE LOGIN nv3 WITH PASSWORD = 'nv3'
ALTER SERVER ROLE QuanLy  ADD MEMBER nv1

USE ConvenienceStore 
CREATE USER nv1 FOR LOGIN nv1
CREATE USER nv2 FOR LOGIN nv2
CREATE USER nv3 FOR LOGIN nv3
ALTER ROLE QuanLy ADD MEMBER nv1
ALTER ROLE BanHang ADD MEMBER nv2