CREATE DATABASE TranVoLapDB
GO
USE TranVoLapDB
GO

CREATE TABLE UserAccount(
	IDUser varchar(30) PRIMARY KEY,
	UserName Varchar(30) ,
	Password Varchar(50),
	PhoneNumber	CHAR(10)  CHECK ( PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' ) NULL,
	Status bit DEFAULT '1' CHECK ( Status IN ( '0', '1' ) ), --0: chưa kích hoạt, 1: đã kích hoạt
	UserType Varchar(30)  --(loại người dùng),
	CONSTRAINT nhanvien_duynhat UNIQUE (UserName)
)
go

SET DATEFORMAT dmy
INSERT INTO dbo.UserAccount
        ( IDUser, UserName,Password,PhoneNumber,UserType,Status )
VALUES  ( 'NV01','knvolap',		'123123123', '0375163017','Admin', '1'),
		( 'NV02','nhannguyen',  '123123123', '0375163444','Membership', '0'),
		( 'NV03','minhhieu',	'123123123', '0375163123','Membership', '0'),
		( 'NV04','minhnhat',	'123123123', '0375163347','Membership', '0'),
		( 'NV05','huypro',		'123123123', '0372223022','Membership', '0'),
		( 'NV06','thanhdat',	'123123123', '0372468055','Membership', '0'),
		( 'NV07','lap123',		'123123123', '0375163066','Membership', '0'),
		( 'NV08','knvolap1412', '123123123', '0375161277','Membership', '0')
GO

CREATE TABLE Category(   --Thể loại sách
	IDCategory varchar(30) PRIMARY KEY,
	NameCategory NVarchar(200),
	Description NVarchar(200), --Mô tả
	Supplier  NVarchar(100)		--Nhà cung cấp
)
go

INSERT INTO dbo.Category
			(IDCategory,NameCategory,Description,Supplier)
VALUES		('TL01',N'Tiểu Thuyết',N'Sách dành cho trẻ em',N'Kim Đồng'),
			('TL02',N'Truyện Ngắn',N'Sách dành cho trẻ em',N'Hà Nội'),		
			('TL03',N'Tiểu Luận',N'Sách dành cho trẻ em',N'Kim Đồng'),
			('TL04',N'Trinh Thám',N'Sách dành cho trẻ em',N'Kim Đồng'),
			('TL05',N'Tản Văn',N'Sách dành cho trẻ em',N'Hà Nội'),		
			('TL06',N'Kiếm Hiệp',N'Sách dành cho trẻ em',N'TP Hồ Chí Minh'),
			('TL07',N'Tuổi TEEN',N'Sách dành cho trẻ em',N'TP Hồ Chí Minh')
go

CREATE TABLE Product(
	IDProduct varchar(30) PRIMARY KEY,
	IDCategory varchar(30) FOREIGN KEY REFERENCES dbo.Category(IDCategory) ON DELETE CASCADE ON UPDATE CASCADE ,
	NameProduct NVarchar(200),
	MetaName Varchar(200),		--Tên không giấu
	Quantity int,				--số lượng
	UnitCost float,				--giá bán
	Image Varchar(100),			--Ảnh
	Author		NVarchar(200),	--Tác giả
	Description NVarchar(300) Null,	--Mô tả sách
	Status bit DEFAULT '1' CHECK ( Status IN ( '0', '1' ) ), --0: hết hàng, 1: còn hàng
)
go
INSERT INTO dbo.Product
			(IDProduct,IDCategory,NameProduct,MetaName,Quantity,UnitCost,Image,Author,Description,Status)
VALUES		('SP01','TL01',N'Sa môn Không Hải thết yến bầy quỷ Đại Đường ','sa-mon-khong-hai-thet-yen-bay-quy-dai','50000','10','http://static.nhanam.com.vn/thumb/0x230/crop/Books/Images/2018/9/26/IVFUNACP.jpg',N' Yumemakura Baku',N'Nhà sư trẻ tuổi Không Hải, cùng người bạn thân Quất Dật Thế, từ Nhật Bản xa xôi vượt biển tới Đại Đường với tư cách sứ thần sang du học. Vào thời đại đó','1'),
			('SP02','TL01',N'CUỘC TRỐN CHẠY CỦA JOSEF MENGELE ','cuoc-tron-chay-cua-josef-mengele','60000','10','http://nhanam.com.vn/sach/19136/cuoc-tron-chay-cua-josef-mengele',N' Olivier Guez',N'Cái ác liệu có khi nào không phải đền tội? Mặc dù đã chạy trốn sang Mĩ Latinh','1'),
			('SP03','TL01',N'TẮT ĐÈN','tat-den','47000','10','http://static.nhanam.com.vn/thumb/0x230/crop/Books/Images/2018/9/26/IVFUNACP.jpg',N' Ngô Tất Tố',N'Đánh ‘xoảng’ một cái, cái bát ở mâm lý cựu bay thẳng sang mâm lý đương. Và đánh ‘chát’ một cái, cái chậu ở chiếu lý đương cũng đập luôn vào cây cột bên cạnh lý cựu.','1'),
			('SP04','TL02',N'Mua vé số vào ngày nào thì dễ trúng?','mua-ve-so-vao-ngay-nao-thi-de-trung','60000','10','http://static.nhanam.com.vn/thumb/0x230/crop/Books/Images/2018/9/26/IVFUNACP.jpg',N' Rob Eastaway , Jeremy Wyndham',N'Bạn lại vừa phải trải qua một ngày thứ Hai điển hình… Buổi sáng bạn quên đun nước pha cà phê trước khi đánh răng ','1'),
			('SP05','TL02',N'ĐÊM NÚM SEN','dem-num-sen','80000','10','http://static.nhanam.com.vn/thumb/0x230/crop/Books/Images/2018/9/26/IVFUNACP.jpg',N'Trần Dần',N'Ba giờ đêm, dưới phố, lại lào xào một cuộc hành binh dài dặc, về làng','1'),
			('SP06','TL03',N'NGỤY','nguy','50000','10','http://nhanam.com.vn/sach/5049/nguy',N'Nguyễn Trí.',N'Vì mày mà mẹ mày mới chết và rồi đây con mày, nếu tao chết nó sẽ ra sao? Tao hận trời xanh, hận cha tao đã đẻ tao ra trên cõi đời này… Mày tệ quá Độ ơi','1')
go

CREATE TABLE UserOder(
	IDOder varchar(30) PRIMARY KEY,
	IDProduct varchar(30)FOREIGN KEY REFERENCES dbo.Product(IDProduct) ON DELETE CASCADE ON UPDATE CASCADE ,
	UserName NVarchar(30),
	PhoneNumber CHAR(10)  CHECK ( PhoneNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' ),
	Quantity int,			--số lượng
	Amount	float,		--Tổng tiền
	DayBuy	date,		--Ngày mua	
	Address NVarchar(200),	
	Status bit DEFAULT '0' CHECK ( Status IN ( '0', '1' ) ), --0:chưa duyệt, 1: đã duyệt
)
go
INSERT INTO dbo.UserOder
			(IDOder,IDProduct,UserName,PhoneNumber,Quantity,Amount,DayBuy,Address,Status)
VALUES		('1','SP01',N'Trần Võ Lập'	,'0976883552','2','100000','25/03/2021',N'Cát Hưng-Phù Cát-Bình Định','0'),
			('2','SP01',N'Thanh Thúy'	,'0970006852','2','100000','25/04/2021',N'Hải Châu - Đà Nẵng','0'),
			('3','SP02',N'Minh Dự'		,'0976883999','2','120000','25/04/2021',N'Duy Xuyên - Quảng Nam','0'),
			('4','SP04',N'Thuận Nguyễn'	,'0976883777','2','120000','25/05/2021',N'Hải Châu - Đà Nẵng','0'),
			('5','SP05',N'Minh Nhật'	,'0976883222','2','160000','25/01/2021',N'Cẩm Lệ - Đà Nẵng','0'),
			('6','SP06',N'Thành Đạt'	,'0976883444','2','100000','25/01/2021',N'Ngũ Hành Sơn - Đà Nẵng','0')
go


