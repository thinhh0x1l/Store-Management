USE master
GO

CREATE DATABASE ConvenienceStore;
GO

USE ConvenienceStore;
GO

-- tạo bảng Sản Phẩm Từ Nhà Cung Cấp
DROP TABLE IF EXISTS SanPhamNCC
GO
CREATE TABLE SanPhamNCC(
	id INT IDENTITY(1, 1) NOT NULL, --Primary Key
	ten NVARCHAR(50) NOT NULL,
	LoaiSanPham_id INT NOT NULL,   --Foreign Key
	donGia INT NOT NULL,
	urlAnh VARBINARY(MAX) ,
	ngayHetHan Date NOT NULL,
	trangThai BIT DEFAULT 1 NOT NULL
);
GO

---------------------------------------------------
--thêm dữ liệu vào Sản Phẩm Từ Nhà Cung Cấp
INSERT INTO SanPhamNCC (ten,LoaiSanPham_id,donGia,urlAnh,ngayHetHan,trangThai)
VALUES
(N'Nước tinh khiết Aquafina',3,3500, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\aqua.png', SINGLE_BLOB) AS Anh),'2024-12-31',1),
(N'Bánh bao Malai bakery', 18, 32000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhbao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh gạo cốm Orion', 1, 17000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhcom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bột bánh cuốn', 15, 19000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhcuon.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh gạo Ichi', 1, 17000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhgao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh gạo An', 1, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhgao1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh mì nhân Socola', 1, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhmituoi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Panka chocolate', 1, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhmituoi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh que Pretz', 1, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhque.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh quy Goute', 1, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhquy.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh tráng', 17, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhtrang.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bột bánh su kem Rich''s', 15, 77000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\botlambanh.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bột rau câu dẻo', 15, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\botraucau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Cà phê hòa tan 3in1', 4, 57000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\caphe.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo cà phê sữa Alpenliebe', 2, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\caphesua.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Tương ớt Chinsu', 12, 16000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhgao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Chocopie', 1, 4000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chocopie.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Chocopie vị đào', 1, 4000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chocopie1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Chôm chôm ngâm', 9, 90000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chomchom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Tương ớt Cholimex chua ngọt', 18, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chuangot.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo dẻo Chupachup', 2, 4000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chupachup.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Coca light', 3, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cocalight.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Trà quế Cozy', 7, 34000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Trà đào Cozy', 7, 34000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Trà dâu Cozy', 7, 34000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Trà sen Cozy', 7, 34000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy3.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Trà bạc hà Cozy', 7, 34000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy4.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh CreamO Socola', 1, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\creamo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh CreamO kem Socola', 1, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\creamo1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh CreamO dâu', 1, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\creamo2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Dầu ăn Meizan', 12, 27000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dauan.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Đường trắng', 12, 28000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\duongmia.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Đường mía Nasu', 12, 36000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\duongmia2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa Dutchlady vị socola', 5, 6000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dutchlady.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa Dutchlady', 5, 6000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dutchlady1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),

(N'Kẹo Dynamite cam', 2, 24000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dynamite.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo Dynamite dâu', 2, 24000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dynamite1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo Dynamite chew', 2, 24000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dynamite2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Cà phê espresso', 4, 47000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\espresso.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Karo', 1, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\karo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kem làm mềm bánh', 5, 45000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\kemlambanh.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo bạc hà', 2, 55000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keobacha.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo chanh muối', 2, 55000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keochanhmuoi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo dẻo', 2, 27000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo dẻo fluffy', 2, 27000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo dẻo kem xoài', 2, 30000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo dẻo con sâu', 2, 25500, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo3.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo me lắc', 2, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keome.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Cà phê sữa King coffe', 4, 49000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\kingcoff.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Lays Tôm hùm', 1, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\lays.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Lays Gà cay', 1, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\lays1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Bánh Lays vị Kim Chi Seoul', 1, 19000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\lays2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),

(N'Siro Trà Xanh', 9, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\matcha.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Mì Koreno', 14, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mihanquoc.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),

(N'Mì Trộn Tương Đen', 14, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mituongden.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Mì Udon', 14, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\miudon.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Kẹo M&M', 2, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mm.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Mộc Châu Milk', 5, 5000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mochau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Muối IỐT', 12, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\muoiiot.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Muối Tôm Shrimp Salt', 12, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\muoitom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Muối Tinh Himalya', 12, 16000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\muoitrang.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'STRAW BERRY', 8, 45000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mutdau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'FRUIT OF THE FOREST', 8, 45000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mutrung.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'PINÃ', 8, 45000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mutthom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'NesCafe 3in1', 4, 55000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nescoff.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Gạo Ngọc Sa', 13, 86000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\ngocsa.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Tams Zero', 3, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nho.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Nui Gạo', 13, 33000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nui.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Number 1', 3, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\number1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 0),
(N'Nước Mắm Thuyền Xưa', 12, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nuocmam.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Nước Mắm Hải Nhi', 12, 14000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nuocmam1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Nuti', 5, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nuti.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Snack Tôm Cay', 1, 4000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oishi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 0),
(N'Snack Bí Đỏ', 1, 4000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oishi1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Trà Ô Long', 3, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\olong.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Creamer đặc vị Socola', 5, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\ongthosocola.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Oreo', 1, 43000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oreo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'INDOS Chip!', 1, 4000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oshi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 0),
(N'Satori', 3, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\satori1-5.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Túi Trà Hương Việt Quất', 7, 33000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\select.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Túi Trà Hương Đào', 7, 33000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\select1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Syrup Peach', 9, 39000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\sirodao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Syrup StrawBerry', 9, 37000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\sirodau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Durian Syrup', 9, 46000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\sirosau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Gạo Tám Sông Hồng', 9, 80000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\songhong.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),

(N'Sữa Chua Trái Cây', 3, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa Chua Nha Đam', 6, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Dalat Milk', 6, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa Chua Chuối', 6, 43000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua3.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa Chưa Hương Dâu Tự Nhiên', 6, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua4.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa tươi Nuti', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suagau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Yakult', 5, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suauong.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Dutch Lady', 5, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suauong1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sweetened Creamer', 5, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suni.png', SINGLE_BLOB) AS Anh), '2024-12-31', 0),
(N'Swing', 1, 6000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\swing.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Nước Tăng Lực Power In', 3, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tangluc.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Nước Táo', 3, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thjuice.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'TH true MILK', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thmilk.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'TH true MILK GOLD', 5, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thmilk2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Gạo Thơm Đặc Sản ST25', 13, 78000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Chocopie', 1, 20000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thungchoco.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Toonies', 1, 6000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\toonies.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),

(N'Hộp trứng cút', 11, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\trungcut.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Hộp trứng gà', 11, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\trungga.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Tương cà', 12, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tuongca.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sos Sojuwy', 12, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tuongden.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Tương đen', 12, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tuongden1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Gạo VEBO ST25', 12, 160000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\vebo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Sữa Dinh Dưỡng Hương Dâu', 13, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\vinamilk1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'TaYO! X', 5, 6000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\x.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1),
(N'Xúc Xích Heo', 1, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\xucxich.png', SINGLE_BLOB) AS Anh), '2024-12-31', 0);
GO



---------------------------------------------------
---------------------------------------------------
-- tạo bảng Sản Phẩm
DROP TABLE IF EXISTS SanPham
GO
CREATE TABLE SanPham(
	id INT IDENTITY(1, 1) NOT NULL,		 --Primary Key
	ten NVARCHAR(50) NOT NULL,
	LoaiSanPham_id INT NOT NULL,		--Foreign Key
	donGia INT NOT NULL,
	urlAnh VARBINARY(MAX) ,
	ngayHetHan Date NOT NULL,  --primary key
	trangThai smallint DEFAULT 1 NOT NULL,
	soLuong INT NOT NULL
);
GO

EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;
-----------------------------
--thêm dữ liệu vào Sản Phẩm
SET IDENTITY_INSERT SanPham OFF; 


--TrangThai1
INSERT INTO SanPham (ten,LoaiSanPham_id,donGia,urlAnh,ngayHetHan,trangThai,soLuong)
VALUES
(N'Nước tinh khiết Aquafina',3,6500, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\aqua.png', SINGLE_BLOB) AS Anh),'2024-12-31',1,3),
(N'Bánh bao Malai bakery', 18, 35000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhbao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,5),
(N'Bánh gạo cốm Orion', 1, 20000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhcom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,4),
(N'Bột bánh cuốn', 15, 22000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhcuon.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,6),
(N'Bánh gạo Ichi', 1, 20000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhgao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,132),
(N'Bánh gạo An', 1, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhgao1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,78),
(N'Bánh mì nhân Socola', 1, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhmituoi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,45),
(N'Bánh Panka chocolate', 1, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhmituoi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,66),
(N'Bánh que Pretz', 1, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhque.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'Bánh quy Goute', 1, 16000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhquy.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,88),
(N'Bánh tráng', 17, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhtrang.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,79),
(N'Bột bánh su kem Rich''s', 15, 80000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\botlambanh.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,102),
(N'Bột rau câu dẻo', 15, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\botraucau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,100),
(N'Cà phê hòa tan 3in1', 4, 60000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\caphe.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,54),
(N'Kẹo cà phê sữa Alpenliebe', 2, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\caphesua.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,76),
(N'Tương ớt Chinsu', 12, 19000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\banhgao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,61),
(N'Bánh Chocopie', 1, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chocopie.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,70),
(N'Bánh Chocopie vị đào', 1, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chocopie1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,123),
(N'Chôm chôm ngâm', 9, 93000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chomchom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,109),
(N'Tương ớt Cholimex chua ngọt', 18, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chuangot.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,94),
(N'Kẹo dẻo Chupachup', 2, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\chupachup.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,81),
(N'Coca light', 3, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cocalight.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,40),
(N'Trà quế Cozy', 7, 37000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,100),
(N'Trà đào Cozy', 7, 37000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,66),
(N'Trà dâu Cozy', 7, 37000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,75),
(N'Trà sen Cozy', 7, 37000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy3.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,74),
(N'Trà bạc hà Cozy', 7, 37000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\cozy4.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,111),
(N'Bánh CreamO Socola', 1, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\creamo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,82),
(N'Bánh CreamO kem Socola', 1, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\creamo1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,102),
(N'Bánh CreamO dâu', 1, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\creamo2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,98),
(N'Dầu ăn Meizan', 12, 30000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dauan.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,90),
(N'Đường trắng', 12, 31000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\duongmia.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,50),
(N'Đường mía Nasu', 12, 39000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\duongmia2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,61),
(N'Sữa Dutchlady vị socola', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dutchlady.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,83),
(N'Sữa Dutchlady', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dutchlady1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,74),

(N'Kẹo Dynamite cam', 2, 27000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dynamite.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,104),
(N'Kẹo Dynamite dâu', 2, 27000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dynamite1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,55),
(N'Kẹo Dynamite chew', 2, 27000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dynamite2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,59),
(N'Cà phê espresso', 4, 50000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\espresso.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'Bánh Karo', 1, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\karo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,67),
(N'Kem làm mềm bánh', 5, 48000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\kemlambanh.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,88),
(N'Kẹo bạc hà', 2, 58000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keobacha.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,89),
(N'Kẹo chanh muối', 2, 58000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keochanhmuoi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,67),
(N'Kẹo dẻo', 2, 30000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,98),
(N'Kẹo dẻo fluffy', 2, 30000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,109),
(N'Kẹo dẻo kem xoài', 2, 33000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,55),
(N'Kẹo dẻo con sâu', 2, 28500, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keodeo3.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,33),
(N'Kẹo me lắc', 2, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\keome.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,54),
(N'Cà phê sữa King coffe', 4, 54000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\kingcoff.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'Bánh Lays Tôm hùm', 1, 21000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\lays.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'Bánh Lays Gà cay', 1, 21000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\lays1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,44),
(N'Bánh Lays vị Kim Chi Seoul', 1, 22000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\lays2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,41),

(N'Siro Trà Xanh', 9, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\matcha.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,122),
(N'Mì Koreno', 14, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mihanquoc.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),

(N'Mì Trộn Tương Đen', 14, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mituongden.png', SINGLE_BLOB) AS Anh), '2024-12-31',1, 95),
(N'Mì Udon', 14, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\miudon.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,84),
(N'Kẹo M&M', 2, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mm.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'Mộc Châu Milk', 5, 8000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mochau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,103),
(N'Muối IỐT', 12, 21000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\muoiiot.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,71),
(N'Muối Tôm Shrimp Salt', 12, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\muoitom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,66),
(N'Muối Tinh Himalya', 12, 19000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\muoitrang.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'STRAW BERRY', 8, 48000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mutdau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,99),
(N'FRUIT OF THE FOREST', 8, 48000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mutrung.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'PINÃ', 8, 48000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\mutthom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,65),
(N'NesCafe 3in1', 4, 58000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nescoff.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'Gạo Ngọc Sa', 13, 89000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\ngocsa.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,84),
(N'Tams Zero', 3, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nho.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,94),
(N'Nui Gạo', 13, 36000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nui.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,87),
(N'Number 1', 3, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\number1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,100),
(N'Nước Mắm Thuyền Xưa', 12, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nuocmam.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,108),
(N'Nước Mắm Hải Nhi', 12, 17000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nuocmam1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,111),
(N'Nuti', 5, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\nuti.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,55),
(N'Snack Tôm Cay', 1, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oishi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,76),
(N'Snack Bí Đỏ', 1, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oishi1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,88),
(N'Trà Ô Long', 3, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\olong.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,54),
(N'Creamer đặc vị Socola', 5, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\ongthosocola.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,44),
(N'Oreo', 1, 46000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oreo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,43),
(N'INDOS Chip!', 1, 7000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\oshi.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,87),
(N'Satori', 3, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\satori1-5.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,55),
(N'Túi Trà Hương Việt Quất', 7, 36000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\select.png', SINGLE_BLOB) AS Anh), '2024-08-30', 1,44),
(N'Túi Trà Hương Đào', 7, 36000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\select1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,86),
(N'Syrup Peach', 9, 42000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\sirodao.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'Syrup StrawBerry', 9, 40000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\sirodau.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,45),
(N'Durian Syrup', 9, 49000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\sirosau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,64),
(N'Gạo Tám Sông Hồng', 9, 83000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\songhong.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,99),

(N'Sữa Chua Trái Cây', 3, 10000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'Sữa Chua Nha Đam', 6, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua1.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,91),
(N'Dalat Milk', 6, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua2.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,39),
(N'Sữa Chua Chuối', 6, 46000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua3.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,64),
(N'Sữa Chưa Hương Dâu Tự Nhiên', 6, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suachua4.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,100),
(N'Sữa tươi Nuti', 5, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suagau.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,142),
(N'Yakult', 5, 14000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suauong.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,175),
(N'Dutch Lady', 5, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suauong1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,129),
(N'Sweetened Creamer', 5, 16000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\suni.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,124),
(N'Swing', 1, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\swing.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'Nước Tăng Lực Power In', 3, 14000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tangluc.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'Nước Táo', 3, 41000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thjuice.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,43),
(N'TH true MILK', 5, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thmilk.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,74),
(N'TH true MILK GOLD', 5, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thmilk2.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,0),
(N'Gạo Thơm Đặc Sản ST25', 13, 81000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thom.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,0),
(N'Chocopie', 1, 23000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thungchoco.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,57),
(N'Toonies', 1, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\toonies.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,46),

(N'Hộp trứng cút', 11, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\trungcut.png', SINGLE_BLOB) AS Anh), '2024-08-31', 1,95),
(N'Hộp trứng gà', 11, 18000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\trungga.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,66),
(N'Tương cà', 12, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tuongca.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,77),
(N'Sos Sojuwy', 12, 15000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tuongden.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,94),
(N'Tương đen', 12, 17000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tuongden1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,48),
(N'Gạo VEBO ST25', 12, 163000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\vebo.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,58),
(N'Sữa Dinh Dưỡng Hương Dâu', 13, 11000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\vinamilk1.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,84),
(N'TaYO! X', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\x.png', SINGLE_BLOB) AS Anh), '2024-12-31', 1,64);


SET IDENTITY_INSERT SanPham ON; 
--trangThai2
INSERT INTO SanPham (id,ten,LoaiSanPham_id,donGia,urlAnh,ngayHetHan,trangThai,soLuong)
VALUES
(95,N'Swing', 1, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\swing.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,64),
(96,N'Nước Tăng Lực Power In', 3, 14000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\tangluc.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,61),
(97,N'Nước Táo', 3, 41000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thjuice.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,43),
(98,N'TH true MILK', 5, 12000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thmilk.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,74),
(99,N'TH true MILK GOLD', 5, 13000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thmilk2.png', SINGLE_BLOB) AS Anh), '2025-08-31', 2,84),
(100,N'Gạo Thơm Đặc Sản ST25', 13, 81000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thom.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,95),
(101,N'Chocopie', 1, 23000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\thungchoco.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,57),
(102,N'Toonies', 1, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\toonies.png', SINGLE_BLOB) AS Anh), '2025-12-31', 2,46);

--trangThai3
INSERT INTO SanPham (id,ten,LoaiSanPham_id,donGia,urlAnh,ngayHetHan,trangThai,soLuong)
VALUES
(32,N'Đường trắng', 12, 31000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\duongmia.png', SINGLE_BLOB) AS Anh), '2024-6-30', 3,0),
(33,N'Đường mía Nasu', 12, 39000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\duongmia2.png', SINGLE_BLOB) AS Anh), '2024-06-30', 3,1),
(34,N'Sữa Dutchlady vị socola', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dutchlady.png', SINGLE_BLOB) AS Anh), '2024-06-30', 3,3),
(35,N'Sữa Dutchlady', 5, 9000, (SELECT * FROM OPENROWSET(BULK N'D:\hinh anh\dutchlady1.png', SINGLE_BLOB) AS Anh), '2024-06-30', 3,4);
GO
---------------------------------------------------
---------------------------------------------------
--tạo bảng Loại Sản Phẩm
DROP TABLE IF EXISTS LoaiSanPham
GO
CREATE TABLE LoaiSanPham(
	id INT IDENTITY(1, 1) NOT NULL,		 --Primary Key
	ten NVARCHAR(30) NOT NULL
);
GO

--------------------------------
--thêm dữ liệu vào Loại Sản Phẩm
INSERT INTO LoaiSanPham(ten) VALUES(N'Bánh')
INSERT INTO LoaiSanPham(ten) VALUES(N'Kẹo')
INSERT INTO LoaiSanPham(ten) VALUES(N'Nước giải khát')
INSERT INTO LoaiSanPham(ten) VALUES(N'Cà phê')
INSERT INTO LoaiSanPham(ten) VALUES(N'Sữa tươi')
INSERT INTO LoaiSanPham(ten) VALUES(N'Sữa chua/lên men')
INSERT INTO LoaiSanPham(ten) VALUES(N'Trà')
INSERT INTO LoaiSanPham(ten) VALUES(N'Mứt')
INSERT INTO LoaiSanPham(ten) VALUES(N'Siro')
INSERT INTO LoaiSanPham(ten) VALUES(N'Đồ chiên')
INSERT INTO LoaiSanPham(ten) VALUES(N'Đồ tươi')
INSERT INTO LoaiSanPham(ten) VALUES(N'Gia vị')
INSERT INTO LoaiSanPham(ten) VALUES(N'Gạo')
INSERT INTO LoaiSanPham(ten) VALUES(N'Mì')
INSERT INTO LoaiSanPham(ten) VALUES(N'Bột')
INSERT INTO LoaiSanPham(ten) VALUES(N'Bún')
INSERT INTO LoaiSanPham(ten) VALUES(N'Bánh tráng')
INSERT INTO LoaiSanPham(ten) VALUES(N'Bánh bao')

GO

---------------------------------------------------
---------------------------------------------------
--tạo bảng Nhân Viên
DROP TABLE IF EXISTS NhanVien
GO
CREATE TABLE NhanVien(
	id VARCHAR(15)  NOT NULL,		 --Primary Key
	ho NVARCHAR(30) NOT NULL,
	ten NVARCHAR(10) NOT NULL,
	ngaySinh DATE NOT NULL, -- 'YYYY-MM-DD'
	SDT CHAR(10) NOT NULL,
	diaChi NVARCHAR(255),
	urlAnh VARBINARY(MAX),
	CCCD CHAR(12) NOT NULL,
	gioiTinh BIT NOT NULL,
	trangThai BIT NOT NULL DEFAULT 1,
	Quyen_ID  SMALLINT NOT NULL
);
GO

-------------------------
--thêm dữ liệu Nhân Viên
INSERT INTO NhanVien VALUES('nv0',N' ',N'Admin','2001-11-11','0111111111',N' ',(SELECT * FROM OPENROWSET(BULK N'D:\Staff Avt\admin.png', SINGLE_BLOB) AS Anh),'011111111111',1,1,0)
INSERT INTO NhanVien VALUES('nv1',N'Diệp',N'Chi','2003-01-11','0111111112',N'Biển Xa',(SELECT * FROM OPENROWSET(BULK N'D:\Staff Avt\nv1.png', SINGLE_BLOB) AS Anh),'011111111112',0,1,1)
INSERT INTO NhanVien VALUES('nv2',N'Văn',N'Luân','2003-06-17','0111111113',N'Miền Nam Việt Nam',(SELECT * FROM OPENROWSET(BULK N'D:\Staff Avt\a.png', SINGLE_BLOB) AS Anh),'011111111113',1,1,2)
INSERT INTO NhanVien VALUES('nv3',N'Hoàng',N'Thịnh','2003-06-17','0111111114',N'HCMC',(SELECT * FROM OPENROWSET(BULK N'D:\Staff Avt\images.png', SINGLE_BLOB) AS Anh),'011111111114',1,1,0) 

GO


---------------------------------------------------
---------------------------------------------------
--tạo bảng Khách Hàng
DROP TABLE IF EXISTS KhachHang
GO
CREATE TABLE KhachHang(
	id INT IDENTITY NOT NULL,		 --Primary Key
	ho NVARCHAR(50) NOT NULL,
	ten NVARCHAR(15) NOT NULL,
	SDT VARCHAR(15) NOT NULL UNIQUE,
	tichDiem INT DEFAULT 0
);
GO

---------------------------
--thêm dữ liệu Khách Hàng
INSERT INTO KhachHang(ho,ten,SDT,tichDiem) VALUES (N'Phú Nhị' , N'Đại','0999999999',10000)
INSERT INTO KhachHang(ho,ten,SDT,tichDiem) VALUES (N'Trịnh Trần Phương' , N'Tuấn','0000000001',5000)
INSERT INTO KhachHang(ho,ten,SDT,tichDiem) VALUES (N'Xuân' , N'Ca','0123456789',600)
INSERT INTO KhachHang(ho,ten,SDT,tichDiem) VALUES (N'Lê' , N'Sinh','0987654321',1200)
GO


---------------------------------------------------
---------------------------------------------------
--tạo bảng Hóa Đơn Bán
DROP TABLE IF EXISTS HoaDonBan;
GO
CREATE TABLE HoaDonBan(
	id 	INT IDENTITY(1,1) NOT NULL ,		 --Primary Key
	KhachHang_id INT NOT NULL,			--Foreign Key
	NhanVien_id	VARCHAR(15) NOT NULL,			--Foreign Key
	ngayBan	DATE NOT NULL,
	gioBan	TIME NOT NULL,
	tongTien INT NOT NULL
);
GO

---------------------------
--thêm dữ liệu Hóa Đơn Bán
INSERT INTO HoaDonBan
VALUES
(1,'nv1','2024-08-08','13:45:04',9000),
(2,'nv2','2024-08-08','13:45:04',9000),
(3,'nv3','2024-08-08','13:45:04',9000);
GO
---------------------------------------------------
---------------------------------------------------
--tạo bảng Hóa Đơn Bán
DROP TABLE IF EXISTS ChiTietHoaDonBan;
GO
CREATE TABLE ChiTietHoaDonBan(
	HoaDonBan_id INT  NOT NULL,		 --Primary Key - Foreign Key
	SanPham_id INT NOT NULL,		 --Primary Key - Foreign Key
	soLuong	INT NOT NULL,
	Sanpham_NgayHetHan DATE NOT NULL
);
GO

---------------------------
--thêm dữ liệu Chi Tiết Hóa Đơn Bán
INSERT INTO ChiTietHoaDonBan 
VALUES
(1,35,1,'2024-06-30'),
(2,35,1,'2024-06-30'),
(3,35,1,'2024-06-30');
GO




---------------------------------------------------
---------------------------------------------------
--tạo bảng Hóa Đơn Bán
DROP TABLE IF EXISTS HoaDonNhap;
GO
CREATE TABLE HoaDonNhap(
	id 	INT IDENTITY(1,1) NOT NULL,		 --Primary Key
	NhanVien_id	VARCHAR(15) NOT NULL,	 --Foreign Key
	ngayNhap DATE NOT NULL,
	gioNhap	TIME NOT NULL,
	tongTien BIGINT NOT NULL
);
GO

---------------------------
--thêm dữ liệu Hóa Đơn Nhập

GO


DROP TABLE IF EXISTS ChiTietHoaDonNhap;
GO
CREATE TABLE ChiTietHoaDonNhap(
	HoaDonNhap_id INT  NOT NULL,		 --Primary Key - Foreign Key
	SanPhamNCC_id INT NOT NULL,			 --Primary Key - Foreign Key
	soLuong	INT NOT NULL,
	SanPham_NgayHetHan DATE NOT NULL
);
GO


---------------------------
--thêm dữ liệu Hóa Đơn Nhập

GO

DROP TABLE IF EXISTS Quyen;
GO
CREATE TABLE Quyen(
	id SMALLINT NOT NULL,		 --
	ten VARCHAR(50) NOT NULL,			
	
);
GO


---------------------------
--thêm dữ liệu Chi Tiết Hóa Đơn Bán
	
INSERT INTO Quyen 
VALUES(0,'BaoVe'),(1,'QuanLy'),(2,'BanHang'),(3,'KiemKe'),(4,'NhapHang')



ALTER TABLE Quyen 
ADD PRIMARY KEY(id);
GO

ALTER TABLE SanPhamNCC 
ADD PRIMARY KEY(id);
GO

ALTER TABLE LoaiSanPham 
ADD PRIMARY KEY(id);
GO

ALTER TABLE SanPham 
ADD PRIMARY KEY(id,ngayHetHan);
GO

ALTER TABLE NhanVien
ADD PRIMARY KEY(id);
GO

ALTER TABLE KhachHang
ADD PRIMARY KEY(id);
GO

ALTER TABLE HoaDonNhap
ADD PRIMARY KEY(id);
GO

ALTER TABLE ChiTietHoaDonNhap
ADD PRIMARY KEY(HoaDonNhap_id,SanPhamNCC_id);
GO


ALTER TABLE HoaDonBan
ADD PRIMARY KEY(id);
GO

ALTER TABLE ChiTietHoaDonBan 
ADD PRIMARY KEY(HoaDonBan_id,Sanpham_NgayHetHan,SanPham_id);
GO


ALTER TABLE SanPham
ADD CONSTRAINT FK_SanPham_LoaiSanPham FOREIGN KEY (LoaiSanPham_id) REFERENCES LoaiSanPham (id)
GO

ALTER TABLE SanPhamNCC
ADD CONSTRAINT FK_SanPhamNCC_LoaiSanPham FOREIGN KEY (LoaiSanPham_id) REFERENCES LoaiSanPham (id)
GO

ALTER TABLE HoaDonBan
ADD CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY (NhanVien_id) REFERENCES NhanVien (id)
GO

ALTER TABLE HoaDonBan
ADD CONSTRAINT FK_HoaDonBan_KhachHang FOREIGN KEY (KhachHang_id) REFERENCES KhachHang (id)
GO

ALTER TABLE ChiTietHoaDonBan
ADD CONSTRAINT FK_ChiTietHoaDonBan_HoaDonBan FOREIGN KEY (HoaDonBan_id) REFERENCES HoaDonBan (id)
GO

ALTER TABLE ChiTietHoaDonBan
ADD CONSTRAINT FK_ChiTietHoaDonBan_SanPham FOREIGN KEY (SanPham_id,SanPham_NgayHetHan) REFERENCES SanPham (id,ngayHetHan)
GO

ALTER TABLE HoaDonNhap
ADD CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY (NhanVien_id) REFERENCES NhanVien (id)
GO

ALTER TABLE ChiTietHoaDonNhap
ADD CONSTRAINT FK_ChiTietHoaDonNhap_HoaDonNhap FOREIGN KEY (HoaDonNhap_id) REFERENCES HoaDonNhap (id)
GO
/*
ALTER TABLE ChiTietHoaDonNhap
ADD CONSTRAINT FK_ChiTietHoaDonNhap_SanPhamNCC FOREIGN KEY (SanPhamNCC_id) REFERENCES SanPhamNCC (id)
GO 
*/

ALTER TABLE NhanVien
ADD CONSTRAINT FK_NhanVien_Quyen FOREIGN KEY (Quyen_id) REFERENCES Quyen (id)
GO
